using System;
using System.Collections.Generic;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;
using Apibim.Tekla.Plugins.BuiltUpColumn.Models;
using Apibim.Tekla.Plugins.BuiltUpColumn.Services;

namespace Apibim.Tekla.Plugins.BuiltUpColumn
{
    public class PluginData
    {
        [StructuresField("TopExtension")]
        public double TopExtension;

        [StructuresField("BottomExtension")]
        public double BottomExtension;

        [StructuresField("LacingBottomClearance")]
        public double LacingBottomClearance;

        [StructuresField("LacingTopClearance")]
        public double LacingTopClearance;

        [StructuresField("TargetLacingStep")]
        public double TargetLacingStep;

        [StructuresField("BranchProfile")]
        public string BranchProfile;

        [StructuresField("LacingProfile")]
        public string LacingProfile;

        [StructuresField("Material")]
        public string Material;
    }

    [Plugin("Apibim_BuiltUpColumn")]
    // КРИТИЧЕСКИ ВАЖНО: Точный путь до класса окна
    [PluginUserInterface("Apibim.Tekla.Plugins.BuiltUpColumn.MainWindow")]
    public class ModelPlugin : PluginBase
    {
        private PluginData Data { get; set; }

        public ModelPlugin(PluginData data)
        {
            Data = data;
        }

        public override List<InputDefinition> DefineInput()
        {
            try
            {
                Picker picker = new Picker();
                List<InputDefinition> inputs = new List<InputDefinition>();

                Point p1 = picker.PickPoint("Укажите базовую точку первой ветви");
                Point p2 = picker.PickPoint("Укажите базовую точку второй ветви");

                inputs.Add(new InputDefinition(p1));
                inputs.Add(new InputDefinition(p2));

                return inputs;
            }
            catch (Exception)
            {
                return new List<InputDefinition>();
            }
        }

        public override bool Run(List<InputDefinition> Input)
        {
            try
            {
                if (Input == null || Input.Count < 2) return false;

                Point p1 = (Point)Input[0].GetInput();
                Point p2 = (Point)Input[1].GetInput();

                // Перекладываем данные из слоя WPF-плагина в наш математический класс
                BuiltUpColumnData colData = new BuiltUpColumnData
                {
                    BasePoint1 = p1,
                    BasePoint2 = p2,
                    TopExtension = Data.TopExtension,
                    BottomExtension = Data.BottomExtension,
                    LacingBottomClearance = Data.LacingBottomClearance,
                    LacingTopClearance = Data.LacingTopClearance,
                    TargetLacingStep = Data.TargetLacingStep,
                    BranchProfile = Data.BranchProfile,
                    LacingProfile = Data.LacingProfile,
                    Material = Data.Material
                };

                // Получаем чистую геометрию
                var branchLines = ColumnGeometryBuilder.GetBranchLines(colData);
                var lacingLines = ColumnGeometryBuilder.GetLacingLines(colData);

                // Отрисовываем ветви
                foreach (var line in branchLines)
                {
                    Beam branch = new Beam(line.Point1, line.Point2);
                    branch.Profile.ProfileString = colData.BranchProfile;
                    branch.Material.MaterialString = colData.Material;
                    branch.Class = "1";
                    branch.Insert();
                }

                // Отрисовываем решетку
                foreach (var line in lacingLines)
                {
                    Beam lacing = new Beam(line.Point1, line.Point2);
                    lacing.Profile.ProfileString = colData.LacingProfile;
                    lacing.Material.MaterialString = colData.Material;
                    lacing.Class = "3";
                    lacing.Insert();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
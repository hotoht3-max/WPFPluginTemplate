using System;
using System.Collections.Generic;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;
using Apibim.Plugins.BuiltUpColumn.Models;
using Apibim.Plugins.BuiltUpColumn.Services;
using Tekla.Extension;

namespace Apibim.Plugins.BuiltUpColumn
{
    public class PluginData
    {
        [StructuresField("Hcol_1")] public double Hcol_1 = 10000.0;
        [StructuresField("Hcol_e1")] public double Hcol_e1 = 500.0;
        [StructuresField("Hcol_e2")] public double Hcol_e2 = 600.0;
        [StructuresField("Hcol_e3")] public double Hcol_e3 = 600.0;
        [StructuresField("Hr_base")] public double Hr_base = 1200.0;
        [StructuresField("BranchProfile")] public string BranchProfile = "I20K1_57837_2017";
        [StructuresField("LacingProfile")] public string LacingProfile = "L75X6_8509_93";
        [StructuresField("Material")] public string Material = "C355Б";
    }

    [Plugin("Apibim_BuiltUpColumn")]
    [PluginUserInterface("Apibim.Plugins.BuiltUpColumn.MainWindow")]
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
                Logger.Write("=== ЗАПУСК ГЕНЕРАЦИИ КОЛОННЫ ===", LogLevel.Info);

                if (Input == null || Input.Count < 2)
                {
                    Logger.Write("Недостаточно входных точек.", LogLevel.Error);
                    return false;
                }

                Point p1 = (Point)Input[0].GetInput();
                Point p2 = (Point)Input[1].GetInput();

                p2 = p2.ResetZ(p1.Z);
                Logger.Write($"Базовые точки: P1({p1.X}, {p1.Y}, {p1.Z}), P2({p2.X}, {p2.Y}, {p2.Z})", LogLevel.Info);

                if (Distance.PointToPoint(p1, p2) < 10.0)
                {
                    Tekla.Structures.Model.Operations.Operation.DisplayPrompt("Ошибка: Точки совпадают или находятся на одной вертикали!");
                    Logger.Write("Точки совпадают (расстояние < 10мм).", LogLevel.Warning);
                    return false;
                }

                // Вычисление локальной плоскости колонны
                double dx = p2.X - p1.X;
                double dy = p2.Y - p1.Y;
                double planeAngleRad = Math.Atan2(dy, dx);
                double planeAngleDeg = planeAngleRad * (180.0 / Math.PI);
                Logger.Write($"Угол локальной плоскости: {planeAngleDeg:F2} градусов", LogLevel.Info);

                // Если вдруг макро-буфер пуст, предотвращаем краш API
                if (string.IsNullOrWhiteSpace(Data.BranchProfile) || string.IsNullOrWhiteSpace(Data.LacingProfile))
                {
                    Logger.Write("Ошибка: Не заданы профили. Загрузите файл standard или введите данные в UI.", LogLevel.Error);
                    return false;
                }

                // Чистая передача данных
                BuiltUpColumnData colData = new BuiltUpColumnData
                {
                    BasePoint1 = p1,
                    BasePoint2 = p2,
                    Hcol_1 = Data.Hcol_1,
                    Hcol_e1 = Data.Hcol_e1,
                    Hcol_e2 = Data.Hcol_e2,
                    Hcol_e3 = Data.Hcol_e3,
                    Hr_base = Data.Hr_base,
                    BranchProfile = Data.BranchProfile,
                    LacingProfile = Data.LacingProfile,
                    Material = Data.Material
                };

                Logger.Write($"Параметры: Высота={colData.Hcol_1}, ВылетВниз={colData.Hcol_e1}, ШагРешетки={colData.Hr_base}", LogLevel.Info);
                Logger.Write($"Профили: Ветвь={colData.BranchProfile}, Решетка={colData.LacingProfile}, Материал={colData.Material}", LogLevel.Info);

                var branchLines = ColumnGeometryBuilder.GetBranchLines(colData);
                var lacingLines = ColumnGeometryBuilder.GetLacingLines(colData);

                // --- ГЕНЕРАЦИЯ ВЕТВЕЙ ---
                foreach (var line in branchLines)
                {
                    Beam branch = new Beam(line.Point1, line.Point2);
                    branch.Profile.ProfileString = colData.BranchProfile;
                    branch.Material.MaterialString = colData.Material;
                    branch.Class = "1";

                    branch.Position.Plane = Position.PlaneEnum.MIDDLE;
                    branch.Position.Depth = Position.DepthEnum.MIDDLE;
                    branch.Position.Rotation = Position.RotationEnum.TOP;
                    branch.Position.RotationOffset = planeAngleDeg + 90.0;

                    branch.Insert();
                }

                // --- ГЕНЕРАЦИЯ РЕШЕТКИ ---
                foreach (var line in lacingLines)
                {
                    Beam lacing = new Beam(line.Point1, line.Point2);
                    lacing.Profile.ProfileString = colData.LacingProfile;
                    lacing.Material.MaterialString = colData.Material;
                    lacing.Class = "3";

                    lacing.Position.Plane = Position.PlaneEnum.MIDDLE;
                    lacing.Position.Depth = Position.DepthEnum.MIDDLE;
                    lacing.Position.Rotation = Position.RotationEnum.FRONT;
                    lacing.Position.RotationOffset = 0.0;

                    lacing.Insert();
                }

                Logger.Write("Успешное завершение. Колонна построена.", LogLevel.Success);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Write($"ФАТАЛЬНАЯ ОШИБКА: {ex.Message} | StackTrace: {ex.StackTrace}", LogLevel.Error);
                return false;
            }
        }
    }
}
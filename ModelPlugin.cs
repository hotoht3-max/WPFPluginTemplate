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
        [StructuresField("Bcol")] public double Bcol = 500.0;
        [StructuresField("Br_Rot")] public double Br_Rot = 90.0;
        [StructuresField("Hcol_1")] public double Hcol_1 = 10000.0;
        [StructuresField("Hcol_e1")] public double Hcol_e1 = 500.0;
        [StructuresField("Hcol_e2")] public double Hcol_e2 = 600.0;
        [StructuresField("Hcol_e3")] public double Hcol_e3 = 600.0;
        [StructuresField("Hr_base")] public double Hr_base = 1200.0;

        [StructuresField("L_Type")] public int L_Type = 1;
        [StructuresField("L_Preset")] public int L_Preset = 1;
        [StructuresField("L_Offset")] public double L_Offset = 0.0;
        [StructuresField("L_Rasc")] public double L_Rasc = 50.0;

        [StructuresField("S_Preset")] public int S_Preset = 1;

        [StructuresField("BranchProfile")] public string BranchProfile = "I20K1_57837_2017";
        [StructuresField("LacingProfile")] public string LacingProfile = "L75X6_8509_93";
        [StructuresField("S_Profile")] public string S_Profile = "16P_8240_97";

        [StructuresField("Material")] public string Material = "C355Б";
        [StructuresField("S_Material")] public string S_Material = "C245";
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
                inputs.Add(new InputDefinition(picker.PickPoint("Укажите ось первой ветви (Точка 1)")));
                inputs.Add(new InputDefinition(picker.PickPoint("Укажите направление колонны (Точка 2)")));
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
                Point p2Temp = (Point)Input[1].GetInput();
                p2Temp = p2Temp.ResetZ(p1.Z);

                double dx = p2Temp.X - p1.X;
                double dy = p2Temp.Y - p1.Y;
                double length = Math.Sqrt(dx * dx + dy * dy);

                if (length < 10.0) return false;

                Vector localX = new Vector(dx / length, dy / length, 0);
                Vector localY = new Vector(-localX.Y, localX.X, 0);
                double planeAngleDeg = Math.Atan2(localX.Y, localX.X) * (180.0 / Math.PI);

                Point p2 = new Point(p1.X + localX.X * Data.Bcol, p1.Y + localX.Y * Data.Bcol, p1.Z);

                BuiltUpColumnData colData = new BuiltUpColumnData
                {
                    BasePoint1 = p1,
                    BasePoint2 = p2,
                    Bcol = Data.Bcol,
                    Br_Rot = Data.Br_Rot,
                    Hcol_1 = Data.Hcol_1,
                    Hcol_e1 = Data.Hcol_e1,
                    Hcol_e2 = Data.Hcol_e2,
                    Hcol_e3 = Data.Hcol_e3,
                    Hr_base = Data.Hr_base,
                    L_Rasc = Data.L_Rasc,
                    L_Type = Data.L_Type,
                    L_Preset = Data.L_Preset,
                    L_Offset = Data.L_Offset,
                    S_Preset = Data.S_Preset,
                    BranchProfile = Data.BranchProfile,
                    LacingProfile = Data.LacingProfile,
                    S_Profile = Data.S_Profile,
                    Material = Data.Material,
                    S_Material = Data.S_Material
                };

                var branchLines = ColumnGeometryBuilder.GetBranchLines(colData);
                var lacingLines = ColumnGeometryBuilder.GetLacingLines(colData);
                var strutLines = ColumnGeometryBuilder.GetStrutLines(colData);

                double autoBaseDist = 0.0;
                foreach (var line in branchLines)
                {
                    Beam branch = new Beam(line.Point1, line.Point2);
                    branch.Profile.ProfileString = colData.BranchProfile;
                    branch.Material.MaterialString = colData.Material;
                    branch.Class = "1";
                    branch.Position.Plane = Position.PlaneEnum.MIDDLE;
                    branch.Position.Depth = Position.DepthEnum.MIDDLE;
                    branch.Position.Rotation = Position.RotationEnum.TOP;
                    branch.Position.RotationOffset = planeAngleDeg + colData.Br_Rot;
                    branch.Insert();

                    if (autoBaseDist == 0.0) branch.GetReportProperty("PROFILE.HEIGHT", ref autoBaseDist);
                }

                if (autoBaseDist <= 0.0) autoBaseDist = 200.0;

                // --- ГЕНЕРАЦИЯ РЕШЕТКИ ---
                foreach (var line in lacingLines)
                {
                    if (colData.L_Type == 0)
                    {
                        CreateLacingBeam(line.Point1, line.Point2, colData).Insert();
                    }
                    else
                    {
                        Vector shift = localY * (autoBaseDist / 2.0);
                        Point p1_A = new Point(line.Point1.X + shift.X, line.Point1.Y + shift.Y, line.Point1.Z);
                        Point p2_A = new Point(line.Point2.X + shift.X, line.Point2.Y + shift.Y, line.Point2.Z);
                        CreateLacingBeam(p1_A, p2_A, colData).Insert();

                        Point p1_B = new Point(line.Point1.X - shift.X, line.Point1.Y - shift.Y, line.Point1.Z);
                        Point p2_B = new Point(line.Point2.X - shift.X, line.Point2.Y - shift.Y, line.Point2.Z);
                        CreateLacingBeam(p2_B, p1_B, colData).Insert();
                    }
                }

                // --- ГЕНЕРАЦИЯ ПОПЕРЕЧНЫХ ПЛАНОК (STRUTS) ---
                foreach (var line in strutLines)
                {
                    if (colData.S_Preset == 0) continue; // Нет планок

                    if (colData.S_Preset == 1) // 100% Клон логики решетки
                    {
                        if (colData.L_Type == 0)
                        {
                            CreateStrutBeam_AsLacing(line.Point1, line.Point2, colData).Insert();
                        }
                        else
                        {
                            Vector shift = localY * (autoBaseDist / 2.0);
                            Point p1_A = new Point(line.Point1.X + shift.X, line.Point1.Y + shift.Y, line.Point1.Z);
                            Point p2_A = new Point(line.Point2.X + shift.X, line.Point2.Y + shift.Y, line.Point2.Z);
                            CreateStrutBeam_AsLacing(p1_A, p2_A, colData).Insert();

                            Point p1_B = new Point(line.Point1.X - shift.X, line.Point1.Y - shift.Y, line.Point1.Z);
                            Point p2_B = new Point(line.Point2.X - shift.X, line.Point2.Y - shift.Y, line.Point2.Z);
                            CreateStrutBeam_AsLacing(p2_B, p1_B, colData).Insert();
                        }
                    }
                    else if (colData.S_Preset == 2) // Уникальный Швеллер по центру
                    {
                        CreateStrutBeam_Channel(line.Point1, line.Point2, colData).Insert();
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private Beam CreateLacingBeam(Point p1, Point p2, BuiltUpColumnData data)
        {
            Beam b = new Beam(p1, p2);
            b.Profile.ProfileString = data.LacingProfile;
            b.Material.MaterialString = data.Material;
            b.Class = "3";
            b.Position.PlaneOffset = 0.0;
            b.Position.DepthOffset = 0.0;

            int activePreset = data.L_Type == 1 ? 1 : data.L_Preset;

            switch (activePreset)
            {
                case 1:
                    b.Position.Plane = Position.PlaneEnum.MIDDLE;
                    b.Position.Depth = Position.DepthEnum.FRONT;
                    b.Position.Rotation = Position.RotationEnum.TOP;
                    b.Position.RotationOffset = 90.0;
                    b.Position.DepthOffset = data.L_Offset;
                    break;
                case 2:
                    b.Position.Plane = Position.PlaneEnum.LEFT;
                    b.Position.Depth = Position.DepthEnum.MIDDLE;
                    b.Position.Rotation = Position.RotationEnum.FRONT;
                    b.Position.RotationOffset = 0.0;
                    b.Position.PlaneOffset = data.L_Offset;
                    break;
                case 3:
                    b.Position.Plane = Position.PlaneEnum.MIDDLE;
                    b.Position.Depth = Position.DepthEnum.MIDDLE;
                    b.Position.Rotation = Position.RotationEnum.FRONT;
                    b.Position.RotationOffset = 0.0;
                    b.Position.PlaneOffset = data.L_Offset;
                    break;
            }
            return b;
        }

        // Создает планку, полностью копируя настройки CreateLacingBeam
        private Beam CreateStrutBeam_AsLacing(Point p1, Point p2, BuiltUpColumnData data)
        {
            Beam b = CreateLacingBeam(p1, p2, data);
            b.Profile.ProfileString = data.S_Profile;
            b.Material.MaterialString = data.S_Material;
            b.Class = "4";
            return b;
        }

        // Создает уникальный швеллер (строго по центру, перевернутый корытом)
        private Beam CreateStrutBeam_Channel(Point p1, Point p2, BuiltUpColumnData data)
        {
            Beam b = new Beam(p1, p2);
            b.Profile.ProfileString = data.S_Profile;
            b.Material.MaterialString = data.S_Material;
            b.Class = "4";

            b.Position.Plane = Position.PlaneEnum.MIDDLE;
            b.Position.Depth = Position.DepthEnum.BEHIND;
            b.Position.PlaneOffset = 0.0;
            b.Position.DepthOffset = 0.0;

            // Заменили TOP на BACK ("Сзади")
            b.Position.Rotation = Position.RotationEnum.BACK;
            b.Position.RotationOffset = 0.0;

            return b;
        }
    }
}
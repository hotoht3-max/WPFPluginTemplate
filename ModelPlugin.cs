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

        [StructuresField("SplicesText")] public string SplicesText = "";

        [StructuresField("Splice1Component")] public string Splice1Component = "77"; [StructuresField("Splice1Preset")] public string Splice1Preset = "standard";
        [StructuresField("Splice2Component")] public string Splice2Component = ""; [StructuresField("Splice2Preset")] public string Splice2Preset = ""; [StructuresField("Splice2Indexes")] public string Splice2Indexes = "";
        [StructuresField("Splice3Component")] public string Splice3Component = ""; [StructuresField("Splice3Preset")] public string Splice3Preset = ""; [StructuresField("Splice3Indexes")] public string Splice3Indexes = "";
        [StructuresField("Splice4Component")] public string Splice4Component = ""; [StructuresField("Splice4Preset")] public string Splice4Preset = ""; [StructuresField("Splice4Indexes")] public string Splice4Indexes = "";
        [StructuresField("Splice5Component")] public string Splice5Component = ""; [StructuresField("Splice5Preset")] public string Splice5Preset = ""; [StructuresField("Splice5Indexes")] public string Splice5Indexes = "";

        [StructuresField("L_StepMode")] public int L_StepMode = 0;
        [StructuresField("Hr_base")] public double Hr_base = 1200.0;
        [StructuresField("L_StepText")] public string L_StepText = "";
        [StructuresField("L_Rasc")] public double L_Rasc = 50.0;
        [StructuresField("L_Rasc_Base")] public double L_Rasc_Base = 50.0;
        [StructuresField("L_Rasc_Top")] public double L_Rasc_Top = 50.0;
        [StructuresField("L_RascOverrides")] public string L_RascOverrides = "";

        [StructuresField("L_Type")] public int L_Type = 1;
        [StructuresField("L_Preset")] public int L_Preset = 1;
        [StructuresField("L_Offset")] public double L_Offset = 0.0;

        [StructuresField("S_Mode")] public int S_Mode = 0;
        [StructuresField("S_NodesDouble")] public string S_NodesDouble = "";
        [StructuresField("S_NodesChannel")] public string S_NodesChannel = "";
        [StructuresField("S_NodesExclude")] public string S_NodesExclude = "";
        [StructuresField("S_Base_Preset")] public int S_Base_Preset = 2;
        [StructuresField("S_Top_Preset")] public int S_Top_Preset = 2;
        [StructuresField("S_Splice_Preset")] public int S_Splice_Preset = 2;
        [StructuresField("S_Preset")] public int S_Preset = 1;

        [StructuresField("B_Profile")] public string B_Profile = "I20K1_57837_2017"; [StructuresField("B_Material")] public string B_Material = "C355Б"; [StructuresField("B_AssyPref")] public string B_AssyPref = "К"; [StructuresField("B_AssyNo")] public string B_AssyNo = "1"; [StructuresField("B_PartPref")] public string B_PartPref = "к"; [StructuresField("B_PartNo")] public string B_PartNo = "1"; [StructuresField("B_Name")] public string B_Name = "ВЕТВЬ"; [StructuresField("B_Class")] public string B_Class = "1"; [StructuresField("B_UDA")] public string B_UDA = "";
        [StructuresField("D_Profile")] public string D_Profile = "16P_8240_97"; [StructuresField("D_Material")] public string D_Material = "C245"; [StructuresField("D_AssyPref")] public string D_AssyPref = ""; [StructuresField("D_AssyNo")] public string D_AssyNo = ""; [StructuresField("D_PartPref")] public string D_PartPref = "д"; [StructuresField("D_PartNo")] public string D_PartNo = "1"; [StructuresField("D_Name")] public string D_Name = "ДИАФРАГМА"; [StructuresField("D_Class")] public string D_Class = "4"; [StructuresField("D_UDA")] public string D_UDA = "";
        [StructuresField("L_Profile")] public string L_Profile = "L75X6_8509_93"; [StructuresField("L_Material")] public string L_Material = "C245"; [StructuresField("L_AssyPref")] public string L_AssyPref = ""; [StructuresField("L_AssyNo")] public string L_AssyNo = ""; [StructuresField("L_PartPref")] public string L_PartPref = "р"; [StructuresField("L_PartNo")] public string L_PartNo = "1"; [StructuresField("L_Name")] public string L_Name = "РАСКОС"; [StructuresField("L_Class")] public string L_Class = "3"; [StructuresField("L_UDA")] public string L_UDA = "";
        [StructuresField("LS_Profile")] public string LS_Profile = ""; [StructuresField("LS_Material")] public string LS_Material = ""; [StructuresField("LS_AssyPref")] public string LS_AssyPref = ""; [StructuresField("LS_AssyNo")] public string LS_AssyNo = ""; [StructuresField("LS_PartPref")] public string LS_PartPref = "рс"; [StructuresField("LS_PartNo")] public string LS_PartNo = "1"; [StructuresField("LS_Name")] public string LS_Name = "РАСКОС СТЫКОВОЙ"; [StructuresField("LS_Class")] public string LS_Class = "3"; [StructuresField("LS_UDA")] public string LS_UDA = "";
        [StructuresField("S_Profile")] public string S_Profile = ""; [StructuresField("S_Material")] public string S_Material = ""; [StructuresField("S_AssyPref")] public string S_AssyPref = ""; [StructuresField("S_AssyNo")] public string S_AssyNo = ""; [StructuresField("S_PartPref")] public string S_PartPref = "рп"; [StructuresField("S_PartNo")] public string S_PartNo = "1"; [StructuresField("S_Name")] public string S_Name = "РАСПОРКА"; [StructuresField("S_Class")] public string S_Class = "4"; [StructuresField("S_UDA")] public string S_UDA = "";
    }

    [Plugin("Apibim_BuiltUpColumn")]
    [PluginUserInterface("Apibim.Plugins.BuiltUpColumn.MainWindow")]
    public class ModelPlugin : PluginBase
    {
        private PluginData Data { get; set; }

        public ModelPlugin(PluginData data) { Data = data; }

        public override List<InputDefinition> DefineInput()
        {
            try
            {
                Picker picker = new Picker();
                return new List<InputDefinition>
                {
                    new InputDefinition(picker.PickPoint("Укажите ось первой ветви (Точка 1)")),
                    new InputDefinition(picker.PickPoint("Укажите направление колонны (Точка 2)"))
                };
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("User interrupt")) return new List<InputDefinition>();
                System.Windows.MessageBox.Show($"Ошибка выбора точек:\n\n{ex.Message}", "RAM BIM", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
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
                    SplicesText = Data.SplicesText,
                    Splice1Component = Data.Splice1Component,
                    Splice1Preset = Data.Splice1Preset,
                    Splice2Component = Data.Splice2Component,
                    Splice2Preset = Data.Splice2Preset,
                    Splice2Indexes = Data.Splice2Indexes,
                    Splice3Component = Data.Splice3Component,
                    Splice3Preset = Data.Splice3Preset,
                    Splice3Indexes = Data.Splice3Indexes,
                    Splice4Component = Data.Splice4Component,
                    Splice4Preset = Data.Splice4Preset,
                    Splice4Indexes = Data.Splice4Indexes,
                    Splice5Component = Data.Splice5Component,
                    Splice5Preset = Data.Splice5Preset,
                    Splice5Indexes = Data.Splice5Indexes,
                    L_StepMode = Data.L_StepMode,
                    Hr_base = Data.Hr_base,
                    L_StepText = Data.L_StepText,
                    L_Rasc = Data.L_Rasc,
                    L_Rasc_Base = Data.L_Rasc_Base,
                    L_Rasc_Top = Data.L_Rasc_Top,
                    L_RascOverrides = Data.L_RascOverrides,
                    L_Type = Data.L_Type,
                    L_Preset = Data.L_Preset,
                    L_Offset = Data.L_Offset,
                    S_Mode = Data.S_Mode,
                    S_NodesDouble = Data.S_NodesDouble,
                    S_NodesChannel = Data.S_NodesChannel,
                    S_NodesExclude = Data.S_NodesExclude,
                    S_Base_Preset = Data.S_Base_Preset,
                    S_Top_Preset = Data.S_Top_Preset,
                    S_Splice_Preset = Data.S_Splice_Preset,
                    S_Preset = Data.S_Preset,

                    B_Profile = Data.B_Profile,
                    B_Material = Data.B_Material,
                    B_AssyPref = Data.B_AssyPref,
                    B_AssyNo = Data.B_AssyNo,
                    B_PartPref = Data.B_PartPref,
                    B_PartNo = Data.B_PartNo,
                    B_Name = Data.B_Name,
                    B_Class = Data.B_Class,
                    B_UDA = Data.B_UDA,
                    D_Profile = Data.D_Profile,
                    D_Material = Data.D_Material,
                    D_AssyPref = Data.D_AssyPref,
                    D_AssyNo = Data.D_AssyNo,
                    D_PartPref = Data.D_PartPref,
                    D_PartNo = Data.D_PartNo,
                    D_Name = Data.D_Name,
                    D_Class = Data.D_Class,
                    D_UDA = Data.D_UDA,
                    L_Profile = Data.L_Profile,
                    L_Material = Data.L_Material,
                    L_AssyPref = Data.L_AssyPref,
                    L_AssyNo = Data.L_AssyNo,
                    L_PartPref = Data.L_PartPref,
                    L_PartNo = Data.L_PartNo,
                    L_Name = Data.L_Name,
                    L_Class = Data.L_Class,
                    L_UDA = Data.L_UDA,
                    LS_Profile = Data.LS_Profile,
                    LS_Material = Data.LS_Material,
                    LS_AssyPref = Data.LS_AssyPref,
                    LS_AssyNo = Data.LS_AssyNo,
                    LS_PartPref = Data.LS_PartPref,
                    LS_PartNo = Data.LS_PartNo,
                    LS_Name = Data.LS_Name,
                    LS_Class = Data.LS_Class,
                    LS_UDA = Data.LS_UDA,
                    S_Profile = Data.S_Profile,
                    S_Material = Data.S_Material,
                    S_AssyPref = Data.S_AssyPref,
                    S_AssyNo = Data.S_AssyNo,
                    S_PartPref = Data.S_PartPref,
                    S_PartNo = Data.S_PartNo,
                    S_Name = Data.S_Name,
                    S_Class = Data.S_Class,
                    S_UDA = Data.S_UDA
                };

                if (string.IsNullOrWhiteSpace(colData.B_Profile)) throw new Exception("Не заполнен 'Профиль' для Ветви. Построение отменено.");
                if (string.IsNullOrWhiteSpace(colData.L_Profile)) throw new Exception("Не заполнен 'Профиль' для Раскоса. Построение отменено.");

                var branchLines = ColumnGeometryBuilder.GetBranchLines(colData);
                var zNodes = ColumnGeometryBuilder.GetZNodes(colData);
                var lacingLines = ColumnGeometryBuilder.GetLacingLines(colData, zNodes);
                var strutLines = ColumnGeometryBuilder.GetStrutLines(colData, zNodes);

                var splices = StringParserService.ParseSplices(colData.SplicesText);

                // --- 1. ГЕНЕРАЦИЯ И КЭШИРОВАНИЕ ВЕТВЕЙ ---
                double autoBaseDist = 0.0;
                List<Beam> createdBranches = new List<Beam>();

                foreach (var line in branchLines)
                {
                    Beam branch = new Beam(line.Point1, line.Point2);
                    branch.Profile.ProfileString = colData.B_Profile;
                    branch.Material.MaterialString = colData.B_Material;
                    branch.Class = colData.B_Class;
                    branch.Name = colData.B_Name;
                    branch.PartNumber.Prefix = colData.B_PartPref; branch.PartNumber.StartNumber = GetInt(colData.B_PartNo, 1);
                    branch.AssemblyNumber.Prefix = colData.B_AssyPref; branch.AssemblyNumber.StartNumber = GetInt(colData.B_AssyNo, 1);

                    branch.Position.Plane = Position.PlaneEnum.MIDDLE;
                    branch.Position.Depth = Position.DepthEnum.MIDDLE;
                    branch.Position.Rotation = Position.RotationEnum.TOP;
                    branch.Position.RotationOffset = planeAngleDeg + colData.Br_Rot;

                    if (!branch.Insert()) throw new Exception($"Не удалось построить ветвь: {colData.B_Profile} / {colData.B_Material}");

                    createdBranches.Add(branch);
                    if (autoBaseDist == 0.0) branch.GetReportProperty("PROFILE.HEIGHT", ref autoBaseDist);
                }

                if (autoBaseDist <= 0.0) autoBaseDist = 200.0;

                // --- 2. УСТАНОВКА КОМПОНЕНТОВ СТЫКОВ (5 УРОВНЕЙ КАСКАДА) ---
                var idx2 = ParseIndexes(colData.Splice2Indexes);
                var idx3 = ParseIndexes(colData.Splice3Indexes);
                var idx4 = ParseIndexes(colData.Splice4Indexes);
                var idx5 = ParseIndexes(colData.Splice5Indexes);

                int branchesPerSide = createdBranches.Count / 2;
                for (int i = 0; i < branchesPerSide - 1; i++)
                {
                    int currentLevel = i + 1; // Порядковый номер стыка для пользователя (1, 2, 3...)

                    // Уровень 1 (Базовый)
                    string activeComp = colData.Splice1Component;
                    string activePreset = colData.Splice1Preset;

                    // КАСКАДНОЕ ПЕРЕОПРЕДЕЛЕНИЕ (Кто ниже в коде - тот и Царь)
                    if (idx2.Contains(currentLevel)) { activeComp = colData.Splice2Component; activePreset = colData.Splice2Preset; }
                    if (idx3.Contains(currentLevel)) { activeComp = colData.Splice3Component; activePreset = colData.Splice3Preset; }
                    if (idx4.Contains(currentLevel)) { activeComp = colData.Splice4Component; activePreset = colData.Splice4Preset; }
                    if (idx5.Contains(currentLevel)) { activeComp = colData.Splice5Component; activePreset = colData.Splice5Preset; }

                    if (!string.IsNullOrWhiteSpace(activeComp))
                    {
                        // Левая ветвь
                        TeklaComponentService.InsertConnection(activeComp, activePreset, createdBranches[i], new List<ModelObject> { createdBranches[i + 1] }, null, out string errL);
                        // Правая ветвь
                        TeklaComponentService.InsertConnection(activeComp, activePreset, createdBranches[branchesPerSide + i], new List<ModelObject> { createdBranches[branchesPerSide + i + 1] }, null, out string errR);
                    }
                }

                // --- 3. ГЕНЕРАЦИЯ РЕШЕТКИ (СО СТРОГОЙ ПРОВЕРКОЙ СТЫКОВЫХ РАСКОСОВ) ---
                foreach (var line in lacingLines)
                {
                    bool isSpliceDiagonal = false;
                    double minZ = Math.Min(line.Point1.Z, line.Point2.Z);
                    double maxZ = Math.Max(line.Point1.Z, line.Point2.Z);

                    foreach (var spliceZ in splices)
                    {
                        if (spliceZ >= minZ && spliceZ <= maxZ)
                        {
                            isSpliceDiagonal = true;
                            break;
                        }
                    }

                    if (colData.L_Type == 0) CreateLacingBeam(line.Point1, line.Point2, colData, isSpliceDiagonal).Insert();
                    else
                    {
                        Vector shift = localY * (autoBaseDist / 2.0);
                        Point p1_A = new Point(line.Point1.X + shift.X, line.Point1.Y + shift.Y, line.Point1.Z);
                        Point p2_A = new Point(line.Point2.X + shift.X, line.Point2.Y + shift.Y, line.Point2.Z);
                        CreateLacingBeam(p1_A, p2_A, colData, isSpliceDiagonal).Insert();

                        Point p1_B = new Point(line.Point1.X - shift.X, line.Point1.Y - shift.Y, line.Point1.Z);
                        Point p2_B = new Point(line.Point2.X - shift.X, line.Point2.Y - shift.Y, line.Point2.Z);
                        CreateLacingBeam(p2_B, p1_B, colData, isSpliceDiagonal).Insert();
                    }
                }

                // --- 4. МАРШРУТИЗАЦИЯ ПЛАНОК (УЛЬТИМАТИВНЫЕ ИСКЛЮЧЕНИЯ) ---
                int totalNodes = strutLines.Count;
                var spliceNodes = ColumnGeometryBuilder.GetSpliceAdjacentNodes(zNodes, splices);

                // Читаем исключения ВСЕГДА, независимо от режима!
                var excludeNodes = StringParserService.ParseNodes(colData.S_NodesExclude, totalNodes);
                var doubleNodes = new HashSet<int>();
                var channelNodes = new HashSet<int>();

                if (colData.S_Mode == 1)
                {
                    doubleNodes = StringParserService.ParseNodes(colData.S_NodesDouble, totalNodes);
                    channelNodes = StringParserService.ParseNodes(colData.S_NodesChannel, totalNodes);
                }
                else if (colData.S_Mode == 2)
                {
                    channelNodes = StringParserService.ParseNodes(colData.S_NodesChannel, totalNodes);
                }

                for (int i = 0; i < totalNodes; i++)
                {
                    // АБСОЛЮТНЫЙ ПРИОРИТЕТ 1: Исключение планки
                    if (excludeNodes.Contains(i)) continue;

                    var line = strutLines[i];
                    int presetToUse = 0;

                    if (i == 0) presetToUse = colData.S_Base_Preset;
                    else if (i == totalNodes - 1) presetToUse = colData.S_Top_Preset;
                    else if (spliceNodes.Contains(i)) presetToUse = colData.S_Splice_Preset;
                    else if (colData.S_Mode > 0)
                    {
                        if (channelNodes.Contains(i)) presetToUse = 2;
                        else if (colData.S_Mode == 2 || doubleNodes.Contains(i)) presetToUse = colData.S_Preset;
                    }

                    if (presetToUse == 1) InsertStrut_AsLacing(line, colData, localY, autoBaseDist);
                    else if (presetToUse == 2) CreateStrutBeam_Channel(line.Point1, line.Point2, colData).Insert();
                }

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Критическая ошибка построения (Run):\n\n{ex}", "RAM BIM: Ошибка", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return false;
            }
        }

        // --- ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ---
        private int GetInt(string val, int fallback)
        {
            if (int.TryParse(val, out int result)) return result;
            return fallback;
        }


        private void InsertStrut_AsLacing(LineSegment line, BuiltUpColumnData colData, Vector localY, double autoBaseDist)
        {
            if (colData.L_Type == 0) CreateStrutBeam_AsLacing(line.Point1, line.Point2, colData).Insert();
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

        private Beam CreateLacingBeam(Point p1, Point p2, BuiltUpColumnData data, bool isSpliceDiagonal)
        {
            Beam b = new Beam(p1, p2);

            // Наследование для стыкового раскоса (Если LS_ пустой, берет значение от обычного раскоса L_)
            string prof = isSpliceDiagonal && !string.IsNullOrWhiteSpace(data.LS_Profile) ? data.LS_Profile : data.L_Profile;
            string mat = isSpliceDiagonal && !string.IsNullOrWhiteSpace(data.LS_Material) ? data.LS_Material : data.L_Material;
            string cls = isSpliceDiagonal && !string.IsNullOrWhiteSpace(data.LS_Class) ? data.LS_Class : data.L_Class;
            string name = isSpliceDiagonal && !string.IsNullOrWhiteSpace(data.LS_Name) ? data.LS_Name : data.L_Name;
            string pPref = isSpliceDiagonal && !string.IsNullOrWhiteSpace(data.LS_PartPref) ? data.LS_PartPref : data.L_PartPref;
            string pNo = isSpliceDiagonal && !string.IsNullOrWhiteSpace(data.LS_PartNo) ? data.LS_PartNo : data.L_PartNo;
            string aPref = isSpliceDiagonal && !string.IsNullOrWhiteSpace(data.LS_AssyPref) ? data.LS_AssyPref : data.L_AssyPref;
            string aNo = isSpliceDiagonal && !string.IsNullOrWhiteSpace(data.LS_AssyNo) ? data.LS_AssyNo : data.L_AssyNo;

            b.Profile.ProfileString = prof;
            b.Material.MaterialString = mat;
            b.Class = cls;
            b.Name = name;
            b.PartNumber.Prefix = pPref; b.PartNumber.StartNumber = GetInt(pNo, 1);
            b.AssemblyNumber.Prefix = aPref; b.AssemblyNumber.StartNumber = GetInt(aNo, 1);

            b.Position.PlaneOffset = 0.0;
            b.Position.DepthOffset = 0.0;

            int activePreset = data.L_Type == 1 ? 1 : data.L_Preset;
            switch (activePreset)
            {
                case 1: b.Position.Plane = Position.PlaneEnum.MIDDLE; b.Position.Depth = Position.DepthEnum.FRONT; b.Position.Rotation = Position.RotationEnum.TOP; b.Position.RotationOffset = 90.0; b.Position.DepthOffset = data.L_Offset; break;
                case 2: b.Position.Plane = Position.PlaneEnum.LEFT; b.Position.Depth = Position.DepthEnum.MIDDLE; b.Position.Rotation = Position.RotationEnum.FRONT; b.Position.RotationOffset = 0.0; b.Position.PlaneOffset = data.L_Offset; break;
                case 3: b.Position.Plane = Position.PlaneEnum.MIDDLE; b.Position.Depth = Position.DepthEnum.MIDDLE; b.Position.Rotation = Position.RotationEnum.FRONT; b.Position.RotationOffset = 0.0; b.Position.PlaneOffset = data.L_Offset; break;
            }
            return b;
        }

        private Beam CreateStrutBeam_AsLacing(Point p1, Point p2, BuiltUpColumnData data)
        {
            // Распорка технически это просто горизонтальный раскос (передаем false)
            Beam b = CreateLacingBeam(p1, p2, data, false);

            if (!string.IsNullOrWhiteSpace(data.S_Profile)) b.Profile.ProfileString = data.S_Profile;
            if (!string.IsNullOrWhiteSpace(data.S_Material)) b.Material.MaterialString = data.S_Material;
            if (!string.IsNullOrWhiteSpace(data.S_Class)) b.Class = data.S_Class;
            if (!string.IsNullOrWhiteSpace(data.S_Name)) b.Name = data.S_Name;
            if (!string.IsNullOrWhiteSpace(data.S_PartPref)) b.PartNumber.Prefix = data.S_PartPref;
            if (!string.IsNullOrWhiteSpace(data.S_PartNo)) b.PartNumber.StartNumber = GetInt(data.S_PartNo, 1);

            return b;
        }

        private Beam CreateStrutBeam_Channel(Point p1, Point p2, BuiltUpColumnData data)
        {
            Beam b = new Beam(p1, p2);
            b.Profile.ProfileString = data.D_Profile;
            b.Material.MaterialString = data.D_Material;
            b.Class = data.D_Class;
            b.Name = data.D_Name;
            b.PartNumber.Prefix = data.D_PartPref; b.PartNumber.StartNumber = GetInt(data.D_PartNo, 1);
            b.AssemblyNumber.Prefix = data.D_AssyPref; b.AssemblyNumber.StartNumber = GetInt(data.D_AssyNo, 1);

            b.Position.Plane = Position.PlaneEnum.MIDDLE;
            b.Position.Depth = Position.DepthEnum.BEHIND;
            b.Position.PlaneOffset = 0.0;
            b.Position.DepthOffset = 0.0;
            b.Position.Rotation = Position.RotationEnum.BACK;
            b.Position.RotationOffset = 0.0;

            return b;
        }
        private HashSet<int> ParseIndexes(string text)
        {
            var set = new HashSet<int>();
            if (string.IsNullOrWhiteSpace(text)) return set;
            var parts = text.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var p in parts)
            {
                if (int.TryParse(p, out int val)) set.Add(val);
            }
            return set;
        }
    }
}
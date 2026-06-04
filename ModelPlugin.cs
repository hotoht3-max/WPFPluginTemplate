using Apibim.Plugins.BuiltUpColumn.Models;
using Apibim.Plugins.BuiltUpColumn.Services;
using System;
using System.Collections.Generic;
using Tekla.Extension;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;

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

        // --- ПЛАНКИ (Правила и слоты) ---
        [StructuresField("S_Base_Preset")] public int S_Base_Preset = 2;
        [StructuresField("S_Top_Preset")] public int S_Top_Preset = 2;
        [StructuresField("S_Splice_Preset")] public int S_Splice_Preset = 2;
        [StructuresField("S_Preset")] public int S_Preset = 1;

        [StructuresField("S_NodesAngle")] public string S_NodesAngle = "";
        [StructuresField("S_NodesAnglePlate")] public string S_NodesAnglePlate = "";
        [StructuresField("S_NodesD1")] public string S_NodesD1 = "";
        [StructuresField("S_NodesD2")] public string S_NodesD2 = "";
        [StructuresField("S_NodesExcludePlate")] public string S_NodesExcludePlate = "";
        [StructuresField("S_NodesExclude")] public string S_NodesExclude = "";

        // Плоские свойства для связи с UI
        [StructuresField("B_Profile")] public string B_Profile = "I20K1_57837_2017"; [StructuresField("B_Material")] public string B_Material = "C355Б"; [StructuresField("B_AssyPref")] public string B_AssyPref = "К"; [StructuresField("B_AssyNo")] public string B_AssyNo = "1"; [StructuresField("B_PartPref")] public string B_PartPref = "к"; [StructuresField("B_PartNo")] public string B_PartNo = "1"; [StructuresField("B_Name")] public string B_Name = "ВЕТВЬ"; [StructuresField("B_Class")] public string B_Class = "1"; [StructuresField("B_UDA")] public string B_UDA = "";
        [StructuresField("D_Profile")] public string D_Profile = "16P_8240_97"; [StructuresField("D_Material")] public string D_Material = "C245"; [StructuresField("D_AssyPref")] public string D_AssyPref = ""; [StructuresField("D_AssyNo")] public string D_AssyNo = ""; [StructuresField("D_PartPref")] public string D_PartPref = "д1"; [StructuresField("D_PartNo")] public string D_PartNo = "1"; [StructuresField("D_Name")] public string D_Name = "ДИАФРАГМА 1"; [StructuresField("D_Class")] public string D_Class = "4"; [StructuresField("D_UDA")] public string D_UDA = "";
        [StructuresField("D2_Profile")] public string D2_Profile = "20B1_57837_2017"; [StructuresField("D2_Material")] public string D2_Material = "C245"; [StructuresField("D2_AssyPref")] public string D2_AssyPref = ""; [StructuresField("D2_AssyNo")] public string D2_AssyNo = ""; [StructuresField("D2_PartPref")] public string D2_PartPref = "д2"; [StructuresField("D2_PartNo")] public string D2_PartNo = "1"; [StructuresField("D2_Name")] public string D2_Name = "ДИАФРАГМА 2"; [StructuresField("D2_Class")] public string D2_Class = "4"; [StructuresField("D2_UDA")] public string D2_UDA = "";
        [StructuresField("S_Profile")] public string S_Profile = "L75X6_8509_93"; [StructuresField("S_Material")] public string S_Material = "C245"; [StructuresField("S_AssyPref")] public string S_AssyPref = ""; [StructuresField("S_AssyNo")] public string S_AssyNo = ""; [StructuresField("S_PartPref")] public string S_PartPref = "рп"; [StructuresField("S_PartNo")] public string S_PartNo = "1"; [StructuresField("S_Name")] public string S_Name = "РАСПОРКА"; [StructuresField("S_Class")] public string S_Class = "4"; [StructuresField("S_UDA")] public string S_UDA = "";
        [StructuresField("L_Profile")] public string L_Profile = "L75X6_8509_93"; [StructuresField("L_Material")] public string L_Material = "C245"; [StructuresField("L_AssyPref")] public string L_AssyPref = ""; [StructuresField("L_AssyNo")] public string L_AssyNo = ""; [StructuresField("L_PartPref")] public string L_PartPref = "р"; [StructuresField("L_PartNo")] public string L_PartNo = "1"; [StructuresField("L_Name")] public string L_Name = "РАСКОС"; [StructuresField("L_Class")] public string L_Class = "3"; [StructuresField("L_UDA")] public string L_UDA = "";
        [StructuresField("LS_Profile")] public string LS_Profile = ""; [StructuresField("LS_Material")] public string LS_Material = ""; [StructuresField("LS_AssyPref")] public string LS_AssyPref = ""; [StructuresField("LS_AssyNo")] public string LS_AssyNo = ""; [StructuresField("LS_PartPref")] public string LS_PartPref = "рс"; [StructuresField("LS_PartNo")] public string LS_PartNo = "1"; [StructuresField("LS_Name")] public string LS_Name = "РАСКОС СТЫКОВОЙ"; [StructuresField("LS_Class")] public string LS_Class = "3"; [StructuresField("LS_UDA")] public string LS_UDA = "";
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

                // --- 1. ПОДГОТОВКА СИСТЕМЫ КООРДИНАТ ---
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

                // --- 2. МАППИНГ ДАННЫХ (DataMapper) ---
                var colData = PluginDataMapper.Map(Data);
                colData.BasePoint1 = p1;
                colData.BasePoint2 = p2;

                if (string.IsNullOrWhiteSpace(colData.Branch.Profile)) throw new Exception("Не заполнен 'Профиль' для Ветви. Построение отменено.");
                if (string.IsNullOrWhiteSpace(colData.Lacing.Profile)) throw new Exception("Не заполнен 'Профиль' для Раскоса. Построение отменено.");

                // --- 3. ГЕОМЕТРИЧЕСКИЙ КАРКАС ---
                var branchLines = ColumnGeometryBuilder.GetBranchLines(colData);
                var zNodes = ColumnGeometryBuilder.GetZNodes(colData);
                var lacingLines = ColumnGeometryBuilder.GetLacingLines(colData, zNodes);
                var strutLines = ColumnGeometryBuilder.GetStrutLines(colData, zNodes);
                var splices = StringParserService.ParseSplices(colData.SplicesText);

                // --- 4. ОРКЕСТРАЦИЯ (Вызов Фабрик) ---
                var branches = BuildBranches(branchLines, colData, planeAngleDeg, out double autoBaseDist);
                BuildSplices(branches, colData);
                BuildLacing(lacingLines, splices, colData, localY, autoBaseDist);
                BuildStrutsAndDiaphragms(strutLines, zNodes, splices, colData, localY, autoBaseDist);

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Критическая ошибка построения (Run):\n\n{ex}", "RAM BIM: Ошибка", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return false;
            }
        }

        // =========================================================================
        // ОРКЕСТРАТОРЫ ПОСТРОЕНИЯ (Дирижируют фабриками)
        // =========================================================================

        private List<Beam> BuildBranches(List<LineSegment> branchLines, BuiltUpColumnData colData, double planeAngleDeg, out double autoBaseDist)
        {
            autoBaseDist = 0.0;
            List<Beam> createdBranches = new List<Beam>();

            foreach (var line in branchLines)
            {
                Beam branch = TeklaPartBuilder.CreateBranch(line.Point1, line.Point2, colData.Branch, planeAngleDeg + colData.Br_Rot);
                if (!branch.Insert()) throw new Exception($"Не удалось построить ветвь: {colData.Branch.Profile}");

                createdBranches.Add(branch);
                if (autoBaseDist == 0.0) branch.GetReportProperty("PROFILE.HEIGHT", ref autoBaseDist);
            }

            if (autoBaseDist <= 0.0) autoBaseDist = 200.0;
            return createdBranches;
        }

        private void BuildSplices(List<Beam> branches, BuiltUpColumnData colData)
        {
            var idx2 = ParseIndexes(colData.Splice2Indexes);
            var idx3 = ParseIndexes(colData.Splice3Indexes);
            var idx4 = ParseIndexes(colData.Splice4Indexes);
            var idx5 = ParseIndexes(colData.Splice5Indexes);

            int branchesPerSide = branches.Count / 2;
            for (int i = 0; i < branchesPerSide - 1; i++)
            {
                int currentLevel = i + 1;
                string activeComp = colData.Splice1Component;
                string activePreset = colData.Splice1Preset;

                // Каскад переопределений
                if (idx2.Contains(currentLevel)) { activeComp = colData.Splice2Component; activePreset = colData.Splice2Preset; }
                if (idx3.Contains(currentLevel)) { activeComp = colData.Splice3Component; activePreset = colData.Splice3Preset; }
                if (idx4.Contains(currentLevel)) { activeComp = colData.Splice4Component; activePreset = colData.Splice4Preset; }
                if (idx5.Contains(currentLevel)) { activeComp = colData.Splice5Component; activePreset = colData.Splice5Preset; }

                if (!string.IsNullOrWhiteSpace(activeComp))
                {
                    TeklaComponentService.InsertConnection(activeComp, activePreset, branches[i], new List<ModelObject> { branches[i + 1] }, null, out _);
                    TeklaComponentService.InsertConnection(activeComp, activePreset, branches[branchesPerSide + i], new List<ModelObject> { branches[branchesPerSide + i + 1] }, null, out _);
                }
            }
        }

        private void BuildLacing(List<LineSegment> lacingLines, List<double> splices, BuiltUpColumnData colData, Vector localY, double autoBaseDist)
        {
            foreach (var line in lacingLines)
            {
                bool isSpliceDiagonal = false;
                double minZ = Math.Min(line.Point1.Z, line.Point2.Z);
                double maxZ = Math.Max(line.Point1.Z, line.Point2.Z);

                foreach (var spliceZ in splices)
                {
                    if (spliceZ >= minZ && spliceZ <= maxZ) { isSpliceDiagonal = true; break; }
                }

                // Выбор настроек (Стыковой раскос или Рядовой)
                PartSettings settings = isSpliceDiagonal && !string.IsNullOrWhiteSpace(colData.LacingSplice.Profile)
                    ? colData.LacingSplice
                    : colData.Lacing;

                int activePreset = colData.L_Type == 1 ? 1 : colData.L_Preset;

                if (colData.L_Type == 0) // Одинарная решетка
                {
                    TeklaPartBuilder.CreateLacing(line.Point1, line.Point2, settings, activePreset, colData.L_Offset).Insert();
                }
                else // Сдвоенная решетка
                {
                    Vector shift = localY * (autoBaseDist / 2.0);
                    Point p1_A = new Point(line.Point1.X + shift.X, line.Point1.Y + shift.Y, line.Point1.Z);
                    Point p2_A = new Point(line.Point2.X + shift.X, line.Point2.Y + shift.Y, line.Point2.Z);
                    TeklaPartBuilder.CreateLacing(p1_A, p2_A, settings, activePreset, colData.L_Offset).Insert();

                    Point p1_B = new Point(line.Point1.X - shift.X, line.Point1.Y - shift.Y, line.Point1.Z);
                    Point p2_B = new Point(line.Point2.X - shift.X, line.Point2.Y - shift.Y, line.Point2.Z);
                    TeklaPartBuilder.CreateLacing(p2_B, p1_B, settings, activePreset, colData.L_Offset).Insert();
                }
            }
        }

        private void BuildStrutsAndDiaphragms(List<LineSegment> strutLines, List<double> zNodes, List<double> splices, BuiltUpColumnData colData, Vector localY, double autoBaseDist)
        {
            var idxAngle = ParseIndexes(colData.S_NodesAngle);
            var idxAnglePlate = ParseIndexes(colData.S_NodesAnglePlate);
            var idxD1 = ParseIndexes(colData.S_NodesD1);
            var idxD2 = ParseIndexes(colData.S_NodesD2);
            var idxExcPlate = ParseIndexes(colData.S_NodesExcludePlate);
            var idxExclude = ParseIndexes(colData.S_NodesExclude);

            int totalNodes = strutLines.Count;
            var spliceNodes = ColumnGeometryBuilder.GetSpliceAdjacentNodes(zNodes, splices);

            for (int i = 0; i < totalNodes; i++)
            {
                int currentLevel = i + 1;
                int slotType = 0;

                // 1. ФОНОВАЯ ЗАЛИВКА
                if (i == 0) slotType = colData.S_Base_Preset;
                else if (i == totalNodes - 1) slotType = colData.S_Top_Preset;
                else if (spliceNodes.Contains(i)) slotType = colData.S_Splice_Preset;
                else slotType = colData.S_Preset;

                // 2. РУЧНОЕ СОЗИДАНИЕ
                if (idxAngle.Contains(currentLevel)) slotType = 1;
                if (idxAnglePlate.Contains(currentLevel)) slotType = 2;
                if (idxD1.Contains(currentLevel)) slotType = 3;
                if (idxD2.Contains(currentLevel)) slotType = 4;

                // 3. ДЕГРАДАЦИЯ (Снос листа)
                if (idxExcPlate.Contains(currentLevel) && slotType == 2) slotType = 1;

                // 4. АННИГИЛЯЦИЯ
                if (idxExclude.Contains(currentLevel)) slotType = 0;

                if (slotType == 0) continue;

                var line = strutLines[i];

                if (slotType == 1 || slotType == 2)
                {
                    // --- ЗАЩИТА ОТ ДУРАКА ---
                    if (string.IsNullOrWhiteSpace(colData.Strut.Profile))
                        throw new Exception($"Узел {currentLevel}: Назначена Распорка, но её 'Профиль' пуст во вкладке Атрибуты!");

                    int activePreset = colData.L_Type == 1 ? 1 : colData.L_Preset;

                    if (colData.L_Type == 0)
                    {
                        TeklaPartBuilder.CreateLacing(line.Point1, line.Point2, colData.Strut, activePreset, colData.L_Offset).Insert();
                    }
                    else
                    {
                        Vector shift = localY * (autoBaseDist / 2.0);
                        Point p1_A = new Point(line.Point1.X + shift.X, line.Point1.Y + shift.Y, line.Point1.Z);
                        Point p2_A = new Point(line.Point2.X + shift.X, line.Point2.Y + shift.Y, line.Point2.Z);
                        TeklaPartBuilder.CreateLacing(p1_A, p2_A, colData.Strut, activePreset, colData.L_Offset).Insert();

                        Point p1_B = new Point(line.Point1.X - shift.X, line.Point1.Y - shift.Y, line.Point1.Z);
                        Point p2_B = new Point(line.Point2.X - shift.X, line.Point2.Y - shift.Y, line.Point2.Z);
                        TeklaPartBuilder.CreateLacing(p2_B, p1_B, colData.Strut, activePreset, colData.L_Offset).Insert();
                    }

                    if (slotType == 2 && colData.L_Type == 1) // Лист (только для сдвоенной)
                    {
                        TeklaPartBuilder.CreateGussetPlate(line.Point1, line.Point2, colData.GussetPlate).Insert();
                    }
                }
                else if (slotType == 3)
                {
                    // --- ЗАЩИТА ОТ ДУРАКА ---
                    if (string.IsNullOrWhiteSpace(colData.Diaphragm1.Profile))
                        throw new Exception($"Узел {currentLevel}: Назначена Диафрагма (Тип 1), но её 'Профиль' пуст во вкладке Атрибуты!");

                    TeklaPartBuilder.CreateDiaphragm(line.Point1, line.Point2, colData.Diaphragm1).Insert();
                }
                else if (slotType == 4)
                {
                    // --- ЗАЩИТА ОТ ДУРАКА ---
                    if (string.IsNullOrWhiteSpace(colData.Diaphragm2.Profile))
                        throw new Exception($"Узел {currentLevel}: Назначена Диафрагма (Тип 2), но её 'Профиль' пуст во вкладке Атрибуты!");

                    TeklaPartBuilder.CreateDiaphragm(line.Point1, line.Point2, colData.Diaphragm2).Insert();
                }
            }
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
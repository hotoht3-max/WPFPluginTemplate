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
        // =========================================================
        // --- ALPHA 1.0: БАЗОВАЯ ГЕОМЕТРИЯ ---
        // =========================================================
        [StructuresField("Bcol")] public double Bcol = 500.0;
        [StructuresField("Br_Rot")] public double Br_Rot = 90.0;
        [StructuresField("Hcol_1")] public double Hcol_1 = 10000.0;
        [StructuresField("Hcol_e1")] public double Hcol_e1 = 500.0;
        [StructuresField("Hcol_e2")] public double Hcol_e2 = 600.0;
        [StructuresField("Hcol_e3")] public double Hcol_e3 = 600.0;

        // --- ALPHA 1.6.1: СМЕЩЕНИЯ ---

        [StructuresField("Global_Dx")] public double Global_Dx = 0.0;
        [StructuresField("Global_Dy")] public double Global_Dy = 0.0;
        [StructuresField("Global_Rot")] public double Global_Rot = 0.0;

        // =========================================================
        // --- ALPHA 1.1: СТЫКИ ВЕТВЕЙ ---
        // =========================================================
        [StructuresField("SplicesText")] public string SplicesText = "";
        [StructuresField("Splice1Component")] public string Splice1Component = "77"; [StructuresField("Splice1Preset")] public string Splice1Preset = "standard";
        [StructuresField("Splice2Component")] public string Splice2Component = ""; [StructuresField("Splice2Preset")] public string Splice2Preset = ""; [StructuresField("Splice2Indexes")] public string Splice2Indexes = "";
        [StructuresField("Splice3Component")] public string Splice3Component = ""; [StructuresField("Splice3Preset")] public string Splice3Preset = ""; [StructuresField("Splice3Indexes")] public string Splice3Indexes = "";
        [StructuresField("Splice4Component")] public string Splice4Component = ""; [StructuresField("Splice4Preset")] public string Splice4Preset = ""; [StructuresField("Splice4Indexes")] public string Splice4Indexes = "";
        [StructuresField("Splice5Component")] public string Splice5Component = ""; [StructuresField("Splice5Preset")] public string Splice5Preset = ""; [StructuresField("Splice5Indexes")] public string Splice5Indexes = "";

        // =========================================================
        // --- ALPHA 1.2: УМНАЯ РЕШЕТКА И ПЛАНКИ ---
        // =========================================================
        [StructuresField("L_StepMode")] public int L_StepMode = 0;
        [StructuresField("L_StepText")] public string L_StepText = ""; // Заменил жесткий Hr_base
        [StructuresField("L_MinRemainder")] public double L_MinRemainder = 0.0;
        [StructuresField("L_MergePanels")] public int L_MergePanels = 2;
        [StructuresField("L_RemainPanels")] public int L_RemainPanels = 2;

        [StructuresField("L_Invert")] public int L_Invert = 0;
        [StructuresField("L_Exclude")] public string L_Exclude = "";
        [StructuresField("L_HoldPhase")] public int L_HoldPhase = 0;

        [StructuresField("L_Rasc")] public double L_Rasc = 50.0;
        [StructuresField("L_Rasc_Base")] public double L_Rasc_Base = 50.0;
        [StructuresField("L_Rasc_Top")] public double L_Rasc_Top = 50.0;
        [StructuresField("L_RascOverrides")] public string L_RascOverrides = "";

        [StructuresField("L_Type")] public int L_Type = 1;
        [StructuresField("L_Preset")] public int L_Preset = 1;
        [StructuresField("L_Offset")] public double L_Offset = 0.0;

        // Каскад планок
        [StructuresField("S_Base_Preset")] public int S_Base_Preset = 2;
        [StructuresField("S_Top_Preset")] public int S_Top_Preset = 2;
        [StructuresField("S_Splice_Preset")] public int S_Splice_Preset = 2;
        [StructuresField("S_KeyElev_Preset")] public int S_KeyElev_Preset = 0;
        [StructuresField("S_Preset")] public int S_Preset = 1;
        [StructuresField("S_NodesAngle")] public string S_NodesAngle = "";
        [StructuresField("S_NodesAnglePlate")] public string S_NodesAnglePlate = "";
        [StructuresField("S_NodesD1")] public string S_NodesD1 = "";
        [StructuresField("S_NodesD2")] public string S_NodesD2 = "";
        [StructuresField("S_NodesExcludePlate")] public string S_NodesExcludePlate = "";
        [StructuresField("S_NodesExclude")] public string S_NodesExclude = "";

        // =========================================================
        // --- ALPHA 1.3: ВРЕЗКА И ПОЗИЦИОНИРОВАНИЕ ДИАФРАГМ ---
        // =========================================================
        [StructuresField("D1_CutComp")] public string D1_CutComp = "123";
        [StructuresField("D1_CutAttr")] public string D1_CutAttr = "standard";
        [StructuresField("D2_CutComp")] public string D2_CutComp = "123";
        [StructuresField("D2_CutAttr")] public string D2_CutAttr = "standard";
        [StructuresField("GP_CutMode")] public int GP_CutMode = 1; // 0 - Габарит, 1 - Стенка
        [StructuresField("D1_CutMode")] public int D1_CutMode = 1;
        [StructuresField("D2_CutMode")] public int D2_CutMode = 1;
        [StructuresField("D_GapW")] public double D_GapW = 0.0;
        [StructuresField("D_GapL")] public double D_GapL = 0.0;

        [StructuresField("D1_PosPlane")] public int D1_PosPlane = 0; [StructuresField("D1_PosPlaneOff")] public double D1_PosPlaneOff = 0.0;
        [StructuresField("D1_PosRot")] public int D1_PosRot = 0; [StructuresField("D1_PosRotOff")] public double D1_PosRotOff = 0.0;
        [StructuresField("D1_PosDepth")] public int D1_PosDepth = 0; [StructuresField("D1_PosDepthOff")] public double D1_PosDepthOff = 0.0;

        [StructuresField("D2_PosPlane")] public int D2_PosPlane = 0; [StructuresField("D2_PosPlaneOff")] public double D2_PosPlaneOff = 0.0;
        [StructuresField("D2_PosRot")] public int D2_PosRot = 0; [StructuresField("D2_PosRotOff")] public double D2_PosRotOff = 0.0;
        [StructuresField("D2_PosDepth")] public int D2_PosDepth = 0; [StructuresField("D2_PosDepthOff")] public double D2_PosDepthOff = 0.0;

        // =========================================================
        // --- ALPHA 1.0 - 1.3: АТРИБУТЫ ПРОФИЛЕЙ (Деталировка) ---
        // =========================================================
        [StructuresField("B_Profile")] public string B_Profile = "I20K1_57837_2017"; [StructuresField("B_Material")] public string B_Material = "C355Б"; [StructuresField("B_AssyPref")] public string B_AssyPref = "К"; [StructuresField("B_AssyNo")] public string B_AssyNo = "1"; [StructuresField("B_PartPref")] public string B_PartPref = "к"; [StructuresField("B_PartNo")] public string B_PartNo = "1"; [StructuresField("B_Name")] public string B_Name = "ВЕТВЬ"; [StructuresField("B_Class")] public string B_Class = "1"; [StructuresField("B_UDA")] public string B_UDA = "";
        [StructuresField("D_Profile")] public string D_Profile = "16P_8240_97"; [StructuresField("D_Material")] public string D_Material = "C245"; [StructuresField("D_AssyPref")] public string D_AssyPref = ""; [StructuresField("D_AssyNo")] public string D_AssyNo = ""; [StructuresField("D_PartPref")] public string D_PartPref = "д1"; [StructuresField("D_PartNo")] public string D_PartNo = "1"; [StructuresField("D_Name")] public string D_Name = "ДИАФРАГМА 1"; [StructuresField("D_Class")] public string D_Class = "4"; [StructuresField("D_UDA")] public string D_UDA = "";
        [StructuresField("D2_Profile")] public string D2_Profile = "20B1_57837_2017"; [StructuresField("D2_Material")] public string D2_Material = "C245"; [StructuresField("D2_AssyPref")] public string D2_AssyPref = ""; [StructuresField("D2_AssyNo")] public string D2_AssyNo = ""; [StructuresField("D2_PartPref")] public string D2_PartPref = "д2"; [StructuresField("D2_PartNo")] public string D2_PartNo = "1"; [StructuresField("D2_Name")] public string D2_Name = "ДИАФРАГМА 2"; [StructuresField("D2_Class")] public string D2_Class = "4"; [StructuresField("D2_UDA")] public string D2_UDA = "";
        [StructuresField("L_Profile")] public string L_Profile = "L75X6_8509_93"; [StructuresField("L_Material")] public string L_Material = "C245"; [StructuresField("L_AssyPref")] public string L_AssyPref = ""; [StructuresField("L_AssyNo")] public string L_AssyNo = ""; [StructuresField("L_PartPref")] public string L_PartPref = "р"; [StructuresField("L_PartNo")] public string L_PartNo = "1"; [StructuresField("L_Name")] public string L_Name = "РАСКОС"; [StructuresField("L_Class")] public string L_Class = "3"; [StructuresField("L_UDA")] public string L_UDA = "";
        [StructuresField("LS_Profile")] public string LS_Profile = ""; [StructuresField("LS_Material")] public string LS_Material = ""; [StructuresField("LS_AssyPref")] public string LS_AssyPref = ""; [StructuresField("LS_AssyNo")] public string LS_AssyNo = ""; [StructuresField("LS_PartPref")] public string LS_PartPref = "рс"; [StructuresField("LS_PartNo")] public string LS_PartNo = "1"; [StructuresField("LS_Name")] public string LS_Name = "РАСКОС СТЫКОВОЙ"; [StructuresField("LS_Class")] public string LS_Class = "3"; [StructuresField("LS_UDA")] public string LS_UDA = "";
        [StructuresField("S_Profile")] public string S_Profile = "L75X6_8509_93"; [StructuresField("S_Material")] public string S_Material = "C245"; [StructuresField("S_AssyPref")] public string S_AssyPref = ""; [StructuresField("S_AssyNo")] public string S_AssyNo = ""; [StructuresField("S_PartPref")] public string S_PartPref = "рп"; [StructuresField("S_PartNo")] public string S_PartNo = "1"; [StructuresField("S_Name")] public string S_Name = "РАСПОРКА"; [StructuresField("S_Class")] public string S_Class = "4"; [StructuresField("S_UDA")] public string S_UDA = "";

        // Лист распорки (Альфа 1.3)
        [StructuresField("GP_Thickness")] public string GP_Thickness = "10"; [StructuresField("GP_Material")] public string GP_Material = "C245"; [StructuresField("GP_AssyPref")] public string GP_AssyPref = ""; [StructuresField("GP_AssyNo")] public string GP_AssyNo = ""; [StructuresField("GP_PartPref")] public string GP_PartPref = "пл"; [StructuresField("GP_PartNo")] public string GP_PartNo = "1"; [StructuresField("GP_Name")] public string GP_Name = "ЛИСТ РАСПОРКИ"; [StructuresField("GP_Class")] public string GP_Class = "99"; [StructuresField("GP_UDA")] public string GP_UDA = "";

        // =========================================================
        // --- ALPHA 1.4: НАДКОЛОННИК ---
        // =========================================================
        [StructuresField("NK_Mode")] public int NK_Mode = 0;
        [StructuresField("NK_HeightType")] public int NK_HeightType = 0;
        [StructuresField("NK_Value")] public double NK_Value = 1000.0;
        [StructuresField("NK_Offset")] public double NK_Offset = 0.0;
        [StructuresField("NK_Rot")] public double NK_Rot = 0.0;

        [StructuresField("NK_Profile")] public string NK_Profile = "40K1_57837_2017";
        [StructuresField("NK_Material")] public string NK_Material = "C355Б";
        [StructuresField("NK_AssyPref")] public string NK_AssyPref = "К";
        [StructuresField("NK_AssyNo")] public string NK_AssyNo = "1";
        [StructuresField("NK_PartPref")] public string NK_PartPref = "нк";
        [StructuresField("NK_PartNo")] public string NK_PartNo = "1";
        [StructuresField("NK_Name")] public string NK_Name = "НАДКОЛОННИК";
        [StructuresField("NK_Class")] public string NK_Class = "1";
        [StructuresField("NK_UDA")] public string NK_UDA = "";

        // =========================================================
        // --- ALPHA 1.6.2: ОГОЛОВОК (Балка и Надколонник) ---
        // =========================================================
        [StructuresField("Head_Type")] public int Head_Type = 0; // 0-Нет, 1-Надколонник, 2-Балка, 3-Всё
        [StructuresField("HB_OverhangLeft")] public double HB_OverhangLeft = 200.0;
        [StructuresField("HB_OverhangRight")] public double HB_OverhangRight = 200.0;

        // Позиционирование балки
        [StructuresField("HB_PosPlane")] public int HB_PosPlane = 0;
        [StructuresField("HB_PosPlaneOff")] public double HB_PosPlaneOff = 0.0;
        [StructuresField("HB_PosRot")] public int HB_PosRot = 0;
        [StructuresField("HB_PosRotOff")] public double HB_PosRotOff = 0.0;
        [StructuresField("HB_PosDepth")] public int HB_PosDepth = 2; // По умолчанию "Позади" (сверху ветвей)
        [StructuresField("HB_PosDepthOff")] public double HB_PosDepthOff = 0.0;

        // Атрибуты детали балки
        [StructuresField("HB_Profile")] public string HB_Profile = "40B1_57837_2017";
        [StructuresField("HB_Material")] public string HB_Material = "C245";
        [StructuresField("HB_AssyPref")] public string HB_AssyPref = "Б";
        [StructuresField("HB_AssyNo")] public string HB_AssyNo = "1";
        [StructuresField("HB_PartPref")] public string HB_PartPref = "б";
        [StructuresField("HB_PartNo")] public string HB_PartNo = "1";
        [StructuresField("HB_Name")] public string HB_Name = "БАЛКА ОГОЛОВКА";
        [StructuresField("HB_Class")] public string HB_Class = "6";
        [StructuresField("HB_UDA")] public string HB_UDA = "";
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
                p2Temp = p2Temp.ResetZ(p1.Z); // Используем Extension!

                // Исходное направление по двум точкам
                Vector initialDir = PointExtension.GetVector(p1, p2Temp);
                if (initialDir.GetLength() < 10.0) return false;

                // Вычисляем углы и применяем глобальный поворот
                double initialAngleRad = Math.Atan2(initialDir.Y, initialDir.X);
                double finalAngleRad = initialAngleRad + (Data.Global_Rot * Math.PI / 180.0);

                // Формируем повернутые локальные векторы
                Vector localX = new Vector(Math.Cos(finalAngleRad), Math.Sin(finalAngleRad), 0);
                Vector localY = new Vector(-Math.Sin(finalAngleRad), Math.Cos(finalAngleRad), 0);
                double planeAngleDeg = finalAngleRad * (180.0 / Math.PI);

                // Сдвиг p1 в локальной плоскости (вдоль уже повернутых векторов)
                Vector totalShift = new Vector(
                    localX.X * Data.Global_Dx + localY.X * Data.Global_Dy,
                    localX.Y * Data.Global_Dx + localY.Y * Data.Global_Dy,
                    0);

                p1.Translate(totalShift.X, totalShift.Y, totalShift.Z);

                // p2 теперь жестко привязывается к p1 по вектору на расстоянии Bcol
                Point p2 = new Point(p1);
                p2.Translate(localX.X * Data.Bcol, localX.Y * Data.Bcol, localX.Z * Data.Bcol);

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

                /// --- 4. ОРКЕСТРАЦИЯ (Вызов Фабрик) ---

                // 1. Честное расстояние между теоретическими осями ветвей (Для вычисления ДЛИНЫ листа)
                // ИСПРАВЛЕНИЕ: Берем строго из colData.Bcol, чтобы появление стыков не искажало расстояние
                double distBetweenAxes = colData.Bcol;

                // 2. Строим ветви и получаем габариты, включая толщину стенки
                var branches = BuildBranches(branchLines, colData, planeAngleDeg, out double autoBaseDist, out double branchWidth, out double branchWebThick);

                BuildSplices(branches, colData);
                BuildLacing(lacingLines, splices, colData, localY, autoBaseDist);

                // 3. Передаем branchWebThick в фабрику распорок
                BuildStrutsAndDiaphragms(strutLines, zNodes, splices, colData, localY, autoBaseDist, distBetweenAxes, branchWidth, branchWebThick, branches);
                               
                // 4. Строим надколонник (Альфа 1.5)
                BuildSupColumn(branches, colData, localX, planeAngleDeg, branchWidth, splices);

                // ==========================================
                // ВЫЗОВЫ ОГОЛОВКА (Альфа 1.6.2)
                // ==========================================
                if (colData.Head_Type == 1 || colData.Head_Type == 3)
                {
                    // ОБЯЗАТЕЛЬНО ПЕРЕДАЕМ splices ШЕСТЫМ АРГУМЕНТОМ!
                    BuildSupColumn(branches, colData, localX, planeAngleDeg, branchWidth, splices);
                }

                if (colData.Head_Type == 2 || colData.Head_Type == 3)
                {
                    BuildHeadBeam(p1, colData, localX, planeAngleDeg, colData.Hcol_1);
                }

                return true;
            }
            catch (Exception ex)
            {
                // ...
                System.Windows.MessageBox.Show($"Критическая ошибка построения (Run):\n\n{ex}", "RAM BIM: Ошибка", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return false;
            }
        }

        // =========================================================================
        // ОРКЕСТРАТОРЫ ПОСТРОЕНИЯ (Дирижируют фабриками)
        // =========================================================================

        private List<Beam> BuildBranches(List<LineSegment> branchLines, BuiltUpColumnData colData, double planeAngleDeg, out double autoBaseDist, out double branchWidth, out double branchWebThick)
        {
            autoBaseDist = 0.0;
            branchWidth = 0.0;
            branchWebThick = 0.0; // <--- НОВОЕ
            List<Beam> createdBranches = new List<Beam>();

            foreach (var line in branchLines)
            {
                // Физическое создание (оставляем сумму углов - это верно для глобальной ориентации)
                Beam branch = TeklaPartBuilder.CreateBranch(line.Point1, line.Point2, colData.Branch, planeAngleDeg + colData.Br_Rot);
                if (!branch.Insert()) throw new Exception($"Не удалось построить ветвь: {colData.Branch.Profile}");

                createdBranches.Add(branch);

                if (autoBaseDist == 0.0)
                {
                    // ИСПРАВЛЕНИЕ: Передаем только локальный угол ветви (Br_Rot)
                    Services.TeklaProfileHelper.GetActualDimensions(branch, colData.Br_Rot, out double hAlongY, out double wAlongX, out double twAlongX);
                    autoBaseDist = hAlongY;
                    branchWidth = wAlongX;
                    branchWebThick = twAlongX;
                }
            }
            // ... (дальше без изменений)

            if (autoBaseDist <= 0.0) autoBaseDist = 200.0;
            if (branchWidth <= 0.0) branchWidth = 200.0;
            return createdBranches;
        }

        private void BuildSplices(List<Beam> branches, BuiltUpColumnData colData)
        {
            int branchesPerSide = branches.Count / 2;
            int totalSplices = branchesPerSide - 1;

            // ИСПОЛЬЗУЕМ УМНЫЙ ПАРСЕР ДЛЯ СТЫКОВ (Поддерживает диапазоны N-N)
            // Парсер возвращает 0-based индексы, поэтому дальше будем сверять их прямо с `i`
            var idx2 = StringParserService.ParseNodes(colData.Splice2Indexes, totalSplices);
            var idx3 = StringParserService.ParseNodes(colData.Splice3Indexes, totalSplices);
            var idx4 = StringParserService.ParseNodes(colData.Splice4Indexes, totalSplices);
            var idx5 = StringParserService.ParseNodes(colData.Splice5Indexes, totalSplices);

            for (int i = 0; i < totalSplices; i++)
            {
                string activeComp = colData.Splice1Component;
                string activePreset = colData.Splice1Preset;

                // Каскад переопределений (Используем `i` вместо `currentLevel`)
                if (idx2.Contains(i)) { activeComp = colData.Splice2Component; activePreset = colData.Splice2Preset; }
                if (idx3.Contains(i)) { activeComp = colData.Splice3Component; activePreset = colData.Splice3Preset; }
                if (idx4.Contains(i)) { activeComp = colData.Splice4Component; activePreset = colData.Splice4Preset; }
                if (idx5.Contains(i)) { activeComp = colData.Splice5Component; activePreset = colData.Splice5Preset; }

                if (!string.IsNullOrWhiteSpace(activeComp))
                {
                    TeklaComponentService.InsertConnection(activeComp, activePreset, branches[i], new List<ModelObject> { branches[i + 1] }, null, out _);
                    TeklaComponentService.InsertConnection(activeComp, activePreset, branches[branchesPerSide + i], new List<ModelObject> { branches[branchesPerSide + i + 1] }, null, out _);
                }
            }
        }

        private void BuildLacing(List<LineSegment> lacingLines, List<double> splices, BuiltUpColumnData colData, Vector localY, double autoBaseDist)
        {
            // ПАРСИМ СПИСОК УДАЛЯЕМЫХ РАСКОСОВ (Механика п. 4.4)
            var excludeList = StringParserService.ParseNodes(colData.L_Exclude, lacingLines.Count);

            for (int i = 0; i < lacingLines.Count; i++)
            {
                // ЗАЩИТА: Если раскос в списке на удаление, просто переходим к следующему
                if (excludeList.Contains(i)) continue;

                var line = lacingLines[i];
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
                else // Сдвоенная решетка (Tekla.Extension)
                {
                    Vector shift = localY * (autoBaseDist / 2.0);

                    // Ветвь А
                    Point p1_A = new Point(line.Point1); p1_A.Translate(shift);
                    Point p2_A = new Point(line.Point2); p2_A.Translate(shift);
                    TeklaPartBuilder.CreateLacing(p1_A, p2_A, settings, activePreset, colData.L_Offset).Insert();

                    // Ветвь Б
                    Point p1_B = new Point(line.Point1); p1_B.Translate(shift.Negative());
                    Point p2_B = new Point(line.Point2); p2_B.Translate(shift.Negative());
                    TeklaPartBuilder.CreateLacing(p2_B, p1_B, settings, activePreset, colData.L_Offset).Insert();
                }
            }
        }

        private void BuildStrutsAndDiaphragms(List<LineSegment> strutLines, List<double> zNodes, List<double> splices, BuiltUpColumnData colData, Vector localY, double autoBaseDist, double distBetweenAxes, double branchWidth, double branchWebThick, List<Beam> branches)
        {
            int totalNodes = strutLines.Count;

            // --- 1. ПАРСИНГ И ПОДГОТОВКА ---
            var idxAngle = StringParserService.ParseNodes(colData.S_NodesAngle, totalNodes);
            var idxAnglePlate = StringParserService.ParseNodes(colData.S_NodesAnglePlate, totalNodes);
            var idxD1 = StringParserService.ParseNodes(colData.S_NodesD1, totalNodes);
            var idxD2 = StringParserService.ParseNodes(colData.S_NodesD2, totalNodes);
            var idxExcPlate = StringParserService.ParseNodes(colData.S_NodesExcludePlate, totalNodes);
            var idxExclude = StringParserService.ParseNodes(colData.S_NodesExclude, totalNodes);

            var spliceNodes = ColumnGeometryBuilder.GetSpliceAdjacentNodes(zNodes, splices);
            var keyElevNodes = ColumnGeometryBuilder.GetKeyElevationNodes(colData, zNodes);

            // --- 2. ЦИКЛ ОРКЕСТРАЦИИ СЛОТОВ ---
            for (int i = 0; i < totalNodes; i++)
            {
                int currentLevel = i + 1;
                int slotType = 0;

                // Фоновая заливка
                if (i == 0) slotType = colData.S_Base_Preset;
                else if (i == totalNodes - 1) slotType = colData.S_Top_Preset;
                else if (spliceNodes.Contains(i)) slotType = colData.S_Splice_Preset;
                else if (keyElevNodes.Contains(i)) slotType = colData.S_KeyElev_Preset;
                else slotType = colData.S_Preset;

                // Ручное созидание
                if (idxAngle.Contains(i)) slotType = 1;
                if (idxAnglePlate.Contains(i)) slotType = 2;
                if (idxD1.Contains(i)) slotType = 3;
                if (idxD2.Contains(i)) slotType = 4;

                // Деградация и Аннигиляция
                if (idxExcPlate.Contains(i) && slotType == 2) slotType = 1;
                if (idxExclude.Contains(i)) slotType = 0;

                if (slotType == 0) continue;

                var line = strutLines[i];

                // --- 3. ВЫЗОВЫ СТРОИТЕЛЕЙ (Инкапсуляция) ---
                if (slotType == 1 || slotType == 2)
                {
                    BuildStrutSlot(line, slotType, currentLevel, colData, localY, autoBaseDist, distBetweenAxes, branchWidth, branchWebThick);
                }
                else if (slotType == 3)
                {
                    BuildDiaphragmSlot(line, colData.Diaphragm1, currentLevel, colData.L_Type, colData.L_Preset, colData.L_Offset,
                        colData.D1_PosPlane, colData.D1_PosPlaneOff, colData.D1_PosRot, colData.D1_PosRotOff, colData.D1_PosDepth, colData.D1_PosDepthOff,
                        colData.D1_CutMode, colData.D1_CutComp, colData.D1_CutAttr, branches, distBetweenAxes, branchWidth, branchWebThick);
                }
                else if (slotType == 4)
                {
                    BuildDiaphragmSlot(line, colData.Diaphragm2, currentLevel, colData.L_Type, colData.L_Preset, colData.L_Offset,
                        colData.D2_PosPlane, colData.D2_PosPlaneOff, colData.D2_PosRot, colData.D2_PosRotOff, colData.D2_PosDepth, colData.D2_PosDepthOff,
                        colData.D2_CutMode, colData.D2_CutComp, colData.D2_CutAttr, branches, distBetweenAxes, branchWidth, branchWebThick);
                }
            }
        }

        // ==================================================================================================
        // Вспомогательный метод: Построение Распорки (+ Лист)
        // ==================================================================================================
        private void BuildStrutSlot(LineSegment line, int slotType, int currentLevel, BuiltUpColumnData colData, Vector localY, double autoBaseDist, double distBetweenAxes, double branchWidth, double branchWebThick)
        {
            if (string.IsNullOrWhiteSpace(colData.Strut.Profile))
                throw new Exception($"Узел {currentLevel}: Назначена Распорка, но её 'Профиль' пуст во вкладке Атрибуты!");

            int activePreset = colData.L_Type == 1 ? 1 : colData.L_Preset;
            Beam strutA = null;

            if (colData.L_Type == 0)
            {
                strutA = TeklaPartBuilder.CreateLacing(line.Point1, line.Point2, colData.Strut, activePreset, colData.L_Offset);
                strutA.Insert();
            }
            else
            {
                Vector shift = localY * (autoBaseDist / 2.0);

                Point p1_A = new Point(line.Point1); p1_A.Translate(shift);
                Point p2_A = new Point(line.Point2); p2_A.Translate(shift);
                strutA = TeklaPartBuilder.CreateLacing(p1_A, p2_A, colData.Strut, activePreset, colData.L_Offset);
                strutA.Insert();

                Point p1_B = new Point(line.Point1); p1_B.Translate(shift.Negative());
                Point p2_B = new Point(line.Point2); p2_B.Translate(shift.Negative());
                TeklaPartBuilder.CreateLacing(p2_B, p1_B, colData.Strut, activePreset, colData.L_Offset).Insert();
            }

            // МАТЕМАТИКА ЛИСТА
            if (slotType == 2 && colData.L_Type == 1 && strutA != null)
            {
                double W = autoBaseDist - 2 * colData.L_Offset - (colData.D_GapW * 2);
                if (W < 10) W = 10;

                double t = 10.0;
                string prof = colData.GussetPlate.Profile.ToUpper().Replace("PL", "");
                if (prof.Contains("*") && double.TryParse(prof.Split('*')[0], out double parsedT)) t = parsedT;

                colData.GussetPlate.Profile = $"PL{t}*{Math.Round(W)}";

                double baseClearanceDist = (colData.GP_CutMode == 1) ? branchWebThick : branchWidth;
                double actualClearDist = distBetweenAxes - baseClearanceDist;
                double L = actualClearDist - colData.D_GapL;
                if (L < 10) L = 10;

                Vector dir = PointExtension.GetVector(line.Point1, line.Point2);
                dir.Normalize();

                Point center = new Point(line.Point1);
                center.Translate(dir * (distBetweenAxes / 2.0));

                Point pStart = new Point(center); pStart.Translate(dir * (-L / 2.0));
                Point pEnd = new Point(center); pEnd.Translate(dir * (L / 2.0));

                double angleWidth = 0.0;
                strutA.GetReportProperty("PROFILE.WIDTH", ref angleWidth);
                double zOffset = (angleWidth / 2.0) + (t / 2.0);

                Beam plate = TeklaPartBuilder.CreateGussetPlate(pStart, pEnd, colData.GussetPlate);
                plate.Position.DepthOffset = zOffset;
                plate.Position.Rotation = Tekla.Structures.Model.Position.RotationEnum.BACK;
                plate.Insert();
            }
        }

        // ==================================================================================================
        // Вспомогательный метод: Построение Диафрагмы (+ Внедренный Шаг 2: Позиционирование)
        // ==================================================================================================
        private void BuildDiaphragmSlot(LineSegment line, PartSettings partSettings, int currentLevel, int lType, int lPreset, double lOffset,
            int plane, double planeOff, int rot, double rotOff, int depth, double depthOff,
            int cutMode, string compName, string compAttr, System.Collections.Generic.List<Beam> branches, double distBetweenAxes, double branchWidth, double branchWebThick)
        {
            if (string.IsNullOrWhiteSpace(partSettings.Profile))
                throw new Exception($"Узел {currentLevel}: Назначена Диафрагма, но её 'Профиль' пуст во вкладке Атрибуты!");

            int activePreset = lType == 1 ? 1 : lPreset;
            Beam diaphragm = TeklaPartBuilder.CreateLacing(line.Point1, line.Point2, partSettings, activePreset, lOffset);

            diaphragm.Position.Plane = (Tekla.Structures.Model.Position.PlaneEnum)plane;
            diaphragm.Position.PlaneOffset = planeOff;

            diaphragm.Position.Rotation = (Tekla.Structures.Model.Position.RotationEnum)rot;
            diaphragm.Position.RotationOffset = rotOff;

            diaphragm.Position.Depth = (Tekla.Structures.Model.Position.DepthEnum)depth;
            diaphragm.Position.DepthOffset = depthOff;

            diaphragm.Insert();

            // --- ШАГ 3: SOLID ВЫРЕЗЫ ---
            if (cutMode != 0 && branches != null && branches.Count >= 2)
            {
                Services.ICuttingStrategy strategy = Services.CuttingStrategyFactory.GetStrategy(cutMode, compName, compAttr);

                Point colCenter = new Point(line.Point1);
                Vector dir = PointExtension.GetVector(line.Point1, line.Point2);
                dir.Normalize();
                colCenter.Translate(dir * (distBetweenAxes / 2.0));

                // --- ФИКС БАГА "СТАРТОВОЙ ВЕТВИ" ---
                // Список branches хранит сначала все левые ветви, затем все правые.
                int half = branches.Count / 2;
                Beam targetLeft = branches[0];
                Beam targetRight = branches[half];

                double zLevel = line.Point1.Z;

                // Динамически ищем ветви, которые физически пересекаются с диафрагмой по высоте
                for (int j = 0; j < half; j++)
                {
                    Beam lBranch = branches[j];
                    double minZ = Math.Min(lBranch.StartPoint.Z, lBranch.EndPoint.Z) - 10.0;
                    double maxZ = Math.Max(lBranch.StartPoint.Z, lBranch.EndPoint.Z) + 10.0;
                    if (zLevel >= minZ && zLevel <= maxZ) targetLeft = lBranch;

                    Beam rBranch = branches[half + j];
                    double minZR = Math.Min(rBranch.StartPoint.Z, rBranch.EndPoint.Z) - 10.0;
                    double maxZR = Math.Max(rBranch.StartPoint.Z, rBranch.EndPoint.Z) + 10.0;
                    if (zLevel >= minZR && zLevel <= maxZR) targetRight = rBranch;
                }

                // Теперь передаем в Фабрику строго нужную левую и нужную правую ветвь
                strategy.ApplyCut(diaphragm, targetLeft, colCenter, line.Point1, branchWidth, branchWebThick);
                strategy.ApplyCut(diaphragm, targetRight, colCenter, line.Point2, branchWidth, branchWebThick);
            }
        }

        // ==========================================
        // МЕТОД: ПОСТРОЕНИЕ НАДКОЛОННИКА
        // ==========================================
        private void BuildSupColumn(List<Beam> branches, BuiltUpColumnData colData, Vector localX, double planeAngleDeg, double branchWidth, List<double> splices)
        {
            // 1. ЖЕЛЕЗОБЕТОННАЯ ЗАЩИТА: Строим только если режим 1 (Надколонник) или 3 (Всё)
            if (colData.Head_Type == 0 || colData.Head_Type == 2) return;

            if (branches == null || branches.Count < 2) return;

            if (string.IsNullOrWhiteSpace(colData.SupColumn.Profile))
                throw new Exception("Назначен Надколонник, но его 'Профиль' пуст во вкладке Атрибуты!");

            int half = branches.Count / 2;

            // 2. ИСПРАВЛЕНИЕ ВЫСОТЫ: Берем ВЕРХНИЕ сегменты ветвей (последние в своей подгруппе)
            Beam topLeftBranch = branches[half - 1];
            Beam topRightBranch = branches[branches.Count - 1];

            Point pTopLeft = topLeftBranch.EndPoint.Z > topLeftBranch.StartPoint.Z ? topLeftBranch.EndPoint : topLeftBranch.StartPoint;
            Point pTopRight = topRightBranch.EndPoint.Z > topRightBranch.StartPoint.Z ? topRightBranch.EndPoint : topRightBranch.StartPoint;

            Point pStart = new Point();
            Vector inwardDir = new Vector();

            if (colData.NK_Mode == 0) // Слева
            {
                pStart = new Point(pTopLeft);
                inwardDir = new Vector(localX.X, localX.Y, localX.Z);
            }
            else if (colData.NK_Mode == 1) // Справа
            {
                pStart = new Point(pTopRight);
                inwardDir = new Vector(-localX.X, -localX.Y, -localX.Z);
            }
            else if (colData.NK_Mode == 2) // Центр
            {
                pStart = new Point((pTopLeft.X + pTopRight.X) / 2.0, (pTopLeft.Y + pTopRight.Y) / 2.0, (pTopLeft.Z + pTopRight.Z) / 2.0);
                inwardDir = new Vector(localX.X, localX.Y, localX.Z);
            }

            double length = 0.0;
            if (colData.NK_HeightType == 0) length = colData.NK_Value;
            else if (colData.NK_HeightType == 1) length = (colData.BasePoint1.Z + colData.NK_Value) - pStart.Z;

            if (length <= 0) return;

            Point pEnd = new Point(pStart);
            pEnd.Translate(0, 0, length);

            // --- ФИЛЬТРАЦИЯ СТЫКОВ ВНУТРИ НАДКОЛОННИКА ---
            List<double> nkSplices = new List<double>();
            if (splices != null)
            {
                foreach (double z in splices)
                {
                    if (z > pStart.Z + 1.0 && z < pEnd.Z - 1.0) nkSplices.Add(z);
                }
                nkSplices.Sort();
            }

            Point firstSegEnd = new Point(pStart);
            firstSegEnd.Z = nkSplices.Count > 0 ? nkSplices[0] : pEnd.Z;

            Beam firstNk = TeklaPartBuilder.CreateBranch(pStart, firstSegEnd, colData.SupColumn, planeAngleDeg + colData.NK_Rot);
            if (!firstNk.Insert()) throw new Exception("Не удалось вставить Надколонник.");

            Services.TeklaProfileHelper.GetActualDimensions(firstNk, colData.NK_Rot, out double _, out double nkWidth, out double _);

            double shiftValue = 0.0;
            if (colData.NK_Mode == 0 || colData.NK_Mode == 1)
            {
                shiftValue = (nkWidth / 2.0) - (branchWidth / 2.0);
            }
            shiftValue += colData.NK_Offset;

            if (Math.Abs(shiftValue) > 0.01)
            {
                pStart.Translate(inwardDir.X * shiftValue, inwardDir.Y * shiftValue, inwardDir.Z * shiftValue);
                pEnd.Translate(inwardDir.X * shiftValue, inwardDir.Y * shiftValue, inwardDir.Z * shiftValue);
            }

            List<Beam> nkSegments = new List<Beam>();
            firstNk.StartPoint = new Point(pStart);
            firstNk.EndPoint = new Point(pStart.X, pStart.Y, nkSplices.Count > 0 ? nkSplices[0] : pEnd.Z);
            firstNk.Modify();
            nkSegments.Add(firstNk);

            for (int i = 0; i < nkSplices.Count; i++)
            {
                Point segStart = new Point(pStart.X, pStart.Y, nkSplices[i]);
                Point segEnd = new Point(pStart.X, pStart.Y, (i + 1 < nkSplices.Count) ? nkSplices[i + 1] : pEnd.Z);

                Beam nk = TeklaPartBuilder.CreateBranch(segStart, segEnd, colData.SupColumn, planeAngleDeg + colData.NK_Rot);
                if (!nk.Insert()) throw new Exception("Не удалось вставить сегмент надколонника.");
                nkSegments.Add(nk);
            }

            if (nkSplices.Count > 0 && !string.IsNullOrWhiteSpace(colData.Splice5Component))
            {
                for (int i = 0; i < nkSegments.Count - 1; i++)
                {
                    Services.TeklaComponentService.InsertConnection(
                        colData.Splice5Component, colData.Splice5Preset,
                        nkSegments[i], new List<ModelObject> { nkSegments[i + 1] }, null, out _);
                }
            }
        }
        private void BuildHeadBeam(Point p1, BuiltUpColumnData colData, Vector localX, double planeAngleDeg, double zLevel)
        {
            if (string.IsNullOrWhiteSpace(colData.HeadBeam.Profile))
                throw new Exception("Назначена Балка оголовка, но её 'Профиль' пуст во вкладке Атрибуты!");

            // 1. Формируем осевую линию балки
            Point bStart = new Point(p1.X, p1.Y, p1.Z + zLevel);
            Point bEnd = new Point(bStart);
            bEnd.Translate(localX.X * colData.Bcol, localX.Y * colData.Bcol, localX.Z * colData.Bcol);

            // 2. Применяем вылеты
            if (Math.Abs(colData.HB_OverhangLeft) > 0.01)
                bStart.Translate(localX.X * -colData.HB_OverhangLeft, localX.Y * -colData.HB_OverhangLeft, localX.Z * -colData.HB_OverhangLeft);

            if (Math.Abs(colData.HB_OverhangRight) > 0.01)
                bEnd.Translate(localX.X * colData.HB_OverhangRight, localX.Y * colData.HB_OverhangRight, localX.Z * colData.HB_OverhangRight);

            // 3. Вызываем PartBuilder
            Beam headBeam = TeklaPartBuilder.CreateBranch(bStart, bEnd, colData.HeadBeam, planeAngleDeg);

            // 4. ПЕРЕОПРЕДЕЛЯЕМ ПОЗИЦИОНИРОВАНИЕ ИЗ UI до вставки в модель
            headBeam.Position.Plane = (Tekla.Structures.Model.Position.PlaneEnum)colData.HB_PosPlane;
            headBeam.Position.PlaneOffset = colData.HB_PosPlaneOff;

            // ИСПРАВЛЕНИЕ: Передаем только чистый угол из UI, без planeAngleDeg!
            headBeam.Position.Rotation = (Tekla.Structures.Model.Position.RotationEnum)colData.HB_PosRot;
            headBeam.Position.RotationOffset = colData.HB_PosRotOff;

            headBeam.Position.Depth = (Tekla.Structures.Model.Position.DepthEnum)colData.HB_PosDepth;
            headBeam.Position.DepthOffset = colData.HB_PosDepthOff;

            // 5. ВСТАВЛЯЕМ ДЕТАЛЬ В БАЗУ ДАННЫХ
            if (!headBeam.Insert())
            {
                throw new Exception("Не удалось вставить Балку оголовка в модель.");
            }
        }
    }
}
using System;
using Tekla.Structures.Geometry3d;

namespace Apibim.Tekla.Plugins.BuiltUpColumn.Models
{
    /// <summary>
    /// Класс для хранения всех входных параметров нашей колонны
    /// </summary>
    public class BuiltUpColumnData
    {
        // --- Базовые точки ---
        public Point BasePoint1 { get; set; }
        public Point BasePoint2 { get; set; }

        // --- Высотные отметки и отступы ---
        /// <summary>
        /// Высота ветвей вверх от базовых точек (бывш. Hcol_1)
        /// </summary>
        public double TopExtension { get; set; }

        /// <summary>
        /// Глубина опускания ветвей вниз от базовых точек (бывш. Hcol_e1)
        /// </summary>
        public double BottomExtension { get; set; }

        /// <summary>
        /// Свободная зона ветви снизу до начала решетки (бывш. Hcol_e2)
        /// </summary>
        public double LacingBottomClearance { get; set; }

        /// <summary>
        /// Свободная зона ветви сверху от конца решетки (бывш. Hcol_e3)
        /// </summary>
        public double LacingTopClearance { get; set; }

        // --- Параметры решетки ---
        /// <summary>
        /// Желаемый (базовый) шаг решетки (бывш. Hr_base)
        /// </summary>
        public double TargetLacingStep { get; set; }

        // --- Профили и материалы (задел на будущее) ---
        public string BranchProfile { get; set; } = "I20K1"; // Профиль ветвей по умолчанию
        public string LacingProfile { get; set; } = "L75X6";  // Профиль решетки по умолчанию
        public string Material { get; set; } = "C245";

        /// <summary>
        /// Вспомогательный метод: вычисляет общую доступную высоту для решетки
        /// </summary>
        public double GetLacingZoneLength()
        {
            double totalBranchLength = TopExtension + BottomExtension;
            return totalBranchLength - LacingBottomClearance - LacingTopClearance;
        }
    }
}
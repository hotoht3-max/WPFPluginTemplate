using System;
using Tekla.Structures.Model;

namespace Apibim.Plugins.BuiltUpColumn.Services
{
    public static class TeklaProfileHelper
    {
        /// <summary>
        /// Безопасно извлекает габариты профиля с учетом его поворота в модели.
        /// </summary>
        public static void GetActualDimensions(Part part, double rotation, out double heightAlongY, out double widthAlongX, out double webThicknessAlongX)
        {
            double h = 0.0, w = 0.0, tw = 0.0;
            part.GetReportProperty("PROFILE.HEIGHT", ref h);
            part.GetReportProperty("PROFILE.WIDTH", ref w);
            part.GetReportProperty("PROFILE.WEB_THICKNESS", ref tw);

            // ЗАЩИТА: Если у профиля нет толщины стенки (труба) или она некорректна
            if (tw <= 0) tw = h;

            double rot = Math.Abs(rotation % 180);

            if (rot > 45 && rot < 135) // Например, Br_Rot = 90
            {
                heightAlongY = h; // Разнос решетки = полная высота двутавра
                widthAlongX = w;  // Ширина ветви в плоскости колонны = ширина полки
                webThicknessAlongX = tw; // Толщина стенки тоже повернулась и смотрит вдоль оси X
            }
            else // Например, Br_Rot = 0
            {
                heightAlongY = w; // Разнос решетки = ширина полки
                widthAlongX = h;  // Ширина ветви в плоскости колонны = полная высота двутавра
                webThicknessAlongX = h; // При угле 0 стенка развернута поперек оси X, поэтому габарит по X = полной высоте h
            }
        }
    }
}
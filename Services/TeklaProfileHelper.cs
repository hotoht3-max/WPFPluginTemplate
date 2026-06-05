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

            if (rot > 45 && rot < 135)
            {
                heightAlongY = w; // Разнос ветвей
                widthAlongX = h;  // Габарит вдоль распорки
                webThicknessAlongX = h; // Если ветвь повернута боком, мы упираемся в ширину полок. Стенка недоступна = Габарит.
            }
            else
            {
                heightAlongY = h;
                widthAlongX = w;
                webThicknessAlongX = tw; // Честная толщина стенки для двутавра
            }
        }
    }
}
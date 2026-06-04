using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Apibim.Plugins.BuiltUpColumn.Models;

namespace Apibim.Plugins.BuiltUpColumn.Services
{
    /// <summary>
    /// Фабрика для создания деталей Tekla Structures.
    /// Изолирует логику позиционирования и применения атрибутов от основного алгоритма.
    /// </summary>
    public static class TeklaPartBuilder
    {
        /// <summary>
        /// Универсальный инъектор настроек (профиль, материал, префиксы и т.д.)
        /// </summary>
        public static void ApplySettings(Part part, PartSettings settings)
        {
            if (settings == null) return;

            part.Profile.ProfileString = settings.Profile;
            part.Material.MaterialString = settings.Material;
            part.Class = settings.Class;
            part.Name = settings.Name;

            part.PartNumber.Prefix = settings.PartPrefix;
            part.PartNumber.StartNumber = settings.PartStartNo;

            part.AssemblyNumber.Prefix = settings.AssemblyPrefix;
            part.AssemblyNumber.StartNumber = settings.AssemblyStartNo;

            // Задел под Шаг "Внедрение UDA" (пока просто оставляем комментарий)
            // if (!string.IsNullOrWhiteSpace(settings.UDA)) { ... }
        }

        /// <summary>
        /// Фабрика Ветви (Колонны)
        /// </summary>
        public static Beam CreateBranch(Point p1, Point p2, PartSettings settings, double rotationAngle)
        {
            Beam beam = new Beam(p1, p2);
            ApplySettings(beam, settings);

            beam.Position.Plane = Position.PlaneEnum.MIDDLE;
            beam.Position.Depth = Position.DepthEnum.MIDDLE;
            beam.Position.Rotation = Position.RotationEnum.TOP;
            beam.Position.RotationOffset = rotationAngle;

            return beam;
        }

        /// <summary>
        /// Фабрика Раскоса (Рядового и Стыкового) и Распорок из уголков
        /// </summary>
        public static Beam CreateLacing(Point p1, Point p2, PartSettings settings, int presetType, double offset)
        {
            Beam beam = new Beam(p1, p2);
            ApplySettings(beam, settings);

            beam.Position.PlaneOffset = 0.0;
            beam.Position.DepthOffset = 0.0;

            switch (presetType)
            {
                case 1: // Полка по оси
                    beam.Position.Plane = Position.PlaneEnum.MIDDLE;
                    beam.Position.Depth = Position.DepthEnum.FRONT;
                    beam.Position.Rotation = Position.RotationEnum.TOP;
                    beam.Position.RotationOffset = 90.0;
                    beam.Position.DepthOffset = offset;
                    break;
                case 2: // Уголок по обушку
                    beam.Position.Plane = Position.PlaneEnum.LEFT;
                    beam.Position.Depth = Position.DepthEnum.MIDDLE;
                    beam.Position.Rotation = Position.RotationEnum.FRONT;
                    beam.Position.RotationOffset = 0.0;
                    beam.Position.PlaneOffset = offset;
                    break;
                case 3: // Труба (по центру)
                    beam.Position.Plane = Position.PlaneEnum.MIDDLE;
                    beam.Position.Depth = Position.DepthEnum.MIDDLE;
                    beam.Position.Rotation = Position.RotationEnum.FRONT;
                    beam.Position.RotationOffset = 0.0;
                    beam.Position.PlaneOffset = offset;
                    break;
            }
            return beam;
        }

        /// <summary>
        /// Фабрика Диафрагмы (Применяется для Тип 1 и Тип 2)
        /// </summary>
        public static Beam CreateDiaphragm(Point p1, Point p2, PartSettings settings)
        {
            Beam beam = new Beam(p1, p2);
            ApplySettings(beam, settings);

            beam.Position.Plane = Position.PlaneEnum.MIDDLE;
            beam.Position.Depth = Position.DepthEnum.BEHIND;
            beam.Position.Rotation = Position.RotationEnum.BACK;

            beam.Position.PlaneOffset = 0.0;
            beam.Position.DepthOffset = 0.0;
            beam.Position.RotationOffset = 0.0;

            return beam;
        }

        /// <summary>
        /// Фабрика Листа-надстройки
        /// </summary>
        public static Beam CreateGussetPlate(Point p1, Point p2, PartSettings settings)
        {
            Beam beam = new Beam(p1, p2);
            ApplySettings(beam, settings);

            // Ставим пластину строго по центру между ветвями
            beam.Position.Plane = Position.PlaneEnum.MIDDLE;
            beam.Position.Depth = Position.DepthEnum.MIDDLE;
            beam.Position.Rotation = Position.RotationEnum.TOP;

            return beam;
        }
    }
}
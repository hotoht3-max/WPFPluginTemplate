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
        public static Beam CreateLacing(Point p1, Point p2, PartSettings settings, int lType, int preset, double offset)
        {
            Beam beam = new Beam(p1, p2);
            beam.Profile.ProfileString = settings.Profile;
            beam.Material.MaterialString = settings.Material;

            beam.PartNumber.Prefix = settings.PartPrefix;
            beam.PartNumber.StartNumber = settings.PartStartNo;
            beam.AssemblyNumber.Prefix = settings.AssemblyPrefix;
            beam.AssemblyNumber.StartNumber = settings.AssemblyStartNo;

            beam.Name = settings.Name;
            beam.Class = settings.Class;

            // --- АЛЬФА 2.01: ЖЕСТКИЕ ПРЕСЕТЫ ПОЗИЦИОНИРОВАНИЯ ---
            if (lType == 0) // 0 - Одинарная решетка
            {
                switch (preset)
                {
                    case 2: // Полка по оси (Бывший 3-й пресет)
                        beam.Position.Plane = Position.PlaneEnum.RIGHT;
                        beam.Position.Depth = Position.DepthEnum.MIDDLE;
                        beam.Position.Rotation = Position.RotationEnum.BACK; // Заменили TOP на BACK
                        break;
                    case 3: // Труба по центру (Бывший 2-й пресет)
                        beam.Position.Plane = Position.PlaneEnum.MIDDLE;
                        beam.Position.Depth = Position.DepthEnum.MIDDLE;
                        beam.Position.Rotation = Position.RotationEnum.BELOW;
                        break;
                    case 1: // Уголок по обушку (Остался правильным)
                    default:
                        beam.Position.Plane = Position.PlaneEnum.LEFT;
                        beam.Position.Depth = Position.DepthEnum.MIDDLE;
                        beam.Position.Rotation = Position.RotationEnum.BELOW;
                        break;
                }
            }
            else // 1 - Сдвоенная решетка
            {
                switch (preset)
                {
                    case 2:
                        beam.Position.Plane = Position.PlaneEnum.RIGHT;
                        beam.Position.Depth = Position.DepthEnum.MIDDLE;
                        beam.Position.Rotation = Position.RotationEnum.BACK;
                        break;
                    case 3:
                        beam.Position.Plane = Position.PlaneEnum.LEFT;
                        beam.Position.Depth = Position.DepthEnum.MIDDLE;
                        beam.Position.Rotation = Position.RotationEnum.FRONT;
                        break;
                    case 4:
                        beam.Position.Plane = Position.PlaneEnum.LEFT;
                        beam.Position.Depth = Position.DepthEnum.MIDDLE;
                        beam.Position.Rotation = Position.RotationEnum.BELOW;
                        break;
                    case 1: // По умолчанию
                    default:
                        beam.Position.Plane = Position.PlaneEnum.RIGHT;
                        beam.Position.Depth = Position.DepthEnum.MIDDLE;
                        beam.Position.Rotation = Position.RotationEnum.TOP;
                        break;
                }
            }

            // ЖЕСТКАЯ ПРИВЯЗКА СМЕЩЕНИЯ К ПЛОСКОСТИ (Всё уходит в PlaneOffset)
            beam.Position.PlaneOffset = offset;
            beam.Position.DepthOffset = 0.0;
            beam.Position.RotationOffset = 0.0;

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
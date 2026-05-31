using System;
using System.Collections.Generic;
using Tekla.Structures.Geometry3d;
using Apibim.Tekla.Plugins.BuiltUpColumn.Models;
using Tekla.Extension; // Подключаем наши расширения (в частности VectorExtension и методы Point)

namespace Apibim.Tekla.Plugins.BuiltUpColumn.Services
{
    /// <summary>
    /// Сервис для генерации чистой геометрии (отрезков) на основе входных данных
    /// </summary>
    public static class ColumnGeometryBuilder
    {
        /// <summary>
        /// Возвращает два отрезка, представляющих центральные оси ветвей
        /// </summary>
        public static List<LineSegment> GetBranchLines(BuiltUpColumnData data)
        {
            List<LineSegment> lines = new List<LineSegment>();

            // Используем Z-вектор из расширений для направления вверх
            Vector upVector = VectorExtension.Z;

            // --- Ветвь 1 ---
            Point p1Start = new Point(data.BasePoint1);
            p1Start.Translate(upVector * -data.BottomExtension); // Опускаем вниз

            Point p1End = new Point(data.BasePoint1);
            p1End.Translate(upVector * data.TopExtension);       // Поднимаем вверх

            lines.Add(new LineSegment(p1Start, p1End));

            // --- Ветвь 2 ---
            Point p2Start = new Point(data.BasePoint2);
            p2Start.Translate(upVector * -data.BottomExtension);

            Point p2End = new Point(data.BasePoint2);
            p2End.Translate(upVector * data.TopExtension);

            lines.Add(new LineSegment(p2Start, p2End));

            return lines;
        }

        /// <summary>
        /// Возвращает список отрезков, представляющих оси решетки (зигзаг)
        /// </summary>
        public static List<LineSegment> GetLacingLines(BuiltUpColumnData data)
        {
            List<LineSegment> lines = new List<LineSegment>();

            double zoneLength = data.GetLacingZoneLength();
            if (zoneLength <= 0)
                return lines; // Защита от дурака: если отступы съели всю колонну, решетку не строим

            // --- Реализация Эквидистантного шага ---
            // Делим длину зоны на желаемый шаг, округляем до целого числа панелей
            int panelsCount = (int)Math.Round(zoneLength / data.TargetLacingStep);
            if (panelsCount < 1) panelsCount = 1; // Минимум 1 панель

            // Вычисляем фактический идеальный шаг
            double actualStep = zoneLength / panelsCount;

            Vector upVector = VectorExtension.Z;

            // Вычисляем стартовые точки решетки (нижние узлы)
            Point startLeft = new Point(data.BasePoint1);
            startLeft.Translate(upVector * (-data.BottomExtension + data.LacingBottomClearance));

            Point startRight = new Point(data.BasePoint2);
            startRight.Translate(upVector * (-data.BottomExtension + data.LacingBottomClearance));

            // --- Генерация зигзага ---
            bool toggleToRight = true; // Направление текущего раскоса: true = слева направо
            Point currentPoint = startLeft;

            for (int i = 1; i <= panelsCount; i++)
            {
                // Выбираем, на какой ветви будет следующий узел
                Point nextPoint = toggleToRight ? new Point(startRight) : new Point(startLeft);

                // Поднимаем точку на нужную высоту текущего шага
                nextPoint.Translate(upVector * (actualStep * i));

                // Создаем ось раскоса
                lines.Add(new LineSegment(currentPoint, nextPoint));

                // Переходим к следующему шагу
                currentPoint = nextPoint;
                toggleToRight = !toggleToRight; // Меняем направление зигзага
            }

            return lines;
        }
    }
}
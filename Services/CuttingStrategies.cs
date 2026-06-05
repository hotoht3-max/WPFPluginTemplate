using Tekla.Extension;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace Apibim.Plugins.BuiltUpColumn.Services
{
    // ============================================================================
    // БАЗОВЫЙ КЛАСС
    // ============================================================================
    public abstract class CutStrategyBase : ICuttingStrategy
    {
        public abstract void ApplyCut(Beam diaphragm, Beam branch, Point colCenter, Point branchAxisPoint, double branchWidth, double branchWebThick);

        protected void CreateFitting(Beam diaphragm, Point origin, Vector normalTowardsCenter)
        {
            Fitting fitting = new Fitting();
            fitting.Plane = new Plane();
            fitting.Plane.Origin = origin;

            double planeVisualSize = 1000.0;
            Vector axisX = new Vector(-normalTowardsCenter.Y, normalTowardsCenter.X, 0);
            axisX.Normalize();
            fitting.Plane.AxisX = axisX * planeVisualSize;

            Vector axisY = new Vector(0, 0, 1);
            axisY.Normalize();
            fitting.Plane.AxisY = axisY * planeVisualSize;

            fitting.Father = diaphragm;
            fitting.Insert();
        }
    }

    // РЕЖИМ 0: Нет подрезок
    public class NoCutStrategy : CutStrategyBase
    {
        public override void ApplyCut(Beam diaphragm, Beam branch, Point colCenter, Point branchAxisPoint, double branchWidth, double branchWebThick) { }
    }

    // РЕЖИМ 2: Габарит (Вырез по внутренним полкам)
    public class BoundingBoxCutStrategy : CutStrategyBase
    {
        public override void ApplyCut(Beam diaphragm, Beam branch, Point colCenter, Point branchAxisPoint, double branchWidth, double branchWebThick)
        {
            Vector dirToBranch = PointExtension.GetVector(colCenter, branchAxisPoint);
            dirToBranch.Normalize();

            Point planePoint = new Point(branchAxisPoint);
            planePoint.Translate(dirToBranch * (-branchWidth / 2.0));

            CreateFitting(diaphragm, planePoint, dirToBranch);
        }
    }

    // ============================================================================
    // РЕЖИМ 1: КОМПОНЕНТ (Используем бронебойный TeklaComponentService)
    // ============================================================================
    public class ComponentCutStrategy : CutStrategyBase
    {
        private string _compName;
        private string _compAttr;

        public ComponentCutStrategy(string compName, string compAttr)
        {
            _compName = compName;
            _compAttr = compAttr;
        }

        public override void ApplyCut(Beam diaphragm, Beam branch, Point colCenter, Point branchAxisPoint, double branchWidth, double branchWebThick)
        {
            // Упаковываем диафрагму в список, так как сервис принимает List<ModelObject>
            var secondaries = new System.Collections.Generic.List<ModelObject> { diaphragm };

            // Вектор UpVector передаем как null, системный компонент 123 сам прекрасно поймет ориентацию
            bool success = TeklaComponentService.InsertConnection(
                _compName,
                _compAttr,
                branch,
                secondaries,
                null,
                out string errorMessage
            );

            // Если вдруг юзер введет кривое имя компонента, мы это хотя бы не проглотим молча
            if (!success)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка вставки подрезки ({_compName}): {errorMessage}");
            }
        }
    }

    // ============================================================================
    // ФАБРИКА СТРАТЕГИЙ
    // ============================================================================
    public static class CuttingStrategyFactory
    {
        public static ICuttingStrategy GetStrategy(int cutMode, string compName, string compAttr)
        {
            switch (cutMode)
            {
                case 1: return new ComponentCutStrategy(compName, compAttr);
                case 2: return new BoundingBoxCutStrategy();
                case 0:
                default: return new NoCutStrategy();
            }
        }
    }
}
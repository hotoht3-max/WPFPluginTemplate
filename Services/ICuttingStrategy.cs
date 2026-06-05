using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace Apibim.Plugins.BuiltUpColumn.Services
{
    public interface ICuttingStrategy
    {
        void ApplyCut(Beam diaphragm, Beam branch, Point colCenter, Point branchAxisPoint, double branchWidth, double branchWebThick);
    }
}
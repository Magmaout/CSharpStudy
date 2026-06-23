using CSharpStudy.C_urok_06.interfaces;

namespace CSharpStudy.C_urok_06.figure {
    internal class CompositeFigure {
        List<ISimplePolygon> polygons = new List<ISimplePolygon>();
        public void Add(ISimplePolygon polygon) => polygons.Add(polygon);
        public double GetArea() => polygons.Sum(x => x.Area);
    }
}

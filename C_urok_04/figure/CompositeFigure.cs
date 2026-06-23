namespace CSharpStudy.C_urok_04.figure {
    internal class CompositeFigure {
        List<GeometryFigure> figures = new List<GeometryFigure>();

        public void Add(GeometryFigure figure) => figures.Add(figure);
        public double GetArea() => figures.Sum(x => x.GetArea());
    }
}

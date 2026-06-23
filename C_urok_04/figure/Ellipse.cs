namespace CSharpStudy.C_urok_04.figure {
    internal class Ellipse : GeometryFigure {
        double radiusA, radiusB;

        public Ellipse(double radiusA, double radiusB) {
            this.radiusA = radiusA;
            this.radiusB = radiusB;
        }
        public override double GetArea() => Math.PI * radiusA * radiusB;
        public override double GetPerimeter() => Math.PI * (3 * (radiusA + radiusB) - Math.Sqrt((3 * radiusA + radiusB) * (radiusA + 3 * radiusB)));
    }
}

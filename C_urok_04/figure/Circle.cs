namespace CSharpStudy.C_urok_04.figure {
    internal class Circle : GeometryFigure {
        double radius;

        public Circle(double radius) { this.radius = radius; }
        public override double GetArea() => Math.PI * radius * radius;
        public override double GetPerimeter() => 2 * Math.PI * radius;
    }
}

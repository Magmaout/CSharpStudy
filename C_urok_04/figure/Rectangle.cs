namespace CSharpStudy.C_urok_04.figure {
    internal class Rectangle : GeometryFigure {
        double a, b;

        public Rectangle(double a, double b) {
            this.a = a;
            this.b = b;
        }
        public override double GetArea() => a * b;
        public override double GetPerimeter() => 2 * (a + b);
    }
}

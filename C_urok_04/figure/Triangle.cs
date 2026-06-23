namespace CSharpStudy.C_urok_04.figure {
    internal class Triangle : GeometryFigure {
        double a, b, c;

        public Triangle(double a, double b, double c) {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override double GetArea() {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public override double GetPerimeter() => a + b + c;
    }
}

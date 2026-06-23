namespace CSharpStudy.C_urok_04.figure {
    internal class Parallelogram : GeometryFigure {
        double sideA, sideB, height;

        public Parallelogram(double sideA, double sideB, double height) {
            this.sideA = sideA;
            this.sideB = sideB;
            this.height = height;
        }
        public override double GetArea() => sideA * height;
        public override double GetPerimeter() => 2 * (sideA + sideB);
    }
}

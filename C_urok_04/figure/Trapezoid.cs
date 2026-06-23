namespace CSharpStudy.C_urok_04.figure {
    internal class Trapezoid : GeometryFigure {
        double baseA, baseB, height, sideC, sideD;

        public Trapezoid(double baseA, double baseB, double height, double sideC, double sideD) {
            this.baseA = baseA;
            this.baseB = baseB;
            this.height = height;
            this.sideC = sideC;
            this.sideD = sideD;
        }
        public override double GetArea() => (baseA + baseB) / 2 * height;
        public override double GetPerimeter() => baseA + baseB + sideC + sideD;
    }
}

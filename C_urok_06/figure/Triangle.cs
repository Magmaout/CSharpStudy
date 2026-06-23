using CSharpStudy.C_urok_06.interfaces;

namespace CSharpStudy.C_urok_06.figure {
    internal class Triangle : Figure, ISimplePolygon {
        double a, b, c;
        public double Height => 0;
        public double BaseSide => a;
        public double Angle => 0;
        public int SidesCount => 3;
        public double[] SideLengths => new double[] { a, b, c };
        public Triangle(double a, double b, double c) {
            if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a) throw new Exception("Нельзя создать треугольник!");
            this.a = a; this.b = b; this.c = c; Perimeter = a + b + c;
            double p = Perimeter / 2;
            Area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}

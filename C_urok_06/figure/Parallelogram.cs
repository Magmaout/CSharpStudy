using CSharpStudy.C_urok_06.interfaces;

namespace CSharpStudy.C_urok_06.figure {
    internal class Parallelogram : Figure, ISimplePolygon {
        double sideA, sideB, height;
        public double Height => height;
        public double BaseSide => sideA;
        public double Angle => 0;
        public int SidesCount => 4;
        public double[] SideLengths => new double[] { sideA, sideB, sideA, sideB };
        public Parallelogram(double sideA, double sideB, double height) {
            if (sideA <= 0 || sideB <= 0 || height <= 0) throw new Exception("Нельзя создать параллелограмм!");
            this.sideA = sideA; this.sideB = sideB; this.height = height; Area = sideA * height; Perimeter = 2 * (sideA + sideB);
        }
    }
}

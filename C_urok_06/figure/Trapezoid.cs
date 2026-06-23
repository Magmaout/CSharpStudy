using CSharpStudy.C_urok_06.interfaces;

namespace CSharpStudy.C_urok_06.figure {
    internal class Trapezoid : Figure, ISimplePolygon {
        double baseA, baseB, height, sideC, sideD;
        public double Height => height;
        public double BaseSide => baseA;
        public double Angle => 0;
        public int SidesCount => 4;
        public double[] SideLengths => new double[] { baseA, baseB, sideC, sideD };
        public Trapezoid(double baseA, double baseB, double height, double sideC, double sideD) {
            if (baseA <= 0 || baseB <= 0 || height <= 0 || sideC <= 0 || sideD <= 0) throw new Exception("Нельзя создать трапецию!");
            this.baseA = baseA; this.baseB = baseB; this.height = height; this.sideC = sideC; this.sideD = sideD;
            Area = (baseA + baseB) / 2 * height; Perimeter = baseA + baseB + sideC + sideD;
        }
    }
}

using CSharpStudy.C_urok_06.interfaces;

namespace CSharpStudy.C_urok_06.figure {
    internal class Rhombus : Figure, ISimplePolygon {
        double side, height;
        public double Height => height;
        public double BaseSide => side;
        public double Angle => 0;
        public int SidesCount => 4;
        public double[] SideLengths => new double[] { side, side, side, side };
        public Rhombus(double side, double height) {
            if (side <= 0 || height <= 0) throw new Exception("Нельзя создать ромб!");
            this.side = side; this.height = height; Area = side * height; Perimeter = side * 4;
        }
    }
}

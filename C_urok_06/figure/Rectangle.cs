using CSharpStudy.C_urok_06.interfaces;

namespace CSharpStudy.C_urok_06.figure {
    internal class Rectangle : Figure, ISimplePolygon {
        double width, height;
        public double Height => height;
        public double BaseSide => width;
        public double Angle => 90;
        public int SidesCount => 4;
        public double[] SideLengths => new double[] { width, height, width, height };
        public Rectangle(double width, double height) {
            if (width <= 0 || height <= 0) throw new Exception("Нельзя создать прямоугольник!");
            this.width = width; this.height = height; Area = width * height; Perimeter = 2 * (width + height);
        }
    }
}

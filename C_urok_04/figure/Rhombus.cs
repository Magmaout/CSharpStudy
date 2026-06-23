namespace CSharpStudy.C_urok_04.figure {
    internal class Rhombus : GeometryFigure {
        double side, height;

        public Rhombus(double side, double height) {
            this.side = side;
            this.height = height;
        }
        public override double GetArea() => side * height;
        public override double GetPerimeter() => side * 4;
    }
}

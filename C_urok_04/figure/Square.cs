namespace CSharpStudy.C_urok_04.figure {
    internal class Square : GeometryFigure {
        double side;

        public Square(double side) { this.side = side; }
        public override double GetArea() => side * side;
        public override double GetPerimeter() => side * 4;
    }
}

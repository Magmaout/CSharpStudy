namespace CSharpStudy.C_urok_06.shapes {
    internal class DrawTrapezoid : ConsoleShape {
        int height;
        public DrawTrapezoid(int x, int y, int height, ConsoleColor color) : base(x, y, color) { this.height = height; }
        public override void Draw() {
            for (int i = 0; i < height; i++) WriteAt(x + height - i, y + i, new string('*', height + i * 2));
        }
    }
}

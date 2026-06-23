namespace CSharpStudy.C_urok_06.shapes {
    internal class DrawRectangle : ConsoleShape {
        int width, height;
        public DrawRectangle(int x, int y, int width, int height, ConsoleColor color) : base(x, y, color) { this.width = width; this.height = height; }
        public override void Draw() {
            for (int i = 0; i < height; i++) WriteAt(x, y + i, new string('*', width));
        }
    }
}

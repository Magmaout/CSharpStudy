namespace CSharpStudy.C_urok_06.shapes {
    internal class DrawPolygon : ConsoleShape {
        int size;
        public DrawPolygon(int x, int y, int size, ConsoleColor color) : base(x, y, color) { this.size = size; }
        public override void Draw() {
            WriteAt(x + 1, y, new string('*', size));
            for (int i = 1; i < size; i++) WriteAt(x, y + i, "*" + new string(' ', size) + "*");
            WriteAt(x + 1, y + size, new string('*', size));
        }
    }
}

namespace CSharpStudy.C_urok_06.shapes {
    internal class DrawRhombus : ConsoleShape {
        int size;
        public DrawRhombus(int x, int y, int size, ConsoleColor color) : base(x, y, color) { this.size = size; }
        public override void Draw() {
            for (int i = 0; i < size; i++) WriteAt(x + size - i, y + i, new string('*', i * 2 + 1));
            for (int i = size - 2; i >= 0; i--) WriteAt(x + size - i, y + (size * 2 - i - 2), new string('*', i * 2 + 1));
        }
    }
}

namespace CSharpStudy.C_urok_06.shapes {
    internal class DrawTriangle : ConsoleShape {
        int size;
        public DrawTriangle(int x, int y, int size, ConsoleColor color) : base(x, y, color) { this.size = size; }
        public override void Draw() {
            for (int i = 1; i <= size; i++) WriteAt(x, y + i, new string('*', i));
        }
    }
}

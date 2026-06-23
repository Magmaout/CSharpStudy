namespace CSharpStudy.C_urok_06.shapes {
    internal abstract class ConsoleShape {
        protected int x, y; protected ConsoleColor color;
        public int OffsetY { get; set; }
        protected ConsoleShape(int x, int y, ConsoleColor color) { this.x = x; this.y = y; this.color = color; }
        public abstract void Draw();
        protected void WriteAt(int left, int top, string text) {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            if (Console.IsOutputRedirected) {
                Console.WriteLine(text);
            }
            else {
                Console.SetCursorPosition(left, top + OffsetY);
                Console.Write(text);
            }
            Console.ForegroundColor = old;
        }
    }
}

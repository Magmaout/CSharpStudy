using System.Collections;

namespace CSharpStudy.C_urok_06.shapes {
    internal class ShapeCollection : IEnumerable<ConsoleShape> {
        List<ConsoleShape> shapes = new List<ConsoleShape>();
        public void Add(ConsoleShape shape) => shapes.Add(shape);
        public void ShowAll() {
            int offset = Console.IsOutputRedirected ? 0 : Console.CursorTop;
            foreach (ConsoleShape shape in this) {
                shape.OffsetY = offset;
                shape.Draw();
            }
            if (!Console.IsOutputRedirected) Console.SetCursorPosition(0, offset + 10);
        }
        public IEnumerator<ConsoleShape> GetEnumerator() => shapes.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

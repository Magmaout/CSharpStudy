using CSharpStudy.C_urok_06.interfaces;

namespace CSharpStudy.C_urok_06.converter {
    internal class CelsiusToFahrenheit : IConverter {
        public string FromScale { get; set; } = "Цельсий";
        public string ToScale { get; set; } = "Фаренгейт";
        public double Convert(double value) => 1.8 * value + 32;
        public void Print() => Console.WriteLine(FromScale + " -> " + ToScale);
    }
}

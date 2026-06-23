using CSharpStudy.C_urok_06.interfaces;

namespace CSharpStudy.C_urok_06.converter {
    internal class CelsiusToKelvin : IConverter {
        public string FromScale { get; set; } = "Цельсий";
        public string ToScale { get; set; } = "Кельвин";
        public double Convert(double value) => 273.15 + value;
        public void Print() => Console.WriteLine(FromScale + " -> " + ToScale);
    }
}

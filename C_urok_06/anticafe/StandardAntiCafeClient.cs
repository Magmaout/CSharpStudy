using CSharpStudy.C_urok_06.interfaces;

namespace CSharpStudy.C_urok_06.anticafe {
    internal class StandardAntiCafeClient : AntiCafeClient {
        static double hourCost = 100;
        public string FullName { get; set; }
        public int Hours { get; set; }
        public StandardAntiCafeClient(string fullName, int hours) { FullName = fullName; Hours = hours; }
        public double TotalCost() => Hours * hourCost;
        public void Print() => Console.WriteLine(FullName + ", часов: " + Hours + ", стоимость: " + TotalCost());
    }
}

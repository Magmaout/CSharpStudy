using CSharpStudy.C_urok_06.interfaces;

namespace CSharpStudy.C_urok_06.anticafe {
    internal class VipAntiCafeClient : AntiCafeClient {
        static double hourCost = 150;
        public string FullName { get; set; }
        public int Hours { get; set; }
        public VipAntiCafeClient(string fullName, int hours) { FullName = fullName; Hours = hours; }
        public double TotalCost() => Hours * hourCost * 1.05;
        public void Print() => Console.WriteLine(FullName + ", часов: " + Hours + ", стоимость: " + TotalCost());
    }
}

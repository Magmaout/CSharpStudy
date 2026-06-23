using CSharpStudy.C_urok_06.interfaces;

namespace CSharpStudy.C_urok_06.salary {
    internal class Manager : ISalary, IConsolePrint {
        public string FullName { get; set; }
        public int WorkDays { get; set; }
        public Manager(string fullName, int workDays) { FullName = fullName; WorkDays = workDays; }
        public double CalculateSalary() => WorkDays * 1000;
        public void Print() => Console.WriteLine(FullName + ", дней: " + WorkDays + ", зарплата: " + CalculateSalary());
    }
}

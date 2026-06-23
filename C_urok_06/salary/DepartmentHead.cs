using CSharpStudy.C_urok_06.interfaces;

namespace CSharpStudy.C_urok_06.salary {
    internal class DepartmentHead : ISalary, IConsolePrint {
        public string FullName { get; set; }
        public int WorkDays { get; set; }
        public DepartmentHead(string fullName, int workDays) { FullName = fullName; WorkDays = workDays; }
        public double CalculateSalary() => WorkDays * 2500;
        public void Print() => Console.WriteLine(FullName + ", дней: " + WorkDays + ", зарплата: " + CalculateSalary());
    }
}

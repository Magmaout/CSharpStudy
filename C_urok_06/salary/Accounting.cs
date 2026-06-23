using CSharpStudy.C_urok_06.interfaces;

namespace CSharpStudy.C_urok_06.salary {
    internal class Accounting {
        public double GetTax(ISalary salary) => salary.CalculateSalary() * 0.13;
    }
}

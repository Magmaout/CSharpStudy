namespace CSharpStudy.C_urok_06.interfaces {
    internal interface ISalary {
        string FullName { get; set; }
        int WorkDays { get; set; }
        double CalculateSalary();
    }
}

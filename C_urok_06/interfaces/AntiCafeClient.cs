namespace CSharpStudy.C_urok_06.interfaces {
    internal interface AntiCafeClient : IConsolePrint {
        string FullName { get; set; }
        int Hours { get; set; }
        double TotalCost();
    }
}

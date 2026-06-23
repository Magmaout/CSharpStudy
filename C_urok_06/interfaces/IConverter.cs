namespace CSharpStudy.C_urok_06.interfaces {
    internal interface IConverter : IConsolePrint {
        string FromScale { get; set; }
        string ToScale { get; set; }
        double Convert(double value);
    }
}

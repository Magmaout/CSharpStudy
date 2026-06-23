namespace CSharpStudy.C_urok_06.interfaces {
    internal interface ISimplePolygon {
        double Height { get; }
        double BaseSide { get; }
        double Angle { get; }
        int SidesCount { get; }
        double[] SideLengths { get; }
        double Area { get; }
        double Perimeter { get; }
    }
}

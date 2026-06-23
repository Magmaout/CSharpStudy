namespace CSharpStudy.C_urok_04.transport {
    internal class Trolleybus : Transport {
        double battery;

        public Trolleybus(int number, int capacity, int speed, double battery) : base(number, capacity, speed) { this.battery = battery; }
        public double GetDistance() => battery / 200 * 70;
    }
}

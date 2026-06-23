namespace CSharpStudy.C_urok_04.transport {
    internal class Bus : Transport {
        double tank;

        public Bus(int number, int capacity, int speed, double tank) : base(number, capacity, speed) { this.tank = tank; }
        public double GetDistance() => tank / 20 * 25;
    }
}

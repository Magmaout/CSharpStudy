namespace CSharpStudy.C_urok_04.transport {
    internal class Transport {
        int number, capacity, speed;

        public Transport(int number, int capacity, int speed) {
            this.number = number;
            this.capacity = capacity;
            this.speed = speed;
        }
        public virtual string GetInfo() => "Транспорт №" + number + ", вместимость: " + capacity + ", скорость: " + speed;
    }
}

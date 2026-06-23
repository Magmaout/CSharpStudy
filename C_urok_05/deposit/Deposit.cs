namespace CSharpStudy.C_urok_05.deposit {
    internal class Deposit {
        static double percent = 5;

        string fullName;
        double sum;

        public Deposit(string fullName, double sum) {
            this.fullName = fullName;
            this.sum = sum;
        }
        public static Deposit operator ++(Deposit deposit) { deposit.sum += deposit.sum * percent / 100; return deposit; }
        public static double GetPercent() => percent;
        public string Info() => fullName + ", вклад: " + Math.Round(sum, 2);
    }
}

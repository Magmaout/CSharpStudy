namespace CSharpStudy.C_urok_05.deposit {
    internal class Credit {
        static double percent = 12;

        string fullName;
        double sum;

        public Credit(string fullName, double sum) {
            this.fullName = fullName;
            this.sum = sum;
        }
        public static Credit operator -(Credit credit, double payment) { credit.sum -= payment; return credit; }
        public static double GetPercent() => percent;
        public string Info() => fullName + ", остаток кредита: " + Math.Round(sum, 2);
    }
}

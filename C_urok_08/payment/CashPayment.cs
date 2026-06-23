namespace CSharpStudy.C_urok_08.payment {
    internal struct CashPayment : IPayment {
        public double Change;
        public double PaymentSum { get; set; }
        public CashPayment(double change, double paymentSum) {
            Change = change; PaymentSum = paymentSum;
        }
        public string GetInfo() => "Наличный расчет, сумма: " + PaymentSum + ", сдача: " + Change;
    }
}

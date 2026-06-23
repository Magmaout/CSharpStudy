namespace CSharpStudy.C_urok_08.payment {
    internal struct CardPayment : IPayment {
        public string CardNumber;
        public DateTime IssueDate;
        public string Owner;
        public string Cvc;
        public double PaymentSum { get; set; }
        public CardPayment(string cardNumber, DateTime issueDate, string owner, string cvc, double paymentSum) {
            CardNumber = cardNumber; IssueDate = issueDate; Owner = owner; Cvc = cvc; PaymentSum = paymentSum;
        }
        public string GetInfo() => "Безналичный расчет, карта: " + CardNumber + ", владелец: " + Owner + ", сумма: " + PaymentSum;
    }
}

using CSharpStudy.C_urok_08.payment;

namespace CSharpStudy.C_urok_08.purchase {
    internal class Purchase<T> where T : IPayment {
        string phone;
        T payment;
        double sum;
        public Purchase(string phone, T payment, double sum) {
            this.phone = phone; this.payment = payment; this.sum = sum;
        }
        public string GetInfo() => "Телефон: " + phone + ", сумма покупки: " + sum + ", " + payment.GetInfo();
    }
}

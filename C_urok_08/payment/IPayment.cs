namespace CSharpStudy.C_urok_08.payment {
    internal interface IPayment {
        double PaymentSum { get; set; }
        string GetInfo();
    }
}

namespace CSharpStudy.C_urok_04.product {
    internal class FoodProduct : Product {
        string expirationDate;

        public FoodProduct(string name, double price, string expirationDate) : base(name, price) { this.expirationDate = expirationDate; }
        public override string Info() => base.Info() + ", годен до: " + expirationDate;
    }
}

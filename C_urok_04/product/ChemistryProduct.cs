namespace CSharpStudy.C_urok_04.product {
    internal class ChemistryProduct : Product {
        string type;

        public ChemistryProduct(string name, double price, string type) : base(name, price) { this.type = type; }
        public override string Info() => base.Info() + ", тип: " + type;
    }
}

namespace CSharpStudy.C_urok_04.product {
    internal class ProductFlow {
        List<Product> products = new List<Product>();

        public void Income(Product product) => products.Add(product);
        public void Sell(string name) => ChangeStatus(name, "реализовано");
        public void WriteOff(string name) => ChangeStatus(name, "списано");
        public void Transfer(string name) => ChangeStatus(name, "передано");

        void ChangeStatus(string name, string status) {
            Product? product = products.FirstOrDefault(x => x.Name == name);
            if (product != null) product.Status = status;
        }

        public void Print() {
            foreach (Product product in products) Console.WriteLine(product.Info());
        }
    }
}

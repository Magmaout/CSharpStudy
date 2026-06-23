namespace CSharpStudy.C_urok_04.product {
    internal class Product {
        public string Name { get; protected set; }
        public double Price { get; protected set; }
        public string Status { get; set; } = "на складе";

        public Product(string name, double price) {
            Name = name;
            Price = price;
        }
        public virtual string Info() => Name + ", цена: " + Price + ", статус: " + Status;
    }
}

using CSharpStudy.C_urok_07.structs;

namespace CSharpStudy.C_urok_07.items {
    internal class HardwarePart : IInventoryItem {
        private readonly string name;
        private readonly decimal price;
        private int quantity;
        private readonly CategoryInfo category;

        public string Name => name;
        public decimal Price => price;
        public int Quantity { get => quantity; set => quantity = value; }
        public CategoryInfo Category => category;
        public string Info => $"Комплектующее: {name}, Цена: {price}, Количество: {quantity}, Категория: {category}";

        public HardwarePart(string name, decimal price, int quantity, CategoryInfo category) {
            if (string.IsNullOrWhiteSpace(name)) {
                Console.WriteLine("Ошибка: название не может быть пустым!");
                return;
            }
            if (price < 0) {
                Console.WriteLine("Ошибка: цена не может быть отрицательной!");
                return;
            }
            if (quantity < 0) {
                Console.WriteLine("Ошибка: количество не может быть отрицательным!");
                return;
            }
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.category = category;
        }
    }
}

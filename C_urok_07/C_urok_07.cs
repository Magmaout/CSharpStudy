using System.Collections.Generic;
using System.Linq;

namespace CSharpStudy {
    internal static class C_urok_07 {
        public static void Run() {
            WarehouseManager<IInventoryItem> warehouse = new WarehouseManager<IInventoryItem>();
            warehouse.OnLowStock += HandleLowStock;

            warehouse.Add(new StoreBook("C# Programming", 2500m, 50, new CategoryInfo("Книги", "BK")));
            warehouse.Add(new StoreBook("Python Basics", 1800m, 30, new CategoryInfo("Книги", "BK")));
            warehouse.Add(new HardwarePart("CPU Intel", 15000m, 10, new CategoryInfo("Комплектующие", "HW")));
            warehouse.Add(new HardwarePart("GPU NVIDIA", 45000m, 5, new CategoryInfo("Комплектующие", "HW")));
            warehouse.Add(new HardwarePart("RAM 16GB", 8000m, 20, new CategoryInfo("Комплектующие", "HW")));

            while (true) {
                InputHelper.ClearConsole();
                Console.WriteLine("Урок 7 \"Умный склад\":");
                Console.WriteLine("1. \"Добавить товар\";");
                Console.WriteLine("2. \"Удалить товар\";");
                Console.WriteLine("3. \"Изменить количество\";");
                Console.WriteLine("4. \"Показать все товары\";");
                Console.WriteLine("5. \"Товары с низким остатком\";");
                Console.WriteLine("6. \"Группировка по категориям\";");
                Console.WriteLine("7. \"Общая стоимость склада\";");
                Console.WriteLine("8. \"Топ категорий по стоимости\";");
                Console.WriteLine("9. \"Демонстрация событий\";");
                Console.WriteLine("0. \"Выбор урока\".");

                try {
                    switch (InputHelper.GetMenuPositiveInteger("\nВведите номер задания (0 - выбор урока): ", "0-9")) {
                        case 0:
                            warehouse.OnLowStock -= HandleLowStock;
                            return;
                        case 1:
                            AddItem(warehouse);
                            break;
                        case 2:
                            RemoveItem(warehouse);
                            break;
                        case 3:
                            UpdateItemQuantity(warehouse);
                            break;
                        case 4:
                            PrintAllItems(warehouse);
                            break;
                        case 5:
                            ShowLowStockItems(warehouse);
                            break;
                        case 6:
                            ShowItemsByCategory(warehouse);
                            break;
                        case 7:
                            Console.WriteLine("Общая стоимость склада: " + warehouse.GetTotalInventoryValue());
                            break;
                        case 8:
                            ShowTopCategories(warehouse);
                            break;
                        case 9:
                            DemoEvents(warehouse);
                            break;
                        default:
                            Console.WriteLine("Задания с таким номером не существует!");
                            break;
                    }
                } catch (TaskResetException) {
                    continue;
                } catch (WarehouseException ex) {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                if (!InputHelper.AskContinue("Продолжить работу с практикой?")) break;
            }
        }

        static void HandleLowStock(string itemName, int currentQuantity) {
            Console.WriteLine($"⚠️ ВНИМАНИЕ: Товар '{itemName}' заканчивается! Остаток: {currentQuantity}");
        }

        static void AddItem(WarehouseManager<IInventoryItem> warehouse) {
            Console.WriteLine("\nВыберите тип товара:");
            Console.WriteLine("1. Книга");
            Console.WriteLine("2. Комплектующее");
            int type = InputHelper.GetMenuPositiveInteger("Введите номер: ", "1 или 2");
            string name = InputHelper.GetString("Введите название: ");
            decimal price = (decimal)InputHelper.GetPositiveDouble("Введите цену: ");
            int quantity = InputHelper.GetPositiveInteger("Введите количество: ");
            string categoryName = InputHelper.GetString("Введите категорию: ");
            string categoryCode = InputHelper.GetString("Введите код категории: ");
            CategoryInfo category = new CategoryInfo(categoryName, categoryCode);

            if (type == 1) {
                warehouse.Add(new StoreBook(name, price, quantity, category));
                Console.WriteLine("Книга добавлена!");
            } else {
                warehouse.Add(new HardwarePart(name, price, quantity, category));
                Console.WriteLine("Комплектующее добавлено!");
            }
        }

        static void RemoveItem(WarehouseManager<IInventoryItem> warehouse) {
            string name = InputHelper.GetString("Введите название для удаления: ");
            warehouse.Remove(name);
            Console.WriteLine("Товар удален!");
        }

        static void UpdateItemQuantity(WarehouseManager<IInventoryItem> warehouse) {
            string name = InputHelper.GetString("Введите название товара: ");
            int quantity = InputHelper.GetPositiveInteger("Введите новое количество: ");
            warehouse.UpdateQuantity(name, quantity);
            Console.WriteLine("Количество обновлено!");
        }

        static void PrintAllItems(WarehouseManager<IInventoryItem> warehouse) {
            var items = warehouse.GetAll();
            if (!items.Any()) {
                Console.WriteLine("Склад пуст!");
                return;
            }
            Console.WriteLine("\n=== Все товары ===");
            foreach (var item in items) Console.WriteLine(item.Info);
        }

        static void ShowLowStockItems(WarehouseManager<IInventoryItem> warehouse) {
            int threshold = InputHelper.GetPositiveInteger("Введите порог низкого остатка: ");
            var lowStock = warehouse.GetLowStockItems(threshold);
            if (!lowStock.Any()) {
                Console.WriteLine("Нет товаров с низким остатком!");
                return;
            }
            Console.WriteLine("\n=== Товары с низким остатком ===");
            foreach (var item in lowStock) Console.WriteLine(item.Info);
        }

        static void ShowItemsByCategory(WarehouseManager<IInventoryItem> warehouse) {
            var grouped = warehouse.GetItemsByCategory();
            Console.WriteLine("\n=== Группировка по категориям ===");
            foreach (var group in grouped) {
                Console.WriteLine($"\n{group.Key}:");
                foreach (var item in group) Console.WriteLine("  " + item.Info);
            }
        }

        static void ShowTopCategories(WarehouseManager<IInventoryItem> warehouse) {
            int count = InputHelper.GetPositiveInteger("Введите количество топ категорий: ");
            var top = warehouse.GetTopCategoriesByValue(count);
            Console.WriteLine($"\n=== Топ {count} категорий по стоимости ===");
            int i = 1;
            foreach (var cat in top) Console.WriteLine($"{i++}. {cat}");
        }

        static void DemoEvents(WarehouseManager<IInventoryItem> warehouse) {
            Console.WriteLine("\n=== Демонстрация событий ===");

            Console.WriteLine("1. Подписка на событие...");
            warehouse.OnLowStock += HandleLowStock;

            Console.WriteLine("2. Изменение количества до критического...");
            var items = warehouse.GetAll().ToList();
            if (items.Any()) {
                var item = items.First();
                Console.WriteLine($"Товар: {item.Name}");
                warehouse.UpdateQuantity(item.Name, 3);
            }

            Console.WriteLine("3. Отписка от события...");
            warehouse.OnLowStock -= HandleLowStock;

            Console.WriteLine("4. Повторное изменение количества...");
            if (items.Any()) {
                var item = items.First();
                warehouse.UpdateQuantity(item.Name, 2);
                Console.WriteLine("(Событие не сработало - отписка успешна)");
            }
        }
    }

    class WarehouseException : Exception {
        public WarehouseException(string message) : base(message) { }
    }

    readonly struct CategoryInfo {
        public string Name { get; }
        public string Code { get; }

        public CategoryInfo(string name, string code) {
            Name = name;
            Code = code;
        }

        public override string ToString() => $"{Name} ({Code})";
    }

    internal interface IInventoryItem {
        string Name { get; }
        decimal Price { get; }
        int Quantity { get; set; }
        CategoryInfo Category { get; }
        string Info { get; }
    }

    internal class StoreBook : IInventoryItem {
        private readonly string name;
        private readonly decimal price;
        private int quantity;
        private readonly CategoryInfo category;

        public string Name => name;
        public decimal Price => price;
        public int Quantity { get => quantity; set => quantity = value; }
        public CategoryInfo Category => category;
        public string Info => $"Книга: {name}, Цена: {price}, Количество: {quantity}, Категория: {category}";

        public StoreBook(string name, decimal price, int quantity, CategoryInfo category) {
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

    public delegate void LowStockAlertHandler(string itemName, int currentQuantity);

    internal class WarehouseManager<T> where T : class, IInventoryItem {
        private List<T> _items = new List<T>();

        public event LowStockAlertHandler OnLowStock;

        public void Add(T item) {
            if (item == null) throw new WarehouseException("Товар не может быть null!");
            _items.Add(item);
        }

        public bool Remove(string name) {
            T item = _items.FirstOrDefault(x => x.Name == name);
            if (item == null) throw new WarehouseException($"Товар '{name}' не найден!");
            _items.Remove(item);
            return true;
        }

        public void UpdateQuantity(string name, int newQuantity) {
            if (newQuantity < 0) throw new WarehouseException("Количество не может быть отрицательным!");
            T item = _items.FirstOrDefault(x => x.Name == name);
            if (item == null) throw new WarehouseException($"Товар '{name}' не найден!");
            item.Quantity = newQuantity;

            if (newQuantity <= 5) {
                OnLowStock?.Invoke(item.Name, newQuantity);
            }
        }

        public IEnumerable<T> GetAll() {
            return _items;
        }

        public IEnumerable<T> GetLowStockItems(int threshold) {
            return _items
                .Where(x => x.Quantity <= threshold)
                .OrderBy(x => x.Name);
        }

        public IEnumerable<IGrouping<string, T>> GetItemsByCategory() {
            return _items
                .GroupBy(x => x.Category.Name);
        }

        public decimal GetTotalInventoryValue() {
            return _items.Sum(x => x.Price * x.Quantity);
        }

        public IEnumerable<string> GetTopCategoriesByValue(int count) {
            return _items
                .GroupBy(x => x.Category.Name)
                .Select(g => new { Category = g.Key, TotalValue = g.Sum(x => x.Price * x.Quantity) })
                .OrderByDescending(x => x.TotalValue)
                .Take(count)
                .Select(x => x.Category);
        }
    }
}

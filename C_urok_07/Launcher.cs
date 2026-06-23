using CSharpStudy.C_urok_07.items;
using CSharpStudy.C_urok_07.warehouse;
using CSharpStudy.C_urok_07.structs;
using CSharpStudy.C_urok_07.exceptions;

namespace CSharpStudy.C_urok_07 {
    internal static class Launcher {
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
}
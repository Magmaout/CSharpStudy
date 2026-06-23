using CSharpStudy.C_urok_07.items;
using CSharpStudy.C_urok_07.exceptions;

namespace CSharpStudy.C_urok_07.warehouse {
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

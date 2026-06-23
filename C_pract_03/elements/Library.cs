using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpStudy.C_pract_03.elements.media;

namespace CSharpStudy.C_pract_03.elements {
    internal class Library<T> : IMediaManager<T> where T : Media {
        private List<T> _items = new List<T>();
        private Dictionary<string, T> _lookup = new Dictionary<string, T>();

        public void Add(T item) {
            if (item == null) throw new LibraryException("Элемент не может быть null!");
            if (_lookup.ContainsKey(item.Title)) throw new LibraryException($"Элемент '{item.Title}' уже существует!");
            _items.Add(item);
            _lookup[item.Title] = item;
        }

        public bool Remove(string title) {
            if (!_lookup.ContainsKey(title)) throw new LibraryException($"Элемент '{title}' не найден!");
            T item = _lookup[title];
            _items.Remove(item);
            _lookup.Remove(title);
            return true;
        }

        public T FindByTitle(string title) {
            if (!_lookup.TryGetValue(title, out T item)) throw new LibraryException($"Элемент '{title}' не найден!");
            return item;
        }

        public IEnumerable<T> FilterByYear(int year) {
            return _items.Where(m => m.YearPublished == year);
        }

        public IEnumerable<T> GetAllAvailable() {
            return _items.Where(m => m.IsAvailable);
        }

        public void Borrow(string title) {
            T item = FindByTitle(title);
            item.IsAvailable = false;
        }

        public void Return(string title) {
            T item = FindByTitle(title);
            item.IsAvailable = true;
        }

        public void PrintAll() {
            if (_items.Count == 0) {
                Console.WriteLine("Библиотека пуста!");
                return;
            }
            Console.WriteLine("\n=== Все элементы библиотеки ===");
            foreach (var item in _items) Console.WriteLine(item.Info);
        }

        public void ExportToJson(string path) {
            var json = "[" + string.Join(",\n", _items.Select(m => $"  {{\"Title\": \"{m.Title}\", \"Author\": \"{m.Author}\", \"YearPublished\": {m.YearPublished}, \"IsAvailable\": {m.IsAvailable.ToString().ToLower()}, \"Type\": \"{m.GetType().Name}\"}}")) + "]";
            File.WriteAllText(path, json);
        }
    }
}

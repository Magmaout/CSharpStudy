using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace CSharpStudy {
    internal static class C_pract_03 {
        public static void Run() {
            Library<Media> library = new Library<Media>();
            while (true) {
                InputHelper.ClearConsole();
                Console.WriteLine("Практика 3 \"Система управления библиотекой\":");
                Console.WriteLine("1. \"Добавить книгу\";");
                Console.WriteLine("2. \"Добавить фильм\";");
                Console.WriteLine("3. \"Добавить музыкальный альбом\";");
                Console.WriteLine("4. \"Показать все элементы\";");
                Console.WriteLine("5. \"Найти по названию\";");
                Console.WriteLine("6. \"Фильтровать по году\";");
                Console.WriteLine("7. \"Показать доступные\";");
                Console.WriteLine("8. \"Выдать медиа\";");
                Console.WriteLine("9. \"Вернуть медиа\";");
                Console.WriteLine("10. \"Удалить элемент\";");
                Console.WriteLine("11. \"LINQ запросы\";");
                Console.WriteLine("12. \"Экспорт в JSON\";");
                Console.WriteLine("0. \"Выбор урока\".");

                try {
                    switch (InputHelper.GetMenuPositiveInteger("\nВведите номер задания (0 - выбор урока): ", "0-12")) {
                        case 0:
                            return;
                        case 1:
                            AddBook(library);
                            break;
                        case 2:
                            AddMovie(library);
                            break;
                        case 3:
                            AddMusicAlbum(library);
                            break;
                        case 4:
                            library.PrintAll();
                            break;
                        case 5:
                            FindByTitle(library);
                            break;
                        case 6:
                            FilterByYear(library);
                            break;
                        case 7:
                            ShowAvailable(library);
                            break;
                        case 8:
                            BorrowMedia(library);
                            break;
                        case 9:
                            ReturnMedia(library);
                            break;
                        case 10:
                            RemoveMedia(library);
                            break;
                        case 11:
                            LinqQueries(library);
                            break;
                        case 12:
                            ExportToJson(library);
                            break;
                        default:
                            Console.WriteLine("Задания с таким номером не существует!");
                            break;
                    }
                } catch (TaskResetException) {
                    continue;
                } catch (LibraryException ex) {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                if (!InputHelper.AskContinue("Продолжить работу с практикой?")) break;
            }
        }

        static void AddBook(Library<Media> library) {
            string title = InputHelper.GetString("Введите название книги: ");
            string author = InputHelper.GetString("Введите автора: ");
            int year = InputHelper.GetPositiveInteger("Введите год публикации: ");
            int pages = InputHelper.GetPositiveInteger("Введите количество страниц: ");
            string genre = InputHelper.GetString("Введите жанр: ");
            library.Add(new Book(title, author, year, pages, genre));
            Console.WriteLine("Книга добавлена!");
        }

        static void AddMovie(Library<Media> library) {
            string title = InputHelper.GetString("Введите название фильма: ");
            string author = InputHelper.GetString("Введите режиссёра: ");
            int year = InputHelper.GetPositiveInteger("Введите год выпуска: ");
            int duration = InputHelper.GetPositiveInteger("Введите длительность (мин): ");
            string director = InputHelper.GetString("Введите режиссёра: ");
            library.Add(new Movie(title, author, year, duration, director));
            Console.WriteLine("Фильм добавлен!");
        }

        static void AddMusicAlbum(Library<Media> library) {
            string title = InputHelper.GetString("Введите название альбома: ");
            string author = InputHelper.GetString("Введите исполнителя: ");
            int year = InputHelper.GetPositiveInteger("Введите год выпуска: ");
            int trackCount = InputHelper.GetPositiveInteger("Введите количество треков: ");
            string artist = InputHelper.GetString("Введите исполнителя: ");
            library.Add(new MusicAlbum(title, author, year, trackCount, artist));
            Console.WriteLine("Альбом добавлен!");
        }

        static void FindByTitle(Library<Media> library) {
            string title = InputHelper.GetString("Введите название для поиска: ");
            try {
                Media found = library.FindByTitle(title);
                Console.WriteLine("Найдено: " + found.Info);
            } catch (LibraryException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static void FilterByYear(Library<Media> library) {
            int year = InputHelper.GetPositiveInteger("Введите год для фильтрации: ");
            var filtered = library.FilterByYear(year);
            if (!filtered.Any()) {
                Console.WriteLine("Ничего не найдено!");
                return;
            }
            foreach (var item in filtered) Console.WriteLine(item.Info);
        }

        static void ShowAvailable(Library<Media> library) {
            var available = library.GetAllAvailable();
            if (!available.Any()) {
                Console.WriteLine("Нет доступных элементов!");
                return;
            }
            foreach (var item in available) Console.WriteLine(item.Info);
        }

        static void BorrowMedia(Library<Media> library) {
            string title = InputHelper.GetString("Введите название для выдачи: ");
            library.Borrow(title);
            Console.WriteLine("Медиа выдано!");
        }

        static void ReturnMedia(Library<Media> library) {
            string title = InputHelper.GetString("Введите название для возврата: ");
            library.Return(title);
            Console.WriteLine("Медиа возвращено!");
        }

        static void RemoveMedia(Library<Media> library) {
            string title = InputHelper.GetString("Введите название для удаления: ");
            library.Remove(title);
            Console.WriteLine("Элемент удален!");
        }

        static void LinqQueries(Library<Media> library) {
            Console.WriteLine("\n=== LINQ запросы ===");

            int year = InputHelper.GetPositiveInteger("Введите год для поиска книг: ");
            var booksAfterYear = library.GetAllAvailable()
                .OfType<Book>()
                .Where(b => b.YearPublished > year);
            Console.WriteLine($"\nКниги после {year} года:");
            foreach (var book in booksAfterYear) Console.WriteLine(book.Info);

            var moviesByDuration = library.GetAllAvailable()
                .OfType<Movie>()
                .OrderBy(m => m.Duration);
            Console.WriteLine("\nФильмы по длительности:");
            foreach (var movie in moviesByDuration) Console.WriteLine(movie.Info);

            var unavailable = library.GetAllAvailable()
                .Where(m => !m.IsAvailable);
            Console.WriteLine("\nНедоступные элементы:");
            foreach (var item in unavailable) Console.WriteLine(item.Info);
        }

        static void ExportToJson(Library<Media> library) {
            string path = InputHelper.GetString("Введите путь для сохранения файла: ", "путь не должен быть пустым");
            if (!path.EndsWith(".json")) path += ".json";
            library.ExportToJson(path);
            Console.WriteLine("Данные экспортированы в " + path);
        }
    }

    class LibraryException : Exception {
        public LibraryException(string message) : base(message) { }
    }

    internal abstract class Media {
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }
        public bool IsAvailable { get; set; }

        public Media(string title, string author, int yearPublished) {
            if (string.IsNullOrWhiteSpace(title)) throw new LibraryException("Название не может быть пустым!");
            if (yearPublished < 0) throw new LibraryException("Год не может быть отрицательным!");
            Title = title;
            Author = author;
            YearPublished = yearPublished;
            IsAvailable = true;
        }

        public virtual string Info => $"Название: {Title}, Автор: {Author}, Год: {YearPublished}, Доступно: {IsAvailable}";
    }

    internal class Book : Media {
        public int Pages { get; set; }
        public string Genre { get; set; }

        public Book(string title, string author, int yearPublished, int pages, string genre)
            : base(title, author, yearPublished) {
            if (pages <= 0) throw new LibraryException("Количество страниц должно быть положительным!");
            Pages = pages;
            Genre = genre;
        }

        public override string Info => base.Info + $", Тип: Книга, Страниц: {Pages}, Жанр: {Genre}";
    }

    internal class Movie : Media {
        public int Duration { get; set; }
        public string Director { get; set; }

        public Movie(string title, string author, int yearPublished, int duration, string director)
            : base(title, author, yearPublished) {
            if (duration <= 0) throw new LibraryException("Длительность должна быть положительной!");
            Duration = duration;
            Director = director;
        }

        public override string Info => base.Info + $", Тип: Фильм, Длительность: {Duration} мин, Режиссёр: {Director}";
    }

    internal class MusicAlbum : Media {
        public string Artist { get; set; }
        public int TrackCount { get; set; }

        public MusicAlbum(string title, string author, int yearPublished, int trackCount, string artist)
            : base(title, author, yearPublished) {
            if (trackCount <= 0) throw new LibraryException("Количество треков должно быть положительным!");
            TrackCount = trackCount;
            Artist = artist;
        }

        public override string Info => base.Info + $", Тип: Альбом, Исполнитель: {Artist}, Треков: {TrackCount}";
    }

    internal interface IMediaManager<T> {
        void Add(T item);
        bool Remove(string title);
        T FindByTitle(string title);
        IEnumerable<T> FilterByYear(int year);
        IEnumerable<T> GetAllAvailable();
    }

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

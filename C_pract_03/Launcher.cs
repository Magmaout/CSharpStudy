using System.Collections.Generic;
using System.Linq;
using System.IO;
using CSharpStudy.C_pract_03.elements.media;
using CSharpStudy.C_pract_03.elements;

namespace CSharpStudy.C_pract_03 {
    internal static class Launcher {
        public static void Run() {
            Library<Media> library = new Library<Media>();
            while (true) {
                InputHelper.ClearConsole();
                Console.WriteLine("Практика 3 \"Система управления библиотекой\":");
                Console.WriteLine("1.  \"Добавить книгу\";");
                Console.WriteLine("2.  \"Добавить фильм\";");
                Console.WriteLine("3.  \"Добавить музыкальный альбом\";");
                Console.WriteLine("4.  \"Показать все элементы\";");
                Console.WriteLine("5.  \"Найти по названию\";");
                Console.WriteLine("6.  \"Фильтровать по году\";");
                Console.WriteLine("7.  \"Показать доступные\";");
                Console.WriteLine("8.  \"Выдать медиа\";");
                Console.WriteLine("9.  \"Вернуть медиа\";");
                Console.WriteLine("10. \"Удалить элемент\";");
                Console.WriteLine("11. \"LINQ запросы\";");
                Console.WriteLine("12. \"Экспорт в JSON\";");
                Console.WriteLine("0.  \"Выбор урока\".");

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
}

using CSharpStudy.C_urok_03.elements;
using CSharpStudy.C_urok_03.elements.books;
using CSharpStudy.C_urok_03.elements.computers;

namespace CSharpStudy.C_urok_03 {
    internal static class Launcher {
        public static void Run() {
            while (true) {
                InputHelper.ClearConsole();
                Console.WriteLine("Урок №3:");
                Console.WriteLine("1. \"Классы точка, пользователь, персональный компьютер и ноутбук\" (П1:В1-4);");
                Console.WriteLine("2. \"Класс книги\" (П4:В1).");
                try {
                    switch (InputHelper.GetMenuPositiveInteger("\nВведите номер задачи (0 - выбор урока): ", "0, 1 или 2")) {
                        case 0:
                            return;
                        case 1:
                            DemoPractice1();
                            break;
                        case 2:
                            DemoPractice2();
                            break;
                        default:
                            Console.WriteLine("Задания с таким номером не существует!");
                            break;
                    }
                } catch (TaskResetException) {
                    continue;
                }
                if (!InputHelper.AskContinue("Выбрать другое задание?")) break;
            }
        }

        static void DemoPractice1() {
            Point3D point = new Point3D(1, 2, 3);
            point.MoveBy(10, 20, 30);
            Console.WriteLine(point.Info());

            User user = new User("Иванов", "Иван", "Иванович", 20);
            Console.WriteLine(user.Fio());

            PersonalComputer pc = new PersonalComputer("Office PC", 3.4, 16, 512);
            Console.WriteLine(pc.Info());

            Laptop laptop = new Laptop("Lenovo", 2.8, 16, 1024, 1.7);
            Console.WriteLine(laptop.Info());
        }

        static void DemoPractice2() {
            MethodBook methodBook = new MethodBook("Война и мир", "Л.Н. Толстой", 1869, 1225, "Русский вестник");
            FeaturesBook featuresBook = new FeaturesBook("Преступление и наказание", "Ф.М. Достоевский", 1866, 671, "Русский вестник");
            Console.WriteLine(methodBook.GetInfo());
            Console.WriteLine(featuresBook.Info);
            featuresBook.Name = "Белые ночи";
            Console.WriteLine(featuresBook.Info);
        }
    }
}

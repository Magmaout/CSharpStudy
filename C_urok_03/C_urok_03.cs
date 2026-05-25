namespace CSharpStudy {
    internal static class C_urok_03 {
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

    internal class Point3D {
        int x, y, z;
        public Point3D(int x, int y, int z) { this.x = x; this.y = y; this.z = z; }
        public void MoveBy(int dx, int dy, int dz) { x += dx; y += dy; z += dz; }
        public string Info() => "Точка: X=" + x + ", Y=" + y + ", Z=" + z;
    }

    internal class User {
        string lastName, firstName, middleName; int age;
        public User(string lastName, string firstName, string middleName, int age) { this.lastName = lastName; this.firstName = firstName; this.middleName = middleName; this.age = age; }
        public string Fio() => lastName + " " + firstName + " " + middleName + ", возраст: " + age;
    }

    internal class PersonalComputer {
        string model; double cpu; int ram, hdd;
        public PersonalComputer(string model, double cpu, int ram, int hdd) { this.model = model; this.cpu = cpu; this.ram = ram; this.hdd = hdd; }
        public string Info() => "ПК: " + model + ", CPU: " + cpu + ", RAM: " + ram + ", HDD: " + hdd;
    }

    internal class Laptop : PersonalComputer {
        double weight;
        public Laptop(string model, double cpu, int ram, int hdd, double weight) : base(model, cpu, ram, hdd) { this.weight = weight; }
        public new string Info() => base.Info() + ", масса: " + weight;
    }

    internal class MethodBook {
        string name, author, publisher; int year, pages;
        public MethodBook(string name, string author, int year, int pages, string publisher) { this.name = name; this.author = author; this.year = year; this.pages = pages; this.publisher = publisher; }
        public string GetName() => name;
        public void SetName(string name) => this.name = name;
        public string GetAuthor() => author;
        public string GetInfo() => "Книга: " + name + ", автор: " + author + ", год: " + year + ", листов: " + pages + ", издательство: " + publisher;
    }

    internal class FeaturesBook {
        string name, author; int year, pages;
        public string Name { get => name; set => name = value; }
        public string Author => author;
        public string Publisher { get; }
        public string Info => "Книга: " + name + ", автор: " + author + ", год: " + year + ", листов: " + pages + ", издательство: " + Publisher;
        public FeaturesBook(string name, string author, int year, int pages, string publisher) { this.name = name; this.author = author; this.year = year; this.pages = pages; Publisher = publisher; }
    }
}

namespace CSharpStudy.Wonders {
    internal class Pyramid { public string Info() => "Чудо света: Пирамида Хеопса"; }
    internal class Gardens { public string Info() => "Чудо света: Висячие сады Семирамиды"; }
}

namespace CSharpStudy.Russia { internal class Moscow { public const int Population = 13100000; } }
namespace CSharpStudy.Japan { internal class Tokyo { public const int Population = 14000000; } }
namespace CSharpStudy.France { internal class Paris { public const int Population = 2100000; } }

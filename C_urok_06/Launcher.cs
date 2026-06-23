using CSharpStudy.C_urok_06.figure;
using CSharpStudy.C_urok_06.shapes;
using CSharpStudy.C_urok_06.converter;
using CSharpStudy.C_urok_06.salary;
using CSharpStudy.C_urok_06.anticafe;
using CSharpStudy.C_urok_06.interfaces;

namespace CSharpStudy.C_urok_06 {
    internal static class Launcher {
        public static void Run() {
            while (true) {
                InputHelper.ClearConsole();
                Console.WriteLine("Урок №6:");
                Console.WriteLine("1. \"Геометрические фигуры\";");
                Console.WriteLine("2. \"Конвертер, зарплата и клиент антикафе\" (П6:В1,В4,В5).");
                try {
                    switch (InputHelper.GetMenuPositiveInteger("\nВведите номер задачи (0 - выбор урока): ", "0, 1 или 2")) {
                        case 0:
                            return;
                        case 1:
                            CompositeFigure figures = new CompositeFigure();
                            figures.Add(new Rectangle(10, 5));
                            figures.Add(new Triangle(3, 4, 5));
                            figures.Add(new Square(4));
                            figures.Add(new Rhombus(5, 3));
                            figures.Add(new Parallelogram(8, 5, 4));
                            figures.Add(new Trapezoid(10, 6, 4, 5, 5));
                            Console.WriteLine("Суммарная площадь: " + figures.GetArea());
                            Console.WriteLine("Фигуры:");
                            ShapeCollection collection = new ShapeCollection();
                            collection.Add(new DrawRectangle(2, 0, 6, 3, ConsoleColor.Green));
                            collection.Add(new DrawTriangle(12, 0, 5, ConsoleColor.Yellow));
                            collection.Add(new DrawRhombus(22, 0, 4, ConsoleColor.Cyan));
                            collection.Add(new DrawTrapezoid(34, 0, 4, ConsoleColor.Magenta));
                            collection.Add(new DrawPolygon(48, 0, 5, ConsoleColor.White));
                            collection.ShowAll();
                            break;
                        case 2:
                            IConverter fahrenheit = new CelsiusToFahrenheit();
                            IConverter kelvin = new CelsiusToKelvin();
                            Console.WriteLine("25 C в F: " + fahrenheit.Convert(25));
                            Console.WriteLine("25 C в K: " + kelvin.Convert(25));
                            IConsolePrint manager = new Manager("Иванов И.И.", 20);
                            IConsolePrint chief = new DepartmentHead("Петров П.П.", 20);
                            manager.Print();
                            chief.Print();
                            AntiCafeClient standard = new StandardAntiCafeClient("Сидоров С.С.", 3);
                            AntiCafeClient vip = new VipAntiCafeClient("Смирнов С.С.", 3);
                            standard.Print();
                            vip.Print();
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
    }
}

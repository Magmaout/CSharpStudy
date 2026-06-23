using CSharpStudy.C_urok_04.figure;
using CSharpStudy.C_urok_04.person;
using CSharpStudy.C_urok_04.transport;
using CSharpStudy.C_urok_04.product;

namespace CSharpStudy.C_urok_04 {
    internal static class Launcher {
        public static void Run() {
            while (true) {
                InputHelper.ClearConsole();
                Console.WriteLine("Урок №4:");
                Console.WriteLine("1. \"Геометрические фигуры\";");
                Console.WriteLine("2. \"Класс Люди\" (П5:В1);");
                Console.WriteLine("3. \"Класс Общественный транспорт\" (П5:В2).");
                try {
                    switch (InputHelper.GetMenuPositiveInteger("\nВведите номер задачи (0 - выбор урока): ", "0, 1, 2 или 3")) {
                        case 0:
                            return;
                        case 1:
                            CompositeFigure composite = new CompositeFigure();
                            composite.Add(new Square(5));
                            composite.Add(new Circle(3));
                            composite.Add(new Rectangle(4, 8));
                            composite.Add(new Rhombus(6, 4));
                            composite.Add(new Parallelogram(7, 5, 3));
                            composite.Add(new Trapezoid(10, 6, 4, 5, 5));
                            composite.Add(new Ellipse(6, 3));
                            Console.WriteLine("Площадь составной фигуры: " + Math.Round(composite.GetArea(), 2));
                            break;
                        case 2:
                            Person person = new Person("Иван", 30);
                            Student student = new Student("Петр", 18, 2, "ИС-11");
                            Teacher teacher = new Teacher("Анна", 40, 12, 2);
                            Console.WriteLine(person.GetInfo());
                            Console.WriteLine(student.GetInfo());
                            Console.WriteLine(teacher.GetInfo());
                            Console.WriteLine("Зарплата преподавателя: " + teacher.CalculateSalary());
                            break;
                        case 3:
                            Bus bus = new Bus(12, 40, 60, 100);
                            Trolleybus trolleybus = new Trolleybus(5, 60, 50, 400);
                            Console.WriteLine(bus.GetInfo() + ", расстояние: " + bus.GetDistance());
                            Console.WriteLine(trolleybus.GetInfo() + ", расстояние: " + trolleybus.GetDistance());
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

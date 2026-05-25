using System.Collections;

namespace CSharpStudy {
    internal static class C_urok_06 {
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
                            Urok06CompositeFigure figures = new Urok06CompositeFigure();
                            figures.Add(new Urok06Rectangle(10, 5));
                            figures.Add(new Urok06Triangle(3, 4, 5));
                            figures.Add(new Urok06Square(4));
                            figures.Add(new Urok06Rhombus(5, 3));
                            figures.Add(new Urok06Parallelogram(8, 5, 4));
                            figures.Add(new Urok06Trapezoid(10, 6, 4, 5, 5));
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

    internal interface ISimplePolygon {
        double Height { get; }
        double BaseSide { get; }
        double Angle { get; }
        int SidesCount { get; }
        double[] SideLengths { get; }
        double Area { get; }
        double Perimeter { get; }
    }

    internal abstract class Urok06Figure {
        public double Area { get; protected set; }
        public double Perimeter { get; protected set; }
    }

    internal class Urok06Rectangle : Urok06Figure, ISimplePolygon {
        double width, height;
        public double Height => height;
        public double BaseSide => width;
        public double Angle => 90;
        public int SidesCount => 4;
        public double[] SideLengths => new double[] { width, height, width, height };
        public Urok06Rectangle(double width, double height) {
            if (width <= 0 || height <= 0) throw new Exception("Нельзя создать прямоугольник!");
            this.width = width; this.height = height; Area = width * height; Perimeter = 2 * (width + height);
        }
    }

    internal class Urok06Square : Urok06Rectangle {
        public Urok06Square(double side) : base(side, side) { }
    }

    internal class Urok06Rhombus : Urok06Figure, ISimplePolygon {
        double side, height;
        public double Height => height;
        public double BaseSide => side;
        public double Angle => 0;
        public int SidesCount => 4;
        public double[] SideLengths => new double[] { side, side, side, side };
        public Urok06Rhombus(double side, double height) {
            if (side <= 0 || height <= 0) throw new Exception("Нельзя создать ромб!");
            this.side = side; this.height = height; Area = side * height; Perimeter = side * 4;
        }
    }

    internal class Urok06Parallelogram : Urok06Figure, ISimplePolygon {
        double sideA, sideB, height;
        public double Height => height;
        public double BaseSide => sideA;
        public double Angle => 0;
        public int SidesCount => 4;
        public double[] SideLengths => new double[] { sideA, sideB, sideA, sideB };
        public Urok06Parallelogram(double sideA, double sideB, double height) {
            if (sideA <= 0 || sideB <= 0 || height <= 0) throw new Exception("Нельзя создать параллелограмм!");
            this.sideA = sideA; this.sideB = sideB; this.height = height; Area = sideA * height; Perimeter = 2 * (sideA + sideB);
        }
    }

    internal class Urok06Trapezoid : Urok06Figure, ISimplePolygon {
        double baseA, baseB, height, sideC, sideD;
        public double Height => height;
        public double BaseSide => baseA;
        public double Angle => 0;
        public int SidesCount => 4;
        public double[] SideLengths => new double[] { baseA, baseB, sideC, sideD };
        public Urok06Trapezoid(double baseA, double baseB, double height, double sideC, double sideD) {
            if (baseA <= 0 || baseB <= 0 || height <= 0 || sideC <= 0 || sideD <= 0) throw new Exception("Нельзя создать трапецию!");
            this.baseA = baseA; this.baseB = baseB; this.height = height; this.sideC = sideC; this.sideD = sideD;
            Area = (baseA + baseB) / 2 * height; Perimeter = baseA + baseB + sideC + sideD;
        }
    }

    internal class Urok06Triangle : Urok06Figure, ISimplePolygon {
        double a, b, c;
        public double Height => 0;
        public double BaseSide => a;
        public double Angle => 0;
        public int SidesCount => 3;
        public double[] SideLengths => new double[] { a, b, c };
        public Urok06Triangle(double a, double b, double c) {
            if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a) throw new Exception("Нельзя создать треугольник!");
            this.a = a; this.b = b; this.c = c; Perimeter = a + b + c;
            double p = Perimeter / 2;
            Area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }

    internal class Urok06CompositeFigure {
        List<ISimplePolygon> polygons = new List<ISimplePolygon>();
        public void Add(ISimplePolygon polygon) => polygons.Add(polygon);
        public double GetArea() => polygons.Sum(x => x.Area);
    }

    internal abstract class ConsoleShape {
        protected int x, y; protected ConsoleColor color;
        public int OffsetY { get; set; }
        protected ConsoleShape(int x, int y, ConsoleColor color) { this.x = x; this.y = y; this.color = color; }
        public abstract void Draw();
        protected void WriteAt(int left, int top, string text) {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            if (Console.IsOutputRedirected) {
                Console.WriteLine(text);
            }
            else {
                Console.SetCursorPosition(left, top + OffsetY);
                Console.Write(text);
            }
            Console.ForegroundColor = old;
        }
    }

    internal class DrawRectangle : ConsoleShape {
        int width, height;
        public DrawRectangle(int x, int y, int width, int height, ConsoleColor color) : base(x, y, color) { this.width = width; this.height = height; }
        public override void Draw() {
            for (int i = 0; i < height; i++) WriteAt(x, y + i, new string('*', width));
        }
    }

    internal class DrawTriangle : ConsoleShape {
        int size;
        public DrawTriangle(int x, int y, int size, ConsoleColor color) : base(x, y, color) { this.size = size; }
        public override void Draw() {
            for (int i = 1; i <= size; i++) WriteAt(x, y + i, new string('*', i));
        }
    }

    internal class DrawRhombus : ConsoleShape {
        int size;
        public DrawRhombus(int x, int y, int size, ConsoleColor color) : base(x, y, color) { this.size = size; }
        public override void Draw() {
            for (int i = 0; i < size; i++) WriteAt(x + size - i, y + i, new string('*', i * 2 + 1));
            for (int i = size - 2; i >= 0; i--) WriteAt(x + size - i, y + (size * 2 - i - 2), new string('*', i * 2 + 1));
        }
    }

    internal class DrawTrapezoid : ConsoleShape {
        int height;
        public DrawTrapezoid(int x, int y, int height, ConsoleColor color) : base(x, y, color) { this.height = height; }
        public override void Draw() {
            for (int i = 0; i < height; i++) WriteAt(x + height - i, y + i, new string('*', height + i * 2));
        }
    }

    internal class DrawPolygon : ConsoleShape {
        int size;
        public DrawPolygon(int x, int y, int size, ConsoleColor color) : base(x, y, color) { this.size = size; }
        public override void Draw() {
            WriteAt(x + 1, y, new string('*', size));
            for (int i = 1; i < size; i++) WriteAt(x, y + i, "*" + new string(' ', size) + "*");
            WriteAt(x + 1, y + size, new string('*', size));
        }
    }

    internal class ShapeCollection : IEnumerable<ConsoleShape> {
        List<ConsoleShape> shapes = new List<ConsoleShape>();
        public void Add(ConsoleShape shape) => shapes.Add(shape);
        public void ShowAll() {
            int offset = Console.IsOutputRedirected ? 0 : Console.CursorTop;
            foreach (ConsoleShape shape in this) {
                shape.OffsetY = offset;
                shape.Draw();
            }
            if (!Console.IsOutputRedirected) Console.SetCursorPosition(0, offset + 10);
        }
        public IEnumerator<ConsoleShape> GetEnumerator() => shapes.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal interface IConverter : IConsolePrint {
        string FromScale { get; set; }
        string ToScale { get; set; }
        double Convert(double value);
    }

    internal interface IConsolePrint {
        void Print();
    }

    internal class CelsiusToFahrenheit : IConverter {
        public string FromScale { get; set; } = "Цельсий";
        public string ToScale { get; set; } = "Фаренгейт";
        public double Convert(double value) => 1.8 * value + 32;
        public void Print() => Console.WriteLine(FromScale + " -> " + ToScale);
    }

    internal class CelsiusToKelvin : IConverter {
        public string FromScale { get; set; } = "Цельсий";
        public string ToScale { get; set; } = "Кельвин";
        public double Convert(double value) => 273.15 + value;
        public void Print() => Console.WriteLine(FromScale + " -> " + ToScale);
    }

    internal interface ISalary {
        string FullName { get; set; }
        int WorkDays { get; set; }
        double CalculateSalary();
    }

    internal class Manager : ISalary, IConsolePrint {
        public string FullName { get; set; }
        public int WorkDays { get; set; }
        public Manager(string fullName, int workDays) { FullName = fullName; WorkDays = workDays; }
        public double CalculateSalary() => WorkDays * 1000;
        public void Print() => Console.WriteLine(FullName + ", дней: " + WorkDays + ", зарплата: " + CalculateSalary());
    }

    internal class DepartmentHead : ISalary, IConsolePrint {
        public string FullName { get; set; }
        public int WorkDays { get; set; }
        public DepartmentHead(string fullName, int workDays) { FullName = fullName; WorkDays = workDays; }
        public double CalculateSalary() => WorkDays * 2500;
        public void Print() => Console.WriteLine(FullName + ", дней: " + WorkDays + ", зарплата: " + CalculateSalary());
    }

    internal class Accounting {
        public double GetTax(ISalary salary) => salary.CalculateSalary() * 0.13;
    }

    internal interface AntiCafeClient : IConsolePrint {
        string FullName { get; set; }
        int Hours { get; set; }
        double TotalCost();
    }

    internal class StandardAntiCafeClient : AntiCafeClient {
        static double hourCost = 100;
        public string FullName { get; set; }
        public int Hours { get; set; }
        public StandardAntiCafeClient(string fullName, int hours) { FullName = fullName; Hours = hours; }
        public double TotalCost() => Hours * hourCost;
        public void Print() => Console.WriteLine(FullName + ", часов: " + Hours + ", стоимость: " + TotalCost());
    }

    internal class VipAntiCafeClient : AntiCafeClient {
        static double hourCost = 150;
        public string FullName { get; set; }
        public int Hours { get; set; }
        public VipAntiCafeClient(string fullName, int hours) { FullName = fullName; Hours = hours; }
        public double TotalCost() => Hours * hourCost * 1.05;
        public void Print() => Console.WriteLine(FullName + ", часов: " + Hours + ", стоимость: " + TotalCost());
    }
}

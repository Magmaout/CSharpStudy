namespace CSharpStudy {
    internal static class C_urok_04 {
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
                            composite.Add(new SquareFigure(5));
                            composite.Add(new CircleFigure(3));
                            composite.Add(new RectangleFigure(4, 8));
                            composite.Add(new RhombusFigure(6, 4));
                            composite.Add(new ParallelogramFigure(7, 5, 3));
                            composite.Add(new TrapezoidFigure(10, 6, 4, 5, 5));
                            composite.Add(new EllipseFigure(6, 3));
                            Console.WriteLine("Площадь составной фигуры: " + Math.Round(composite.GetArea(), 2));
                            break;
                        case 2:
                            Person person = new Person("Иван", 30);
                            Urok04Student student = new Urok04Student("Петр", 18, 2, "ИС-11");
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

    internal abstract class GeometryFigure {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    internal class SquareFigure : GeometryFigure {
        double side;
        public SquareFigure(double side) { this.side = side; }
        public override double GetArea() => side * side;
        public override double GetPerimeter() => side * 4;
    }

    internal class CircleFigure : GeometryFigure {
        double radius;
        public CircleFigure(double radius) { this.radius = radius; }
        public override double GetArea() => Math.PI * radius * radius;
        public override double GetPerimeter() => 2 * Math.PI * radius;
    }

    internal class RectangleFigure : GeometryFigure {
        double a, b;
        public RectangleFigure(double a, double b) { this.a = a; this.b = b; }
        public override double GetArea() => a * b;
        public override double GetPerimeter() => 2 * (a + b);
    }

    internal class RhombusFigure : GeometryFigure {
        double side, height;
        public RhombusFigure(double side, double height) { this.side = side; this.height = height; }
        public override double GetArea() => side * height;
        public override double GetPerimeter() => side * 4;
    }

    internal class ParallelogramFigure : GeometryFigure {
        double sideA, sideB, height;
        public ParallelogramFigure(double sideA, double sideB, double height) { this.sideA = sideA; this.sideB = sideB; this.height = height; }
        public override double GetArea() => sideA * height;
        public override double GetPerimeter() => 2 * (sideA + sideB);
    }

    internal class TrapezoidFigure : GeometryFigure {
        double baseA, baseB, height, sideC, sideD;
        public TrapezoidFigure(double baseA, double baseB, double height, double sideC, double sideD) { this.baseA = baseA; this.baseB = baseB; this.height = height; this.sideC = sideC; this.sideD = sideD; }
        public override double GetArea() => (baseA + baseB) / 2 * height;
        public override double GetPerimeter() => baseA + baseB + sideC + sideD;
    }

    internal class TriangleFigure : GeometryFigure {
        double a, b, c;
        public TriangleFigure(double a, double b, double c) { this.a = a; this.b = b; this.c = c; }
        public override double GetArea() {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public override double GetPerimeter() => a + b + c;
    }

    internal class EllipseFigure : GeometryFigure {
        double radiusA, radiusB;
        public EllipseFigure(double radiusA, double radiusB) { this.radiusA = radiusA; this.radiusB = radiusB; }
        public override double GetArea() => Math.PI * radiusA * radiusB;
        public override double GetPerimeter() => Math.PI * (3 * (radiusA + radiusB) - Math.Sqrt((3 * radiusA + radiusB) * (radiusA + 3 * radiusB)));
    }

    internal class CompositeFigure {
        List<GeometryFigure> figures = new List<GeometryFigure>();
        public void Add(GeometryFigure figure) => figures.Add(figure);
        public double GetArea() => figures.Sum(x => x.GetArea());
    }

    internal class Product {
        public string Name { get; protected set; }
        public double Price { get; protected set; }
        public string Status { get; set; } = "на складе";
        public Product(string name, double price) { Name = name; Price = price; }
        public virtual string Info() => Name + ", цена: " + Price + ", статус: " + Status;
    }

    internal class FoodProduct : Product {
        string expirationDate;
        public FoodProduct(string name, double price, string expirationDate) : base(name, price) { this.expirationDate = expirationDate; }
        public override string Info() => base.Info() + ", годен до: " + expirationDate;
    }

    internal class ChemistryProduct : Product {
        string type;
        public ChemistryProduct(string name, double price, string type) : base(name, price) { this.type = type; }
        public override string Info() => base.Info() + ", тип: " + type;
    }

    internal class ProductFlow {
        List<Product> products = new List<Product>();
        public void Income(Product product) => products.Add(product);
        public void Sell(string name) => ChangeStatus(name, "реализовано");
        public void WriteOff(string name) => ChangeStatus(name, "списано");
        public void Transfer(string name) => ChangeStatus(name, "передано");
        void ChangeStatus(string name, string status) {
            Product? product = products.FirstOrDefault(x => x.Name == name);
            if (product != null) product.Status = status;
        }
        public void Print() {
            foreach (Product product in products) Console.WriteLine(product.Info());
        }
    }

    internal class Person {
        string name; int age;
        public Person(string name, int age) { this.name = name; this.age = age; }
        public virtual string GetInfo() => "Человек: " + name + ", возраст: " + age;
    }

    internal class Urok04Student : Person {
        int course; string group;
        public Urok04Student(string name, int age, int course, string group) : base(name, age) { this.course = course; this.group = group; }
        public override string GetInfo() => base.GetInfo() + ", курс: " + course + ", группа: " + group;
    }

    internal class Teacher : Person {
        int experience, level;
        public Teacher(string name, int age, int experience, int level) : base(name, age) { this.experience = experience; this.level = level; }
        public double CalculateSalary() => 16242 + experience * 500 + level * 900;
        public override string GetInfo() => base.GetInfo() + ", стаж: " + experience + ", квалификация: " + level;
    }

    internal class PublicTransport {
        int number, capacity, speed;
        public PublicTransport(int number, int capacity, int speed) { this.number = number; this.capacity = capacity; this.speed = speed; }
        public virtual string GetInfo() => "Транспорт №" + number + ", вместимость: " + capacity + ", скорость: " + speed;
    }

    internal class Bus : PublicTransport {
        double tank;
        public Bus(int number, int capacity, int speed, double tank) : base(number, capacity, speed) { this.tank = tank; }
        public double GetDistance() => tank / 20 * 25;
    }

    internal class Trolleybus : PublicTransport {
        double battery;
        public Trolleybus(int number, int capacity, int speed, double battery) : base(number, capacity, speed) { this.battery = battery; }
        public double GetDistance() => battery / 200 * 70;
    }
}

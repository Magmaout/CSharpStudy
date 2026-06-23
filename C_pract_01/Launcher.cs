using CSharpStudy.C_pract_01.shapes;

namespace CSharpStudy.C_pract_01 {
    internal static class Launcher {
        public static void Run() {
            FigureStorage storage = new FigureStorage();
            while (true) {
                InputHelper.ClearConsole();
                Console.WriteLine("Практика 1 \"GeoCalc Pro\":");
                Console.WriteLine("1. \"Добавить фигуру\";");
                Console.WriteLine("2. \"Показать все фигуры\";");
                Console.WriteLine("3. \"Сравнить две фигуры\";");
                Console.WriteLine("4. \"Посчитать стоимость материалов\";");
                Console.WriteLine("5. \"Общая площадь\";");
                Console.WriteLine("0. \"Выбор урока\".");

                try {
                    switch (InputHelper.GetMenuPositiveInteger("\nВведите номер задания (0 - выбор урока): ", "0, 1, 2, 3, 4 или 5")) {
                        case 0:
                            return;
                        case 1:
                            AddFigureMenu(storage);
                            break;
                        case 2:
                            ShowAllFigures(storage);
                            break;
                        case 3:
                            CompareFigures(storage);
                            break;
                        case 4:
                            CalculateCost(storage);
                            break;
                        case 5:
                            Console.WriteLine("Общая площадь всех фигур: " + storage.GetTotalArea());
                            break;
                        default:
                            Console.WriteLine("Задания с таким номером не существует!");
                            break;
                    }
                } catch (TaskResetException) {
                    continue;
                }
                if (!InputHelper.AskContinue("Продолжить работу с практикой?")) break;
            }
        }

        static void AddFigureMenu(FigureStorage storage) {
            Console.WriteLine("\nВыберите тип фигуры:");
            Console.WriteLine("1. Круг");
            Console.WriteLine("2. Прямоугольник");
            Console.WriteLine("3. Треугольник");
            int type = InputHelper.GetMenuPositiveInteger("Введите номер: ", "1, 2 или 3");
            string color = InputHelper.GetString("Введите цвет фигуры: ");
            string name = InputHelper.GetString("Введите название фигуры: ");

            switch (type) {
                case 1:
                    double radius = InputHelper.GetPositiveDouble("Введите радиус: ");
                    storage.AddFigure(new Circle(color, name, radius));
                    break;
                case 2:
                    double width = InputHelper.GetPositiveDouble("Введите ширину: ");
                    double height = InputHelper.GetPositiveDouble("Введите высоту: ");
                    storage.AddFigure(new Rectangle(color, name, width, height));
                    break;
                case 3:
                    double a = InputHelper.GetPositiveDouble("Введите сторону A: ");
                    double b = InputHelper.GetPositiveDouble("Введите сторону B: ");
                    double c = InputHelper.GetPositiveDouble("Введите сторону C: ");
                    storage.AddFigure(new Triangle(color, name, a, b, c));
                    break;
                default:
                    Console.WriteLine("Неверный тип фигуры!");
                    return;
            }
            Console.WriteLine("Фигура успешно добавлена!");
        }

        static void ShowAllFigures(FigureStorage storage) {
            Figure[] figures = storage.GetAll();
            if (figures.Length == 0) {
                Console.WriteLine("Нет добавленных фигур!");
                return;
            }
            Console.WriteLine("\nВсе фигуры:");
            for (int i = 0; i < figures.Length; i++) {
                Console.WriteLine((i + 1) + ". " + figures[i].GetInfo());
            }
        }

        static void CompareFigures(FigureStorage storage) {
            Figure[] figures = storage.GetAll();
            if (figures.Length < 2) {
                Console.WriteLine("Недостаточно фигур для сравнения!");
                return;
            }
            ShowAllFigures(storage);
            int idx1 = InputHelper.GetPositiveInteger("Введите индекс первой фигуры: ") - 1;
            int idx2 = InputHelper.GetPositiveInteger("Введите индекс второй фигуры: ") - 1;
            if (idx1 < 0 || idx1 >= figures.Length || idx2 < 0 || idx2 >= figures.Length) {
                Console.WriteLine("Неверный индекс!");
                return;
            }
            Figure f1 = figures[idx1];
            Figure f2 = figures[idx2];
            Console.WriteLine(f1.Name + " " + (f1 > f2 ? "больше" : f1 < f2 ? "меньше" : "равна") + " " + f2.Name + " по площади.");
        }

        static void CalculateCost(FigureStorage storage) {
            Figure[] figures = storage.GetAll();
            if (figures.Length == 0) {
                Console.WriteLine("Нет добавленных фигур!");
                return;
            }
            double price = InputHelper.GetPositiveDouble("Введите цену за кв.м: ");
            Console.WriteLine("\nСтоимость материалов:");
            for (int i = 0; i < figures.Length; i++) {
                if (figures[i] is ICostable costable) {
                    Console.WriteLine((i + 1) + ". " + figures[i].Name + ": " + costable.CalculateMaterialCost(price));
                }
            }
        }
    }
}

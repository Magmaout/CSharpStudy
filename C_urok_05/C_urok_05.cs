namespace CSharpStudy {
    internal static class C_urok_05 {
        public static void Run() {
            while (true) {
                InputHelper.ClearConsole();
                Console.WriteLine("Урок №5:");
                Console.WriteLine("1. \"Класс Абитуриент\" (П3:В1);");
                Console.WriteLine("2. \"Классы Вклад и Кредит\" (П3:В2);");
                Console.WriteLine("3. \"Матрица с перегрузкой операторов\".");
                try {
                    switch (InputHelper.GetMenuPositiveInteger("\nВведите номер задачи (0 - выбор урока): ", "0, 1, 2 или 3")) {
                        case 0:
                            return;
                        case 1:
                            string fullName = InputHelper.GetString("Введите ФИО абитуриента: ");
                            double averageMark = InputHelper.GetPositiveDouble("Введите средний балл аттестата: ");
                            int achievementPoints = InputHelper.GetPositiveInteger("Введите баллы за личные достижения: ");
                            Applicant applicant = new Applicant(fullName, averageMark, achievementPoints, DateTime.Now);
                            Console.WriteLine("Абитуриент проходит: " + Admission.IsPassed(applicant));
                            break;
                        case 2:
                            Deposit deposit = new Deposit("Петров Петр", 10000);
                            deposit++;
                            Console.WriteLine(deposit.Info());
                            Credit credit = new Credit("Петров Петр", 20000);
                            credit = credit - 5000;
                            Console.WriteLine(credit.Info());
                            break;
                        case 3:
                            Matrix m1 = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
                            Matrix m2 = new Matrix(new double[,] { { 5, 6 }, { 7, 8 } });
                            Console.WriteLine("m1 + m2:\n" + (m1 + m2));
                            Console.WriteLine("m1 * m2:\n" + (m1 * m2));
                            Console.WriteLine("m1 + 10:\n" + (m1 + 10));
                            Console.WriteLine("m2 > m1: " + (m2 > m1));
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

    internal struct LinearEquation {
        public int A;
        public int B;
        public LinearEquation(int a, int b) { A = a; B = b; }
        public static LinearEquation Parse(string text) {
            string[] parts = text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return new LinearEquation(int.Parse(parts[0]), int.Parse(parts[1]));
        }
        public static bool Solve(LinearEquation first, LinearEquation second, out double x, out double y) {
            x = 0; y = 0;
            double determinant = first.A * second.B - second.A * first.B;
            return determinant != 0;
        }
        public override string ToString() => A + "*X + " + B + "*Y = 0";
    }

    internal class Complex {
        public double Re { get; }
        public double Im { get; }
        public Complex(double re, double im) { Re = re; Im = im; }
        public static Complex operator +(Complex a, Complex b) => new Complex(a.Re + b.Re, a.Im + b.Im);
        public static Complex operator -(Complex a, Complex b) => new Complex(a.Re - b.Re, a.Im - b.Im);
        public static Complex operator -(Complex a, double b) => new Complex(a.Re - b, a.Im);
        public static Complex operator *(Complex a, Complex b) => new Complex(a.Re * b.Re - a.Im * b.Im, a.Re * b.Im + a.Im * b.Re);
        public static Complex operator *(double a, Complex b) => new Complex(a * b.Re, a * b.Im);
        public static Complex operator /(Complex a, Complex b) {
            double denominator = b.Re * b.Re + b.Im * b.Im;
            return new Complex((a.Re * b.Re + a.Im * b.Im) / denominator, (a.Im * b.Re - a.Re * b.Im) / denominator);
        }
        public override string ToString() => Math.Round(Re, 2) + (Im >= 0 ? " + " : " - ") + Math.Round(Math.Abs(Im), 2) + "i";
    }

    internal class Fraction {
        public int Numerator { get; }
        public int Denominator { get; }
        public Fraction(int numerator, int denominator) {
            if (denominator == 0) throw new DivideByZeroException();
            int gcd = Gcd(Math.Abs(numerator), Math.Abs(denominator));
            Numerator = denominator < 0 ? -numerator / gcd : numerator / gcd;
            Denominator = Math.Abs(denominator) / gcd;
        }
        static int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);
        public static Fraction operator +(Fraction a, Fraction b) => new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        public static Fraction operator +(Fraction a, double b) => a + FromDouble(b);
        public static Fraction operator -(Fraction a, Fraction b) => new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        public static Fraction operator *(Fraction a, int b) => new Fraction(a.Numerator * b, a.Denominator);
        public static Fraction operator *(int a, Fraction b) => b * a;
        public static Fraction operator /(Fraction a, Fraction b) => new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        public static bool operator ==(Fraction a, Fraction b) => a.Numerator == b.Numerator && a.Denominator == b.Denominator;
        public static bool operator !=(Fraction a, Fraction b) => !(a == b);
        public static bool operator <(Fraction a, Fraction b) => a.Numerator * b.Denominator < b.Numerator * a.Denominator;
        public static bool operator >(Fraction a, Fraction b) => a.Numerator * b.Denominator > b.Numerator * a.Denominator;
        public static bool operator true(Fraction a) => Math.Abs(a.Numerator) < Math.Abs(a.Denominator);
        public static bool operator false(Fraction a) => Math.Abs(a.Numerator) > Math.Abs(a.Denominator);
        static Fraction FromDouble(double value) => new Fraction((int)(value * 10), 10);
        public override bool Equals(object? obj) => obj is Fraction f && this == f;
        public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);
        public override string ToString() => Numerator + "/" + Denominator;
    }

    internal class Applicant {
        public string FullName { get; }
        public double AverageMark { get; }
        public int AchievementPoints { get; }
        public DateTime ApplyDate { get; }
        public Applicant(string fullName, double averageMark, int achievementPoints, DateTime applyDate) { FullName = fullName; AverageMark = averageMark; AchievementPoints = achievementPoints; ApplyDate = applyDate; }
        public static bool operator >(Applicant a, Applicant b) => a.AverageMark == b.AverageMark ? a.AchievementPoints > b.AchievementPoints : a.AverageMark > b.AverageMark;
        public static bool operator <(Applicant a, Applicant b) => a.AverageMark == b.AverageMark ? a.AchievementPoints < b.AchievementPoints : a.AverageMark < b.AverageMark;
    }

    internal static class Admission {
        public static double PassMark = 4.5;
        public static bool IsPassed(Applicant applicant) => applicant.AverageMark >= PassMark;
    }

    internal class Deposit {
        static double percent = 5;
        string fullName; double sum;
        public Deposit(string fullName, double sum) { this.fullName = fullName; this.sum = sum; }
        public static Deposit operator ++(Deposit deposit) { deposit.sum += deposit.sum * percent / 100; return deposit; }
        public static double GetPercent() => percent;
        public string Info() => fullName + ", вклад: " + Math.Round(sum, 2);
    }

    internal class Credit {
        static double percent = 12;
        string fullName; double sum;
        public Credit(string fullName, double sum) { this.fullName = fullName; this.sum = sum; }
        public static Credit operator -(Credit credit, double payment) { credit.sum -= payment; return credit; }
        public static double GetPercent() => percent;
        public string Info() => fullName + ", остаток кредита: " + Math.Round(sum, 2);
    }

    internal class Matrix {
        double[,] data;
        public int Rows => data.GetLength(0);
        public int Cols => data.GetLength(1);
        public double this[int row, int col] { get => data[row, col]; set => data[row, col] = value; }
        public Matrix(double[,] data) { this.data = data; }
        public static Matrix operator +(Matrix a, Matrix b) => ElementOperation(a, b, (x, y) => x + y);
        public static Matrix operator -(Matrix a, Matrix b) => ElementOperation(a, b, (x, y) => x - y);
        public static Matrix operator +(Matrix a, double b) => NumberOperation(a, x => x + b);
        public static Matrix operator -(Matrix a, double b) => NumberOperation(a, x => x - b);
        public static Matrix operator *(Matrix a, double b) => NumberOperation(a, x => x * b);
        public static Matrix operator *(double a, Matrix b) => b * a;
        public static Matrix operator *(Matrix a, Matrix b) {
            if (a.Cols != b.Rows) throw new Exception("Матрицы нельзя умножить!");
            Matrix result = new Matrix(new double[a.Rows, b.Cols]);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < b.Cols; j++)
                    for (int k = 0; k < a.Cols; k++) result[i, j] += a[i, k] * b[k, j];
            return result;
        }
        public static bool operator >(Matrix a, Matrix b) => a.Sum() > b.Sum();
        public static bool operator <(Matrix a, Matrix b) => a.Sum() < b.Sum();
        double Sum() {
            double sum = 0;
            foreach (double item in data) sum += item;
            return sum;
        }
        static Matrix ElementOperation(Matrix a, Matrix b, Func<double, double, double> operation) {
            if (a.Rows != b.Rows || a.Cols != b.Cols) throw new Exception("Размеры матриц не совпадают!");
            Matrix result = new Matrix(new double[a.Rows, a.Cols]);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++) result[i, j] = operation(a[i, j], b[i, j]);
            return result;
        }
        static Matrix NumberOperation(Matrix a, Func<double, double> operation) {
            Matrix result = new Matrix(new double[a.Rows, a.Cols]);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++) result[i, j] = operation(a[i, j]);
            return result;
        }
        public override string ToString() {
            string text = "";
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Cols; j++) text += data[i, j] + " ";
                text += Environment.NewLine;
            }
            return text;
        }
    }
}

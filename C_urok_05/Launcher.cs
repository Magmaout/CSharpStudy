using CSharpStudy.C_urok_05.matrix;
using CSharpStudy.C_urok_05.deposit;
using CSharpStudy.C_urok_05.college;

namespace CSharpStudy.C_urok_05 {
    internal static class Launcher {
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
                            Console.WriteLine("Абитуриент проходит: " + Launcher.IsPassed(applicant));
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

        public static double PassMark = 4.5;

        public static bool IsPassed(Applicant applicant) => applicant.AverageMark >= PassMark;
    }
}

namespace CSharpStudy {
    internal static class C_urok_01 {
        public static void Run() {
            while (true) {
                InputHelper.ClearConsole();
                Console.WriteLine("Урок №1:");
                Console.WriteLine("1. \"Кол-во квадратов в прямоугольнике и остаточная площадь\";");
                Console.WriteLine("2. \"Кол-во месяцев через которое вклад превысит 11тр и его итоговый размер\";");
                Console.WriteLine("3. \"Вывод чисел в указанном диапазоне в кол-ве их значений\";");
                Console.WriteLine("4. \"Перевернуть число\".");
                int A, B;
                try {
                    switch (InputHelper.GetMenuPositiveInteger("\nВведите номер задачи (0 - выбор урока): ", "0, 1, 2, 3 или 4")) {
                        case 0:
                            return;
                        case 1:
                            Console.WriteLine("\nЗадача 1 \"Кол-во квадратов в прямоугольнике и остаточная площадь\":");
                            A = InputHelper.GetPositiveInteger("Введите переменную A: ");
                            B = InputHelper.GetPositiveInteger("Введите переменную B: ");
                            int C = InputHelper.GetPositiveInteger("Введите переменную C: ");
                            if (C == 0 || C > A || C > B) {
                                Console.WriteLine("Невозможно разместить ни одного квадрата!");
                            }
                            else {
                                int squaresCount = (A / C) * (B / C);
                                int freeArea = A * B - squaresCount * C * C;
                                Console.WriteLine("Количество квадратов: " + squaresCount);
                                Console.WriteLine("Площадь незанятой части: " + freeArea);
                            }
                            break;
                        case 2:
                            Console.WriteLine("\nЗадача 2 \"Кол-во месяцев через которое вклад превысит 11тр и его итоговый размер\":");
                            double P = InputHelper.GetPositiveDouble("Введите число P (0 < P < 25): ", "число больше 0 и меньше 25"), deposit = 10000;
                            int months = 0;
                            while (P <= 0 || P >= 25) {
                                P = InputHelper.GetPositiveDouble("Введите число P строго в диапазоне (0; 25): ", "число больше 0 и меньше 25");
                            }
                            while (deposit <= 11000) {
                                deposit += deposit * P / 100;
                                months++;
                            }
                            Console.WriteLine("Количество месяцев: " + months);
                            Console.WriteLine("Итоговый размер вклада: " + Math.Round(deposit, 2));
                            break;
                        case 3:
                            Console.WriteLine("\nЗадача 3 \"Вывод чисел в указанном диапазоне в кол-ве их значений\":");
                            do {
                                A = InputHelper.GetPositiveInteger("Введите число A: ");
                                B = InputHelper.GetPositiveInteger("Введите число B (должно быть больше A): ");
                            } while (A >= B);
                            for (int i = A; i <= B; i++) {
                                for (int j = 0; j < i; j++) Console.Write(i + " ");
                                Console.WriteLine();
                            }
                            break;
                        case 4:
                            Console.WriteLine("\nЗадача 4 \"Перевернуть число\":");
                            int N = InputHelper.GetPositiveInteger("Введите число N: "), reversed = 0;
                            while (N > 0) {
                                reversed = reversed * 10 + N % 10;
                                N /= 10;
                            }
                            Console.WriteLine("Число наоборот: " + reversed);
                            break;
                        default:
                            Console.WriteLine("\nЗадания с таким номером не существует!");
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

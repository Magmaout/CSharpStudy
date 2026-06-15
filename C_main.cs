namespace CSharpStudy {
    internal class C_main {
        static void Main(string[] args) {
            while (true) {
                InputHelper.ClearConsole();
                Console.WriteLine("Главное меню для проверки заданий по C#:");
                Console.WriteLine("1.  \"Урок 1\";");
                Console.WriteLine("2.  \"Урок 2\";");
                Console.WriteLine("3.  \"Урок 3\";");
                Console.WriteLine("4.  \"Урок 4\";");
                Console.WriteLine("5.  \"Урок 5\";");
                Console.WriteLine("6.  \"Урок 6\";");
                Console.WriteLine("7.  \"Урок 7\";");
                Console.WriteLine("8.  \"Урок 8\".");
                Console.WriteLine("9.  \"Практ 1\".");
                Console.WriteLine("10. \"Практ 2\".");
                Console.WriteLine("11. \"Практ 3\".");

                switch (InputHelper.GetMenuPositiveInteger("\nВведите номер урока (0 - выход): ", "0-11")) {
                    case 0:
                        return;
                    case 1:
                        C_urok_01.Run();
                        break;
                    case 2:
                        C_urok_02.Run();
                        break;
                    case 3:
                        C_urok_03.Run();
                        break;
                    case 4:
                        C_urok_04.Run();
                        break;
                    case 5:
                        C_urok_05.Run();
                        break;
                    case 6:
                        C_urok_06.Run();
                        break;
                    case 7:
                        C_urok_07.Run();
                        break;
                    case 8:
                        C_urok_08.Run();
                        break;
                    case 9:
                        C_pract_01.Run();
                        break;
                    case 10:
                        C_pract_02.Run();
                        break;
                    case 11:
                        C_pract_03.Run();
                        break;
                    default:
                        Console.WriteLine("Урок с таким номером не найден!");
                        Console.ReadKey(true);
                        break;
                }
            }
        }
    }

    internal class TaskResetException : Exception {}

    internal static class InputHelper {
        public static string GetString() {
            string? input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? "" : input.Trim();
        }

        public static string GetString(string prompt, string hint = "строка не должна быть пустой") {
            string currentPrompt = prompt;
            while (true) {
                int line = GetCursorTop();
                Console.Write(currentPrompt);
                string input = GetString();
                if (input.Length > 0) return input;
                if (AskStopTask()) throw new Exception();
                RewriteInputLine(line);
                currentPrompt = AddHint(prompt, hint);
            }
        }

        public static int GetMenuPositiveInteger(string prompt, string hint) {
            string currentPrompt = prompt;
            while (true) {
                int line = GetCursorTop();
                Console.Write(currentPrompt);
                string input = GetString();
                if (input.Length == 0) return 0;
                if (int.TryParse(input, out int number) && number >= 0) return number;
                RewriteInputLine(line);
                currentPrompt = AddHint(prompt, hint);
            }
        }

        public static int GetPositiveInteger() {
            return GetPositiveInteger("Введите целое число не меньше 0: ");
        }

        public static int GetPositiveInteger(string prompt, string hint = "целое число не меньше 0") {
            string currentPrompt = prompt;
            while (true) {
                int line = GetCursorTop();
                Console.Write(currentPrompt);
                string input = GetString();
                if (input.Length == 0) {
                    if (AskStopTask()) throw new Exception();
                    RewriteInputLine(line);
                    currentPrompt = AddHint(prompt, hint);
                    continue;
                }
                if (int.TryParse(input, out int number) && number >= 0) return number;
                RewriteInputLine(line);
                currentPrompt = AddHint(prompt, hint);
            }
        }

        public static int GetInteger() {
            return GetInteger("Введите целое число: ");
        }

        public static int GetInteger(string prompt, string hint = "целое число") {
            string currentPrompt = prompt;
            while (true) {
                int line = GetCursorTop();
                Console.Write(currentPrompt);
                string input = GetString();
                if (input.Length == 0) {
                    if (AskStopTask()) throw new Exception();
                    RewriteInputLine(line);
                    currentPrompt = AddHint(prompt, hint);
                    continue;
                }
                if (int.TryParse(input, out int number)) return number;
                RewriteInputLine(line);
                currentPrompt = AddHint(prompt, hint);
            }
        }

        public static double GetPositiveDouble() {
            return GetPositiveDouble("Введите число не меньше 0: ");
        }

        public static double GetPositiveDouble(string prompt, string hint = "число не меньше 0") {
            string currentPrompt = prompt;
            while (true) {
                int line = GetCursorTop();
                Console.Write(currentPrompt);
                string input = GetString().Replace('.', ',');
                if (input.Length == 0) {
                    if (AskStopTask()) throw new Exception();
                    RewriteInputLine(line);
                    currentPrompt = AddHint(prompt, hint);
                    continue;
                }
                if (double.TryParse(input, out double number) && number >= 0) return number;
                RewriteInputLine(line);
                currentPrompt = AddHint(prompt, hint);
            }
        }

        public static double GetDouble() {
            return GetDouble("Введите число: ");
        }

        public static double GetDouble(string prompt, string hint = "число") {
            string currentPrompt = prompt;
            while (true) {
                int line = GetCursorTop();
                Console.Write(currentPrompt);
                string input = GetString().Replace('.', ',');
                if (input.Length == 0) {
                    if (AskStopTask()) throw new Exception();
                    RewriteInputLine(line);
                    currentPrompt = AddHint(prompt, hint);
                    continue;
                }
                if (double.TryParse(input, out double number)) return number;
                RewriteInputLine(line);
                currentPrompt = AddHint(prompt, hint);
            }
        }

        public static DateTime GetDateTime() {
            return GetDateTime("Введите дату и время: ");
        }

        public static DateTime GetDateTime(string prompt, string hint = "пример: 24.05.2026 18:30") {
            string currentPrompt = prompt;
            while (true) {
                int line = GetCursorTop();
                Console.Write(currentPrompt);
                string input = GetString();
                if (input.Length == 0) {
                    if (AskStopTask()) throw new Exception();
                    RewriteInputLine(line);
                    currentPrompt = AddHint(prompt, hint);
                    continue;
                }
                if (DateTime.TryParse(input, out DateTime date)) return date;
                RewriteInputLine(line);
                currentPrompt = AddHint(prompt, hint);
            }
        }

        public static bool AskContinue(string text) {
            string prompt = text + " (0 - нет, 1 - да): ";
            while (true) {
                int line = GetCursorTop();
                Console.Write(prompt);
                string input = GetString();
                if (input.Length == 0) return false;
                if (input == "0") return false;
                if (input == "1") return true;
                RewriteInputLine(line);
            }
        }

        public static bool AskStopTask() {
            while (true) {
                int line = GetCursorTop();
                Console.Write("Хотите остановить задачу? (0 - нет, 1 - да): ");
                string input = GetString();
                if (input == "0") return true;
                if (input == "1") return false;
                RewriteInputLine(line);
            }
        }

        public static void ClearConsole() {
            try {
                Console.Clear();
            } catch (IOException) {
                Console.WriteLine();
            }
        }

        static string AddHint(string prompt, string hint) {
            int index = prompt.LastIndexOf(':');
            if (index < 0) return prompt + " (" + hint + "): ";
            return prompt.Substring(0, index) + " (" + hint + ")" + prompt.Substring(index);
        }

        static void RewriteInputLine(int line) {
            try {
                int bottom = GetCursorTop();
                for (int i = bottom; i >= line; i--) {
                    Console.SetCursorPosition(0, i);
                    Console.Write(new string(' ', Math.Max(Console.WindowWidth - 1, 1)));
                }
                Console.SetCursorPosition(0, line);
            } catch (IOException) {
                Console.WriteLine();
            }
        }

        static int GetCursorTop() {
            try {
                return Console.CursorTop;
            } catch (IOException) {
                return 0;
            }
        }
    }
}

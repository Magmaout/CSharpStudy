namespace CSharpStudy.C_urok_02 {
    internal static class Launcher {
        public static void Run() {
            while (true) {
                InputHelper.ClearConsole();
                Console.WriteLine("Урок №2:");
                Console.WriteLine("1. \"Сжать массив, удалив 0 и заполнив справа -1\";");
                Console.WriteLine("2. \"Сначала отрицательные, потом положительные\";");
                Console.WriteLine("3. \"Посчитать число в массиве\";");
                Console.WriteLine("4. \"Поменять местами столбцы двумерного массива\".");
                try {
                    switch (InputHelper.GetMenuPositiveInteger("\nВведите номер задачи (0 - выбор урока): ", "0, 1, 2, 3 или 4")) {
                        case 0:
                            return;
                        case 1:
                            int[] array1 = ReadArray();
                            int index = 0;
                            for (int i = 0; i < array1.Length; i++) {
                                if (array1[i] != 0) array1[index++] = array1[i];
                            }
                            while (index < array1.Length) array1[index++] = -1;
                            PrintArray(array1);
                            break;
                        case 2:
                            int[] array2 = ReadArray();
                            int[] sorted = array2.Where(x => x < 0).Concat(array2.Where(x => x >= 0)).ToArray();
                            PrintArray(sorted);
                            break;
                        case 3:
                            int[] array3 = ReadArray();
                            int number = InputHelper.GetInteger("Введите число для поиска: ");
                            Console.WriteLine("Количество повторений: " + array3.Count(x => x == number));
                            break;
                        case 4:
                            int rows = InputHelper.GetPositiveInteger("Введите количество строк M: ");
                            int cols = InputHelper.GetPositiveInteger("Введите количество столбцов N: ");
                            int[,] matrix = new int[rows, cols];
                            for (int i = 0; i < rows; i++) {
                                for (int j = 0; j < cols; j++) {
                                    matrix[i, j] = InputHelper.GetInteger("matrix[" + i + "," + j + "] = ");
                                }
                            }
                            int first = InputHelper.GetPositiveInteger("Введите первый столбец: ");
                            int second = InputHelper.GetPositiveInteger("Введите второй столбец: ");
                            if (first >= cols || second >= cols) {
                                Console.WriteLine("Такого столбца нет!");
                            }
                            else {
                                for (int i = 0; i < rows; i++) {
                                    int temp = matrix[i, first];
                                    matrix[i, first] = matrix[i, second];
                                    matrix[i, second] = temp;
                                }
                                PrintMatrix(matrix);
                            }
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

        static int[] ReadArray() {
            int size = InputHelper.GetPositiveInteger("Введите размер массива: ");
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++) {
                array[i] = InputHelper.GetInteger("array[" + i + "] = ");
            }
            return array;
        }

        static void PrintArray(int[] array) {
            Console.WriteLine("Массив: " + string.Join(" ", array));
        }

        static void PrintMatrix(int[,] matrix) {
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}

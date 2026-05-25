namespace CSharpStudy {
    internal static class C_urok_08 {
        public static void Run() {
            while (true) {
                InputHelper.ClearConsole();
                Console.WriteLine("Урок №8:");
                Console.WriteLine("1. \"Показ фильма\";");
                Console.WriteLine("2. \"Покупка\";");
                Console.WriteLine("3. \"Подсчет слов через Dictionary\".");
                try {
                    switch (InputHelper.GetMenuPositiveInteger("\nВведите номер задачи (0 - выбор урока): ", "0, 1, 2 или 3")) {
                        case 0:
                            return;
                        case 1:
                            FilmShowTask();
                            break;
                        case 2:
                            PurchaseTask();
                            break;
                        case 3:
                            WordsTask();
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

        static void FilmShowTask() {
            List<FilmShow> shows = new List<FilmShow> {
                new FilmShow("Интерстеллар", "Зал 1", new DateTime(2026, 5, 12, 18, 0, 0), 120, 350),
                new FilmShow("Матрица", "Зал 2", new DateTime(2026, 5, 12, 20, 0, 0), 80, 300),
                new FilmShow("Начало", "Зал 3", new DateTime(2026, 5, 13, 18, 30, 0), 100, 320),
                new FilmShow("Дюна", "Зал 1", new DateTime(2026, 5, 13, 21, 0, 0), 120, 400),
                new FilmShow("Аватар", "Зал 4", new DateTime(2026, 5, 14, 19, 0, 0), 150, 450)
            };

            while (true) {
                Console.WriteLine("\n1. \"Посмотреть весь список\";");
                Console.WriteLine("2. \"Найти показ фильма\";");
                Console.WriteLine("3. \"Создать новый показ\".");
                switch (InputHelper.GetMenuPositiveInteger("Введите действие (0 - завершить задачу): ", "0, 1, 2 или 3")) {
                    case 0:
                        return;
                    case 1:
                        shows = shows.OrderBy(x => x.FilmName).ToList();
                        PrintFilmShows(shows);
                        break;
                    case 2:
                        List<int> foundIndexes = FindFilmShows(shows);
                        if (foundIndexes.Count == 0) {
                            Console.WriteLine("Показ не найден.");
                            break;
                        }

                        Console.WriteLine("Найденные показы:");
                        for (int i = 0; i < foundIndexes.Count; i++) {
                            Console.WriteLine((i + 1) + ". " + shows[foundIndexes[i]].Info);
                        }

                        if (InputHelper.AskContinue("Удалить найденный показ?")) {
                            int deleteIndex = 0;
                            if (foundIndexes.Count > 1) {
                                deleteIndex = InputHelper.GetPositiveInteger("Введите номер показа из найденного списка: ", "целое число от 1 до " + foundIndexes.Count) - 1;
                                while (deleteIndex < 0 || deleteIndex >= foundIndexes.Count) {
                                    deleteIndex = InputHelper.GetPositiveInteger("Введите номер показа из найденного списка: ", "целое число от 1 до " + foundIndexes.Count) - 1;
                                }
                            }
                            shows.RemoveAt(foundIndexes[deleteIndex]);
                            Console.WriteLine("Показ удален.");
                        }
                        break;
                    case 3:
                        string name = InputHelper.GetString("Название фильма: ");
                        int hallNumber = InputHelper.GetPositiveInteger("Номер зала: ", "целое число");
                        DateTime date = InputHelper.GetDateTime("Дата и время (пример: 24.05.2026 18:30): ");
                        int seats = InputHelper.GetPositiveInteger("Количество мест: ");
                        double price = InputHelper.GetPositiveDouble("Стоимость билета: ");
                        if (shows.Any(x => x.Hall == "Зал " + hallNumber && x.ShowDate == date)) {
                            Console.WriteLine("Нельзя создать показ: в этом зале на это время уже есть фильм.");
                            break;
                        }
                        shows.Add(new FilmShow(name, "Зал " + hallNumber, date, seats, price));
                        Console.WriteLine("Показ добавлен.");
                        break;
                    default:
                        Console.WriteLine("Действия с таким номером не существует!");
                        break;
                }
            }
        }

        static void PrintFilmShows(List<FilmShow> shows) {
            for (int i = 0; i < shows.Count; i++) {
                Console.WriteLine((i + 1) + ". " + shows[i].Info + ", полный зал: " + shows[i].GetIncome());
            }
        }

        static List<int> FindFilmShows(List<FilmShow> shows) {
            Console.Write("Название фильма (можно оставить пустым): ");
            string searchName = InputHelper.GetString();
            Console.Write("Дата или дата и время (пример: 24.05.2026 или 24.05.2026 18:30): ");
            string dateText = InputHelper.GetString();

            DateTime? searchDate = null;
            bool dateOnly = false;
            if (dateText.Length > 0) {
                while (!DateTime.TryParse(dateText, out DateTime parsedDate)) {
                    Console.Write("Дата или дата и время (пример: 24.05.2026 или 24.05.2026 18:30): ");
                    dateText = InputHelper.GetString();
                }
                searchDate = DateTime.Parse(dateText);
                dateOnly = !dateText.Contains(":");
            }

            List<int> result = new List<int>();
            for (int i = 0; i < shows.Count; i++) {
                bool nameMatches = searchName.Length == 0 || shows[i].FilmName.Contains(searchName, StringComparison.OrdinalIgnoreCase);
                bool dateMatches = !searchDate.HasValue || (dateOnly ? shows[i].ShowDate.Date == searchDate.Value.Date : shows[i].ShowDate == searchDate.Value);
                if (nameMatches && dateMatches) result.Add(i);
            }
            return result;
        }

        static void PurchaseTask() {
            CardPayment card = new CardPayment("1111 2222 3333 4444", new DateTime(2026, 1, 1), "Иванов Иван", "123", 2500);
            Purchase<CardPayment> cardPurchase = new Purchase<CardPayment>("89990000000", card, 2500);
            CashPayment cash = new CashPayment(500, 1500);
            Purchase<CashPayment> cashPurchase = new Purchase<CashPayment>("89991111111", cash, 1500);
            Console.WriteLine(cardPurchase.GetInfo());
            Console.WriteLine(cashPurchase.GetInfo());
        }

        static void WordsTask() {
            string text = InputHelper.GetString("Введите текст: ").ToLower();
            Dictionary<string, int> words = new Dictionary<string, int>();
            char[] separators = new char[] { ' ', ',', '.', '!', '?', ':', ';', '-', '(', ')', '\t' };
            foreach (string word in text.Split(separators, StringSplitOptions.RemoveEmptyEntries)) {
                if (!words.ContainsKey(word)) words[word] = 0;
                words[word]++;
            }

            Console.WriteLine("Слово\tКоличество");
            foreach (KeyValuePair<string, int> item in words.OrderBy(x => x.Key)) {
                Console.WriteLine(item.Key + "\t" + item.Value);
            }
        }
    }

    internal struct FilmShow {
        public string FilmName;
        public string Hall;
        public DateTime ShowDate;
        public int SeatsCount;
        public double TicketPrice;
        public string Info => FilmName + ", " + Hall + ", " + ShowDate + ", мест: " + SeatsCount + ", билет: " + TicketPrice;
        public FilmShow(string filmName, string hall, DateTime showDate, int seatsCount, double ticketPrice) {
            FilmName = filmName; Hall = hall; ShowDate = showDate; SeatsCount = seatsCount; TicketPrice = ticketPrice;
        }
        public double GetIncome(int peopleCount = -1) {
            if (peopleCount < 0) peopleCount = SeatsCount;
            if (peopleCount > SeatsCount) peopleCount = SeatsCount;
            return peopleCount * TicketPrice;
        }
    }

    internal interface IPayment {
        static string PaymentName = "Оплата";
        double PaymentSum { get; set; }
        string GetInfo();
    }

    internal struct CardPayment : IPayment {
        public string CardNumber;
        public DateTime IssueDate;
        public string Owner;
        public string Cvc;
        public double PaymentSum { get; set; }
        public CardPayment(string cardNumber, DateTime issueDate, string owner, string cvc, double paymentSum) {
            CardNumber = cardNumber; IssueDate = issueDate; Owner = owner; Cvc = cvc; PaymentSum = paymentSum;
        }
        public string GetInfo() => "Безналичный расчет, карта: " + CardNumber + ", владелец: " + Owner + ", сумма: " + PaymentSum;
    }

    internal struct CashPayment : IPayment {
        public double Change;
        public double PaymentSum { get; set; }
        public CashPayment(double change, double paymentSum) {
            Change = change; PaymentSum = paymentSum;
        }
        public string GetInfo() => "Наличный расчет, сумма: " + PaymentSum + ", сдача: " + Change;
    }

    internal class Purchase<T> where T : IPayment {
        string phone;
        T payment;
        double sum;
        public Purchase(string phone, T payment, double sum) {
            this.phone = phone; this.payment = payment; this.sum = sum;
        }
        public string GetInfo() => "Телефон: " + phone + ", сумма покупки: " + sum + ", " + payment.GetInfo();
    }
}

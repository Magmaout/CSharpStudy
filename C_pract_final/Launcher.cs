using CSharpStudy.C_pract_final.artifacts;
using CSharpStudy.C_pract_final.processors;

namespace CSharpStudy.C_pract_final {
    internal static class Launcher {
        private static ShopManager _shopManager = null!;
        private const string DataFolder = "C_pract_final/data";
        private const string XmlPath = "C_pract_final/data/antique.xml";
        private const string JsonPath = "C_pract_final/data/modern.json";
        private const string LegendsPath = "C_pract_final/data/legends.txt";

        public static void Run() {
            _shopManager = new ShopManager();
            
            while (true) {
                InputHelper.ClearConsole();
                Console.WriteLine("Практика Final \"Магический магазин артефактов\":");
                Console.WriteLine("1.  \"Загрузить все данные\";");
                Console.WriteLine("2.  \"Показать все артефакты\";");
                Console.WriteLine("3.  \"Найти проклятые артефакты\";");
                Console.WriteLine("4.  \"Группировка по редкости\";");
                Console.WriteLine("5.  \"Топ по силе\";");
                Console.WriteLine("6.  \"Поиск по названию\";");
                Console.WriteLine("7.  \"Фильтр по редкости\";");
                Console.WriteLine("8.  \"Фильтр по мин. силе\";");
                Console.WriteLine("9.  \"Добавить артефакт\";");
                Console.WriteLine("10. \"Удалить артефакт\";");
                Console.WriteLine("11. \"Экспорт в JSON\";");
                Console.WriteLine("12. \"Экспорт в XML\";");
                Console.WriteLine("13. \"Сгенерировать отчет\";");
                Console.WriteLine("14. \"Средняя сила по редкости\";");
                Console.WriteLine("0.  \"Выбор урока\".");

                try {
                    switch (InputHelper.GetMenuPositiveInteger("\nВведите номер задания (0 - выбор урока): ", "0-14")) {
                        case 0:
                            return;
                        case 1:
                            LoadAllData();
                            break;
                        case 2:
                            ShowAllArtifacts();
                            break;
                        case 3:
                            FindCursedArtifacts();
                            break;
                        case 4:
                            GroupByRarity();
                            break;
                        case 5:
                            TopByPower();
                            break;
                        case 6:
                            SearchByName();
                            break;
                        case 7:
                            FilterByRarity();
                            break;
                        case 8:
                            FilterByMinPower();
                            break;
                        case 9:
                            AddArtifact();
                            break;
                        case 10:
                            RemoveArtifact();
                            break;
                        case 11:
                            ExportToJson();
                            break;
                        case 12:
                            ExportToXml();
                            break;
                        case 13:
                            GenerateReport();
                            break;
                        case 14:
                            ShowAveragePowerByRarity();
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

        static void LoadAllData() {
            Console.WriteLine("\n=== Загрузка данных ===");
            try {
                _shopManager.LoadAllData(XmlPath, JsonPath, LegendsPath);
                Console.WriteLine("Все данные успешно загружены!");
            } catch (Exception ex) {
                Console.WriteLine($"Ошибка загрузки: {ex.Message}");
            }
        }

        static void ShowAllArtifacts() {
            Console.WriteLine("\n=== Все артефакты ===");
            var artifacts = _shopManager.GetAllArtifacts();
            if (artifacts.Count == 0) {
                Console.WriteLine("Нет загруженных артефактов! Сначала загрузите данные (пункт 1).");
                return;
            }
            foreach (var artifact in artifacts) {
                Console.WriteLine($"  {artifact.Id}. {artifact.Serialize()}");
            }
        }

        static void FindCursedArtifacts() {
            Console.WriteLine("\n=== Проклятые артефакты (PowerLevel > 50) ===");
            var cursed = _shopManager.FindCursedArtifacts();
            if (cursed.Count == 0) {
                Console.WriteLine("Проклятых артефактов с PowerLevel > 50 не найдено.");
                return;
            }
            foreach (var artifact in cursed) {
                Console.WriteLine($"  {artifact.Id}. {artifact.Name} (Power: {artifact.PowerLevel})");
            }
        }

        static void GroupByRarity() {
            Console.WriteLine("\n=== Группировка по редкости ===");
            var groups = _shopManager.GroupByRarity();
            if (groups.Count == 0) {
                Console.WriteLine("Нет данных для группировки.");
                return;
            }
            foreach (var kvp in groups) {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value} шт.");
            }
        }

        static void TopByPower() {
            Console.WriteLine("\n=== Топ по силе ===");
            int count = InputHelper.GetPositiveInteger("Сколько артефактов показать? ", "число больше 0");
            var top = _shopManager.TopByPower(count);
            if (top.Count == 0) {
                Console.WriteLine("Нет артефактов для отображения.");
                return;
            }
            for (int i = 0; i < top.Count; i++) {
                Console.WriteLine($"  {i + 1}. {top[i].Name} (Power: {top[i].PowerLevel})");
            }
        }

        static void SearchByName() {
            Console.WriteLine("\n=== Поиск по названию ===");
            string name = InputHelper.GetString("Введите название для поиска: ");
            var results = _shopManager.SearchByName(name);
            if (results.Count == 0) {
                Console.WriteLine($"Артефакты с названием '{name}' не найдены.");
                return;
            }
            foreach (var artifact in results) {
                Console.WriteLine($"  {artifact.Id}. {artifact.Serialize()}");
            }
        }

        static void FilterByRarity() {
            Console.WriteLine("\n=== Фильтр по редкости ===");
            Console.WriteLine("1. Common");
            Console.WriteLine("2. Rare");
            Console.WriteLine("3. Epic");
            Console.WriteLine("4. Legendary");
            int choice = InputHelper.GetMenuPositiveInteger("Выберите редкость: ", "1-4");
            Rarity rarity = (Rarity)(choice - 1);
            var filtered = _shopManager.FilterByRarity(rarity);
            if (filtered.Count == 0) {
                Console.WriteLine($"Артефактов редкости {rarity} не найдено.");
                return;
            }
            foreach (var artifact in filtered) {
                Console.WriteLine($"  {artifact.Id}. {artifact.Serialize()}");
            }
        }

        static void FilterByMinPower() {
            Console.WriteLine("\n=== Фильтр по минимальной силе ===");
            int minPower = InputHelper.GetPositiveInteger("Введите минимальный PowerLevel: ");
            var filtered = _shopManager.FilterByMinPower(minPower);
            if (filtered.Count == 0) {
                Console.WriteLine($"Артефактов с PowerLevel >= {minPower} не найдено.");
                return;
            }
            foreach (var artifact in filtered) {
                Console.WriteLine($"  {artifact.Id}. {artifact.Name} (Power: {artifact.PowerLevel})");
            }
        }

        static void AddArtifact() {
            Console.WriteLine("\n=== Добавление артефакта ===");
            Console.WriteLine("Выберите тип артефакта:");
            Console.WriteLine("1. Антикварный (AntiqueArtifact)");
            Console.WriteLine("2. Современный (ModernArtifact)");
            Console.WriteLine("3. Легендарный (LegendaryArtifact)");
            int type = InputHelper.GetMenuPositiveInteger("Введите номер: ", "1-3");

            int id = InputHelper.GetPositiveInteger("Введите ID: ");
            string name = InputHelper.GetString("Введите название: ");
            int powerLevel = InputHelper.GetPositiveInteger("Введите PowerLevel: ");
            Console.WriteLine("1. Common  2. Rare  3. Epic  4. Legendary");
            int rarityChoice = InputHelper.GetMenuPositiveInteger("Выберите редкость: ", "1-4");
            Rarity rarity = (Rarity)(rarityChoice - 1);

            Artifact? artifact = type switch {
                1 => CreateAntiqueArtifact(id, name, powerLevel, rarity),
                2 => CreateModernArtifact(id, name, powerLevel, rarity),
                3 => CreateLegendaryArtifact(id, name, powerLevel, rarity),
                _ => null
            };

            if (artifact != null) {
                _shopManager.AddArtifact(artifact);
            }
        }

        static AntiqueArtifact CreateAntiqueArtifact(int id, string name, int powerLevel, Rarity rarity) {
            int age = InputHelper.GetPositiveInteger("Введите возраст (лет): ");
            string origin = InputHelper.GetString("Введите происхождение: ");
            return new AntiqueArtifact(id, name, powerLevel, rarity, age, origin);
        }

        static ModernArtifact CreateModernArtifact(int id, string name, int powerLevel, Rarity rarity) {
            double techLevel = InputHelper.GetDouble("Введите техно-уровень: ");
            string manufacturer = InputHelper.GetString("Введите производителя: ");
            return new ModernArtifact(id, name, powerLevel, rarity, techLevel, manufacturer);
        }

        static LegendaryArtifact CreateLegendaryArtifact(int id, string name, int powerLevel, Rarity rarity) {
            string curseDesc = InputHelper.GetString("Введите описание проклятия: ");
            bool isCursed = InputHelper.GetMenuPositiveInteger("Проклят? (0 - нет, 1 - да): ", "0 или 1") == 1;
            return new LegendaryArtifact(id, name, powerLevel, rarity, curseDesc, isCursed);
        }

        static void RemoveArtifact() {
            Console.WriteLine("\n=== Удаление артефакта ===");
            int id = InputHelper.GetPositiveInteger("Введите ID артефакта для удаления: ");
            _shopManager.RemoveArtifact(id);
        }

        static void ExportToJson() {
            Console.WriteLine("\n=== Экспорт в JSON ===");
            string path = InputHelper.GetString("Введите путь для файла (например, output.json): ", "путь не должен быть пустым");
            if (!path.EndsWith(".json")) path += ".json";
            _shopManager.ExportAllToJson(path);
        }

        static void ExportToXml() {
            Console.WriteLine("\n=== Экспорт в XML ===");
            string path = InputHelper.GetString("Введите путь для файла (например, output.xml): ", "путь не должен быть пустым");
            if (!path.EndsWith(".xml")) path += ".xml";
            _shopManager.ExportAllToXml(path);
        }

        static void GenerateReport() {
            Console.WriteLine("\n=== Генерация отчета ===");
            string path = InputHelper.GetString("Введите путь для отчета (например, report.txt): ", "путь не должен быть пустым");
            if (!path.EndsWith(".txt")) path += ".txt";
            _shopManager.GenerateReport(path);
        }

        static void ShowAveragePowerByRarity() {
            Console.WriteLine("\n=== Средняя сила по редкости ===");
            var averages = _shopManager.GetAveragePowerByRarity();
            if (averages.Count == 0) {
                Console.WriteLine("Нет данных для расчета.");
                return;
            }
            foreach (var kvp in averages) {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value:F2}");
            }
        }
    }
}

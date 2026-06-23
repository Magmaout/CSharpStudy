using System.Linq;
using System.Text;
using CSharpStudy.C_pract_final.artifacts;
using CSharpStudy.C_pract_final.processors;

namespace CSharpStudy.C_pract_final {
    public class ShopManager {
        private readonly List<Artifact> _artifacts;
        private readonly XmlProcessor _xmlProcessor;
        private readonly JsonProcessor _jsonProcessor;
        private readonly LegendaryProcessor _legendaryProcessor;

        public ShopManager() {
            _artifacts = new List<Artifact>();
            _xmlProcessor = new XmlProcessor();
            _jsonProcessor = new JsonProcessor();
            _legendaryProcessor = new LegendaryProcessor();
        }

        public List<Artifact> GetAllArtifacts() => _artifacts;

        public void LoadAllData(string xmlPath, string jsonPath, string legendsPath) {
            // Загрузка XML (AntiqueArtifact)
            var antiques = _xmlProcessor.LoadData(xmlPath);
            _artifacts.AddRange(antiques.Cast<Artifact>());
            Console.WriteLine($"Загружено антикварных артефактов: {antiques.Count}");

            // Загрузка JSON (ModernArtifact)
            var modern = _jsonProcessor.LoadData(jsonPath);
            _artifacts.AddRange(modern.Cast<Artifact>());
            Console.WriteLine($"Загружено современных артефактов: {modern.Count}");

            // Загрузка текстовых (LegendaryArtifact)
            var legendary = _legendaryProcessor.LoadData(legendsPath);
            _artifacts.AddRange(legendary.Cast<Artifact>());
            Console.WriteLine($"Загружено легендарных артефактов: {legendary.Count}");
        }

        public List<Artifact> FindCursedArtifacts() {
            return _artifacts
                .OfType<LegendaryArtifact>()
                .Where(a => a.IsCursed && a.PowerLevel > 50)
                .Cast<Artifact>()
                .ToList();
        }

        public Dictionary<Rarity, int> GroupByRarity() {
            return _artifacts
                .GroupBy(a => a.Rarity)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public List<Artifact> TopByPower(int count) {
            return _artifacts
                .OrderByDescending(a => a.PowerLevel)
                .Take(count)
                .ToList();
        }

        public Dictionary<Rarity, double> GetAveragePowerByRarity() {
            return _artifacts
                .GroupBy(a => a.Rarity)
                .ToDictionary(g => g.Key, g => g.Average(a => a.PowerLevel));
        }

        public void GenerateReport(string filePath) {
            try {
                var report = new StringBuilder();
                report.AppendLine("=== Отчет по магическому магазину ===\n");

                report.AppendLine($"Всего артефактов: {_artifacts.Count}\n");

                report.AppendLine("Количество по редкости:");
                foreach (var kvp in GroupByRarity()) {
                    report.AppendLine($"  {kvp.Key}: {kvp.Value}");
                }

                report.AppendLine("\nСредний PowerLevel по редкости:");
                foreach (var kvp in GetAveragePowerByRarity()) {
                    report.AppendLine($"  {kvp.Key}: {kvp.Value:F2}");
                }

                report.AppendLine("\nТоп-5 по силе:");
                var top = TopByPower(5);
                for (int i = 0; i < top.Count; i++) {
                    report.AppendLine($"  {i + 1}. {top[i].Name} (Power: {top[i].PowerLevel})");
                }

                report.AppendLine("\nПроклятые артефакты (PowerLevel > 50):");
                var cursed = FindCursedArtifacts();
                if (cursed.Count == 0) {
                    report.AppendLine("  Нет проклятых артефактов с PowerLevel > 50");
                } else {
                    foreach (var artifact in cursed) {
                        report.AppendLine($"  {artifact.Name} (Power: {artifact.PowerLevel})");
                    }
                }

                File.WriteAllText(filePath, report.ToString());
                Console.WriteLine($"Отчет сохранен в {filePath}");
            } catch (Exception ex) {
                Console.WriteLine($"Ошибка сохранения отчета: {ex.Message}");
            }
        }

        public void ExportAllToJson(string filePath) {
            try {
                var json = "[" + string.Join(",", _artifacts.Select(a => a.ExportToJson())) + "]";
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Все артефакты экспортированы в {filePath}");
            } catch (Exception ex) {
                Console.WriteLine($"Ошибка экспорта JSON: {ex.Message}");
            }
        }

        public void ExportAllToXml(string filePath) {
            try {
                var xml = new StringBuilder();
                xml.AppendLine("<ArrayOfArtifact>");
                foreach (var artifact in _artifacts) {
                    xml.AppendLine("  " + artifact.ExportToXml());
                }
                xml.AppendLine("</ArrayOfArtifact>");
                File.WriteAllText(filePath, xml.ToString());
                Console.WriteLine($"Все артефакты экспортированы в {filePath}");
            } catch (Exception ex) {
                Console.WriteLine($"Ошибка экспорта XML: {ex.Message}");
            }
        }

        public void AddArtifact(Artifact artifact) {
            _artifacts.Add(artifact);
            Console.WriteLine($"Артефакт '{artifact.Name}' добавлен!");
        }

        public void RemoveArtifact(int id) {
            var artifact = _artifacts.FirstOrDefault(a => a.Id == id);
            if (artifact != null) {
                _artifacts.Remove(artifact);
                Console.WriteLine($"Артефакт '{artifact.Name}' удален!");
            } else {
                Console.WriteLine($"Артефакт с ID {id} не найден!");
            }
        }

        public List<Artifact> SearchByName(string name) {
            return _artifacts.Where(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Artifact> FilterByRarity(Rarity rarity) {
            return _artifacts.Where(a => a.Rarity == rarity).ToList();
        }

        public List<Artifact> FilterByMinPower(int minPower) {
            return _artifacts.Where(a => a.PowerLevel >= minPower).ToList();
        }
    }
}
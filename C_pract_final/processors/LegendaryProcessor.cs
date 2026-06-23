using CSharpStudy.C_pract_final.artifacts;
using CSharpStudy.C_pract_final.interfaces;

namespace CSharpStudy.C_pract_final.processors {
    public class LegendaryProcessor : IDataProcessor<LegendaryArtifact> {
        public List<LegendaryArtifact> LoadData(string filePath) {
            var artifacts = new List<LegendaryArtifact>();
            try {
                string[] lines = File.ReadAllLines(filePath);
                int id = 1;
                foreach (string line in lines) {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split('|');
                    if (parts.Length != 5) {
                        Console.WriteLine($"Неверный формат строки: {line}");
                        continue;
                    }
                    try {
                        string name = parts[0];
                        int powerLevel = int.Parse(parts[1]);
                        Rarity rarity = Enum.Parse<Rarity>(parts[2], true);
                        string curseDescription = parts[3];
                        bool isCursed = bool.Parse(parts[4]);

                        artifacts.Add(new LegendaryArtifact(id++, name, powerLevel, rarity, curseDescription, isCursed));
                    } catch (Exception ex) {
                        Console.WriteLine($"Ошибка парсинга строки '{line}': {ex.Message}");
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine($"Ошибка загрузки текстового файла: {ex.Message}");
            }
            return artifacts;
        }

        public void SaveData(List<LegendaryArtifact> data, string filePath) {
            try {
                string[] lines = data.Select(a => $"{a.Name}|{a.PowerLevel}|{a.Rarity}|{a.CurseDescription}|{a.IsCursed}").ToArray();
                File.WriteAllLines(filePath, lines);
            } catch (Exception ex) {
                Console.WriteLine($"Ошибка сохранения текстового файла: {ex.Message}");
            }
        }
    }
}

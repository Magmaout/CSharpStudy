using Newtonsoft.Json;
using CSharpStudy.C_pract_final.artifacts;
using CSharpStudy.C_pract_final.interfaces;

namespace CSharpStudy.C_pract_final.processors {
    public class JsonProcessor : IDataProcessor<ModernArtifact> {
        public List<ModernArtifact> LoadData(string filePath) {
            var artifacts = new List<ModernArtifact>();
            try {
                string json = File.ReadAllText(filePath);
                var loaded = JsonConvert.DeserializeObject<List<ModernArtifact>>(json);
                if (loaded != null) {
                    artifacts.AddRange(loaded);
                }
            } catch (Exception ex) {
                Console.WriteLine($"Ошибка загрузки JSON: {ex.Message}");
            }
            return artifacts;
        }

        public void SaveData(List<ModernArtifact> data, string filePath) {
            try {
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, json);
            } catch (Exception ex) {
                Console.WriteLine($"Ошибка сохранения JSON: {ex.Message}");
            }
        }
    }
}

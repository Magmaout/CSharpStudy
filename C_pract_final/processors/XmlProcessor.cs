using System.Xml.Serialization;
using CSharpStudy.C_pract_final.artifacts;
using CSharpStudy.C_pract_final.interfaces;

namespace CSharpStudy.C_pract_final.processors {
    public class XmlProcessor : IDataProcessor<AntiqueArtifact> {
        public List<AntiqueArtifact> LoadData(string filePath) {
            var artifacts = new List<AntiqueArtifact>();
            try {
                XmlSerializer serializer = new XmlSerializer(typeof(List<AntiqueArtifact>));
                using (FileStream fs = new FileStream(filePath, FileMode.Open)) {
                    var loaded = (List<AntiqueArtifact>)serializer.Deserialize(fs);
                    artifacts.AddRange(loaded);
                }
            } catch (Exception ex) {
                Console.WriteLine($"Ошибка загрузки XML: {ex.Message}");
            }
            return artifacts;
        }

        public void SaveData(List<AntiqueArtifact> data, string filePath) {
            try {
                XmlSerializer serializer = new XmlSerializer(typeof(List<AntiqueArtifact>));
                using (FileStream fs = new FileStream(filePath, FileMode.Create)) {
                    serializer.Serialize(fs, data);
                }
            } catch (Exception ex) {
                Console.WriteLine($"Ошибка сохранения XML: {ex.Message}");
            }
        }
    }
}

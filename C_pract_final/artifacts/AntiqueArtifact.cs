using System.Xml.Serialization;

namespace CSharpStudy.C_pract_final.artifacts {
    [XmlRoot("AntiqueArtifact")]
    public class AntiqueArtifact : Artifact {
        [XmlElement("Age")]
        public int Age { get; set; }
        [XmlElement("OriginRealm")]
        public string OriginRealm { get; set; }

        public AntiqueArtifact() : base(0, "", 0, 0) { }

        public AntiqueArtifact(int id, string name, int powerLevel, Rarity rarity, int age, string originRealm)
            : base(id, name, powerLevel, rarity) {
            Age = age;
            OriginRealm = originRealm;
        }

        public override string Serialize() {
            return $"AntiqueArtifact: {Name}, Возраст: {Age} лет, Происхождение: {OriginRealm}";
        }

        public override string ExportToJson() {
            return $"{{\"Id\":{Id},\"Name\":\"{EscapeJson(Name)}\",\"PowerLevel\":{PowerLevel},\"Rarity\":\"{Rarity}\",\"Age\":{Age},\"OriginRealm\":\"{EscapeJson(OriginRealm)}\"}}";
        }

        public override string ExportToXml() {
            return $"<AntiqueArtifact><Id>{Id}</Id><Name>{EscapeXml(Name)}</Name><PowerLevel>{PowerLevel}</PowerLevel><Rarity>{Rarity}</Rarity><Age>{Age}</Age><OriginRealm>{EscapeXml(OriginRealm)}</OriginRealm></AntiqueArtifact>";
        }
    }
}

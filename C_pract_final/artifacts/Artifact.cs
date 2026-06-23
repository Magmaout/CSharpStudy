using CSharpStudy.C_pract_final.interfaces;

namespace CSharpStudy.C_pract_final.artifacts {
    public abstract class Artifact : IExportable {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PowerLevel { get; set; }
        public Rarity Rarity { get; set; }

        protected Artifact() {
            Id = 0;
            Name = "";
            PowerLevel = 0;
            Rarity = 0;
        }

        protected Artifact(int id, string name, int powerLevel, Rarity rarity) {
            Id = id;
            Name = name;
            PowerLevel = powerLevel;
            Rarity = rarity;
        }

        public abstract string Serialize();

        public virtual string ExportToJson() {
            return $"{{\"Id\":{Id},\"Name\":\"{Name}\",\"PowerLevel\":{PowerLevel},\"Rarity\":\"{Rarity}\"}}";
        }

        public virtual string ExportToXml() {
            return $"<Artifact><Id>{Id}</Id><Name>{Name}</Name><PowerLevel>{PowerLevel}</PowerLevel><Rarity>{Rarity}</Rarity></Artifact>";
        }

        public override string ToString() {
            return $"{Name} (ID: {Id}, Power: {PowerLevel}, Rarity: {Rarity})";
        }

        public static string EscapeJson(string s) => s
            .Replace("\\", "\\\\")
            .Replace("\"", "\\\"")
            .Replace("\n", "\\n")
            .Replace("\r", "\\r")
            .Replace("\t", "\\t");

        public static string EscapeXml(string s) => s
            .Replace("&", "&amp;")
            .Replace("<", "&lt;")
            .Replace(">", "&gt;")
            .Replace("\"", "&quot;")
            .Replace("'", "&apos;");
    }
}

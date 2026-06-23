namespace CSharpStudy.C_pract_final.artifacts {
    public class ModernArtifact : Artifact {
        public double TechLevel { get; set; }
        public string Manufacturer { get; set; }

        public ModernArtifact() : base(0, "", 0, 0) { }

        public ModernArtifact(int id, string name, int powerLevel, Rarity rarity, double techLevel, string manufacturer)
            : base(id, name, powerLevel, rarity) {
            TechLevel = techLevel;
            Manufacturer = manufacturer;
        }

        public override string Serialize() {
            return $"ModernArtifact: {Name}, Техно-уровень: {TechLevel}, Производитель: {Manufacturer}";
        }

        public override string ExportToJson() {
            return $"{{\"Id\":{Id},\"Name\":\"{EscapeJson(Name)}\",\"PowerLevel\":{PowerLevel},\"Rarity\":\"{Rarity}\",\"TechLevel\":{TechLevel},\"Manufacturer\":\"{EscapeJson(Manufacturer)}\"}}";
        }

        public override string ExportToXml() {
            return $"<ModernArtifact><Id>{Id}</Id><Name>{EscapeXml(Name)}</Name><PowerLevel>{PowerLevel}</PowerLevel><Rarity>{Rarity}</Rarity><TechLevel>{TechLevel}</TechLevel><Manufacturer>{EscapeXml(Manufacturer)}</Manufacturer></ModernArtifact>";
        }
    }
}

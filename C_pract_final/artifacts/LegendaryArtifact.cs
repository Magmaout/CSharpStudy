namespace CSharpStudy.C_pract_final.artifacts {
    public class LegendaryArtifact : Artifact {
        public string CurseDescription { get; set; }
        public bool IsCursed { get; set; }

        public LegendaryArtifact() : base(0, "", 0, 0) { }

        public LegendaryArtifact(int id, string name, int powerLevel, Rarity rarity, string curseDescription, bool isCursed)
            : base(id, name, powerLevel, rarity) {
            CurseDescription = curseDescription;
            IsCursed = isCursed;
        }

        public override string Serialize() {
            return $"LegendaryArtifact: {Name}, Проклят: {IsCursed}, Описание: {CurseDescription}";
        }

        public override string ExportToJson() {
            return $"{{\"Id\":{Id},\"Name\":\"{EscapeJson(Name)}\",\"PowerLevel\":{PowerLevel},\"Rarity\":\"{Rarity}\",\"CurseDescription\":\"{EscapeJson(CurseDescription)}\",\"IsCursed\":{IsCursed.ToString().ToLower()}}}";
        }

        public override string ExportToXml() {
            return $"<LegendaryArtifact><Id>{Id}</Id><Name>{EscapeXml(Name)}</Name><PowerLevel>{PowerLevel}</PowerLevel><Rarity>{Rarity}</Rarity><CurseDescription>{EscapeXml(CurseDescription)}</CurseDescription><IsCursed>{IsCursed.ToString().ToLower()}</IsCursed></LegendaryArtifact>";
        }
    }
}

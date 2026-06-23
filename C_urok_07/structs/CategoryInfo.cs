namespace CSharpStudy.C_urok_07.structs {
    readonly struct CategoryInfo {
        public string Name { get; }
        public string Code { get; }

        public CategoryInfo(string name, string code) {
            Name = name;
            Code = code;
        }

        public override string ToString() => $"{Name} ({Code})";
    }
}

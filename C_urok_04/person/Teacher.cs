namespace CSharpStudy.C_urok_04.person {
    internal class Teacher : Person {
        int experience, level;

        public Teacher(string name, int age, int experience, int level) : base(name, age) {
            this.experience = experience;
            this.level = level;
        }
        public double CalculateSalary() => 16242 + experience * 500 + level * 900;
        public override string GetInfo() => base.GetInfo() + ", стаж: " + experience + ", квалификация: " + level;
    }
}

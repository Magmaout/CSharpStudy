namespace CSharpStudy.C_urok_04.person {
    internal class Student : Person {
        int course;
        string group;

        public Student(string name, int age, int course, string group) : base(name, age) { this.course = course; this.group = group; }
        public override string GetInfo() => base.GetInfo() + ", курс: " + course + ", группа: " + group;
    }
}

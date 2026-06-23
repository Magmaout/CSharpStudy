namespace CSharpStudy.C_urok_04.person {
    internal class Person {
        string name;
        int age;

        public Person(string name, int age) { this.name = name; this.age = age; }
        public virtual string GetInfo() => "Человек: " + name + ", возраст: " + age;
    }
}

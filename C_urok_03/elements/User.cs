using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_urok_03.elements {
    internal class User {
        string lastName, firstName, middleName; int age;
        public User(string lastName, string firstName, string middleName, int age) { this.lastName = lastName; this.firstName = firstName; this.middleName = middleName; this.age = age; }
        public string Fio() => lastName + " " + firstName + " " + middleName + ", возраст: " + age;
    }
}

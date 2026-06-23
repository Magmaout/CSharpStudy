using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_urok_03.elements.computers {
    internal class PersonalComputer {
        string model; double cpu; int ram, hdd;
        public PersonalComputer(string model, double cpu, int ram, int hdd) { this.model = model; this.cpu = cpu; this.ram = ram; this.hdd = hdd; }
        public string Info() => "ПК: " + model + ", CPU: " + cpu + ", RAM: " + ram + ", HDD: " + hdd;
    }
}

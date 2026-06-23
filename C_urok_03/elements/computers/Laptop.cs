using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_urok_03.elements.computers {
    internal class Laptop : PersonalComputer {
        double weight;
        public Laptop(string model, double cpu, int ram, int hdd, double weight) : base(model, cpu, ram, hdd) { this.weight = weight; }
        public new string Info() => base.Info() + ", масса: " + weight;
    }
}

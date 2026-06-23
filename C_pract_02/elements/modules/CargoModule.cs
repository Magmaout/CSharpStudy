using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_pract_02.modules {
    internal sealed class CargoModule : AbstractModule {
        public CargoModule(Coord position, int fuel) : base(position, fuel) { }

        public override void Act() {
            Console.WriteLine($"CargoModule at ({Position.X}, {Position.Y}) is transporting cargo...");
        }
    }
}

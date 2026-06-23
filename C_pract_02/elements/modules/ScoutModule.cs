using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_pract_02.modules {
    internal sealed class ScoutModule : AbstractModule {
        public ScoutModule(Coord position, int fuel) : base(position, fuel) { }

        public override void Act() {
            Console.WriteLine($"ScoutModule at ({Position.X}, {Position.Y}) is scouting...");
        }
    }
}

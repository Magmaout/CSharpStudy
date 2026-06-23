using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_pract_02.modules {
    internal abstract class AbstractModule {
        public Coord Position { get; }
        public int Fuel { get; protected set; }

        protected AbstractModule(Coord position, int fuel) {
            Position = position;
            Fuel = fuel;
        }

        public abstract void Act();
    }
}

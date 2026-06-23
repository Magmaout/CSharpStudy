using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpStudy.C_pract_02.modules;

namespace CSharpStudy.C_pract_02 {
    internal class SimulationEngine {
        public bool TryStep(AbstractModule[][] map, int step, out int processed, ref int fuel) {
            processed = 0;
            if (map == null || map.Length == 0) return false;

            foreach (var row in map) {
                if (row == null) continue;
                foreach (var module in row) {
                    if (module == null) continue;
                    module.Act();
                    processed++;
                }
            }

            if (processed == 0) return false;
            fuel = processed * 10;
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_pract_01.shapes {
    internal interface ICostable {
        double CalculateMaterialCost(double pricePerUnit);
    }
}

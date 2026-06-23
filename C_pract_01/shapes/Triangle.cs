using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_pract_01.shapes {
    internal class Triangle : Figure, ICostable {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Triangle(string color, string name, double a, double b, double c) : base(color, name) {
            A = a;
            B = b;
            C = c;
        }
        public override double GetArea() {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
        public override double GetPerimeter() => A + B + C;
        public override string GetInfo() => base.GetInfo() + ", стороны: " + A + ", " + B + ", " + C;
        public double CalculateMaterialCost(double pricePerUnit) => GetArea() * pricePerUnit;
    }
}

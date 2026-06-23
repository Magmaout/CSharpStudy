using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_pract_01.shapes {
    internal class Circle : Figure, ICostable {
        public double Radius { get; set; }

        public Circle(string color, string name, double radius) : base(color, name) { Radius = radius; }
        public override double GetArea() => Math.PI * Radius * Radius;
        public override double GetPerimeter() => 2 * Math.PI * Radius;
        public override string GetInfo() => base.GetInfo() + ", радиус: " + Radius;
        public double CalculateMaterialCost(double pricePerUnit) => GetArea() * pricePerUnit;
    }
}

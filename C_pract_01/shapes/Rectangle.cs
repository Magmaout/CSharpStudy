using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_pract_01.shapes {
    internal class Rectangle : Figure, ICostable {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(string color, string name, double width, double height) : base(color, name) {
            Width = width;
            Height = height;
        }
        public override double GetArea() => Width * Height;
        public override double GetPerimeter() => 2 * (Width + Height);
        public override string GetInfo() => base.GetInfo() + ", ширина: " + Width + ", высота: " + Height;
        public double CalculateMaterialCost(double pricePerUnit) => GetArea() * pricePerUnit;
    }
}

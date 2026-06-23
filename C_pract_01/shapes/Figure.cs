using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_pract_01.shapes {
    internal abstract class Figure {
        public string Color { get; set; }
        public string Name { get; set; }

        public Figure(string color, string name) { Color = color; Name = name; }
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public virtual string GetInfo() => "Фигура: " + Name + ", цвет: " + Color + ", площадь: " + GetArea() + ", периметр: " + GetPerimeter();

        public static bool operator >(Figure a, Figure b) => a.GetArea() > b.GetArea();
        public static bool operator <(Figure a, Figure b) => a.GetArea() < b.GetArea();
        public static double operator +(Figure a, Figure b) => a.GetPerimeter() + b.GetPerimeter();
        public static bool operator ==(Figure a, Figure b) => Math.Abs(a.GetArea() - b.GetArea()) < 0.01;
        public static bool operator !=(Figure a, Figure b) => !(a == b);
    }
}

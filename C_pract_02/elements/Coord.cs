using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_pract_02 {
    internal struct Coord {
        public int X { get; }
        public int Y { get; }

        public Coord(int x, int y) {
            X = x;
            Y = y;
        }

        public static Coord operator +(Coord a, Coord b) => new Coord(a.X + b.X, a.Y + b.Y);
        public static Coord operator -(Coord a, Coord b) => new Coord(a.X - b.X, a.Y - b.Y);
        public static Coord operator *(Coord a, int scalar) => new Coord(a.X * scalar, a.Y * scalar);

        public static bool operator ==(Coord a, Coord b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Coord a, Coord b) => !(a == b);

        public override bool Equals(object? obj) => obj is Coord other && this == other;
        public override int GetHashCode() => HashCode.Combine(X, Y);
    }
}

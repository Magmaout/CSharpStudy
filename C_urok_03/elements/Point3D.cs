using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_urok_03.elements {
    internal class Point3D {
        int x, y, z;
        public Point3D(int x, int y, int z) { this.x = x; this.y = y; this.z = z; }
        public void MoveBy(int dx, int dy, int dz) { x += dx; y += dy; z += dz; }
        public string Info() => "Точка: X=" + x + ", Y=" + y + ", Z=" + z;
    }
}

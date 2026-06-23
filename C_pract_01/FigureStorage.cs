using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpStudy.C_pract_01.shapes;

namespace CSharpStudy.C_pract_01 {
    internal class FigureStorage {
        private Figure[] _figures = new Figure[10];
        private int _count = 0;

        public void AddFigure(Figure f) {
            if (_count >= _figures.Length) {
                Console.WriteLine("Ошибка: массив заполнен!");
                return;
            }
            _figures[_count++] = f;
        }

        public Figure[] GetAll() {
            Figure[] result = new Figure[_count];
            for (int i = 0; i < _count; i++) result[i] = _figures[i];
            return result;
        }

        public double GetTotalArea() {
            double sum = 0;
            for (int i = 0; i < _count; i++) sum += _figures[i].GetArea();
            return sum;
        }
    }
}

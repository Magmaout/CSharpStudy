namespace CSharpStudy.C_urok_05.matrix {
    internal class Matrix {
        double[,] data;
        public int Rows => data.GetLength(0);
        public int Cols => data.GetLength(1);
        public double this[int row, int col] { get => data[row, col]; set => data[row, col] = value; }

        public Matrix(double[,] data) { this.data = data; }
        public static Matrix operator +(Matrix a, Matrix b) => ElementOperation(a, b, (x, y) => x + y);
        public static Matrix operator -(Matrix a, Matrix b) => ElementOperation(a, b, (x, y) => x - y);
        public static Matrix operator +(Matrix a, double b) => NumberOperation(a, x => x + b);
        public static Matrix operator -(Matrix a, double b) => NumberOperation(a, x => x - b);
        public static Matrix operator *(Matrix a, double b) => NumberOperation(a, x => x * b);
        public static Matrix operator *(double a, Matrix b) => b * a;
        public static Matrix operator *(Matrix a, Matrix b) {
            if (a.Cols != b.Rows) throw new Exception("Матрицы нельзя умножить!");
            Matrix result = new Matrix(new double[a.Rows, b.Cols]);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < b.Cols; j++)
                    for (int k = 0; k < a.Cols; k++) result[i, j] += a[i, k] * b[k, j];
            return result;
        }
        public static bool operator >(Matrix a, Matrix b) => a.Sum() > b.Sum();
        public static bool operator <(Matrix a, Matrix b) => a.Sum() < b.Sum();
        double Sum() {
            double sum = 0;
            foreach (double item in data) sum += item;
            return sum;
        }
        static Matrix ElementOperation(Matrix a, Matrix b, Func<double, double, double> operation) {
            if (a.Rows != b.Rows || a.Cols != b.Cols) throw new Exception("Размеры матриц не совпадают!");
            Matrix result = new Matrix(new double[a.Rows, a.Cols]);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++) result[i, j] = operation(a[i, j], b[i, j]);
            return result;
        }
        static Matrix NumberOperation(Matrix a, Func<double, double> operation) {
            Matrix result = new Matrix(new double[a.Rows, a.Cols]);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++) result[i, j] = operation(a[i, j]);
            return result;
        }
        public override string ToString() {
            string text = "";
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Cols; j++) text += data[i, j] + " ";
                text += Environment.NewLine;
            }
            return text;
        }
    }
}

namespace tnn
{ // TODO: add documentation
    class Matrix
    {
        public (int, int) Shape { get; }
        private List<List<float>> _Data;
        public Matrix(int rows, int cols)
        {
            Shape = (rows, cols);
            _Data = Enumerable.Range(0, rows).Select(i => Enumerable.Range(0, cols).Select(j => 0.0f).ToList()).ToList();
        }
        public Matrix(int rows, int cols, float value)
        {
            Shape = (rows, cols);
            _Data = Enumerable.Range(0, rows).Select(i => Enumerable.Range(0, cols).Select(j => value).ToList()).ToList();
        }
        public Matrix Randomize(float high, float low)
        {
            Random rnd = new();
            _Data = Enumerable.Range(0, Shape.Item1).Select(i => Enumerable.Range(0, Shape.Item2).Select(j => (float)(rnd.NextDouble() * high) - low).ToList()).ToList();
            return this;
        }
        public Matrix Randomize()
        {
            Random rnd = new();
            _Data = Enumerable.Range(0, Shape.Item1).Select(i => Enumerable.Range(0, Shape.Item2).Select(j => (float)(rnd.NextDouble() * 2) - 1).ToList()).ToList();
            return this;
        }
        public Matrix T()
        {
            var m = new Matrix(Shape.Item2, Shape.Item1);
            var temp = Enumerable.Range(0, Shape.Item2).Select(i => Enumerable.Range(0, Shape.Item1).Select(j => 0.0f).ToList()).ToList();
            for (int i = 0; i < Shape.Item2; i++)
            {
                for (int j = 0; j < Shape.Item1; j++)
                {
                    temp[i][j] = _Data[j][i];
                }
            }
            return m.SetUnsafe(temp);
        }
        public Matrix? Dot(Matrix other)
        {
            if (other.Shape != T().Shape) return null;
            var result = new Matrix(Shape.Item1, other.Shape.Item2);
            for (int i = 0; i < result.Shape.Item1; i++)
            {
                for (int j = 0; j < result.Shape.Item2; j++)
                {
                    for (int k = 0; k < Shape.Item2; k++)
                    {
                        result._Data[i][j] = _Data[i][k] * other._Data[k][j];
                    }
                }
            }
            return result;
        }
        private Matrix SetUnsafe(List<List<float>> data)
        {
            _Data = data;
            return this;
        }
        public Matrix? Set(List<List<float>> data)
        {
            if (data.Count != Shape.Item1) return null;
            foreach (var item in data)
            {
                if (item.Count != Shape.Item2) return null;
            }
            _Data = data;
            return this;
        }
        public Matrix? Set(float[,] data)
        {
            return Set(Enumerable.Range(0, data.GetLength(0))
                .Select(row => Enumerable.Range(0, data.GetLength(1))
                .Select(col => data[row, col]).ToList()).ToList()
                );
        }
        public Matrix? Set(float[][] data)
        {
            return Set(data.Select(row => row.Select(col => col).ToList()).ToList());
        }
        public List<List<float>> AsList() => _Data;
        public static Matrix operator +(Matrix self, float other) => self.SetUnsafe(self.AsList().Select(row => row.Select(col => col + other).ToList()).ToList());
        public static Matrix operator -(Matrix self, float other) => self.SetUnsafe(self.AsList().Select(row => row.Select(col => col - other).ToList()).ToList());
        public static Matrix operator *(Matrix self, float other) => self.SetUnsafe(self.AsList().Select(row => row.Select(col => col * other).ToList()).ToList());
        public static Matrix operator /(Matrix self, float other) => self.SetUnsafe(self.AsList().Select(row => row.Select(col => col / other).ToList()).ToList());

        public override string ToString()
        {
            var ret = "[\n";
            foreach (var row in _Data)
            {
                var rowString = "    [ ";
                row.ForEach(item => rowString += item.ToString() + " ");
                rowString = rowString.TrimEnd();
                rowString += " ]\n";
                ret += rowString;
            }
            ret += "]";
            return ret;
        }
        public void Print()
        {
            Console.WriteLine("[");
            foreach (var row in _Data)
            {
                var rowString = "    [ ";
                row.ForEach(item => rowString += item.ToString() + " ");
                rowString = rowString.TrimEnd();
                rowString += " ]";
                Console.WriteLine(rowString);
            }
            Console.WriteLine("]");
        }
    }
}

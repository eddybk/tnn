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
        private Matrix SetUnsafe(List<List<float>> data)
        {
            _Data = data; 
            return this;
        }
        public List<List<float>> ToList() => _Data;
        public static Matrix operator +(Matrix self, float other) => self.SetUnsafe(self.ToList().Select(row => row.Select(col => col + other).ToList()).ToList());
        public static Matrix operator -(Matrix self, float other) => self.SetUnsafe(self.ToList().Select(row => row.Select(col => col - other).ToList()).ToList());
        public static Matrix operator *(Matrix self, float other) => self.SetUnsafe(self.ToList().Select(row => row.Select(col => col * other).ToList()).ToList());
        public static Matrix operator /(Matrix self, float other) => self.SetUnsafe(self.ToList().Select(row => row.Select(col => col / other).ToList()).ToList());

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

namespace tnn
{
    struct Matrix
    {
        public (int, int) Shape { get; }
        private List<List<float>> _Data;
        public Matrix(int rows, int cols)
        {
            Shape = (rows, cols);
            _Data = Enumerable.Range(0, rows).Select(i => Enumerable.Range(0, cols).Select(j => 0.0f).ToList()).ToList();
        }
        public List<List<float>> ToList() => _Data;
    }
}

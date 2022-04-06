namespace tnn
{
    struct Vector
    {
        private List<float> _Data;
        public Vector(float[] data)
        {
            _Data = new List<float> { data[0] };
        }
        public Vector(List<float> data)
        {
            _Data = data;
        }
        public List<float> AsList() => _Data;
        public Matrix ToRowMatrix() => new Matrix(_Data.Count, 1).Set(_Data.Select(x => new List<float>(new float[] { x })).ToList())!;
        public Matrix ToColumnMatrix() => new Matrix(1, _Data.Count).Set(new float[][] { _Data.ToArray() })!;
        public float? Dot(Vector other)
        {
            if (_Data.Count != other._Data.Count) return null;
            var temp = new List<float>();
            for (int i = 0; i < _Data.Count; i++)
            {
                temp.Add(_Data[i] * other._Data[i]);
            }
            return temp.Sum();
        }
    }
}

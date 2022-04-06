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
        public float this[int index]
        {
            get => _Data[index];
            set => _Data[index] = value;
        }
        public static Vector operator +(Vector self, float other)
        {
            self._Data = self._Data.Select(x => x + other).ToList();
            return self;
        }
        public static Vector operator +(Vector self, Vector other)
        {
            for (int i = 0; i < self._Data.Count; i++)
            {
                try
                {
                    self._Data[i] += other._Data[i];
                }
                catch(IndexOutOfRangeException)
                {
                    continue;
                }
            }
            return self;
        }
        public static Vector operator -(Vector self, float other)
        {
            self._Data = self._Data.Select(x => x - other).ToList();
            return self;
        }
        public static Vector operator -(Vector self, Vector other)
        {
            for (int i = 0; i < self._Data.Count; i++)
            {
                try
                {
                    self._Data[i] -= other._Data[i];
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
            }
            return self;
        }
        public static Vector operator *(Vector self, float other)
        {
            self._Data = self._Data.Select(x => x * other).ToList();
            return self;
        }
        public static Vector operator *(Vector self, Vector other)
        {
            for (int i = 0; i < self._Data.Count; i++)
            {
                try
                {
                    self._Data[i] *= other._Data[i];
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
            }
            return self;
        }
        public static Vector operator /(Vector self, float other)
        {
            self._Data = self._Data.Select(x => x / other).ToList();
            return self;
        }
        public static Vector operator /(Vector self, Vector other)
        {
            for (int i = 0; i < self._Data.Count; i++)
            {
                try
                {
                    self._Data[i] /= other._Data[i];
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
            }
            return self;
        }
        public override string ToString()
        {
            var ret = "[ ";
            foreach (var item in _Data)
            {
                ret += item.ToString() + " ";
            }
            ret += "]";
            return ret;
        } 
    }
}

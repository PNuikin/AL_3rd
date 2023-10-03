namespace Task_1
{
    abstract class Program
    {
        class MyMatrix
        {
            private List<List<double>> _matrix;

            private int N => _matrix.Count;

            private int M => _matrix[0].Count;

            public MyMatrix(int n, int m, int min, int max)
            {
                Random rand = new Random();
                _matrix = new List<List<double>>();
                for (int j = 0; j < n; j++)
                {
                    _matrix.Add(new List<double>());
                    for (int i = 0; i < m; i++)
                    {
                        _matrix[j].Add(rand.Next(min, max));
                    }
                }
            }

            public void Fill(int min, int max)
            {
                Random rand = new Random();
                for (int j = 0; j < N; j++)
                {
                    for (int i = 0; i < M; i++)
                    {
                        _matrix[j][i] = rand.Next(min, max);
                    }
                }
            }

            public void ChangeSize(int nNew, int mNew, int min, int max)
            {
                Random rand = new Random();
                List<List<double>> newMatrix = new List<List<double>>(nNew);
                for (int i = 0; i < nNew; i++)
                {
                    for (int j = 0; j < mNew; j++)
                    {
                        newMatrix.Add(new List<double>());
                        if (i < N && j < M)
                        {
                            newMatrix[i].Add(_matrix[i][j]);
                        }
                        else
                        {
                            newMatrix[i].Add(rand.Next(min, max));
                        }
                    }
                }

                _matrix = newMatrix;
            }

            public void ShowPartialy(int nStart, int nFinish, int mStart, int mFinish)
            {
                for (int i = nStart - 1; i < nFinish; i++)
                {
                    for (int j = mStart - 1; j < mFinish; j++)
                    {
                        Console.Write($"{_matrix[i][j]} ");
                    }

                    Console.WriteLine();
                }
            }
            
            public void Show()
            {
                foreach (var row in _matrix)
                {
                    foreach (var num in row)
                    {
                        Console.Write($"{num} ");
                    }
                    Console.WriteLine();
                }
            }
            
            public double this[int a, int b]
            {
                get => this._matrix[a][b];
                set => this._matrix[a][b] = value;
            }
        }

        static void Main()
        {
            MyMatrix matrix = new MyMatrix(4, 4, 1, 10);
            matrix.Show();
            Console.WriteLine();
            matrix.Fill(1, 10);
            matrix.ShowPartialy(1, 2, 1, 2);
            Console.WriteLine();
            matrix.ChangeSize(5, 5, 1, 10);
            matrix.Show();
            Console.WriteLine();
        }
    }
}


using System.Threading.Channels;

namespace Task_1
{
    class MyMatrix
    {
        List<List<double>> matrix;

        public int N
        {
            get { return matrix.Count; }
        }

        public int M
        {
            get { return matrix[0].Count(); }
        }
        public MyMatrix(int n, int m, int min, int max)
        {
            Random rand = new Random();
            matrix = new List<List<double>>();
            for (int j = 0; j < n; j++) 
            {
                matrix.Add(new List<double>());
                for (int i = 0; i < m; i++)
                {
                    matrix[j].Add(rand.Next(min, max));
                }
            }
        }
        
        public double this [int a, int b]
        {
            get { return this.matrix[a][b]; }
            set { this.matrix[a][b] = value; }
        }

        public static MyMatrix operator+ (MyMatrix matrix1, MyMatrix matrix2)
        {
            if (matrix1.N != matrix2.N || matrix1.M != matrix2.M) return new MyMatrix(0, 0, 0, 0);
            MyMatrix res_matrix = new MyMatrix(matrix1.N, matrix1.M, 0, 0);
            for (int i = 0; i < matrix1.N; i++)
            {
                for (int j = 0; j < matrix1.M; j++)
                {
                    res_matrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return res_matrix;
        }
        
        public static MyMatrix operator- (MyMatrix matrix1, MyMatrix matrix2)
        {
            if (matrix1.N != matrix2.N || matrix1.M != matrix2.M) return new MyMatrix(0, 0, 0, 0);
            MyMatrix res_matrix = new MyMatrix(matrix1.N, matrix1.M, 0, 0);
            for (int i = 0; i < matrix1.N; i++)
            {
                for (int j = 0; j < matrix1.M; j++)
                {
                    res_matrix[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return res_matrix;
        }
        
        public static MyMatrix operator* (MyMatrix matrix1, MyMatrix matrix2)
        {
            if (matrix1.M != matrix2.N) return new MyMatrix(0, 0, 0, 0);
            MyMatrix res_matrix = new MyMatrix(matrix1.N, matrix2.M, 0, 0);
            for (int i = 0; i < matrix1.N; i++)
            {
                for (int j = 0; j < matrix2.M; j++)
                {
                    res_matrix[i, j] = 0;
                    for (int k = 0; k < matrix1.M; k++)
                    {
                        res_matrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return res_matrix;
        }
        
        public static MyMatrix operator* (MyMatrix matrix1, int num)
        {
            MyMatrix res_matrix = new MyMatrix(matrix1.N, matrix1.M, 0, 0);
            for (int i = 0; i < matrix1.N; i++)
            {
                for (int j = 0; j < matrix1.M; j++)
                {
                    res_matrix[i, j] = matrix1[i, j] * num;
                }
            }

            return res_matrix;
        }
        
        public static MyMatrix operator/ (MyMatrix matrix1, int num)
        {
            MyMatrix res_matrix = new MyMatrix(matrix1.N, matrix1.M, 0, 0);
            for (int i = 0; i < matrix1.N; i++)
            {
                for (int j = 0; j < matrix1.M; j++)
                {
                    res_matrix[i, j] = matrix1[i, j] / num;
                }
            }

            return res_matrix;
        }

        public void Print()
        {
            foreach (var row in matrix)
            {
                foreach (var num in row)
                {
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter range of numbers in matrix");
            Console.Write("Min: ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Max: ");
            int max = Convert.ToInt32(Console.ReadLine());
            MyMatrix matrix1 = new MyMatrix(4, 4, min,max);
            MyMatrix matrix2 = new MyMatrix(4, 4, min, max);
            MyMatrix matrix3 = new MyMatrix(4, 2, min, max);

            Console.WriteLine($"matrix1: ");
            matrix1.Print();

            Console.WriteLine("matrix2: ");
            matrix2.Print();

            Console.WriteLine("matrix1 + matrix2");
            (matrix1 + matrix2).Print();
            
            Console.WriteLine("matrix1 - matrix2");
            (matrix1 - matrix2).Print();
            
            Console.WriteLine("matrix1 * matrix3");
            (matrix1 * matrix3).Print();
            
            Console.WriteLine("matrix1 * 4");
            (matrix1 * 4).Print();
            
            Console.WriteLine("matrix1 / 5");
            (matrix1 / 5).Print();
        }
    }
}
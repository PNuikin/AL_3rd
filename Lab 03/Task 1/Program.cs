using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;

namespace Task_1
{
    struct Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        
        public double Length 
        {
            get
            {
                return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
            }
        }

        public Vector(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector operator +(Vector vec1, Vector vec2)
        {
            return new Vector { X = vec1.X + vec2.X, Y = vec1.Y + vec2.Y, Z = vec1.Z + vec2.Z };
        }

        public static int operator *(Vector vec1, Vector vec2)
        {
            return vec1.X * vec2.X + vec1.Y * vec2.Y + vec1.Z * vec2.Z;
        }

        public static Vector operator *(Vector vec1, int num)
        {
            return new Vector { X = vec1.X * num, Y = vec1.Y * num, Z = vec1.Z * num };
        }
        
        public static bool operator <(Vector vec1, Vector vec2)
        {
            return vec1.Length < vec2.Length;
        }

        public static bool operator >(Vector vec1, Vector vec2)
        {
            return vec1.Length > vec2.Length;
        }
        
        public static bool operator <=(Vector vec1, Vector vec2)
        {
            return vec1.Length <= vec2.Length;
        }
        
        public static bool operator >=(Vector vec1, Vector vec2)
        {
            return vec1.Length >= vec2.Length;
        }

        public void Print()
        {
            Console.WriteLine($"({X}, {Y}, {Z})");
        }
    }

    class Program
    {
        static void Main()
        {
            Vector vec1 = new Vector(10, 30, 3);
            Vector vec2 = new Vector(30, 10, 30);
            Console.Write("vec1 + vec2 = ");
            Vector vec3 = vec1 + vec2;
            vec3.Print();
            Console.WriteLine($"vec1 * vec2 = {vec1 * vec2}");
            Console.Write("vec1 * 4 = ");
            Vector vec4 = vec1 * 4;
            vec4.Print();
            Console.WriteLine($"vec1 < vec2 {vec1 < vec2}");
            Console.WriteLine($"vec1 > vec2 {vec1 > vec2}");
        }
    }
}
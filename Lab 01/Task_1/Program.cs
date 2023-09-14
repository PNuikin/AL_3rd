namespace ConsoleApp1
{
    public class Program
    {
        static void Main()
        {

            Console.WriteLine("{0}\tmin:{1} max:{2} ", typeof(bool), bool.TrueString, bool.FalseString);

            Console.WriteLine("{0}\tmin:{1} max:{2} ", typeof(byte), byte.MinValue, byte.MaxValue);
            Console.WriteLine("{0}\tmin:{1} max:{2} ", typeof(sbyte), sbyte.MinValue, sbyte.MaxValue);

            Console.WriteLine("{0}\tmin:{1} max:{2} ", typeof(char), char.MinValue, char.MaxValue);

            Console.WriteLine("{0}\tmin:{1} max:{2} ", typeof(short), short.MinValue, short.MaxValue);
            Console.WriteLine("{0}\tmin:{1} max:{2} ", typeof(ushort), ushort.MinValue, ushort.MaxValue);

            Console.WriteLine("{0}\tmin:{1} max:{2} ", typeof(int), int.MinValue, int.MaxValue);
            Console.WriteLine("{0}\tmin:{1} max:{2} ", typeof(uint), uint.MinValue, uint.MaxValue);

            Console.WriteLine("{0}\tmin:{1} max:{2} ", typeof(long), long.MinValue, long.MaxValue);
            Console.WriteLine("{0}\tmin:{1} max:{2} ", typeof(ulong), ulong.MinValue, ulong.MaxValue);

            Console.WriteLine("{0}\tmin:{1} max:{2} ", typeof(decimal), decimal.MinValue, decimal.MaxValue);
            Console.WriteLine("{0}\tmin:{1} max:{2} ", typeof(float), float.MinValue, float.MaxValue);
            Console.WriteLine("{0}\tmin:{1} max:{2} ", typeof(double), double.MinValue, double.MaxValue);

        }
    }
}
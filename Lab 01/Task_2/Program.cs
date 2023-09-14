namespace ConsoleApp2
{
    class Rectangle
    {
        private double side1, side2;

        public Rectangle(double sideA, double sideB)
        {
            side1 = sideA;
            side2 = sideB;
        }

        private double CalculateArea()
        {
            return side1 * side2;
        }

        private double CalculatePerimetr()
        {
            return 2 * (side1 + side2);
        }

        public double Area
        {
            get { return CalculateArea(); }
        }

        public double Perimetr
        {
            get { return CalculatePerimetr(); }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Enter lenght of the first side: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter lenght of the second side: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Rectangle rec = new Rectangle(a, b);
            Console.WriteLine($"Space: {rec.Area}, Perimetr: {rec.Perimetr}");
        }
    }
}
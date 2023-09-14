using System;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace ConsoleApp3
{
    class Point
    {
        private int x, y;

        public Point(int a, int b)
        {
            x = a;
            y = b;
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }
    }

    class Figure
    {
        private Point p1, p2, p3, p4, p5;
        public double Perimetr;

        public string Name { get; set; }
        
        public Figure(Point p1, Point p2, Point p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            Name = "Triangle";
        }

        public Figure(Point p1, Point p2, Point p3, Point p4):this(p1, p2, p3)
        {
            this.p4 = p4;
            Name = "Quadrangle";
        }

        public Figure(Point p1, Point p2, Point p3, Point p4, Point p5):this(p1, p2, p3, p4)
        {
            this.p5 = p5;
            Name = "Quadrangle";
        }

        double LenghtSide(Point A, Point B)
        {
            return double.Sqrt((double.Pow(double.Abs(A.X - B.X), 2) + double.Pow(double.Abs(A.Y - B.Y), 2)));
        }

        public void PerimeterCalculator()
        {
            Perimetr = LenghtSide(p1, p2);
            Perimetr += LenghtSide(p2, p3);
            if (Name == "Triangle")
            {
                Perimetr += LenghtSide(p3, p1);
            }
            else if (Name == "Quadrangle")
            {
                Perimetr += LenghtSide(p3, p4);
                Perimetr += LenghtSide(p4, p1);
            }
            else
            {
                Perimetr += LenghtSide(p3, p4);
                Perimetr += LenghtSide(p4, p5);
                Perimetr += LenghtSide(p5, p1);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Point p1 = new Point(10, 20);
            Point p2 = new Point(11, 20);
            Point p3 = new Point(30, 10);
            Point p4 = new Point(30, 0);
            Point p5 = new Point(10, 0);

            Figure figure1 = new Figure(p1, p2, p3);
            figure1.PerimeterCalculator();
            Console.WriteLine($"Name: {figure1.Name}  Perimetr: {figure1.Perimetr}");

            Figure figure2 = new Figure(p1, p2, p3, p4);
            figure2.PerimeterCalculator();
            Console.WriteLine($"Name: {figure2.Name}  Perimetr: {figure2.Perimetr}");
            
            Figure figure3 = new Figure(p1, p2, p3, p4, p5);
            figure3.PerimeterCalculator();
            Console.WriteLine($"Name: {figure3.Name}  Perimetr: {figure3.Perimetr}");
        }
    }
}
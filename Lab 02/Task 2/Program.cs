using System.Runtime.InteropServices;

namespace Task_2
{
    class Vehicle
    {
        private double latitude, longitude;
        private int price, speed, year;

        public Vehicle(double x, double y, int price, int speed, int year)
        {
            latitude = x;
            longitude = y;
            this.price = price;
            this.speed = speed;
            this.year = year;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Latitude: {latitude}\nLongitude: {longitude}\nPrice: {price}\nSpeed: {speed}\nYear: {year}");
        }
    }

    class Car : Vehicle
    {
        public Car(double x, double y, int price, int speed, int year) : base(x, y, price, speed, year) {}

        public override void Print()
        {
            Console.WriteLine("CAR:");
            base.Print();
            Console.WriteLine();
        }
    }

    class Ship : Vehicle
    {
        private int capacity;
        private string port;

        public Ship(double x, double y, int price, int speed, int year, int capacity, string port) : base(x, y, price,
            speed, year)
        {
            this.capacity = capacity;
            this.port = port;
        }

        public override void Print()
        {
            Console.WriteLine("SHIP:");
            base.Print();
            Console.WriteLine($"Capacity: {capacity}\nPort: {port}\n");
        }
    }

    class Plane : Vehicle
    {
        private int height, capacity;
        
        public Plane(double x, double y, int price, int speed, int year, int height, int capacity) : base(x, y, price,
            speed, year)
        {
            this.capacity = capacity;
            this.height = height;
        }

        public override void Print()
        {
            Console.WriteLine("PLANE:");
            base.Print();
            Console.WriteLine($"Height: {height}\nCapacity: {capacity}\n");
        }
    }

    class Program
    {
        static void Main()
        {
            Car car = new Car(100, 60, 1000000, 120, 2005);
            Ship ship = new Ship(30, 20, 25000000, 150, 2020, 300, "Simpheropol");
            Plane plane = new Plane(40, 70, 30000000, 1100, 2023, 10000, 2);
            car.Print();
            ship.Print();
            plane.Print();
        }
    }
}


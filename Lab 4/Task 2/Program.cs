namespace Task2
{
    class Program
    {
        public class Car
        {
            public string Name { get; set; }

            public int ProductionYear { get; set; }

            public int MaxSpeed { get; set; }

            public Car(string name, int prodyear, int maxSpeed)
            {
                Name = name;
                ProductionYear = prodyear;
                MaxSpeed = maxSpeed;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {ProductionYear} {MaxSpeed}");
            }
        }

        public class CarComparer : IComparer<Car>
        {
            private string Arg { get; set; }

            public CarComparer(string arg) => Arg = arg;

            public int Compare(Car? car1, Car? car2)
            {
                if (car1 == null && car2 == null)
                {
                    return 0;
                }

                return Arg switch
                {
                    "name" => car1.Name.CompareTo(car2.Name),
                    "year" => car1.ProductionYear.CompareTo(car2.ProductionYear),
                    "speed" => car1.MaxSpeed.CompareTo(car2.MaxSpeed)
                };
            }
        }


        public static void Main()
        {
            Car car1 = new Car("BMW", 2005, 200);
            Car car2 = new Car("Mercedes", 2020, 100);
            Car car3 = new Car("Nissan", 2000, 150);
            List<Car> cars = new List<Car>{ car1, car3, car2 };
            Console.WriteLine("cars: ");
            foreach (var car in cars)
            {
                car.Print();
            }

            Console.WriteLine();
            Console.WriteLine("cars sorted by name: ");
            cars.Sort(new CarComparer("name"));
            foreach (var car in cars)
            {
                car.Print();
            }

            Console.WriteLine();
            Console.WriteLine("cars sorted by production year: ");
            cars.Sort(new CarComparer("year"));
            foreach (var car in cars)
            {
                car.Print();
            }

            Console.WriteLine();
            Console.WriteLine("cars sorted by max speed: ");
            cars.Sort(new CarComparer("speed"));
            foreach (var car in cars)
            {
                car.Print();
            }
        }
    }
}
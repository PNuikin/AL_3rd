using System.Collections;

namespace Task_3
{
    public class Program
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

        public class CarCatalog
        {
            private Car[] _cars;

            public CarCatalog(params Car[] cars)
            {
                _cars = cars;
            }

            public IEnumerator<Car> GetEnumerator()
            {
                for (int i = 0; i < _cars.Length; i++)
                {
                    yield return _cars[i];
                }
            }
            
            public IEnumerable<Car> Reverse()
            {
                for (int i = _cars.Length - 1; i > -1; i--)
                {
                    yield return _cars[i];
                }
            }

            public IEnumerable<Car> Subset(string arg, int val)
            {
                for (int i = 0; i < _cars.Length; i++)
                {
                    switch (arg)
                    {
                        case "year":
                        {
                            if (_cars[i].ProductionYear == val) yield return _cars[i];
                            break;
                        }
                        case "speed":
                        {
                            if (_cars[i].MaxSpeed == val) yield return _cars[i];
                            break;
                        }
                    }
                }
            }
        }

        static void Main()
        {
            Car car1 = new Car("BMW", 2005, 200);
            Car car2 = new Car("Mercedes", 2020, 100);
            Car car3 = new Car("Nissan", 2000, 150);
            CarCatalog cars = new CarCatalog( car1, car3, car2 );
            Console.WriteLine("cars: ");
            foreach (var car in cars)
            {
                car.Print();
            }

            Console.WriteLine();
            foreach (var car in cars.Reverse())
            {
                car.Print();
            }

            Console.WriteLine();
            foreach (var car in cars.Subset("year", 2000))
            {
                car.Print();
            }

            Console.WriteLine();
            foreach (var car in cars.Subset("speed", 200))
            {
                car.Print();
            }
        }
    }

}
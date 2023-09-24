namespace Task_2
{
    interface IEquatable<T>
    {
        bool Equals(T obj);
    }
    class Car : IEquatable<Car>
    {
        public string Name { get; set; }
        
        public string Engine { get; set; }
        
        public int MaxSpeed { get; set; }

        public Car(string name, string engine, int maxSpeed)
        {
            Name = name;
            Engine = engine;
            MaxSpeed = maxSpeed;
        }
        
        public override string ToString()
        {
            return Name;
        }

        public bool Equals(Car car)
        {
            if (Name == car.Name && Engine == car.Engine && MaxSpeed == car.MaxSpeed)
            {
                return true;
            }

            return false;
        }
    }

    class CarsCatalog
    {
        private Car[] lst;

        public CarsCatalog(params Car[] cars)
        {
            lst = cars;
        }
        
        public string this[int index]
        {
            get { return lst[index].Name + " " + lst[index].Engine; }
        }
    }

    class Program
    {
        static void Main()
        {
            Car car1 = new Car("BMW", "V8", 200);
            Car car2 = new Car("Nissan", "V12", 220);
            Car car3 = new Car("Ferrari", "V12", 300);
            Console.WriteLine(car1.ToString());
            Console.WriteLine(car1.Equals(car2));
            CarsCatalog catalog = new CarsCatalog(car1, car2, car3);
            Console.WriteLine(catalog[2]);
        }
    }
}
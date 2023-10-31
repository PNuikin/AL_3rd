namespace ConsoleApp1Task_3;

class Program
{
    class MyDictionary<TKey, TValue>
    {
        private List<KeyValuePair<TKey, TValue>> _dict;

        public MyDictionary(params KeyValuePair<TKey, TValue>[] args)
        {
            _dict = Enumerable.ToList(args);
        }

        public void Add(KeyValuePair<TKey, TValue> arg)
        {
            _dict.Add(arg);
        }

         public TValue this[TKey key]
        {
            get
            {
                foreach (var pair in _dict)
                {
                    if (Equals(pair.Key, key)) return pair.Value;
                }

                KeyValuePair<TKey, TValue> temp = new KeyValuePair<TKey, TValue>();
                return temp.Value;
            }
        }

         public int Size => _dict.Count;

         public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
         {
             foreach (var arg in _dict)
             {
                 yield return arg;
             }
         }
    }

    static void Main()
    {
        KeyValuePair<string, int> pair = new KeyValuePair<string, int>("Ruslan", 7);
        KeyValuePair<string, int> pair1 = new KeyValuePair<string, int>("Pavel", 10);
        KeyValuePair<string, int> pair2 = new KeyValuePair<string, int>("Dima", 80);
        KeyValuePair<string, int> pair3 = new KeyValuePair<string, int>("Vlad", 100);
        MyDictionary<string, int> myDictionary = new MyDictionary<string, int>(pair, pair1, pair2);
        Console.WriteLine($"{myDictionary["Pavel"]}");
        Console.WriteLine($"{myDictionary.Size}");
        myDictionary.Add(pair3);
        Console.WriteLine($"{myDictionary.Size}");
        foreach (var arg in myDictionary)
        {
            Console.WriteLine($"{arg.Key} {arg.Value}");
        }
    }
}
using System.Collections;
using System.Drawing;

namespace Task_2
{
    class Program
    {
        class MyList<T> : IEnumerable<T>
        {
            private T[] _array;

            public MyList(params T[] args)
            {
                _array = new T[args.Length];
                for (var i = 0; i < args.Length; ++i)
                {
                    _array[i] = args[i];
                }
            }

            public void Add(T arg)
            {
                var tempArray = new T[_array.Length + 1];
                _array.CopyTo(tempArray, 0);
                tempArray[_array.Length] = arg;
                _array = tempArray;
            }

            public T this[int index] => _array[index];

            public int Size => _array.Length;
            public IEnumerator<T> GetEnumerator()
            {
                return (IEnumerator<T>)_array.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        static void Main()
        {
            MyList<int> myList = new MyList<int>(){1, 80, 57, 76};
            Console.WriteLine($"{myList[2]}");
            Console.WriteLine($"{myList.Size}");
            myList.Add(60);
            for (var i = 0; i < myList.Size; ++i)
            {
                Console.Write($"{myList[i]} ");
            }
        }
    }
}


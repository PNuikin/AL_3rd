namespace Task_3
{
    class Currency
    {
        public double Value { get; set; }
    }
    
    class CurrencyRub : Currency
    {
        public static implicit operator CurrencyRub(double num)
        {
            return new CurrencyRub { Value = num };
        }

        public static explicit operator double(CurrencyRub cur)
        {
            return cur.Value;
        }
    }

    class CurrencyUsd : Currency
    {
        public static implicit operator CurrencyUsd(double num)
        {
            return new CurrencyUsd { Value = num };
        }

        public static explicit operator double(CurrencyUsd cur)
        {
            return cur.Value;
        }
    }

    class CurrencyEur : Currency
    {
        public static implicit operator CurrencyEur(double num)
        {
            return new CurrencyEur { Value = num };
        }

        public static explicit operator double(CurrencyEur cur)
        {
            return cur.Value;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Enter USD to RUB currency: ");
            int UsdToRub = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter EUR to RUB currency: ");
            int EurToRub = Convert.ToInt32(Console.ReadLine());
            CurrencyUsd usd = new CurrencyUsd { Value = 1234 };
            CurrencyRub rub1 = ((double)usd * UsdToRub);
            Console.WriteLine($"Convert {usd.Value} USD to RUB: {rub1.Value}");
            CurrencyEur eur1 = ((double)rub1 / EurToRub);
            Console.WriteLine($"Convert {usd.Value} USD to EUR: {eur1.Value}");
            
            CurrencyEur eur = new CurrencyEur { Value = 450 };
            CurrencyRub rub2 = ((double)eur * EurToRub);
            Console.WriteLine($"Convert {eur.Value} EUR to RUB: {rub2.Value}");
            CurrencyUsd usd2 = (double)eur * EurToRub / UsdToRub;
            Console.WriteLine($"Convert {eur.Value} EUR to USD: {usd2.Value}");;
        }
    }
}
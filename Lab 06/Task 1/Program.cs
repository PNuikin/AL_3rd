using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Task_1;

class Program
{
    struct Weather
    {
        public string Country { get; set; }
        
        public string Name { get; set; }
        
        public int Temp { get; set; }
        
        public string Description { get; set; }
    }

    public static string Get(string url)
    {
        var web = new WebClient();
        return web.DownloadString(url);
    }

    static void Main()
    {
        List<double> coords = new List<double>()
        {
            55.75, 37.62,
            24.47, 54.37,
            9.02, 38.75,
            25.29, 51.53,
            53.33, -6.25,
            33.72, 73.04,
            0.32, 32.58,
            8.99, -79.52,
            -13.83, -171.77,
            51.18, 71.45,
            14, -61.01,
            6.5, 2.6,
            42.67, 21.17,
            13.16, -61.23,
            37.95, 58.38,
            40.38, 49.89,
            13.75, 100.5,
            13.16, -61.23,
            55.68, 12.57,
            43.94, 12.45,
            0.34, 6.73,
            0.39, 9.45,
            33.89, 35.5,
            17.25, -88.77,
            52.52, 13.41,
            42.87, 74.59,
            -15.78, -47.93,
            7.09, 171.38,
            -25.97, 32.58,
            41.33, 19.82,
            -41.29, 174.78,
            -34.61, -58.38,
            52.23, 21.01,
            -22.56, 17.08,
            23.13, -82.38,
            14.69, -17.44,
            33.51, 36.29,
            13.51, 2.11,
            -34.9, -56.19,
            54.33, 48.39,
            48.48, 135.08,
            55.15, 61.43,
            57.63, 39.87,
            11.56, 104.92,
            37.57, 126.98,
            1.29, 103.85,
            59.33, 18.06,
            14.08, -87.21,
            35.69, 139.69,
            12.37, -1.53
        };
        List<Weather> list = new List<Weather>();
        for (int i = 0; i < 100; i += 2)
        {
            string json_str =
                Get(
                    $"https://api.openweathermap.org/data/2.5/weather?lat={coords[i]}&lon={coords[i + 1]}&appid=505987218681a20946213ab33f11728b");
            JsonNode forecastNode = JsonNode.Parse(json_str)!;
            string country = forecastNode["sys"]!["country"]!.GetValue<string>();
            string name = forecastNode["name"]!.GetValue<string>();
            int temp = Convert.ToInt32(forecastNode["main"]!["temp"]!.GetValue<double>());
            JsonArray arr = forecastNode["weather"]!.AsArray()!;
            string description = arr[0]!["description"]!.GetValue<string>();
            list.Add(new Weather() { Country = country, Name = name, Temp = temp, Description = description });
        }

        var tmp = from p in list orderby p.Temp select p;
        Console.WriteLine($"Country with max temp: {tmp.Last().Country}, min temp: {tmp.First().Country}");

        var tmp1 = from p in list select p.Temp;
        var mean = tmp1.Sum() / tmp1.LongCount();
        Console.WriteLine($"Average temp: {mean}");

        var tmp2 = from p in list select p.Country;
        HashSet<string> set = new HashSet<string>(tmp2);
        Console.WriteLine($"Different coutries: {set.LongCount()}");

        var clear = from p in list where p.Description == "clear sky" select p;
        var rain = from p in list where p.Description == "rain" select p;
        var clouds = from p in list where p.Description == "few clouds" select p;

        if (clear.LongCount() != 0)
        {
            Console.WriteLine($"{clear.First().Country} {clear.First().Name}");
        } else Console.WriteLine("No \"clear sky\"");

        if (rain.LongCount() != 0)
        {
            Console.WriteLine($"{rain.First().Country} {rain.First().Name}");
        } else Console.WriteLine("No \"rain\"");

        if (clouds.LongCount() != 0)
        {
            Console.WriteLine($"{clouds.First().Country} {clouds.First().Name}");
        } else Console.WriteLine("No \"few clouds\"");
    }
}


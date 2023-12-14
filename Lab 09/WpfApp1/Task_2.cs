using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace WpfApp1
{
    class Programm
    {
        static string Get(string url)
        {
            var web = new WebClient();
            return web.DownloadString(url);
        }

        static Weather Main(double[] coords)
        {
            string json_str =
                Get(
                    $"https://api.openweathermap.org/data/2.5/weather?lat={coords[1]}&lon={coords[2]}&appid=505987218681a20946213ab33f11728b");
            JsonNode forecastNode = JsonNode.Parse(json_str)!;
            string country = forecastNode["sys"]!["country"]!.GetValue<string>();
            string name = forecastNode["name"]!.GetValue<string>();
            int temp = Convert.ToInt32(forecastNode["main"]!["temp"]!.GetValue<double>());
            JsonArray arr = forecastNode["weather"]!.AsArray()!;
            string description = arr[0]!["description"]!.GetValue<string>();
            return new Weather { Country = country, Name = name, Description = description, Temp = temp };
        }

        struct Weather
        {
            public string Country { get; set; }

            public string Name { get; set; }

            public int Temp { get; set; }

            public string Description { get; set; }
        }
    }
}
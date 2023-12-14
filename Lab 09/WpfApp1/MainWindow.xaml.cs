using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, double[]> dict = new Dictionary<string, double[]>()
        {
            { "Moscow", new[] { 55.75, 37.62 } },
            { "Abu_Dhabi", new[] { 24.47, 54.37 } },
            { "Addis_Ababa", new[] { 9.02, 38.75 } },
            { "Doha", new[] { 25.29, 51.53 } }
        };

        public MainWindow()
        {
            InitializeComponent();
        }


        private static string Get(string url)
        {
            var web = new WebClient();
            return web.DownloadString(url);
        }

        private async void Main(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            string city = button!.Name;
            double[] coords = dict[city];
            string jsonStr =
                Get(
                    $"https://api.openweathermap.org/data/2.5/weather?lat={coords[0]}&lon={coords[1]}&appid=505987218681a20946213ab33f11728b");
            JsonNode forecastNode = JsonNode.Parse(jsonStr)!;
            string country = forecastNode["sys"]!["country"]!.GetValue<string>();
            string name = forecastNode["name"]!.GetValue<string>();
            int temp = Convert.ToInt32(forecastNode["main"]!["temp"]!.GetValue<double>());
            JsonArray arr = forecastNode["weather"]!.AsArray()!;
            string description = arr[0]!["description"]!.GetValue<string>();
            MessageBox.Show($"Country: {country}\nCity: {city}\nTemperature: {temp}\nDescription: {description}");
        }
    }
}
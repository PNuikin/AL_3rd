using System.Globalization;
using System.Net;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

bool Get(string ticker)
{
    var web = new WebClient();
    try
    {
        web.DownloadFile($"https://query1.finance.yahoo.com/v7/finance/download/{ticker}?period1=1629072000&period2=1660608000&interval=1d&events=history&includeAdjustedClose=true",
            $"C:\\Users\\Hp\\AL_3rd\\Lab 09\\Files\\{ticker}.csv");
        return true;
    }
    catch (Exception e)
    {
        return false;
    }
    
    
}


StreamReader stream = new StreamReader("C:\\Users\\Hp\\AL_3rd\\Lab 09\\Files\\ticker.txt");
var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ",", PrepareHeaderForMatch = (args) => args.Header.ToLower().Replace(" ", ""),};
while (await stream.ReadLineAsync() is { } ticker)
{
    if (Get(ticker))
    {
        var csvStream = new StreamReader($"C:\\Users\\Hp\\AL_3rd\\Lab 09\\Files\\{ticker}.csv");
        var file = new CsvReader(csvStream, config);
        var records = file.GetRecords<Prices>();
        double avg_price = 0;
        int count = 0;
        foreach (var record in records)
        {
            avg_price += (record.High + record.Low) / 2;
            count++;
        }

        avg_price /= count;
        File.AppendAllText("answer.txt", $"{ticker}:{avg_price}\n");
        csvStream.Close();
    }
    
    File.Delete($"C:\\Users\\Hp\\AL_3rd\\Lab 09\\Files\\{ticker}.csv");
}

public class Prices
{
    public string Date { get; set; }
    public double Open { get; set; }
    public double High {get; set;}
    public double Low { get; set; }
    public double Close { get; set; }
    public double AdjClose { get; set; }
    public double Volume { get; set; }
    
    public Prices(string date, double open, double high, double low, double close, double adjClose, double volume)
    {
        Date = date;
        Open = open;
        High = high;
        Low = low;
        Close = close;
        AdjClose = adjClose;
        Volume = volume;
    }
}
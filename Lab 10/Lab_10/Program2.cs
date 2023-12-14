using System.Globalization;
using System.Net;
using CsvHelper;
using CsvHelper.Configuration;
using Lab_10;

using (ApplicationContext db = new ApplicationContext())
{
    StreamReader stream = new StreamReader("C:\\Users\\Hp\\AL_3rd\\Lab 10\\Lab_10\\ticker.txt");
    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        Delimiter = ",", PrepareHeaderForMatch = (args) =>
            args.Header.ToLower().Replace(" ", ""),
    };
    while (await stream.ReadLineAsync() is { } ticker)
    {
        if (Get(ticker))
        {
            var csvStream = new StreamReader($"C:\\Users\\Hp\\AL_3rd\\Lab 10\\Lab_10\\{ticker}.csv");
            var file = new CsvReader(csvStream, config);
            var records = file.GetRecords<Prices>().ToList();
            if (records.Count >= 2)
            {

                Ticker ticker1 = new Ticker { ticker = ticker };
                db.tickers.AddRange(ticker1);
                db.SaveChanges();



                var tickerId = (from ticket in db.tickers
                    where ticket.ticker == ticker
                    select ticket.Id).First();
                Price price = new Price
                {
                    tickerId = tickerId,
                    price = (records[^2].High + records[^2].Low) / 2,
                    date = records[^2].Date
                };
                db.prices.AddRange(price);
                db.SaveChanges();

                Condition condition = new Condition
                {
                    tickerId = tickerId,
                    state = db.prices.Find(tickerId)!.price > ((records[^1].High + records[^1].Low) / 2)
                };
                db.todayscondition.AddRange(condition);
                db.SaveChanges();
            }
            csvStream.Close();
            File.Delete($"C:\\Users\\Hp\\AL_3rd\\Lab 10\\Lab_10\\{ticker}.csv");
        }
    }
}

bool Get(string ticker)
{
    var web = new WebClient();
    try
    {
        long seconds = (long)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds;
        web.DownloadFile(
            $"https://query1.finance.yahoo.com/v7/finance/download/{ticker}?period1={seconds - 86400 * 2}&period2={seconds}&interval=1d&events=history&includeAdjustedClose=true",
            $"C:\\Users\\Hp\\AL_3rd\\Lab 10\\Lab_10\\{ticker}.csv");
        return true;
    }
    catch (Exception e)
    {
        return false;
    }
}


public class Prices
{
    public string Date { get; set; }
    public double Open { get; set; }
    public double High { get; set; }
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
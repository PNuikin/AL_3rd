using System.Net;

StreamReader stream = new StreamReader("C:\\Users\\Hp\\AL_3rd\\Lab 09\\Files\\ticker.txt");
var web = new WebClient();
while (await stream.ReadLineAsync() is { } ticker)
{
    web.DownloadFile(
        $"https://query1.finance.yahoo.com/v7/finance/download/{ticker}?period1=1629072000&period2=1660608000&interval=1d&events=history&includeAdjustedClose=true",
        $"C:\\Users\\Hp\\AL_3rd\\Lab 09\\Files\\{ticker}.csv");
}
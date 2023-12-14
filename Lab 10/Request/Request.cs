namespace Request;

class Request
{
    static void Main()
    {
        ApplicationContext db = new ApplicationContext();
        Console.WriteLine("Enter ticker you are interested in: ");
        string? ticker = Console.ReadLine();
        var tickerId = (from ticket in db.tickers
            where ticket.ticker == ticker
            select ticket.Id).First();
        var state = db.todayscondition.Find(tickerId)!.state;
        Console.WriteLine($"Current state of chosen ticker: {(state ? "rising" : "falling")}");
    }
}
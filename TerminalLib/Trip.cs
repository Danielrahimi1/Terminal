namespace Terminal;

class Trip
{
    public string Start { get; init; }
    public string End { get; init; }
    public DateTime Date { get; init; }
    public Bus Bus { get; init; }
    public int Capacity { get; set; }
    public decimal Price { get; init; }

    public Trip(string start, string end, DateTime date, Bus bus, decimal price)
    {
        Start = start;
        End = end;
        Date = date;
        Bus = bus;
        Capacity = Bus.Capacity;
        Price = price;
    }
}
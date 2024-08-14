namespace Terminal;

class Trip
{
    public string Origin { get; init; }
    public string Destination { get; init; }
    public DateTime Date { get; init; }
    public Bus Bus { get; init; }
    public int Capacity { get; set; }
    public decimal Price { get; init; }

    public Trip(string origin, string destination, DateTime date, Bus bus, decimal price)
    {
        Origin = origin;
        Destination = destination;
        Date = date;
        Bus = bus;
        Capacity = Bus.Capacity;
        Price = price;
    }
}
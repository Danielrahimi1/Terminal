namespace Terminal;

class Bus
{
    public BusType Type { get; init; }
    public int Capacity { get; set; }
    public string Plate { get; init; }

    public decimal Revenue { get; set; }

    public Bus(BusType type, int capacity, string plate)
    {
        Type = type;
        Capacity = capacity;
        Plate = plate;
        Revenue = 0M;
    }
}
namespace Terminal;

class Ticket
{
    // trip
    // bus
    // traveler
    public Trip Trip { get; init; }
    public Bus Bus { get; init; }
    public Traveler Traveler { get; init; }
    public TicketState State { get; set; }

    public Ticket(Trip trip, Bus bus, Traveler traveler, TicketState state)
    {
        Trip = trip;
        Bus = bus;
        Traveler = traveler;
        State = state;
    }
    
}


public enum TicketState
{
    Reserved = 1,
    Sold
}
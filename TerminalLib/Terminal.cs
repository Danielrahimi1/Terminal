using Terminal.Dto;

namespace Terminal;

public class Terminal
{
    private readonly List<Ticket> _tickets = [];
    private readonly List<Trip> _trips = [];
    private readonly List<Bus> _buses = [];
    private Traveler _traveler;

    public void CreateTraveler(string name, string lastName, string nationalCode, string mobile) =>
        _traveler = new Traveler(name, lastName, nationalCode, mobile);

    public void CreateTrip(string origin, string destination, DateTime date, int busId, decimal price) =>
        _trips.Add(new Trip(origin, destination, date, _buses[busId], price));

    public void ReserveTrip(int tripId, int busId, decimal cost)
    {
        if (DateTime.Now <= _trips[tripId].Date) return;
        if (_trips[tripId].Capacity == 0) return;
        if (_trips[tripId].Price * 0.3M > cost) return;
        var ticket = new Ticket(_trips[tripId], _buses[busId], _traveler, TicketState.Reserved);
        _trips[tripId].Capacity -= 1;
        _tickets.Add(ticket);
        _buses[busId].Revenue += cost;
    }

    public void SellTrip(int tripId, int busId, decimal cost)
    {
        if (DateTime.Now >= _trips[tripId].Date) return;
        if (_trips[tripId].Capacity == 0) return;
        if (_trips[tripId].Price > cost) return;
        var ticket = new Ticket(_trips[tripId], _buses[busId], _traveler, TicketState.Sold);
        _trips[tripId].Capacity -= 1;
        _tickets.Add(ticket);
        _buses[busId].Revenue += _trips[tripId].Price;
    }

    public void CancelTicket(int ticketId, out decimal refund)
    {
        var trip = _tickets[ticketId].Trip;
        refund = 0;
        if (DateTime.Now >= trip.Date) return;
        if (_tickets[ticketId].State == TicketState.Sold) refund = trip.Price * 0.8M;
        trip.Capacity += 1;
        _tickets.RemoveAt(ticketId);
        var busId = _buses.IndexOf(trip.Bus);
        _buses[busId].Revenue -= refund;
        // bug
        // var bus = trip.Bus.Revenue -= refund;
    }

    public void CreateBus(BusType type, int capacity, string plate) => _buses.Add(new Bus(type, capacity, plate));

    public string MostDestination()
    {
        // var asd = _trips.Select(trip => trip.End).GroupBy(_ => _).OrderByDescending(end => end.Count()).FirstOrDefault()!;
        //return _trips.Select(trip => trip.End).GroupBy(_ => _).OrderDescending().FirstOrDefault()!.Key;
        // return _trips.GroupBy(trip => trip.End).OrderDescending().FirstOrDefault()!.Key;
        // return _trips.GroupBy(trip => trip.End).OrderByDescending(end => end.Count()).FirstOrDefault().ToString();
        // return _trips.GroupBy(trip => trip.End).OrderByDescending(end => end.Count()).FirstOrDefault().ToString();
        return _trips.GroupBy(trip => trip.Destination).OrderByDescending(_ => _.Count()).FirstOrDefault()!.Key;
        // .Select(g => g.Key).ToList();
        //return _trips.Select(trip => trip.End).OrderByDescending(end => end.Count()).FirstOrDefault()!;
        // return "";
    }

    // _trips.Select(trip => trip.End).MaxBy();


    public string MostOrigin() => _trips.GroupBy(trip => trip.Origin).OrderByDescending(_ => _.Count()).FirstOrDefault()!.Key;
    // _trips.Select(trip => trip.Origin).OrderByDescending(origin => origin.Count()).FirstOrDefault()!;

    public List<BusDto> BusRevenue()
    {
        List<BusDto> busesDto = [];
        _buses.OrderByDescending(bus => bus.Revenue).ToList().ForEach(bus =>
        {
            busesDto.Add(new BusDto()
            {
                Type = bus.Type.ToString(),
                Plate = bus.Plate,
                Revenue = bus.Revenue
            });
        });
        return busesDto;
    }
}
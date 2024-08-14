using Terminal;

var terminal = new Terminal.Terminal();

terminal.CreateBus(BusType.Normal, 20, "654");
terminal.CreateTraveler("Danial", "Rahimi", "238", "939");
terminal.CreateTrip("Shiraz", "Nurabad", DateTime.Now.AddDays(3), 0, 1000M);
terminal.ReserveTrip(0, 0, 1500M);
terminal.SellTrip(0, 0, 1500M);
terminal.SellTrip(0, 0, 1500M);


foreach (var rev in terminal.BusRevenue())
{
    Console.WriteLine(rev);
}

Console.WriteLine(terminal.MostInTraveler());
Console.WriteLine(terminal.MostOutTraveler());
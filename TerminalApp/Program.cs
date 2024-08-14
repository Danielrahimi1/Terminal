using Terminal;

var terminal = new Terminal.Terminal();

terminal.CreateBus(BusType.Normal, 40, "654");
terminal.CreateBus(BusType.Vip, 20, "123");
terminal.CreateTraveler("Danial", "Rahimi", "238", "939");
terminal.CreateTrip("Shiraz", "Nurabad", DateTime.Now.AddDays(3), 0, 1000M);
terminal.CreateTrip("Sydney", "Nurabad", DateTime.Now.AddDays(3), 0, 1000M);
terminal.CreateTrip("Vancouver", "Masiri", DateTime.Now.AddDays(3), 0, 1000M);
terminal.CreateTrip("Vancouver", "Nurabad", DateTime.Now.AddDays(3), 0, 1000M);
terminal.CreateTrip("Vancouver", "shiraz", DateTime.Now.AddDays(3), 0, 1000M);
terminal.CreateTrip("Vancouver", "London", DateTime.Now.AddDays(3), 0, 1000M);
terminal.ReserveTrip(0, 0, 1500M);
terminal.SellTrip(0, 0, 1500M);
terminal.SellTrip(1, 0, 1500M);
terminal.SellTrip(2, 0, 1500M);
terminal.SellTrip(3, 0, 1500M);
terminal.SellTrip(3, 0, 1500M);
terminal.SellTrip(3, 0, 1500M);
terminal.SellTrip(3, 0, 1500M);
terminal.SellTrip(3, 0, 1500M);
terminal.SellTrip(4, 0, 1500M);
terminal.SellTrip(5, 0, 1500M);
terminal.SellTrip(5, 0, 1500M);


WriteLine($"Plate\t\tType\t\tRevenue");
foreach (var rev in terminal.BusRevenue())
{
    WriteLine(rev);
}

WriteLine($"Most traveled to: {terminal.MostDestination()}");
WriteLine($"Most traveled from: {terminal.MostOrigin()}");

namespace Terminal.Dto;

public class BusDto
{
    public string Type { get; init; }
    public string Plate { get; init; }
    public decimal Revenue { get; init; }

    public override string ToString() => $"{Type} {Plate} {Revenue}";
}
namespace Terminal;

class Traveler
{
    public string Name { get; init; }
    public string LastName { get; init; }
    public string NationalCode { get; init; }
    public string Mobile { get; init; }

    public Traveler(string name, string lastName, string nationalCode, string mobile)
    {
        Name = name;
        LastName = lastName;
        NationalCode = nationalCode;
        Mobile = mobile;
    }
}
namespace MicroFms;

public class Vehicle
{
    public Vehicle(int id, string name, string vinCode)
    {
        Id = id;
        Name = name;
        VinCode = vinCode;
    }

    public int Id { get; }

    public string Name { get; }

    public string VinCode { get; }
}

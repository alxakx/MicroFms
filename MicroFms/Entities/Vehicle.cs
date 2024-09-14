namespace MicroFms.Entities;

public class Vehicle
{
    public Vehicle(int id, string name, string vinCode, bool isDeleted)
    {
        Id = id;
        Name = name;
        VinCode = vinCode;
        IsDeleted = isDeleted;
    }

    public int Id { get; }

    public string Name { get; }

    public string VinCode { get; }

    public bool IsDeleted { get; set; }
}

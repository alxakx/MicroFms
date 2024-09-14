namespace MicroFms.Entities;

public class Driver
{
    public Driver(int id, string name, string lastName, bool isDeleted)
    {
        Id = id;
        FirstName = name;
        LastName = lastName;
        IsDeleted = isDeleted;
    }

    public int Id { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public bool IsDeleted { get; set; }
}

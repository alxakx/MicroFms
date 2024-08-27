namespace MicroFms;

public class Driver
{
    public Driver(int id, string name, string lastName)
    {
        Id = id;
        FirstName = name;
        LastName = lastName;
    }

    public int Id { get; }

    public string FirstName { get; }

    public string LastName { get; }
}

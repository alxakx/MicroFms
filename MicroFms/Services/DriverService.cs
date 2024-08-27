namespace MicroFms;

public class DriverService
{
    private List<Driver> drivers = [];

    public void AddDriver()
    {
        var index = drivers.Count;
        var firstName = EnterFirstName();
        var lastName = EnterLastName();

        if (firstName.Length != 0 && lastName.Length != 0)
        {
            var driver = new Driver(index, firstName, lastName);

            drivers.Add(driver);
        }
        else
        {
            Console.WriteLine($"\n Firstname or lastname is empty");
        }
    }

    public void RemoveDriver()
    {
        if (drivers.Count == 0)
        {
            Console.WriteLine($"\nDriver list is empty\n");
        }
        else
        {
            var firstName = EnterFirstName();
            var lastName = EnterLastName();

            for (int i = 0; i < drivers.Count; i++)
            {
                if (drivers[i].FirstName == firstName && drivers[i].LastName == lastName)
                {
                    drivers.Remove(drivers[i]);
                    Console.WriteLine($"Driver with name = {firstName} and Lastname = {lastName} is removed from driver list");
                }
                else
                {
                    Console.WriteLine($"Driver with name = {firstName} and lastname = {lastName} was not found");
                }
            }
        }
    }

    public void ShowDriverList()
    {
        Console.WriteLine($"\nDrivers:\n");

        if (drivers.Count == 0)
        {
            Console.WriteLine("\nDriver list is empty\n");
        }
        else
        {
            for (var i = 0; i < drivers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {drivers[i].FirstName} {drivers[i].LastName}");
            }
        }
    }

    private static string EnterFirstName()
    {
        Console.Write("Enter firstname: ");

        return Console.ReadLine();
    }

    private static string EnterLastName()
    {
        Console.Write("Enter lastname: ");

        return Console.ReadLine();
    }
}

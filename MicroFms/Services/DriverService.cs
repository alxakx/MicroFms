using MicroFms.Entities;

namespace MicroFms.Services;

public class DriverService
{
    private List<Driver> drivers = [
        new Driver(0, "John", "Smith", false),
        new Driver(1, "Matt", "Sew", false),
        new Driver(2, "Andrew", "Hodson", false),
        new Driver(3, "Olaf", "Bad", false),
        new Driver(4, "Kris", "Little", false),
        ];

    public void AddDriver()
    {
        var index = 0;
        var firstName = EnterFirstName();
        var lastName = EnterLastName();
        var isDeleted = false;

        if (drivers.Count > 0)
        {
            var lastRecord = drivers[drivers.Count - 1];
            index = lastRecord.Id + 1;
        }

        if (firstName.Length != 0 && lastName.Length != 0)
        {
            var driver = new Driver(index, firstName, lastName, isDeleted);

            drivers.Add(driver);

            Console.WriteLine($"Diver {firstName} {lastName} successfull added to list");
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
            var isExists = false;

            for (int i = 0; i < drivers.Count; i++)
            {
                if (drivers[i].FirstName == firstName && drivers[i].LastName == lastName && !drivers[i].IsDeleted)
                {
                    drivers[i].IsDeleted = true;
                    isExists = true;
                    Console.WriteLine($"Driver with name = {firstName} and Lastname = {lastName} is removed from driver list");
                    break;
                }
            }

            if (!isExists)
            {
                Console.WriteLine($"Driver with name = {firstName} and lastname = {lastName} was not found");
            }
        }
    }

    public void ShowDriverList()
    {
        Console.WriteLine($"\nDrivers:\n");
        var count = 1;

        if (drivers.Count == 0)
        {
            Console.WriteLine("\nDriver list is empty\n");
        }
        else
        {
            for (var i = 0; i < drivers.Count; i++)
            {
                if (!drivers[i].IsDeleted)
                {
                    Console.WriteLine($"{count}. {drivers[i].FirstName} {drivers[i].LastName}");
                    count++;
                }
            }
        }
    }

    public List<Driver> GetDrivers()
    {
        return drivers;
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

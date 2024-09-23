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

    public Driver? AddDriver(string firstName, string lastName)
    {
        var index = 0;
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

            return driver;
        }
        else
        {
            return null;
        }
    }

    public Driver? RemoveDriver(int driverId)
    {
        for (int i = 0; i < drivers.Count; i++)
        {
            if (drivers[i].Id == driverId && !drivers[i].IsDeleted)
            {
                drivers[i].IsDeleted = true;
                return drivers[i];
            }
        }

        return null;
    }

    public Driver? FindDriver(string firstName, string lastName)
    {
        return drivers.Where(driver => driver.FirstName == firstName && driver.LastName == lastName).FirstOrDefault();
    }

    public bool IsEmpty()
    {
        return drivers.Count == 0;
    }

    public List<Driver> GetDrivers()
    {
        return drivers;
    }
}

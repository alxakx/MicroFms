using MicroFms.Entities;
using MicroFms.Services;
using System.Xml.Linq;

namespace MicroFms.Controllers;

public class DriverController
{
    private const string ExitCommand = "0";
    private const string AddDriverCommand = "1";
    private const string RemoveDriverCommand = "2";
    private const string ShowDriversListCommand = "3";

    private readonly DriverService _driverService;
    private readonly DriverVehicleRefService _driverVehicleRefService;

    public DriverController(DriverService driverService, DriverVehicleRefService driverVehicleRefService)
    {
        _driverService = driverService;
        _driverVehicleRefService = driverVehicleRefService;
    }

    public void DisplayDriverMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.CursorTop = 5;
            Console.WriteLine("List of commands:\n" +
                $"\n{AddDriverCommand} - Add new driver to drivers list" +
                $"\n{RemoveDriverCommand} - Remove driver from drivers list" +
                $"\n{ShowDriversListCommand} - Show drivers list" +
                $"\n\n{ExitCommand} - Return to BaseMenu");

            Console.Write("\nEnter selected command: ");
            var userSelect = Console.ReadLine();

            switch (userSelect)
            {
                case AddDriverCommand:
                    ExecuteOperation(AddDriver);
                    break;

                case RemoveDriverCommand:
                    ExecuteOperation(RemoveDriver);
                    break;

                case ShowDriversListCommand:
                    ExecuteOperation(ShowDriverList);
                    break;

                case ExitCommand:
                    return;

                default:
                    ExecuteOperation(ShowUnknowCommandMessage);
                    break;
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

    private static void ShowContinueMessage()
    {
        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
    }

    private static void ShowUnknowCommandMessage()
    {
        Console.WriteLine("\nUnknow command");
    }

    private void AddDriver()
    {
        var firstName = EnterFirstName();
        var lastName = EnterLastName();
        var driver = _driverService.FindDriver(firstName, lastName);
        if (driver != null)
        {
            Console.WriteLine($"Driver with firstName = {firstName} and lastName = {lastName} already exists in the driver list");
        }
        else
        {
            var newDriver = _driverService.AddDriver(firstName, lastName);
            if (newDriver != null)
            {
                Console.WriteLine($"Driver {firstName} {lastName} successfull added to list");
            }
            else
            {
                Console.WriteLine($"\nEntered data is incorrected");
            }
        }
    }

    private void RemoveDriver()
    {
        if (_driverService.IsEmpty())
        {
            Console.WriteLine($"\nDriver list is empty\n");
            return;
        }

        var firstName = EnterFirstName();
        var lastName = EnterLastName();
        var driver = _driverService.FindDriver(firstName, lastName);
        if (driver != null)
        {
            _driverVehicleRefService.RemoveRecordByDriverId(driver.Id);
            _driverService.RemoveDriver(driver.Id);
            Console.WriteLine($"Driver with firstName = {firstName} and lastNeme = {lastName} is removed from driver list");
        }
        else
        {
            Console.WriteLine($"Driver with firstName = {firstName} and lastNeme = {lastName} was not found");
        }
    }

    private void ShowDriverList()
    {
        var drivers = _driverService.GetDrivers();
        var count = 1;

        Console.WriteLine($"\nDrivers:\n");

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

    private delegate void Operation();

    private void ExecuteOperation(Operation operation1)
    {
        Console.Clear();
        operation1();
        ShowContinueMessage();
    }
}

using MicroFms.Entities;
using MicroFms.Services;

namespace MicroFms.Controllers;

public class VehicleController
{
    private const string ExitCommand = "0";
    private const string AddVehicleCommand = "1";
    private const string RemoveVehicleCommand = "2";
    private const string ShowVehiclesListCommand = "3";

    private readonly VehicleService _vehicleService;
    private readonly DriverVehicleRefService _driverVehicleRefService;

    public VehicleController(VehicleService vehicleService, DriverVehicleRefService driverVehicleRefService)
    {
        _vehicleService = vehicleService;
        _driverVehicleRefService = driverVehicleRefService;
    }

    public void DisplayVehicleMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.CursorTop = 5;
            Console.WriteLine("List of commands:\n" +
                $"\n{AddVehicleCommand} - Add new vehicle to vehicle list" +
                $"\n{RemoveVehicleCommand} - Remove vehicle from vehicle list" +
                $"\n{ShowVehiclesListCommand} - Show vehicle List" +
                $"\n\n{ExitCommand} - Return to BaseMenu");

            Console.Write("\nEnter selected command: ");
            var userSelect = Console.ReadLine();

            switch (userSelect)
            {
                case AddVehicleCommand:
                    ExecuteOperation(AddVehicle);
                    break;

                case RemoveVehicleCommand:
                    ExecuteOperation(RemoveVehicle);
                    break;

                case ShowVehiclesListCommand:
                    ExecuteOperation(ShowVehicleList);
                    break;

                case ExitCommand:
                    return;

                default:
                    ExecuteOperation(ShowUnknowCommandMessage);
                    break;
            }
        }
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

    private static string EnterName()
    {
        Console.Write("Enter vehicle name: ");

        return Console.ReadLine();
    }

    private static string EnterVinCode()
    {
        Console.Write("Enter vinCode: ");

        return Console.ReadLine();
    }

    private void AddVehicle()
    {
        var name = EnterName();
        var vin = EnterVinCode();
        var vehicle = _vehicleService.FindVehicle(name, vin);
        if (vehicle != null)
        {
            Console.WriteLine($"Vehicle with name = {name} and vincode = {vin} already exists in the vehicle list");
        }
        else
        {
            var newVehicle = _vehicleService.AddVehicle(name, vin);
            if (newVehicle != null)
            {
                Console.WriteLine($"Vehicle {name} VIN: {vin} successfull added to list");
            }
            else
            {
                Console.WriteLine($"\nEntered data is incorrected");
            }
        }
    }

    private void RemoveVehicle()
    {
        if (_vehicleService.IsEmpty())
        {
            Console.WriteLine($"\nVehicle list is empty\n");
            return;
        }

        var name = EnterName();
        var vin = EnterVinCode();
        var vehicle = _vehicleService.FindVehicle(name, vin);
        if (vehicle != null)
        {
            _driverVehicleRefService.RemoveRecordByVehicleId(vehicle.Id);
            _vehicleService.RemoveVehicle(vehicle.Id);
            Console.WriteLine($"Vehicle with name = {name} and vincode = {vin} is removed from vehicle list");
        }
        else
        {
            Console.WriteLine($"Vehicle with name = {name} and vincode = {vin} was not found");
        }
    }

    private void ShowVehicleList()
    {
        var vehicles = _vehicleService.GetVehicles();
        var count = 1;

        Console.WriteLine($"\nVehicles:\n");

        if (vehicles.Count == 0)
        {
            Console.WriteLine("\nVehicle list is empty\n");
        }
        else
        {
            for (var i = 0; i < vehicles.Count; i++)
            {
                if (!vehicles[i].IsDeleted)
                {
                    Console.WriteLine($"{count}. {vehicles[i].Name} {vehicles[i].VinCode}");
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

using MicroFms.Services;

namespace MicroFms.Controllers;

public class VehicleController
{
    private const string ExitCommand = "0";
    private const string AddVehicleCommand = "1";
    private const string RemoveVehicleCommand = "2";
    private const string ShowVehiclesListCommand = "3";

    private readonly BaseController _baseController = new();
    private readonly VehicleService _vehicleService = new();

    public void DisplayVehicleMenu()
    {
        Console.Clear();
        Console.CursorTop = 5;
        Console.WriteLine("List of commands:\n" +
            $"\n{AddVehicleCommand} - Add new vehicle to vehicle list" +
            $"\n{RemoveVehicleCommand} - Remove vehicle from vehicle list" +
            $"\n{ShowVehiclesListCommand} - Show vehicle List" +
            $"\n\n{ExitCommand} - Return to BaseMenu");

        Console.Write("Enter selected command: ");
        var userSelect = Console.ReadLine();

        switch (userSelect)
        {
            case AddVehicleCommand:
                ExecuteOperation(_vehicleService.AddVehicle);
                break;

            case RemoveVehicleCommand:
                ExecuteOperation(_vehicleService.RemoveVehicle);
                break;

            case ShowVehiclesListCommand:
                ExecuteOperation(_vehicleService.ShowVehicleList);
                break;

            case ExitCommand:
                _baseController.DisplayMenu();
                break;

            default:
                ExecuteOperation(ShowUnknowCommandMessage);
                break;
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

    private delegate void Operation();

    private void ExecuteOperation(Operation operation1)
    {
        Console.Clear();
        operation1();
        ShowContinueMessage();
        DisplayVehicleMenu();
    }
}

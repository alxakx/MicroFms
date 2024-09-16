using MicroFms.Services;

namespace MicroFms.Controllers;

public class VehicleController
{
    private const string ExitCommand = "0";
    private const string AddVehicleCommand = "1";
    private const string RemoveVehicleCommand = "2";
    private const string ShowVehiclesListCommand = "3";

    private readonly VehicleService _vehicleService;

    public VehicleController(VehicleService vehicleService)
    {
        _vehicleService = vehicleService;
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
                    ExecuteOperation(_vehicleService.AddVehicle);
                    break;

                case RemoveVehicleCommand:
                    ExecuteOperation(_vehicleService.RemoveVehicle);
                    break;

                case ShowVehiclesListCommand:
                    ExecuteOperation(_vehicleService.ShowVehicleList);
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

    private delegate void Operation();

    private void ExecuteOperation(Operation operation1)
    {
        Console.Clear();
        operation1();
        ShowContinueMessage();
    }
}

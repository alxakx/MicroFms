namespace MicroFms;

public class Menu
{
    private const string ExitCommand = "0";
    private const string AddDriverCommand = "1";
    private const string RemoveDriverCommand = "2";
    private const string ShowDriversListCommand = "3";
    private const string AddVehicleCommand = "4";
    private const string RemoveVehicleCommand = "5";
    private const string ShowVehiclesListCommand = "6";
    private const string ShowDriverAndVevicleListsCommand = "7";

    private readonly DriverService _driverService = new();
    private readonly VehicleService _vehicleService = new();

    public void DisplayMenu()
    {
        Console.Clear();
        Console.CursorTop = 5;
        Console.WriteLine("List of commands:" +
            "\n\nDriver section" +
            $"\n{AddDriverCommand} - Add new driver to drivers list" +
            $"\n{RemoveDriverCommand} - Remove driver from drivers list" +
            $"\n{ShowDriversListCommand} - Show drivers list" +
            "\n\nVehicle section" +
            $"\n{AddVehicleCommand} - Add new vehicle to vehicle list" +
            $"\n{RemoveVehicleCommand} - Remove vehicle from vehicle list" +
            $"\n{ShowVehiclesListCommand} - Show vehicle List" +
            $"\n\n{ShowDriverAndVevicleListsCommand} - Show driver and vehicle list\n" +
            $"\n\n{ExitCommand} - Exit from menu\n\n");

        Console.Write("Enter selected command: ");
        var userSelect = Console.ReadLine();

        switch (userSelect)
        {
            case AddDriverCommand:
                ExecuteOperation(_driverService.AddDriver, null);
                break;

            case RemoveDriverCommand:
                ExecuteOperation(_driverService.RemoveDriver, null);
                break;

            case ShowDriversListCommand:
                ExecuteOperation(_driverService.ShowDriverList, null);
                break;

            case AddVehicleCommand:
                ExecuteOperation(_vehicleService.AddVehicle, null);
                break;

            case RemoveVehicleCommand:
                ExecuteOperation(_vehicleService.RemoveVehicle, null);
                break;

            case ShowVehiclesListCommand:
                ExecuteOperation(_vehicleService.ShowVehicleList, null);
                break;

            case ShowDriverAndVevicleListsCommand:
                ExecuteOperation(_driverService.ShowDriverList, _vehicleService.ShowVehicleList);
                break;

            case ExitCommand:
                Environment.Exit(0);
                break;

            default:
                ExecuteOperation(ShowUnknowCommandMessage, null);
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

    private void ExecuteOperation(Operation operation1, Operation? operation2)
    {
        Console.Clear();
        operation1();
        operation2?.Invoke();
        ShowContinueMessage();
        DisplayMenu();
    }
}

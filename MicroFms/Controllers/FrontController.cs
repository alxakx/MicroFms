namespace MicroFms.Controllers;

public class FrontController
{
    private const string ExitCommand = "0";
    private const string ShowDriverMenu = "1";
    private const string ShowVehicleMenu = "2";
    private const string ShowDriverVehicleRefMenu = "3";

    private readonly DriverController _driverController;
    private readonly VehicleController _vehicleController;
    private readonly DriverVehicleRefController _driverVehicleRefController;

    public FrontController(DriverController driverController, VehicleController vehicleController, DriverVehicleRefController driverVehicleRefController)
    {
        _driverController = driverController;
        _vehicleController = vehicleController;
        _driverVehicleRefController = driverVehicleRefController;
    }

    public void DisplayMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.CursorTop = 5;
            Console.WriteLine("List of commands:\n" +
                $"\n{ShowDriverMenu} - Show driver menu" +
                $"\n{ShowVehicleMenu} - Show vehicle menu" +
                $"\n{ShowDriverVehicleRefMenu} - Show drivers and vehicle referense menu" +
                $"\n\n{ExitCommand} - Exit from menu\n\n");

            Console.Write("Enter selected command: ");
            var userSelect = Console.ReadLine();

            switch (userSelect)
            {
                case ShowDriverMenu:
                    ExecuteOperation(_driverController.DisplayDriverMenu);
                    break;

                case ShowVehicleMenu:
                    ExecuteOperation(_vehicleController.DisplayVehicleMenu);
                    break;

                case ShowDriverVehicleRefMenu:
                    ExecuteOperation(_driverVehicleRefController.DisplayReferenseMenu);
                    break;

                case ExitCommand:
                    Environment.Exit(0);
                    break;

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

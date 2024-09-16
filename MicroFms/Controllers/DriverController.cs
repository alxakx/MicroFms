using MicroFms.Services;

namespace MicroFms.Controllers;

public class DriverController
{
    private const string ExitCommand = "0";
    private const string AddDriverCommand = "1";
    private const string RemoveDriverCommand = "2";
    private const string ShowDriversListCommand = "3";

    private readonly DriverService _driverService;

    public DriverController(DriverService driverService)
    {
        _driverService = driverService;
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
                    ExecuteOperation(_driverService.AddDriver);
                    break;

                case RemoveDriverCommand:
                    ExecuteOperation(_driverService.RemoveDriver);
                    break;

                case ShowDriversListCommand:
                    ExecuteOperation(_driverService.ShowDriverList);
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

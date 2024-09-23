using MicroFms.Entities;
using MicroFms.Services;

namespace MicroFms.Controllers;

public class DriverVehicleRefController
{
   /* private const string ExitCommand = "0";
    private const string AddRecordCommand = "1";
    private const string RemoveRecordCommand = "2";
    private const string ShowRecordsCommand = "3";*/

    private readonly DriverService _driverService;
    private readonly VehicleService _vehicleService;
    private readonly DriverVehicleRefService _driverVehicleRefService;

    public DriverVehicleRefController(DriverService driverService, VehicleService vehicleService, DriverVehicleRefService driverVehicleRefService)
    {
        _driverService = driverService;
        _vehicleService = vehicleService;
        _driverVehicleRefService = driverVehicleRefService;
    }

    public void DisplayReferenseMenu()
    {
        const string ExitCommand = "0";
        const string AddRecordCommand = "1";
        const string RemoveRecordCommand = "2";
        const string ShowRecordsCommand = "3";

        while (true)
        {
            Console.Clear();
            Console.CursorTop = 5;
            Console.WriteLine("List of commands:\n" +
                $"\n{AddRecordCommand} - Add new record to referense list" +
                $"\n{RemoveRecordCommand} - Remove record from referense list" +
                $"\n{ShowRecordsCommand} - Show referense List" +
                $"\n\n{ExitCommand} - Return to BaseMenu");

            Console.Write("\nEnter selected command: ");
            var userSelect = Console.ReadLine();

            switch (userSelect)
            {
                case AddRecordCommand:
                    ExecuteOperation(AddRecord);
                    break;

                case RemoveRecordCommand:
                    ExecuteOperation(RemoveRecord);
                    break;

                case ShowRecordsCommand:
                    ExecuteOperation(ShowRecords);
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

    private static int EnterDriverId()
    {
        Console.WriteLine("Enter driverID: ");
        return EnterId();
    }

    private static int EnterVehicleId()
    {
        Console.WriteLine("Enter vehicleID: ");
        return EnterId();
    }

    private static int EnterDriverVehicleRefId()
    {
        Console.WriteLine("Enter driverVehicleRefID: ");
        return EnterId();
    }

    private static int EnterId()
    {
        var value = Console.ReadLine();
        Console.WriteLine($"Entered '{value}'");

        if (!int.TryParse(value, out int result))
        {
            Console.WriteLine("Invalid integer. Repeat the input: ");
            EnterId();
        }

        return result;
    }

    private void AddRecord()
    {
        Console.Clear();
        Console.WriteLine("\nCreating a new record\n");

        var driverId = EnterDriverId();
        var isExists = _driverVehicleRefService.IsDriverExists(driverId);
        if (!isExists)
        {
            Console.WriteLine($"Driver with Id = {driverId} not found in driver list");
            return;
        }

        var vehicleId = EnterVehicleId();
        isExists = _driverVehicleRefService.IsVehicleExists(vehicleId);

        if (!isExists)
        {
            Console.WriteLine($"Vehicle with Id = {vehicleId} not found in vehicle list");
            return;
        }

        isExists = _driverVehicleRefService.IsRecordExists(driverId, vehicleId);
        if (isExists)
        {
            Console.WriteLine($"Record with DriverId = {driverId} and VehicleId = {vehicleId} already exists in the list of references");
            return;
        }
        else
        {
            _driverVehicleRefService.AddRecord(driverId, vehicleId);
            Console.WriteLine($"Record with DriverId = {driverId} and VehicleId = {vehicleId} successfully added");
        }
    }

    private void RemoveRecord()
    {
        const string removeByRecordIdCommand = "1";
        const string removeByDriverIdCommand = "2";
        const string removeByVehicleIdCommand = "3";
        const string backCommand = "0";

        while (true)
        {
            Console.Clear();
            Console.CursorTop = 5;
            Console.WriteLine("List of commands:\n" +
                $"\n{removeByRecordIdCommand} - Remove record by RecordId" +
                $"\n{removeByDriverIdCommand} - Remove record by DriverId" +
                $"\n{removeByVehicleIdCommand} - Remove record by VehicleId" +
                $"\n\n{backCommand} - back to Record Control Menu");

            Console.Write("\nEnter selected command: ");
            var userSelect = Console.ReadLine();

            switch (userSelect)
            {
                case removeByRecordIdCommand:
                    ExecuteOperation(RemoveByRecordId);
                    break;

                case removeByDriverIdCommand:
                    ExecuteOperation(RemoveByDriverId);
                    break;

                case removeByVehicleIdCommand:
                    ExecuteOperation(RemoveByVehicleId);
                    break;

                case backCommand:
                    return;

                default:
                    ExecuteOperation(ShowUnknowCommandMessage);
                    break;
            }
        }
    }

    private void RemoveByRecordId()
    {
        var recordId = EnterDriverVehicleRefId();
        if (!_driverVehicleRefService.IsRecordIdInRefs(recordId))
        {
            Console.WriteLine($"Record with Id = {recordId} not found in reference list");
        }
        else
        {
            _driverVehicleRefService.RemoveRecordById(recordId);
        }
    }

    private void RemoveByDriverId()
    {
        var driverId = EnterDriverId();
        if (!_driverVehicleRefService.IsRecordIdInRefs(driverId))
        {
            Console.WriteLine($"Record with DriverId = {driverId} not found in reference list");
        }
        else
        {
            _driverVehicleRefService.RemoveRecordByDriverId(driverId);
        }
    }

    private void RemoveByVehicleId()
    {
        var vehicleId = EnterVehicleId();
        if (!_driverVehicleRefService.IsRecordIdInRefs(vehicleId))
        {
            Console.WriteLine($"Record with VehicleId = {vehicleId} not found in reference list");
        }
        else
        {
            _driverVehicleRefService.RemoveRecordByVehicleId(vehicleId);
        }
    }

    private void ShowRecords()
    {
        var records = _driverVehicleRefService.GetReferencesList();
        foreach (var record in records)
        {
            Console.WriteLine($"RecordId = {record.Id}; DriverID = {record.DriverId}; VehicleId = {record.VehicleId}");
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

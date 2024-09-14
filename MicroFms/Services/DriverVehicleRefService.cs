using MicroFms.Entities;

namespace MicroFms.Services;

internal class DriverVehicleRefService
{
    private List<DriverVehicleRef> driverVehicleRefs = new();
   /* private DriverService _driverService;
    private VehicleService _vehicleService;

    public DriverVehicleRefService (DriverService driverService,  VehicleService vehicleService)
    {
        _driverService = driverService;
        _vehicleService = vehicleService;
    }*/

    public void ShowRecords()
    {
        foreach (var record in driverVehicleRefs)
        {
            Console.WriteLine($"RecordId = {record.Id}; DriverID = {record.DrivetId}; VehicleId = {record.VehicleId}");
        }
    }

    public void AddRecord()
    {
        Console.Clear();

        Console.WriteLine("Enter driverID: ");
        var driverId = EnterId();

        Console.WriteLine("Enter vehicleID: ");
        var vehicleId = EnterId();


    }

    public void RemoveRecordByKey()
    {

    }

    public void RemoveRecordByValue() 
    {

    }

    public void UpdateRecordByKey()
    {

    }

    public void UpdateRecordByValue()
    {

    }

    private int EnterId()
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
}

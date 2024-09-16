using MicroFms.Entities;

namespace MicroFms.Services;

public class DriverVehicleRefService
{
    private List<DriverVehicleRef> driverVehicleRefs = [];
    private DriverService _driverService;
    private VehicleService _vehicleService;

    public DriverVehicleRefService(DriverService driverService, VehicleService vehicleService)
    {
        _driverService = driverService;
        _vehicleService = vehicleService;
    }

    public void ShowRecords()
    {
        foreach (var record in driverVehicleRefs)
        {
            Console.WriteLine($"RecordId = {record.Id}; DriverID = {record.DrivetId}; VehicleId = {record.VehicleId}");
        }
    }

    public void AddRecord()
    {
        var index = 0;

        Console.Clear();

        Console.WriteLine("Enter driverID: ");
        var driverId = EnterId();

        var isExists = IsDriverExists(_driverService.GetDrivers(), driverId);

        if (!isExists)
        {
            Console.WriteLine($"Driver with Id={driverId} not exists");
            return;
        }

        Console.WriteLine("Enter vehicleID: ");
        var vehicleId = EnterId();

        isExists = IsVehicleExists(_vehicleService.GetVehicles(), vehicleId);

        if (!isExists)
        {
            Console.WriteLine($"Vehicle with Id={vehicleId} not exists");
            return;
        }

        if (driverVehicleRefs.Count > 0)
        {
            var lastRecord = driverVehicleRefs[driverVehicleRefs.Count - 1];
            index = lastRecord.Id + 1;
        }

        var driverVehicleRef = new DriverVehicleRef(index, driverId, vehicleId);
        driverVehicleRefs.Add(driverVehicleRef);

        Console.WriteLine($"Record for Driver Id={driverId} and Vehicle Id={vehicleId} added successfull");
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

    private bool IsDriverExists(List<Driver> drivers, int id)
    {
        foreach (var driver in drivers)
        {
            if (driver.Id == id && driver.IsDeleted == false)
            {
                return true;
            }
        }


        return false;
    }

    private bool IsVehicleExists(List<Vehicle> vehicles, int id)
    {
        foreach (var vehicle in vehicles)
        {
            if (vehicle.Id == id && vehicle.IsDeleted == false)
            {
                return true;
            }
        }

        return false;
    }
}

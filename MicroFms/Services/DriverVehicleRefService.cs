using MicroFms.Entities;

namespace MicroFms.Services;

public class DriverVehicleRefService
{
    private List<DriverVehicleRef> driverVehicleRefs = [
        new DriverVehicleRef(0, 0, 0),
        new DriverVehicleRef(1, 0, 2),
        new DriverVehicleRef(2, 1, 1),
        new DriverVehicleRef(3, 1, 3),
        new DriverVehicleRef(4, 2, 2),
        new DriverVehicleRef(5, 3, 4),
        new DriverVehicleRef(6, 4, 5),
        new DriverVehicleRef(7, 3, 6),
        new DriverVehicleRef(8, 4, 6),
        ];

    private DriverService _driverService;
    private VehicleService _vehicleService;

    public DriverVehicleRefService(DriverService driverService, VehicleService vehicleService)
    {
        _driverService = driverService;
        _vehicleService = vehicleService;
    }

    public List<DriverVehicleRef> GetReferencesList()
    {
        return driverVehicleRefs;
    }

    public void AddRecord(int driverId, int vehicleId)
    {
        var index = 0;

        if (driverVehicleRefs.Count > 0)
        {
            var lastRecord = driverVehicleRefs[driverVehicleRefs.Count - 1];
            index = lastRecord.Id + 1;
        }

        var driverVehicleRef = new DriverVehicleRef(index, driverId, vehicleId);
        driverVehicleRefs.Add(driverVehicleRef);
    }

    public bool IsVehicleInRefs(int vehicleId)
    {
        return driverVehicleRefs.Where(record => record.VehicleId == vehicleId).Any();
    }

    public bool IsDriverInRefs(int driverId)
    {
        return driverVehicleRefs.Where(record => record.DriverId == driverId).Any();
    }

    public bool IsRecordIdInRefs(int recordId)
    {
        return driverVehicleRefs.Where(record => record.Id == recordId).Any();
    }

    public void RemoveRecordById(int id)
    {
        var record = driverVehicleRefs.Where(record => record.Id == id).Select(record => record).FirstOrDefault();
        if (record != null)
        {
            driverVehicleRefs.Remove(record);
        }
    }

    public void RemoveRecordByDriverId(int id)
    {
        var records = driverVehicleRefs.Where(record => record.DriverId == id).Select(record => record).ToList();
        if (records.Count != 0)
        {
            foreach (var record in records)
            {
                driverVehicleRefs.Remove(record);
            }
        }
    }

    public void RemoveRecordByVehicleId(int id)
    {
        var records = driverVehicleRefs.Where(record => record.VehicleId == id).Select(record => record).ToList();
        if (records.Count != 0)
        {
            foreach (var record in records)
            {
                driverVehicleRefs.Remove(record);
            }
        }
    }

    public bool IsDriverExists(int id)
    {
        var drivers = _driverService.GetDrivers();
        return drivers.Where(driver => driver.Id == id && driver.IsDeleted == false).Any();
    }

    public bool IsVehicleExists(int id)
    {
        var vehicles = _vehicleService.GetVehicles();
        return vehicles.Where(vehicle => vehicle.Id == id && vehicle.IsDeleted == false).Any();
    }

    public bool IsRecordExists(int driverId, int vehicleId)
    {
        return driverVehicleRefs.Where(record => record.DriverId == driverId && record.VehicleId == vehicleId).Any();
    }
}

using MicroFms.Services;

namespace MicroFms.Entities;

public class DriverVehicleRef
{
    public DriverVehicleRef(int id, int driverId, int vehicleId)
    {
        Id = id;
        DriverId = driverId;
        VehicleId = vehicleId;
    }

    public int Id { get; set; }

    public int DriverId { get; set; }

    public int VehicleId { get; set; }
}

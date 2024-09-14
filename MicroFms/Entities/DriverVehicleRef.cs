using MicroFms.Services;

namespace MicroFms.Entities;

public class DriverVehicleRef
{
    public DriverVehicleRef(int id, int driverId, int vehicleId)
    {
        Id = id;
        DrivetId = driverId;
        VehicleId = vehicleId;
    }

    public int Id { get; set; }

    public int DrivetId { get; set; }

    public int VehicleId { get; set; }
}

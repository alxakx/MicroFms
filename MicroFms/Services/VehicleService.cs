using MicroFms.Entities;

namespace MicroFms.Services;

public class VehicleService
{
    private List<Vehicle> vehicles = [
        new Vehicle(0, "pickup", "KPT12345678KP0377", false),
        new Vehicle(1, "pickup", "JR032756712JA4551", false),
        new Vehicle(2, "truck", "JK26548212X7JA546", false),
        new Vehicle(3, "truck", "XTC1528543K2RU345", false),
        new Vehicle(4, "truck", "XTC1534574N425735", false),
        new Vehicle(5, "truck", "XTC2566312N462758", false),
        new Vehicle(6, "thuck", "XTC4666254M765278", false),
    ];

    public Vehicle? AddVehicle(string name, string vinCode)
    {
        var index = 0;
        var isDeleted = false;

        if (vehicles.Count > 0)
        {
            var lastRecord = vehicles[vehicles.Count - 1];
            index = lastRecord.Id + 1;
        }

        if (name.Length != 0 && vinCode.Length != 0)
        {
            var vehicle = new Vehicle(index, name, vinCode, isDeleted);

            vehicles.Add(vehicle);

            return vehicle;
        }
        else
        {
            return null;
        }
    }

    public Vehicle? RemoveVehicle(int vehicleId)
    {
        for (int i = 0; i < vehicles.Count; i++)
        {
            if (vehicles[i].Id == vehicleId && !vehicles[i].IsDeleted)
            {
                vehicles[i].IsDeleted = true;
                return vehicles[i];
            }
        }

        return null;
    }

    public Vehicle? FindVehicle(string name, string vinCode)
    {
        return vehicles.Where(vehicle => vehicle.Name == name && vehicle.VinCode == vinCode).FirstOrDefault();
    }

    public bool IsEmpty()
    {
        return vehicles.Count == 0;
    }

    public List<Vehicle> GetVehicles()
    {
        return vehicles;
    }
}

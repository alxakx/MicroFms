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

    public void AddVehicle()
    {
        var index = 0;
        var name = EnterName();
        var vinCode = EnterVinCode();
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

            Console.WriteLine($"Vehicle {name} VIN: {vinCode} successfull added to list");
        }
        else
        {
            Console.WriteLine($"\nEntered data is incorrected");
        }
    }

    public void RemoveVehicle()
    {
        if (vehicles.Count == 0)
        {
            Console.WriteLine($"\nVehicle list is empty\n");
        }
        else
        {
            var name = EnterName();
            var vinCode = EnterVinCode();
            var isExists = false;

            for (int i = 0; i < vehicles.Count; i++)
            {

                if (vehicles[i].Name == name && vehicles[i].VinCode == vinCode && !vehicles[i].IsDeleted)
                {
                    vehicles[i].IsDeleted = true;
                    isExists = true;
                    Console.WriteLine($"Vehicle with name = {name} and vincode = {vinCode} is removed from vehicle list");
                    break;
                }
            }

            if (!isExists)
            {
                Console.WriteLine($"Vehicle with name = {name} and vincode = {vinCode} was not found");
            }
        }
    }

    public void ShowVehicleList()
    {
        Console.WriteLine($"\nVehicles:\n");
        var count = 1;

        if (vehicles.Count == 0)
        {
            Console.WriteLine("\nVehicle list is empty\n");
        }
        else
        {
            for (var i = 0; i < vehicles.Count; i++)
            {
                if (!vehicles[i].IsDeleted)
                {
                    Console.WriteLine($"{count}. {vehicles[i].Name} {vehicles[i].VinCode}");
                    count++;
                }
            }
        }
    }

    public List<Vehicle> GetVehicles()
    {
        return vehicles;
    }

    private static string EnterName()
    {
        Console.Write("Enter vehicle name: ");

        return Console.ReadLine();
    }

    private static string EnterVinCode()
    {
        Console.Write("Enter vinCode: ");

        return Console.ReadLine();
    }
}

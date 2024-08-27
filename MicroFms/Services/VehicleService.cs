namespace MicroFms;

public class VehicleService
{
    private List<Vehicle> vehicles = [];

    public void AddVehicle()
    {
        var index = vehicles.Count;
        var name = EnterName();
        var vinCode = EnterVinCode();

        if (name.Length != 0 && vinCode.Length != 0)
        {
            var vehicle = new Vehicle(index, name, vinCode);

            vehicles.Add(vehicle);
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

            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i].Name == name && vehicles[i].VinCode == vinCode)
                {
                    vehicles.Remove(vehicles[i]);
                    Console.WriteLine($"Vehicle with name = {name} and vincode = {vinCode} is removed from vehicle list");
                }
                else
                {
                    Console.WriteLine($"Vehicle with name = {name} and vincode = {vinCode} was not found");
                }
            }
        }
    }

    public void ShowVehicleList()
    {
        Console.WriteLine($"\nVehicles:\n");

        if (vehicles.Count == 0)
        {
            Console.WriteLine("\nVehicle list is empty\n");
        }
        else
        {
            for (var i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {vehicles[i].Name} {vehicles[i].VinCode}");
            }
        }
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

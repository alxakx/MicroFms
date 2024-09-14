using MicroFms.Controllers;

namespace MicroFms;

internal class Program
{
    private static void Main(string[] args)
    {
        var driverController = new DriverController();
        var vehicleController = new VehicleController();
        var driverVehicleRefController = new DriverVehicleRefController();
        var baseController = new BaseController(driverController, vehicleController, driverVehicleRefController);
        baseController.DisplayMenu();
    }
}

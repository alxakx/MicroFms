using MicroFms.Controllers;
using MicroFms.Services;

namespace MicroFms;

internal class Program
{
    private static void Main(string[] args)
    {
        var driverService = new DriverService();
        var vehicleService = new VehicleService();
        var driverVehicleRefService = new DriverVehicleRefService(driverService, vehicleService);

        var driverController = new DriverController(driverService, driverVehicleRefService);
        var vehicleController = new VehicleController(vehicleService, driverVehicleRefService);
        var driverVehicleRefController = new DriverVehicleRefController(driverService, vehicleService, driverVehicleRefService);

        var frontController = new FrontController(driverController, vehicleController, driverVehicleRefController);
        frontController.DisplayMenu();
    }
}

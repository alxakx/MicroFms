﻿using MicroFms.Services;

namespace MicroFms.Controllers;

public class DriverVehicleRefController
{
    private const string ExitCommand = "0";
    private const string AddRecordCommand = "1";
    private const string RemoveRecordCommand = "2";
    private const string ShowRecordsCommand = "3";

    private readonly DriverService _driverService;
    private readonly VehicleService _vehicleService;
    private readonly DriverVehicleRefService _driverVehicleRefService;

    public DriverVehicleRefController(DriverService driverService, VehicleService vehicleService, DriverVehicleRefService driverVehicleRefService)
    {
        _driverService = driverService;
        _vehicleService = vehicleService;
        _driverVehicleRefService = driverVehicleRefService;
    }

    public void DisplayReferenseMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.CursorTop = 5;
            Console.WriteLine("List of commands:\n" +
                $"\n{AddRecordCommand} - Add new record to referense list" +
                $"\n{RemoveRecordCommand} - Remove record from referense list" +
                $"\n{ShowRecordsCommand} - Show referense List" +
                $"\n\n{ExitCommand} - Return to BaseMenu");

            Console.Write("\nEnter selected command: ");
            var userSelect = Console.ReadLine();

            switch (userSelect)
            {
                case AddRecordCommand:
                    ExecuteOperation(_driverVehicleRefService.AddRecord);
                    break;

                case RemoveRecordCommand:
                    ExecuteOperation(_driverVehicleRefService.RemoveRecordByKey);
                    break;

                case ShowRecordsCommand:
                    ExecuteOperation(_driverVehicleRefService.ShowRecords);
                    break;

                case ExitCommand:
                    return;

                default:
                    ExecuteOperation(ShowUnknowCommandMessage);
                    break;
            }
        }
    }

    private static void ShowContinueMessage()
    {
        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
    }

    private static void ShowUnknowCommandMessage()
    {
        Console.WriteLine("\nUnknow command");
    }

    private delegate void Operation();

    private void ExecuteOperation(Operation operation1)
    {
        Console.Clear();
        operation1();
        ShowContinueMessage();
    }
}

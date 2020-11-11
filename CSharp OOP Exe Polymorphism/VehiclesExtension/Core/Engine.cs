﻿using VehiclesExtension.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehiclesExtension.Core
{
    public class Engine : IEngine
    {
        private VehicleFactory vehicleFactory;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }

        public void Run()
        {
            Vehicle car = ProduceVehicle();
            Vehicle truck = ProduceVehicle();
            Vehicle bus = ProduceVehicle();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] inputCommand = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string commandType = inputCommand[0];
                string vehicleType = inputCommand[1];

                if (inputCommand[0] == "DriveEmpty")
                {
                    double distance = double.Parse(inputCommand[2]);

                    if (inputCommand[1] == "Bus")
                    {
                        Console.WriteLine(bus.DriveEmpty(distance));
                    }
                }
                if (commandType == "Drive")
                {
                    double distance = double.Parse(inputCommand[2]);

                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                    else if (inputCommand[1] == "Bus")
                    {
                        Console.WriteLine(bus.Drive(distance));
                    }
                }
                else if (commandType == "Refuel")
                {
                    try
                    {
                        double fuel = double.Parse(inputCommand[2]);

                        if (inputCommand[1] == "Car")
                        {
                            car.Refuel(fuel);
                        }
                        else if (inputCommand[1] == "Truck")
                        {
                            truck.Refuel(fuel);
                        }
                        else if (inputCommand[1] == "Bus")
                        {
                            bus.Refuel(fuel);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private Vehicle ProduceVehicle()
        {
            string[] inputVehicle = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

            string vehicleType = inputVehicle[0];
            double fuelQuantity = double.Parse(inputVehicle[1]);
            double fuelConsumption = double.Parse(inputVehicle[2]);
            double tankCapacity = double.Parse(inputVehicle[3]);

            Vehicle vehicle = this.vehicleFactory.ProduceVehicle(vehicleType, fuelQuantity, fuelConsumption, tankCapacity);

            return vehicle;
        }
    }
}
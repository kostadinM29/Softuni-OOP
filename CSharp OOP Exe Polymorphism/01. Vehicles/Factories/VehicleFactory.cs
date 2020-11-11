using VehiclesExtension.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class VehicleFactory
    {
        public Vehicle ProduceVehicle(string vehicleType, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle;

            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            return vehicle;
        }
    }
}

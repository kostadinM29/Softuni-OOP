﻿using VehiclesExtension.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double ADDITIONAL_CONSUMPTION_PER_KM = 0.9;

        public Car(double fuelQuantity, double fuelConsumption,double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        protected override double AdditionalConsumption => ADDITIONAL_CONSUMPTION_PER_KM;
    }
}

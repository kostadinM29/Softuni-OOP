using System;
using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("VW", "Golf", 10, 100);
        }

        [Test]
        [TestCase("VW", "Golf", 10, 100)]
        [TestCase("BMW", "3", 20, 200)]
        public void CarConstructorShouldSetAllDataProperly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            car = new Car(
               make: make,
               model: model,
               fuelConsumption: fuelConsumption,
               fuelCapacity: fuelCapacity);

            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
        }

        [Test]
        [TestCase(null, "Golf", 3, 2)]
        [TestCase("", "Golf", 3, 2)]
        [TestCase("VW", null, 3, 2)]
        [TestCase("VW", "", 3, 2)]
        [TestCase("VW", "Golf", 0, 2)]
        [TestCase("VW", "Golf", -2, 2)]
        [TestCase("VW", "Golf", 2, 0)]
        [TestCase("VW", "Golf", 2, -2)]
        public void CarShouldThrowExceptionsWhenParametersHaveNoValue(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(
                make: make,
                model: model,
                fuelConsumption: fuelConsumption,
                fuelCapacity: fuelCapacity));
        }
        [Test]
        public void ShouldRefuelNormally()
        {
            this.car.Refuel(10);
            Assert.AreEqual(10, this.car.FuelAmount);
        }

        [Test]
        public void CarShouldRefuelNoMoreThanFuelCapacity()
        {
            this.car.Refuel(105);
            Assert.AreEqual(this.car.FuelAmount,100);
        }
        [Test]
        public void CarShouldThrowExceptionWhenRefueledWithNoFuel()
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(0));
        }

        [Test]
        public void CarShouldDriveNormally()
        {
            this.car.Refuel(50);
            this.car.Drive(50);

            Assert.AreEqual(45.0d, this.car.FuelAmount);
        }
        [Test]
        public void DvireShouldThrowInvalidOperationExceptionWhenDistanIsTooBug()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(1000));
        }
    }
}
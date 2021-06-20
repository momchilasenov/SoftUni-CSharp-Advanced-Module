using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Make", "Model", 10, 100);
        }

        [TestCase("", "Model", 10, 100)]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make", null, 10, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", -10, 100)]
        [TestCase("Make", "Model", 10, 0)]
        [TestCase("Make", "Model", 10, -10)]

        public void Ctor_ThrowsException_WhenDataIsInvalid
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Ctor_SetsInitialValues_WhenArgumentsAreValid()
        {
            string make = "Make";
            string model = "Model";
            double fuelConsumption = 10.0d;
            double fuelCapacity = 100.0d;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [TestCase(0)]
        [TestCase(-100)]
        public void Refuel_ThrowsException_WhenFuelToRefuelIsZeroOrNegative(double fuel)
        {
            Car car = new Car("Make", "Model", 10, 100);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        public void Refuel_IncreasesFuelAmount_WhenAmountIsPositive()
        {
            double refuelAmount = this.car.FuelCapacity / 2; //not using magic numbers, refueling with half a tank
            this.car.Refuel(refuelAmount);

            Assert.AreEqual(refuelAmount, this.car.FuelAmount);
        }

        [Test]
        public void Refuel_SetsFuelAmountToEqualCapacity_WhenAmountExceedsCapacity()
        {
            double refuelAmount = this.car.FuelCapacity * 1.5; //refueling 50% more than capacity allows
            this.car.Refuel(refuelAmount);

            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void Drive_DecreasesFuelAmount_WhenDistanceIsValid()
        {
            int distance = 100;
            double initialFuel = this.car.FuelCapacity;

            this.car.Refuel(initialFuel);

            this.car.Drive(distance);

            Assert.That(this.car.FuelAmount, Is.LessThan(initialFuel));
        }

        [Test]
        public void Drive_ThrowsException_WhenFuelNeedesExceedsFuelFuelAmount()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(1000));
        }

        [Test]
        public void Drive_DecreasesFuelAmountToZero_WhenFuelNeededAndFuelAmountAreTheSame()
        {
            this.car.Refuel(this.car.FuelCapacity);

            double distance = this.car.FuelAmount * this.car.FuelConsumption;

            this.car.Drive(distance);

            Assert.That(this.car.FuelAmount, Is.EqualTo(0));
        }




    }
}
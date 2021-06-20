using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver unitDriver;
        private UnitDriver fakeUnitDriver;
        private UnitCar unitCar;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
            this.unitCar = new UnitCar("Test", 1, 1);
            this.unitDriver = new UnitDriver("Test", unitCar);
            this.fakeUnitDriver = new UnitDriver("Does Not Exist", unitCar);
        }

        [Test]
        public void CounterIsZeroByDefault()
        {
            Assert.That(raceEntry.Counter, Is.Zero);
        }

        [Test]
        public void CounterIsSetProperly()
        {
            raceEntry.AddDriver(this.unitDriver);

            Assert.That(this.raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddDriver_ThrowsException_WhenDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>
                (() => raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriver_ThrowsException_WhenDriverExists()
        {
            raceEntry.AddDriver(unitDriver);
            Assert.Throws<InvalidOperationException>
                (() => this.raceEntry.AddDriver(unitDriver));
        }

        [Test]
        public void AddDriver_AddsDriverCorrectly()
        {
            raceEntry.AddDriver(unitDriver);
            Assert.That(raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddDriver_ReturnsAppropriateResult()
        {
            string result = raceEntry.AddDriver(unitDriver);

            string expected = $"Driver {unitDriver.Name} added in race.";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CalcAverageHorsePower_ThrowsException_WhenDriversAreLessThanMinimum()
        {
            this.raceEntry.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>
                (() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void MethodReturnsAverageHorsePower()
        {
            raceEntry.AddDriver(new UnitDriver("A", new UnitCar("A", 10, 10)));
            raceEntry.AddDriver(new UnitDriver("B", new UnitCar("B", 20, 10)));
            raceEntry.AddDriver(new UnitDriver("C", new UnitCar("C", 30, 10)));

            int[] numbers = { 10, 20, 30 };
            double average = numbers.Select(d => d).Average();

            Assert.AreEqual(average, raceEntry.CalculateAverageHorsePower());
        }




    }
}
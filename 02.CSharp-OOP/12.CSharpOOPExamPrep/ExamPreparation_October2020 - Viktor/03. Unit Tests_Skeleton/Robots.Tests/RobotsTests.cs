namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot("Test", 10);
            robotManager = new RobotManager(10);
        }

        [Test]
        public void WhenNewRobotIsCreated_PropertiesShouldBeSetCorrectlyByTheCtor()
        {
            Assert.That(robot.Name, Is.EqualTo("Test"));
            Assert.That(robot.Battery, Is.EqualTo(10));
            Assert.That(robot.MaximumBattery, Is.EqualTo(10));
        }

        [Test]
        public void WhenRobotManagerIsCreated_TheCapacityIsSetCorrectly()
        {
            Assert.That(this.robotManager.Capacity, Is.EqualTo(10));
        }

        [Test]
        public void WhenRobotManagerIsCreated_CountShouldBeZero()
        {
            Assert.That(robotManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void ExceptionIsThrown_WhenRobotManagerHasNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager wrongManager = new RobotManager(-10);
            });
        }

        [Test]
        public void ExceptionIsThrown_WhenRobotWithTheSameNameIsAddedToRobots()
        {
            this.robotManager.Add(new Robot("Pesho", 10));

            Assert.Throws<InvalidOperationException>
                (() => this.robotManager.Add(new Robot("Pesho", 10)));

        }

        [Test]
        public void ExceptionIsThrown_IfRobotIsAdded_WhenCapacityIsFull()
        {
            for (int i = 1; i <= 10; i++)
            {
                robotManager.Add(new Robot($"{"Robot"} {i}", i));
            }

            Assert.Throws<InvalidOperationException>
                (() => robotManager.Add(new Robot("Momchil", 10)));
        }

        [Test]
        public void RobotIsAddedToCollection_WhenDataIsCorrect()
        {
            robotManager.Add(new Robot("Momchil", 10));
            robotManager.Add(new Robot("Pesho", 3));
            robotManager.Add(new Robot("Gosho", 5));

            Assert.That(robotManager.Count, Is.EqualTo(3));
        }

        [Test]
        public void RemoveThrowsException_WhenRobotWithNoSuchNameExists()
        {
            Assert.Throws<InvalidOperationException>
                (() => this.robotManager.Remove("NoSuchRobotExists"));
        }

        [Test]
        public void RobotIsRemovedCorrectly_WhenRobotExists()
        {
            robotManager.Add(new Robot("Robot", 10));
            robotManager.Add(new Robot("Robot2", 10));

            robotManager.Remove("Robot");

            Assert.That(robotManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void WorkThrowsException_WhenRobotWithNoSuchNameIsGiven()
        {
            robotManager.Add(new Robot("Robot", 10));

            Assert.Throws<InvalidOperationException>
                (() => robotManager.Work("NoSuchNameExists", "SomeJob", 5));
        }

        [Test]
        public void WorkThrowsException_WhenBatteryIsLessThanUsage()
        {
            robotManager.Add(new Robot("Robot", 10));

            Assert.Throws<InvalidOperationException>
                (() => robotManager.Work("Robot", "SomeJob", robot.Battery + 10));
        }

        [Test]
        public void BatteryIsDecreased_WhenWorkDataIsCorrect()
        {
            Robot robot = new Robot("Robot", 10);
            robotManager.Add(robot);

            robotManager.Work("Robot", "SomeJob", 5);

            Assert.That(robot.Battery, Is.EqualTo(5));
        }

        [Test]
        public void ChargeThrowsException_WhenRobotWithNoSuchNameIsGiven()
        {
            robotManager.Add(new Robot("Robot", 10));

            Assert.Throws<InvalidOperationException>
                (() => robotManager.Charge("NoSuchNameExists"));
        }

        [Test]
        public void ChargeRechargesRobot_WhenDataIsCorrect()
        {
            robotManager.Add(robot);
            robotManager.Work(robot.Name, "SomeJob", 9);

            robotManager.Charge(robot.Name);

            Assert.That(robot.Battery, Is.EqualTo(robot.MaximumBattery));
        }

    }
}

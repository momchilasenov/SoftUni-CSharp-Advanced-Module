namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private const string name = "Test";
        private const int capacity = 10;

        private Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            this.aquarium = new Aquarium(name, capacity);
        }

        [Test]
        public void ConstructorSetsAquariumDataCorrectly()
        {
            Assert.AreEqual(this.aquarium.Name, name);
            Assert.AreEqual(this.aquarium.Capacity, capacity);
        }

        [Test]
        public void ExceptionIsThrown_WhenNameIsNullOrEmpty()
        {
            string nullName = null;
            string emptyName = string.Empty;

            //Aquarium invalidAquarium = null;

            Assert.Throws<ArgumentNullException>
                (() => aquarium = new Aquarium(nullName, 10));
            Assert.Throws<ArgumentNullException>
                (() => aquarium = new Aquarium(emptyName, 10));

        }

        [Test]
        public void CapacityThrowsException_WhenValueIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium("Name", -10));
        }

        [Test]
        public void CountIsZeroWhenAquariumIsCreated()
        {
            Assert.That(aquarium.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddThrowsException_WhenAquariumIsFul()
        {
            Aquarium aqua = new Aquarium("Name", 2);

            aqua.Add(new Fish("Fish"));
            aqua.Add(new Fish("Fish2"));

            Assert.Throws<InvalidOperationException>(() => aqua.Add(new Fish("Name")));
        }

        [Test]
        public void Add_AddsAFish_WhenDataIsCorrect()
        {
            aquarium.Add(new Fish("Name"));
            Assert.AreEqual(aquarium.Count, 1);
        }

        [Test]
        public void RemoveFish_ThrowsException_WhenFishIsNull()
        {
            aquarium.Add(new Fish("Name"));
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(null));
            
        }

        [Test]
        public void FishIsRemoved_WhenDataIsCorrect()
        {
            aquarium.Add(new Fish("Name"));
            aquarium.RemoveFish("Name");
            Assert.AreEqual(aquarium.Count, 0);

        }

        [Test]
        public void SellFish_ThrowsException_WhenFishIsNull()
        {
            aquarium.Add(new Fish("Name"));
            Assert.Throws<InvalidOperationException>
                (() => aquarium.SellFish(null));
        }

        [Test]
        public void FishIsRemoved_WhenSold()
        {
            Fish fish = new Fish("Name");
            aquarium.Add(fish);
            aquarium.SellFish(fish.Name);
            Assert.That(fish.Available, Is.EqualTo(false));
        }

        [Test]
        public void RequestedFishIsReturned_WhenSold()
        {
            Fish fish = new Fish("Name");
            aquarium.Add(fish);
            
            Fish expected = fish;
            Fish actualFish = aquarium.SellFish(fish.Name);

            Assert.That(expected, Is.EqualTo(actualFish));
        }

        [Test]
        public void Report_ReturnsProperString()
        {
            aquarium.Add(new Fish("Pesho"));
            aquarium.Add(new Fish("Gosho"));

            string expected = $"Fish available at {aquarium.Name}: Pesho, Gosho";
            string actual = aquarium.Report();

            Assert.AreEqual(expected, actual);
        }



    }
}

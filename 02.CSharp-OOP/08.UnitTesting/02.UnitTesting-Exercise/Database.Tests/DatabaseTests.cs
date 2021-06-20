using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void SetUp()
        {
            this.database = new Database.Database();

        }

        [Test]
        public void Ctor_ThrowsException_WhenCapacityIsExceeded()
        {
            int[] elements = new int[17];

            Assert.That(() => this.database = new Database.Database(elements), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void CtorShouldAddElementsToDatabase()
        {
            int[] elements = { 1, 2, 3 };

            this.database = new Database.Database(elements);

            Assert.AreEqual(elements.Length, this.database.Count);
            Assert.That(this.database.Fetch(), Is.EquivalentTo(elements)); //assert the elements are the same
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17),
                "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void Add_ShouldIncreaseDatabaseCount_WhenValid()
        {
            for (int i = 0; i < 10; i++)
            {
                database.Add(i);
            }

            Assert.AreEqual(10, database.Count);
        }

        [Test]
        public void Add_AddsElementToDatabase()
        {
            int element = 123456;

            database.Add(element);

            int[] copyDatabase = database.Fetch();

            Assert.IsTrue(copyDatabase.Contains(element));
        }

        [Test]
        public void Remove_ThrowsException_WhenDatabaseIsEmpty()
        {
            Assert.That(() => database.Remove(),
                Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void Remove_ShouldReduceCount_WhenOperationIsValid()
        {
            database.Add(1);
            database.Add(2);
            database.Add(3);
            database.Add(4);

            for (int i = 0; i < 2; i++)
            {
                database.Remove();
            }

            int expectedCount = 2;

            Assert.That(expectedCount, Is.EqualTo(database.Count));
        }

        [Test]
        public void Remove_ShouldRemoveLastElement()
        {
            database.Add(1);
            database.Add(2);
            database.Add(3);
            database.Add(4);

            database.Remove();

            int[] elements = database.Fetch();

            Assert.IsFalse(elements.Contains(4));
        }

        [Test]
        public void Fetch_ShouldReturnCopyNotAReference()
        {
            database.Add(1);
            database.Add(2);
            database.Add(3);

            int[] first = database.Fetch();

            database.Add(4);

            int[] second = database.Fetch();

            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void CountIsZero_WhenDatabaseCreatedWithNoElements()
        {
            Assert.AreEqual(0, database.Count);
        }



    }
}
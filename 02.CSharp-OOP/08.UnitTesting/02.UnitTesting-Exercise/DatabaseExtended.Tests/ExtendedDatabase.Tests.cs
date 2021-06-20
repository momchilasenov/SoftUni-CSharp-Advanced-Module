using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;

        [SetUp]
        public void Setup()
        {
            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void Add_ThrowsException_WhenCountExceedsCapacity()
        {
            for (int i = 0; i < 16; i++)
            {
                this.extendedDatabase.Add(new Person(i, $"Username {i}"));
            }

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(16, "Invalid Username")));
        }

        [Test]
        public void Add_ThrowsException_WhenPersonExistsInDatabase()
        {
            this.extendedDatabase.Add(new Person(1, "Momchil"));
            this.extendedDatabase.Add(new Person(2, "Pesho"));

            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(new Person(3, "Momchil")));
        }

        [Test]
        public void Add_ThrowsException_WhenIdExistsInDatabase()
        {
            this.extendedDatabase.Add(new Person(1, "Momchil"));
            this.extendedDatabase.Add(new Person(2, "Pesho"));

            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(new Person(1, "Gosho")));
        }

        [Test]
        public void Add_IncreasesCount_WhenUserIsValid()
        {
            this.extendedDatabase.Add(new Person(1, "User1"));
            this.extendedDatabase.Add(new Person(2, "User2"));
            this.extendedDatabase.Add(new Person(3, "User3"));

            int expectedCount = 3;

            Assert.AreEqual(expectedCount, extendedDatabase.Count);
        }

        [Test]
        public void Remove_ThrowsException_WhenDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Remove());
        }

        [Test]
        public void Remove_ReducesCount_WhenOperationIsValid()
        {
            this.extendedDatabase.Add(new Person(1, "Momchil"));
            this.extendedDatabase.Add(new Person(2, "Emo"));
            this.extendedDatabase.Add(new Person(3, "Ivan"));

            int expectedCount = 2;

            this.extendedDatabase.Remove();

            Assert.That(this.extendedDatabase.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Remove_RemovesElementsFromDatabase()
        {
            this.extendedDatabase.Add(new Person(1, "Momchil"));
            this.extendedDatabase.Add(new Person(2, "Emo"));

            this.extendedDatabase.Remove();

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindById(2));
        }

        [TestCase(null)]
        [TestCase("")]
        public void FindByUsername_ThrowsException_WhenNameIsNullOrEmpty(string username)
        {
            Assert.Throws<ArgumentNullException>(() => this.extendedDatabase.FindByUsername(username));
        }

        [TestCase]
        public void FindByUsername_ThrowsException_WhenNameNotPresentInDatabase()
        {
            string invalidUsername = "Invalid Username";

            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindByUsername(invalidUsername));
        }

        [Test]
        public void FindByUsername_ShouldReturnUser_WhenUserExists()
        {
            Person person = new Person(1, "Momchil");

            this.extendedDatabase.Add(person);

            Person dbPerson = this.extendedDatabase.FindByUsername(person.UserName);

            Assert.AreEqual(person, dbPerson);
        }

        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(-1000000000)]
        public void FindById_ThrowsException_WhenIdISLessThanZero(long invalidId)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.extendedDatabase.FindById(invalidId));
        }

        [Test]
        public void FindById_ThrowsException_WhenIdIsNotPresentInDatabase()
        {
            this.extendedDatabase.Add(new Person(1, "Momchil"));

            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindById(2));
        }

        [Test]
        public void FindById_ReturnsUser_WhenUsernameIsValid()
        {
            Person person = new Person(1, "User");

            this.extendedDatabase.Add(person);

            Person dbPerson = this.extendedDatabase.FindById(person.Id);

            Assert.AreEqual(person, dbPerson);
        }

        [Test]
        public void Ctor_ThrowsException_WhenCapacityExceeded()
        {
            Person[] persons = new Person[17];

            Assert.Throws<ArgumentException>(() => this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(persons));
        }

        [Test]
        public void Ctor_AddsInitialPeopleToDatabase()
        {
            Person[] persons = new Person[5];

            for (int i=0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"User {i}");
            }

            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.AreEqual(persons.Length, extendedDatabase.Count);

            foreach(var person in persons)
            {
                Person dbPerson = this.extendedDatabase.FindById(person.Id);
                Assert.AreEqual(person, dbPerson);
            }
        }
    }
}
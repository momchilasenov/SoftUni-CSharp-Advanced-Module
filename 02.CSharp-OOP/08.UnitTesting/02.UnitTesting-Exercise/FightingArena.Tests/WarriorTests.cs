using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase("", 10, 50)]
        [TestCase(null, 10, 50)]
        [TestCase("   ", 10, 50)]
        [TestCase("Name", 0, 50)]
        [TestCase("Name", -10, 50)]
        [TestCase("Name", -100000, 50)]
        [TestCase("Name", 20, -50)]
        public void Ctor_ThrowsException_WhenDataIsInvalid(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase(10, 40)]
        [TestCase(30, 40)]
        [TestCase(40, 10)]
        [TestCase(40, 30)]
        public void Attack_ThrowsException_WhenHpIsBelowMinimum(int attackerHp, int warriorHp)
        {
            Warrior attacker = new Warrior("Attacker", 50, attackerHp);
            Warrior warrior = new Warrior("Warrior", 10, warriorHp);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void Attack_ThrowsException_WhenHpIsLessThanOpponentDamage()
        {
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", attacker.HP+1, 100);

            Assert.That(() => warrior.Attack(warrior), Throws.InvalidOperationException);
        }

        [Test]
        public void Attack_DecreasesHp_WhenDataIsValid()
        {
            Warrior attacker = new Warrior("Attacker", 100, 100);
            Warrior warrior = new Warrior("Warrior", 50, 50);

            int expectedValue = 50;

            attacker.Attack(warrior);

            Assert.AreEqual(expectedValue, attacker.HP);
        }

        [Test]
        public void Attack_SetsEnemyHpToZero_WhenAttackerDamageIsGreaterThanEnemyHp()
        {
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", 30, 40); 

            attacker.Attack(warrior);

            Assert.AreEqual(0, warrior.HP);
        }

        [Test]
        public void Attack_DecreasesEnemyHpByAttackerDamage()
        {
            int initialWarriorHp = 100;
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", 50, initialWarriorHp);

            attacker.Attack(warrior);

            Assert.AreEqual(initialWarriorHp - attacker.Damage, warrior.HP);
        }
    }
}
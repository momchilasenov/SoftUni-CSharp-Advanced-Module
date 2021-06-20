using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Ctor_InitializesWarriors()
        {
            Assert.That(this.arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void CountIsZero_WhenArenaIsEmpty()
        {
            Assert.That(this.arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void Enroll_ThrowsException_WhenWarriorIsAlreadyEnrolled()
        {
            string name = "Name";
            this.arena.Enroll(new Warrior(name, 50, 50));

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(new Warrior(name, 50, 50)));
        }

        [Test]
        public void Enroll_IncreasesArenaCount_WhenDataIsValid()
        {
            Warrior warrior = new Warrior("Momchil", 50, 50);
            this.arena.Enroll(warrior);

            Assert.That(this.arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void Enroll_AddsWarriorToWarriors()
        {
            string name = "Warrior";
            this.arena.Enroll(new Warrior(name, 50, 50));
            Assert.That(this.arena.Warriors.Any(w => w.Name == name), Is.True);
        }

        //[Test]
        //[TestCase("Attacker", null)]
        //[TestCase(null, "Defender")]
        //[TestCase(null, null)]
        //public void Fight_ThrowsException_WhenAttackerOrDefenderIsNull(string attackerName, string defenderName)
        //{
        //    Warrior attacker = new Warrior("Attacker", 50, 50);
        //    Warrior defender = new Warrior("Defender", 50, 50);
        //    arena.Enroll(attacker);
        //    arena.Enroll(defender);

        //    Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName));
        //}

        [Test]
        public void Fight_ThrowsException_WhenDefenderDoesNotExist()
        {
            string name = "Attacker";
            Warrior warrior = new Warrior(name, 50, 50);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(warrior.Name, "Defender"));
        }

        [Test]
        public void Fight_ThrowsException_WhenAttackerDoesNotExist()
        {
            string name = "Defender";
            Warrior warrior = new Warrior(name, 50, 50);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Attacker", warrior.Name));
        }

        [Test]
        public void Fight_ThrowsException_WhenBothWarriorsDoNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Attacker", "Defender"));
        }

        [Test]
        public void AttackerAttacksDefender_WhenBothAreOnTheArena()
        {
            int initialHp = 100;
            Warrior attacker = new Warrior("Attacker", 50, initialHp);
            Warrior defender = new Warrior("Defender", 50, initialHp);
            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(initialHp - defender.Damage, attacker.HP);
            Assert.AreEqual(initialHp - attacker.Damage, defender.HP);

        }
    }
}

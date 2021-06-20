using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private int attack;
    private int durability;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        this.attack = 5;
        this.durability = 5;
        this.axe = new Axe(attack, durability);
        this.dummy = new Dummy(5, 6);
    }

    [Test]
    public void WhenGivenAttackAndDurability_TheyShouldBeSet()
    {
        Assert.AreEqual(axe.AttackPoints, attack);
        Assert.That(axe.DurabilityPoints == durability);
    }

    [Test]
    public void AxeShouldLoseDurabilityPoints_WhenAttacking()
    {
        axe.Attack(this.dummy);
        Assert.AreEqual(durability - 1, axe.DurabilityPoints);
    }

    [Test]
    public void AxeBreaksWhenDurabilityIsZero()
    {
        axe = new Axe(1, 0);

        Assert.That(() =>
        {
            axe.Attack(this.dummy);
        }, Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        
    }
}
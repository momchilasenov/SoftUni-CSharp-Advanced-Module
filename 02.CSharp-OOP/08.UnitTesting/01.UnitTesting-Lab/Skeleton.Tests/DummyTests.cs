using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private int health = 5;
    private int experience = 6;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        this.dummy = new Dummy(health, experience);    
    }

    [Test]
    public void WhenGiven_HealthShouldBeSetCorrectly()
    {
        Assert.That(this.dummy.Health, Is.EqualTo(this.health));
    }

    [Test]
    public void WhenDummyIsAttacked_HealthShouldDecrease()
    {
        int attackPoints = 4;
        dummy.TakeAttack(attackPoints);
        Assert.That(dummy.Health, Is.EqualTo(this.health - attackPoints), 
            "Dummy doesn't lose health when attacked"); //message if an error occurs
    }

    [Test]
    public void WhenDummyIsDead_ExceptionShouldBeThrown()
    {
        dummy = new Dummy(-3, experience);

        Assert.That(() =>
        {
           dummy.TakeAttack(3);
        }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."), 
        "When dummy dies, no exception is thrown");
    }

    [Test]
    public void WhenHealthIsPositive_DummyShouldBeAlive()
    {
        //health is already a positive number
        Assert.That(dummy.IsDead(), Is.EqualTo(false), 
            "Dummy is dead when health is a positive number");
    }

    [Test]
    public void WhenHealthIsZero_DummyShouldDie()
    {
        dummy = new Dummy(0, experience);
        Assert.That(dummy.IsDead(), Is.EqualTo(true));
    }

    [Test]
    public void WhenHealthIsLessThanZero_DummyShouldDie()
    {
        dummy = new Dummy(-1, experience);
        Assert.That(dummy.IsDead(), Is.EqualTo(true));
    }

    [Test]
    public void WhenDead_ShouldReturnExperience()
    {
        dummy = new Dummy(0, experience); //make yourself a dead Dummy

        Assert.That(dummy.GiveExperience(), Is.EqualTo(experience));
    }

    [Test]
    public void WhenAlive_ShouldThrowException()
    {
        Assert.That(() =>
        {
            dummy.GiveExperience();
        }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}

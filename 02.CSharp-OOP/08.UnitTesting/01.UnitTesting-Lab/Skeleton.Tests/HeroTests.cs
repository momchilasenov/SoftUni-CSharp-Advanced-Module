using Moq;
using NUnit.Framework;
using Skeleton.Contracts;
using Skeleton.Tests.Fakes;

[TestFixture]
public class HeroTests
{
    
    [SetUp]
    public void SetUp()
    {
        
    }

    [Test]
    public void WhenTargetDies_HeroReceivesXp()
    {
        Mock<ITarget> mockTarget = new Mock<ITarget>();
        Mock<IWeapon> mockWeapon = new Mock<IWeapon>();

        mockTarget // setup the fake object so that
            .Setup(t => t.IsDead()) // when someone calls IsDead method
            .Returns(true); // return true

        mockTarget.Setup(t=>t.GiveExperience()).Returns(20);


        //FakeTarget target = new FakeTarget();
        //FakeWeapon weapon = new FakeWeapon();

        Hero hero = new Hero("Gosho", mockWeapon.Object);

        hero.Attack(mockTarget.Object);

        Assert.AreEqual(20, hero.Experience);
    }

}
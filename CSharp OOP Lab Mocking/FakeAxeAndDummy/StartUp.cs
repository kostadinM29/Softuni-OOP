using System;
using FakeAxeAndDummy.Contracts;
using Moq;

public class StartUp
{
    static void Main(string[] args)
    {
        Mock<ITarget> target = new Mock<ITarget>();
        target.Setup(t => t.GiveExperience()).Returns(20);
        Mock<IWeapon> weapon = new Mock<IWeapon>();
        weapon.Setup(w => w.AttackPoints).Returns(55);
        Hero hero = new Hero("Pesho", weapon.Object);

        int exp = target.Object.GiveExperience();
        Console.WriteLine(exp);

    }
}

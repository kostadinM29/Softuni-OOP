using System;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;
        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Kokodin", 70, 100);
        }

        [Test]
        public void WarriorConstructorShouldInitializeValuesProperly()
        {
            Assert.AreEqual("Kokodin", this.warrior.Name);
            Assert.AreEqual(70, this.warrior.Damage);
            Assert.AreEqual(100, this.warrior.HP);
        }

        [Test]
        [TestCase("Koko", 60, -1)]
        [TestCase("Koko", 0, 70)]
        [TestCase("", 60, 47)]
        [TestCase(null, 800, 100)]
        public void WarriorShouldThrowExceptionWhenGivenNullValues(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>((() => new Warrior(name, damage, hp)));
        }

        [Test]
        public void WarriorShouldAttackNormally()
        {
            Warrior warrior2 = new Warrior("Cezar", 50, 500);
            this.warrior.Attack(warrior2);

            Assert.AreEqual(430, warrior2.HP);
        }

        [Test]
        public void WarriorShouldThrowErrorWhenAttackingAtLowHP()
        {
            Warrior warrior1 = new Warrior("Brut", 50, 25);
            Warrior warrior2 = new Warrior("Cezar", 20, 500);

            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }
        [Test]
        public void WarriorShouldThrowErrorWhenAttackingLowHPTarget()
        {
            Warrior warrior1 = new Warrior("Brut", 50, 25);
            Warrior warrior2 = new Warrior("Cezar", 20, 500);

            Assert.Throws<InvalidOperationException>(() => warrior2.Attack(warrior1));
        }
        [Test]
        public void WarriorShouldThrowErrorWhenAttackingAtLow()
        {
            Warrior warrior1 = new Warrior("Brut", 50, 100);
            Warrior warrior2 = new Warrior("Cezar", 200, 500);

            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void WhenKillingAnotherWarriorTheirHpShouldBeZero()
        {
            Warrior warrior2 = new Warrior("Cezar", 15, 60);

            this.warrior.Attack(warrior2);
            Assert.AreEqual(0,warrior2.HP);
        }
    }
}
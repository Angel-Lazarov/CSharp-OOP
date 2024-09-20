namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {

        [Test]

        public void WarriorConstructor_ShouldWorkCorrectly()
        {
            // warrior warrior = new(
            Warrior warrior = new("Pesho", 5, 50);

            Assert.IsNotNull(warrior);
            Assert.AreEqual("Pesho", warrior.Name);
            Assert.AreEqual(5, warrior.Damage);
            Assert.AreEqual(50, warrior.HP);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void CreateWarriorWithNullOrWhhiteSpaceName_ShouldThrowException(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Warrior(name, 5, 50));
            Assert.AreEqual("Name should not be empty or whitespace!", exception.Message);
        }

        [TestCase(-1)]
        public void CreateWarriorWithNegativeDamageShouldThrowException(int damage)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Warrior("Pesho", damage, 50));
            Assert.AreEqual("Damage value should be positive!", exception.Message);
        }

        [TestCase(-1)]
        public void CreateWarriorWithNegativeHpShouldThrowException(int hp)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Warrior("Pesho", 5, hp));
            Assert.AreEqual("HP should not be negative!", exception.Message);
        }

        [Test]
        public void AttackMethodDShouldWorkCorectly()
        {
            Warrior attacker = new("attacker", 5, 50);
            Warrior defender = new("defender", 5, 50);
            attacker.Attack(defender);
            Assert.AreEqual(45, attacker.HP);
            Assert.AreEqual(45, defender.HP);
        }

        [TestCase(30)]
        [TestCase(29)]
        public void AttackMethodDShouldThrowExceptionIfAttackerHpIsLessThan30(int hp)
        {
            Warrior attacker = new("attacker", 5, hp);
            Warrior defender = new("defender", 5, 50);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
            Assert.AreEqual("Your HP is too low in order to attack other warriors!", exception.Message);

        }

        [TestCase(30)]
        [TestCase(29)]
        public void AttackMethodDShouldThrowExceptionIfDefenderHpIsLessThan30(int hp)
        {
            Warrior attacker = new("attacker", 5, 50);
            Warrior defender = new("defender", 5, hp);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
            Assert.AreEqual("Enemy HP must be greater than 30 in order to attack him!", exception.Message);
        }

        [Test]
        public void AttackMethodDShouldThrowExceptionIfAttackerHpIsLessThanDefenderDamage()
        {
            Warrior attacker = new("attacker", 5, 50);
            Warrior defender = new("defender", 51, 50);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
            Assert.AreEqual("You are trying to attack too strong enemy", exception.Message);
        }

        [Test]
        public void AttackMethodDShouldKill_IfAttackerDamageIsMoreThanDefenderHp()
        {
            Warrior attacker = new("attacker", 51, 80);
            Warrior defender = new("defender", 51, 50);
            attacker.Attack(defender);

            Assert.AreEqual(0, defender.HP);
        }

        [Test]
        public void AttackMethodDShouldReduceWarriorHPIfAttackerDamageIsLessThanDefenderHp()
        {
            Warrior attacker = new("attacker", 20, 80);
            Warrior defender = new("defender", 51, 50);
            attacker.Attack(defender);

            Assert.AreEqual(30, defender.HP);
        }
    }
}
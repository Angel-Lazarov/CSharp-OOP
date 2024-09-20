namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Threading;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void ArenaCreateIsWorking() 
        {
            Assert.IsNotNull(arena);
        }

        [Test]
        public void ArenaCreateCountIsWorking() 
        {
            arena.Enroll(new Warrior("Pesho", 5, 50));
            int actualResult = arena.Count;
            Assert.AreEqual(1, actualResult);
        }

        [Test]
        public void ArenaEnrollMethodShouldWorkCorrectly() 
        {
            Warrior warrior = new Warrior("Pesho", 5, 50);
            arena.Enroll(warrior);
            int actualResult = arena.Count;
            Assert.AreEqual(1, actualResult);
        }

        [Test]
        public void ArenaEnrollMethodShouldThrowExceptionForWarriorAlreadyExist()
        {
            Warrior warrior = new Warrior("Pesho", 5, 50);
            arena.Enroll(warrior);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
                Assert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
        }

        [Test]
        public void ArenaFightMethod_ShouldWorkCorrectly()
        {
            Warrior attacker = new("attacker", 5, 50);
            Warrior defender = new("defender", 5, 50);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(45, attacker.HP);
            Assert.AreEqual(45, defender.HP);
        }

        [Test]
        public void ArenaFightMethod_ShouldThrowExceptionForNoAttacker()
        {
            Warrior attacker = new("attacker", 5, 50);
            Warrior defender = new("defender", 5, 50);

            //arena.Enroll(attacker);
            arena.Enroll(defender);


            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, defender.Name));
            Assert.AreEqual($"There is no fighter with name {attacker.Name} enrolled for the fights!", exception.Message);
        }
        [Test]
        public void ArenaFightMethod_ShouldThrowExceptionForNoDefender()
        {
            Warrior attacker = new("attacker", 5, 50);
            Warrior defender = new("defender", 5, 50);

            arena.Enroll(attacker);
            //arena.Enroll(defender);


            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, defender.Name));
            Assert.AreEqual($"There is no fighter with name {defender.Name} enrolled for the fights!", exception.Message);
        }






    }
}

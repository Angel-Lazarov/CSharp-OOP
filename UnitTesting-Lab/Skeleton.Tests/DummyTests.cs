using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            dummy = new(5, 2);
        }

        [Test]
        public void NewDummy_ShouldSetDataCorrectly()
        {
            Assert.AreEqual(dummy.Health, 5);
        }

        [Test]
        public void DummyShouldLooseHealthIfAttacked()
        {
            dummy.TakeAttack(2);

            Assert.AreEqual(3, dummy.Health);
        }

        [Test]
        public void TakeAttackWhenDummyIsDead_0Health_ShouldThrowError()
        {
            dummy.TakeAttack(5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(5);
            });
        }

        [Test]
        public void TakeAttackWhenDummyIsDead_NegativeHealth_ShouldThrowError()
        {
            dummy.TakeAttack(6);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(5);
            });
        }

        [Test]
        public void GiveExperienceWhenDummyIsDead_ShouldGiveExperience()
        {
            dummy.TakeAttack(5);

            Assert.AreEqual(dummy.GiveExperience(), 2);
        }

        [Test]
        public void GiveExperienceWhenNotDead_ShouldThrowError()
        {
            Assert.Throws<InvalidOperationException>(() =>
            dummy.GiveExperience()
            ); ;
        }
    }
}
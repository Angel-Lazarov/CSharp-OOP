namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class Tests
    {
        private RailwayStation railwayStation;
        [SetUp]
        public void Setup()
        {
            railwayStation = new("station");
        }


        [Test]
        public void ConsructorIsWorkingProperly()
        {
            Assert.IsNotNull(railwayStation);
            Assert.AreEqual("station", railwayStation.Name);
            Assert.AreEqual(0, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(0, railwayStation.DepartureTrains.Count);
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]

        public void ConstructorCannotBeCreatedWithNullOrWhiteSpaceName_ReturnException(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new RailwayStation(name));

            Assert.AreEqual("Name cannot be null or empty!", exception.Message);

        }

        [Test]
        [TestCase("258")]
        public void NewArrivalOnBoardMethod_ShouldWorkingProperly(string str)
        {
            railwayStation.NewArrivalOnBoard(str);

            Assert.AreEqual(1, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual("258", railwayStation.ArrivalTrains.Peek());
        }
        [Test]

        public void TrainHasArrived_Correctly()
        {
            railwayStation.NewArrivalOnBoard("256");

            Assert.AreEqual("There are other trains to arrive before 290.", railwayStation.TrainHasArrived("290"));
            Assert.AreEqual("256 is on the platform and will leave in 5 minutes.", railwayStation.TrainHasArrived("256"));

            Assert.AreEqual(1, railwayStation.DepartureTrains.Count);
            Assert.AreEqual("256", railwayStation.DepartureTrains.Peek());
        }

        [Test]
        public void HasLeft()
        {
            railwayStation.NewArrivalOnBoard("256"); // добавя в пристигащи
            railwayStation.TrainHasArrived("256"); // ако е пристигнал, го мести в заминаващи
            Assert.IsTrue(railwayStation.TrainHasLeft("256"));
            Assert.IsTrue(railwayStation.TrainHasLeft("290"));

        }

    }



}

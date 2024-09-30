namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        private RailwayStation station;

        [SetUp]
        public void Setup()
        {
            station = new("station");
        }

        [Test]
        public void ConstructorOK()
        {
            Assert.IsNotNull(station);
            Assert.AreEqual(0, station.ArrivalTrains.Count);
            Assert.AreEqual(0, station.DepartureTrains.Count);
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        public void Constructor_IsNullOrWhiteSpace_Name(string name) 
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => station = new(name));
            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
        }

        [Test]
        public void NewArrivalOnBoard_OK ()
        {
            station.NewArrivalOnBoard("sofia-burgas");

            Assert.AreEqual("sofia-burgas", station.ArrivalTrains.Peek());

        }

        [Test]
        public void TrainHasArrived_OK() 
        {
            station.NewArrivalOnBoard("sofia-burgas");

            Assert.AreEqual("There are other trains to arrive before sofia-plovdiv.", station.TrainHasArrived("sofia-plovdiv"));
            
            Assert.AreEqual("sofia-burgas is on the platform and will leave in 5 minutes.", station.TrainHasArrived("sofia-burgas"));

            Assert.AreEqual(1, station.DepartureTrains.Count);

        }


        [Test]

        public void TrainHasLeft_True() 
        {
            //station.DepartureTrains.Enqueue("sofia");
            station.NewArrivalOnBoard("burgas");
            station.TrainHasArrived("burgas");


            Assert.IsTrue(station.TrainHasLeft("burgas"));
            Assert.AreEqual(0, station.DepartureTrains.Count);  
        }

        [Test]

        public void TrainHasLeft_False() 
        {
            //station.DepartureTrains.Enqueue("sofia");
            station.NewArrivalOnBoard("sofia");
            station.TrainHasArrived("sofia");

            Assert.IsFalse(station.TrainHasLeft("burgas"));
            Assert.AreEqual(1, station.DepartureTrains.Count);

        }
    }
}
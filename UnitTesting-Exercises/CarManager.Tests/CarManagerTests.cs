namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {

        [Test]
        public void ConstructorShouldWorkcorrectly() 
        {
            Car car = new Car("make", "model", 10, 100);
            
            Assert.IsNotNull(car);
            Assert.AreEqual("make", car.Make);
            Assert.AreEqual("model", car.Model);
            Assert.AreEqual(10, car.FuelConsumption);
            Assert.AreEqual(100, car.FuelCapacity);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void UsingConstructorWithMakeNullOrEmptyShouldThrowException(string make) 
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Car(make, "model", 10, 100));
            Assert.AreEqual("Make cannot be null or empty!", exception.Message);

        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void UsingConstructorWithModelNullOrEmptyShouldThrowException(string model)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Car("make", model, 10, 100));
            Assert.AreEqual("Model cannot be null or empty!", exception.Message);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void UsingConstructorWithFuelconsumptionZeroOrNegativeShouldThrowException(double fuelconsumption)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Car("make", "model", fuelconsumption, 100));
            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }

        //[Test]
        //[TestCase(-1)]
        //public void UsingConstructorWithFuelAmountZeroOrNegativeShouldThrowException(double fuelAmount)
        //{
        //    Car car = new Car("make", "model", 10, 100);

        //    ArgumentException exception = Assert.Throws<ArgumentException>(() => new Car("make", "model", 10, 100));
        //    Assert.AreEqual("Fuel amount cannot be negative!", exception.Message);
        //}

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void UsingConstructorWithFuelCapacityZeroOrNegativeShouldThrowException(double fuelCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Car("make", "model", 10, fuelCapacity));
            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);
        }

        [Test]
        [TestCase(1)]
        public void RefuelMethodShouldWorkCorrectly(double fuelToRefuel) 
        {
            Car car = new Car("make", "model", 10, 100);

            car.Refuel(fuelToRefuel);

            Assert.AreEqual(1, car.FuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelMethodShouldThrowExceptionIfFuelToRefuelIsZeroOrNegative(double fuelToRefuel) 
        {
            Car car = new Car("make", "model", 10, 100);

            ArgumentException exception = Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);

        }

        [Test]
        [TestCase(101)]
        public void RefuelMethodWithMoreThanCapacityShouldSetFuleAmountEqualToFuelCapacity(double fuelToRefuel)
        {
            Car car = new Car("make", "model", 10, 100);
            car.Refuel(fuelToRefuel);

            Assert.AreEqual(100, car.FuelAmount);
        }

        [Test]
        //[TestCase(1)]
        public void DriveMethodShouldWorkCorrectly() 
        {
            Car car = new Car("make", "model", 10, 100);
            car.Refuel(100);
            car.Drive(100);

            Assert.AreEqual(90, car.FuelAmount);

        }

        [Test]
        public void DriveMethodShouldThrowExceptionIfDistanceIsMoreThanCpability()
        {
            Car car = new Car("make", "model", 10, 100);
            car.Refuel(100);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => car.Drive(1001));
            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }

    }
}
namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using System;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            Person[] persons =
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho"),
                new Person(3, "Pes"),
                new Person(4, "Ivan"),
                new Person(5, "Dragan"),
                new Person(6, "Mindi"),
                new Person(7, "Angel"),
                new Person(8, "Bangel"),
                new Person(9, "Boiko"),
                new Person(10, "John"),
                new Person(11, "Mima"),
            };

            database = new Database(persons);
        }

        [Test]
        public void CreatingDatabaseCountShouldWorkCorrect()
        {
            int excpected = 11;
            Assert.AreEqual(excpected, database.Count);
        }

        [Test]
        public void CreatingDatabaseShouldThrowExceptionWhenCountIsMoreThan16()
        {
            Person[] persons =
    {
                new Person(1, "Pesho"),
                new Person(2, "Gosho"),
                new Person(3, "Pes"),
                new Person(4, "Ivan"),
                new Person(5, "Dragan"),
                new Person(6, "Mindi"),
                new Person(7, "Angel"),
                new Person(8, "Bangel"),
                new Person(9, "Boiko"),
                new Person(10, "John"),
                new Person(11, "Mima"),
                new Person(12, "Lili"),
                new Person(13, "Lina"),
                new Person(14, "Masha"),
                new Person(15, "Duda"),
                new Person(16, "Niki"),
                new Person(17, "Vasil"),
            };

            ArgumentException exception = Assert.Throws<ArgumentException>(() => database = new Database(persons));

            Assert.AreEqual("Provided data length should be in range [0..16]!", exception.Message);
        }


        [Test]
        public void DatabaseCountShouldWorkCorrect()
        {
            int excpected = 11;
            Assert.AreEqual(excpected, database.Count);
        }

        [Test]
        public void DatabaseAddMethodShouldIncreaseCount()
        {
            Person person = new(12, "Pepi");

            database.Add(person);

            Assert.AreEqual(12, database.Count);
        }

        [Test]
        public void DatabaseAddMethodCountShouldWorkCorrect()
        {
            Person person = new(12, "Piper");
            database.Add(person);

            int excpected = 12;
            Assert.AreEqual(excpected, database.Count);
        }

        [Test]
        public void DatabaseAddMethodShouldThrowExceptionIfCountIsMoreThan16()
        {
            Person person1 = new Person(12, "Lili");
            Person person2 = new Person(13, "Lina");
            Person person3 = new Person(14, "Masha");
            Person person4 = new Person(15, "Duda");
            Person person5 = new Person(16, "Niki");

            database.Add(person1);
            database.Add(person2);
            database.Add(person3);
            database.Add(person4);
            database.Add(person5);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17, "Nana")));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void DatabaseShouldThrowExceptionIfPersonWithSameUsernameIsAdded()
        {
            Person person = new(34, "Pesho");

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(person));

            Assert.AreEqual("There is already user with this username!", exception.Message);
        }

        [Test]
        public void DatabaseShouldThrowExceptionIfPersonWithSameIdIsAdded()
        {
            Person person = new Person(1, "Biden");

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(person));

            Assert.AreEqual("There is already user with this Id!", exception.Message);

        }

        [Test]
        public void DatabaseRemoveMethodShouldWorkCorrectly()
        {
            database.Remove();

            Assert.AreEqual(10, database.Count);
        }

        [Test]
        public void DatabaseRemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
        {
            Database database = new();

            Assert.Throws<InvalidOperationException>(() => database.Remove());

        }

        [Test]
        public void DatabaseFindByUsernameShouldWorkCorrectly()
        {
            string expectedResult = "Angel";
            string actualResult = database.FindByUsername("Angel").UserName;

            Assert.AreEqual(expectedResult, actualResult);
        }

        //[Test]
        //public void DatabaseFindByUsernameMethodShouldBeCaseSensitive() 
        //{
        //    string excpectedResult = "anGel";
        //    string actualResult = database.FindByUsername("Angel").UserName;

        //    Assert.AreEqual(excpectedResult, actualResult);
        //}

        [Test]
        [TestCase("")]
        [TestCase(null)]

        public void DatabaseFindByUsernameShouldThrowExceptionIfUsernameIsNullOrEmpty(string username)
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username));

            Assert.AreEqual("Username parameter is null!", exception.ParamName);
        }

        [Test]
        [TestCase("Di")]

        public void DatabaseFindByUserNameShouldThrowExceptionIfUserNameIsNotFound(string username) 
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.FindByUsername(username));

            Assert.AreEqual("No user is present by this username!", exception.Message);
        }

        [Test]
        public void DatabaseFindByIdShouldWorkCorrectly() 
        {
            string excpectedResult = "Angel";
            string actualResult = database.FindById(7).UserName;

            Assert.AreEqual(excpectedResult, actualResult);
        }

        [Test]
        public void DatabaseFindByIdShpuldThrowExceptionIfIdIsNegative() 
        {
            ArgumentOutOfRangeException excepton = Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));

            Assert.AreEqual("Id should be a positive number!", excepton.ParamName);
        }

        [Test]
        public void DatabaseFindByIdShpuldThrowExceptionIfIdIsNotFound() 
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.FindById(100));

            Assert.AreEqual("No user is present by this ID!", exception.Message);
        }
            }
}
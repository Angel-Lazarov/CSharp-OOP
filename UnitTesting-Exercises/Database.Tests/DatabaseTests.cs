namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        }

        [Test]
        public void Constructor_ShouldWorkCorrectly()
        {
            Assert.IsNotNull(database);
            Assert.AreEqual(15, database.Count);

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void Constructor_ShouldAddArrayCorrectly(int[] data)
        {
            database = new(data);
            Assert.AreEqual(data, database.Fetch());
        }

        [TestCase(1)]
        public void AddMethod_ShouldWorkCorectly(int element)
        {
            database.Add(element);

            Assert.AreEqual(16, database.Count);
        }

        [TestCase(1)]
        public void AddMethod_ShouldThrowError(int element)
        {
            database.Add(element);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(element));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void RemoveMethod_ShouldWorkCorectly()
        {
            database.Remove();

            Assert.AreEqual(14, database.Count);
        }

        [Test]
        public void RemoveMethod_ShouldThrowError()
        {
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Remove());

            Assert.AreEqual("The collection is empty!", exception.Message);
        }

        [Test]
        public void FetchMethod_ShouldWork()
        {
            database.Fetch();

            Assert.AreEqual(15, database.Count);
        }


    }
}

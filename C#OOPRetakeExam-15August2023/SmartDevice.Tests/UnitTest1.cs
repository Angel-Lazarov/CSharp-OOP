namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private Device device;
        [SetUp]
        public void Setup()
        {
            device = new Device(4);
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {

            Assert.IsNotNull(device);
            Assert.That(device.MemoryCapacity, Is.EqualTo(4));

            Assert.That(device.AvailableMemory, Is.EqualTo(4));

            Assert.AreEqual(device.MemoryCapacity, device.AvailableMemory);
            Assert.AreEqual(device.Photos, 0);


            Assert.AreEqual(device.Applications.Count, 0);
        }

        [TestCase(3)]
        [TestCase(4)]

        public void TakePhotoMethodShouldWorkCorrectly(int photoSize)
        {
            //public bool TakePhoto(int photoSize)

            Assert.IsTrue(device.TakePhoto(photoSize));
        }

        [Test]
        public void TakePhotoMethodDecreaseAvailableMemmory()
        {
            //this.AvailableMemory -= photoSize;
            device.TakePhoto(3);

            Assert.That(device.AvailableMemory, Is.EqualTo(1));
        }

        [Test]
        public void TakePhotoMethodIncreasePhotosCount()
        {
            //this.Photos++;
            device.TakePhoto(1);
            device.TakePhoto(1);

            Assert.That(device.Photos, Is.EqualTo(2));
        }

        [Test]
        public void TakePhotoMethodShouldReturnFalseIfNoMemmoryAvailable()
        {
            Assert.IsFalse(device.TakePhoto(5));
        }

        [TestCase("appName", 3)]
        [TestCase("appName", 4)]

        public void InstallAppMethodShouldWorkCorrectly(string appName, int appSize)
        {
            //public string InstallApp(string appName, int appSize)
            //if (appSize <= this.AvailableMemory)
            //{
            //    return $"{appName} is installed successfully. Run application?";
            //}


            string result = device.InstallApp(appName, appSize);
            string expected = $"{appName} is installed successfully. Run application?";

            Assert.That(device.Applications.Count, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo(expected));

        }

        [Test]
        public void InstallAppMethodShouldContainsAppName()
        {
            //    this.Applications.Add(appName);
            string result = device.InstallApp("appName", 3);

            Assert.That(device.Applications.Contains("appName"));
            Assert.IsTrue(device.Applications.Contains("appName"));
        }


        [Test]
        public void InstallAppMethodShouldDecreaseAvailableMemmory()
        {
            //    this.AvailableMemory -= appSize;
            string result = device.InstallApp("appName", 3);
            Assert.That(device.AvailableMemory, Is.EqualTo(1));
        }


        [Test]
        public void InstallAppMethodShouldThrowExceptionIfNoMemmoryAvailable()

        {
            //else
            //{
            //    throw new InvalidOperationException("Not enough available memory to install the app.");
            //}

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => device.InstallApp("appName", 6));

            string excpected = "Not enough available memory to install the app.";
            Assert.That("Not enough available memory to install the app.", Is.EqualTo(exception.Message));

        }

        [Test]
        public void FormatDeviceMethodShouldWorkCorrectly()
        {
            //public void FormatDevice()
            //{
            //    this.Photos = 0;
            //    this.Applications = new List<string>();
            //    this.AvailableMemory = this.MemoryCapacity;
            //}

            device.InstallApp("appName", 2);
            device.TakePhoto(1);

            device.FormatDevice();

            Assert.That(device.Photos, Is.EqualTo(0));
            Assert.That(device.Applications.Count, Is.EqualTo(0));
            Assert.That(device.AvailableMemory, Is.EqualTo(4));
            Assert.That(device.MemoryCapacity, Is.EqualTo(4));
        }

        [Test]

        public void GetStatusMethodShouldWorkCorrectly()
        {
            //public string GetDeviceStatus()
            //{
            //    StringBuilder stringBuilder = new StringBuilder();

            //    stringBuilder.AppendLine($"Memory Capacity: {this.MemoryCapacity} MB, Available Memory: {this.AvailableMemory} MB");
            //    stringBuilder.AppendLine($"Photos Count: {this.Photos}");
            //    stringBuilder.AppendLine($"Applications Installed: {string.Join(", ", this.Applications)}");

            //    return stringBuilder.ToString().TrimEnd();
            //}

            device.TakePhoto(1);
            device.InstallApp("appName", 1);

            string result = device.GetDeviceStatus();

            StringBuilder sbExpected = new StringBuilder();

            sbExpected.AppendLine($"Memory Capacity: 4 MB, Available Memory: 2 MB");
            sbExpected.AppendLine($"Photos Count: 1");
            sbExpected.AppendLine($"Applications Installed: appName");

            string expected = sbExpected.ToString().TrimEnd();

            Assert.That(result, Is.EqualTo(expected));

        }
    }
}
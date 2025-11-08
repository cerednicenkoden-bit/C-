using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace DeliverySystem.Tests
{
    [TestFixture]
    public class VanTests
    {
        [Test]
        public void Van_Constructor_InitializesCorrectly()
        {
            // Arrange & Act
            var van = new Van("Ford", 2020, 56000, 5, 1000);

            // Assert
            Assert.That(van.GetInfo(), Is.EqualTo("Van: Ford (2020), Doors: 5, Load: 0/1000kg, Fuel: 50L"));
            Assert.That(van.GetMaxSpeed(), Is.EqualTo(140.0));
        }

        [Test]
        public void Van_GetInfo_ReturnsCorrectFormat()
        {
            // Arrange
            var van = new Van("Ford", 2020, 56000, 5, 1000);

            // Act
            var result = van.GetInfo();

            // Assert
            Assert.That(result, Is.EqualTo("Van: Ford (2020), Doors: 5, Load: 0/1000kg, Fuel: 50L"));
        }

        [Test]
        public void Van_GetMaxSpeed_Returns140()
        {
            // Arrange
            var van = new Van("Ford", 2020, 56000, 5, 1000);

            // Act
            var result = van.GetMaxSpeed();

            // Assert
            Assert.That(result, Is.EqualTo(140.0));
        }

        [Test]
        public void Van_LoadCargo_SuccessfullyLoadsWhenWithinCapacity()
        {
            // Arrange
            var van = new Van("Ford", 2020, 56000, 5, 1000);
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            van.LoadCargo(800);

            // Assert
            Assert.That(van.GetInfo(), Is.EqualTo("Van: Ford (2020), Doors: 5, Load: 800/1000kg, Fuel: 50L"));
            Assert.That(sw.ToString(), Is.EqualTo("800 kg loaded into the van.\r\n"));
        }

        [Test]
        public void Van_LoadCargo_RejectsWhenExceedsCapacity()
        {
            // Arrange
            var van = new Van("Ford", 2020, 56000, 5, 1000);
            van.LoadCargo(800);
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            van.LoadCargo(300);

            // Assert
            Assert.That(van.GetInfo(), Is.EqualTo("Van: Ford (2020), Doors: 5, Load: 800/1000kg, Fuel: 50L"));
            Assert.That(sw.ToString(), Is.EqualTo("Too heavy! Cannot load more cargo.\r\n"));
        }

        [Test]
        public void Van_LoadCargo_AcceptsExactCapacity()
        {
            // Arrange
            var van = new Van("Ford", 2020, 56000, 5, 1000);
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            van.LoadCargo(1000);

            // Assert
            Assert.That(van.GetInfo(), Is.EqualTo("Van: Ford (2020), Doors: 5, Load: 1000/1000kg, Fuel: 50L"));
            Assert.That(sw.ToString(), Is.EqualTo("1000 kg loaded into the van.\r\n"));
        }

        [Test]
        public void Van_UnloadCargo_RemovesAllCargo()
        {
            // Arrange
            var van = new Van("Ford", 2020, 56000, 5, 1000);
            van.LoadCargo(800);
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            van.UnloadCargo();

            // Assert
            Assert.That(van.GetInfo(), Is.EqualTo("Van: Ford (2020), Doors: 5, Load: 0/1000kg, Fuel: 50L"));
            Assert.That(sw.ToString(), Is.EqualTo("Van unloaded.\r\n"));
        }

        [Test]
        public void Van_InheritsFromCar_CanUseCarMethods()
        {
            // Arrange
            var van = new Van("Ford", 2020, 56000, 5, 1000);
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            van.Move(100);
            van.Refuel(20);

            // Assert
            Assert.That(van.GetInfo(), Is.EqualTo("Van: Ford (2020), Doors: 5, Load: 0/1000kg, Fuel: 50L"));
        }
    }
}

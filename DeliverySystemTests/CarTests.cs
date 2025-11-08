using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace DeliverySystem.Tests
{
    [TestFixture]
    public class CarTests
    {
        [Test]
        public void Car_Constructor_InitializesCorrectly()
        {
            // Arrange & Act
            var car = new Car("Toyota", 2021, 34000, 4);

            // Assert
            Assert.That(car.GetInfo(), Is.EqualTo("Car: Toyota (2021), Doors: 4, Fuel: 50L"));
            Assert.That(car.GetMaxSpeed(), Is.EqualTo(180.0));
        }

        [Test]
        public void Car_GetInfo_ReturnsCorrectFormat()
        {
            // Arrange
            var car = new Car("Toyota", 2021, 34000, 4);

            // Act
            var result = car.GetInfo();

            // Assert
            Assert.That(result, Is.EqualTo("Car: Toyota (2021), Doors: 4, Fuel: 50L"));
        }

        [Test]
        public void Car_GetMaxSpeed_Returns180()
        {
            // Arrange
            var car = new Car("Toyota", 2021, 34000, 4);

            // Act
            var result = car.GetMaxSpeed();

            // Assert
            Assert.That(result, Is.EqualTo(180.0));
        }

        [Test]
        public void Car_Move_DecreasesFuelLevel()
        {
            // Arrange
            var car = new Car("Toyota", 2021, 34000, 4);
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            car.Move(50);

            // Assert
            Assert.That(car.GetInfo(), Is.EqualTo("Car: Toyota (2021), Doors: 4, Fuel: 45L"));
        }

        [Test]
        public void Car_Move_FuelLevelNotBelowZero()
        {
            // Arrange
            var car = new Car("Toyota", 2021, 34000, 4);

            // Act
            car.Move(600); // Виснажити паливо

            // Assert
            Assert.That(car.GetInfo(), Is.EqualTo("Car: Toyota (2021), Doors: 4, Fuel: 0L"));
        }

        [Test]
        public void Car_Refuel_AddsFuel()
        {
            // Arrange
            var car = new Car("Toyota", 2021, 34000, 4);
            car.Move(100); // Використати трохи палива

            // Act
            car.Refuel(20);

            // Assert
            Assert.That(car.GetInfo(), Is.EqualTo("Car: Toyota (2021), Doors: 4, Fuel: 50L"));
        }

        [Test]
        public void Car_Refuel_NotAbove50()
        {
            // Arrange
            var car = new Car("Toyota", 2021, 34000, 4);

            // Act
            car.Refuel(100); // Спроба переповнити бак

            // Assert
            Assert.That(car.GetInfo(), Is.EqualTo("Car: Toyota (2021), Doors: 4, Fuel: 50L"));
        }
    }
}

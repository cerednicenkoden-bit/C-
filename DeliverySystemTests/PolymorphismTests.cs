using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace DeliverySystem.Tests
{
    [TestFixture]
    public class PolymorphismTests
    {
        [Test]
        public void Polymorphism_VehicleReferenceToScooter_CallsOverriddenMethods()
        {
            // Arrange
            Vehicle vehicle = new Scooter("Xiaomi", 2023, 1200, 30);

            // Act
            var info = vehicle.GetInfo();
            var speed = vehicle.GetMaxSpeed();

            // Assert
            Assert.That(info, Is.EqualTo("Scooter: Xiaomi (2023), Battery: 100% of 30Ah"));
            Assert.That(speed, Is.EqualTo(45.0));
        }

        [Test]
        public void Polymorphism_VehicleReferenceToCar_CallsOverriddenMethods()
        {
            // Arrange
            Vehicle vehicle = new Car("Toyota", 2021, 34000, 4);

            // Act
            var info = vehicle.GetInfo();
            var speed = vehicle.GetMaxSpeed();

            // Assert
            Assert.That(info, Is.EqualTo("Car: Toyota (2021), Doors: 4, Fuel: 50L"));
            Assert.That(speed, Is.EqualTo(180.0));
        }

        [Test]
        public void Polymorphism_VehicleReferenceToVan_CallsOverriddenMethods()
        {
            // Arrange
            Vehicle vehicle = new Van("Ford", 2020, 56000, 5, 1000);

            // Act
            var info = vehicle.GetInfo();
            var speed = vehicle.GetMaxSpeed();

            // Assert
            Assert.That(info, Is.EqualTo("Van: Ford (2020), Doors: 5, Load: 0/1000kg, Fuel: 50L"));
            Assert.That(speed, Is.EqualTo(140.0));
        }
    }
}

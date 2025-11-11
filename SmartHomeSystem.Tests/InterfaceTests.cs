using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.Tests
{
    [TestFixture]
    public class InterfaceTests
    {
        // Перевіряє, що інтерфейс ISwitchable існує та має необхідні члени
        [Test]
        public void ISwitchable_InterfaceExists()
        {
            var type = typeof(ISwitchable);
            Assert.That(type.IsInterface, Is.True, "ISwitchable має бути інтерфейсом");

            var turnOnMethod = type.GetMethod("TurnOn");
            var turnOffMethod = type.GetMethod("TurnOff");
            var isOnProperty = type.GetProperty("IsOn");

            Assert.That(turnOnMethod, Is.Not.Null, "ISwitchable має містити метод TurnOn()");
            Assert.That(turnOffMethod, Is.Not.Null, "ISwitchable має містити метод TurnOff()");
            Assert.That(isOnProperty, Is.Not.Null, "ISwitchable має містити властивість IsOn");
            Assert.That(isOnProperty.PropertyType, Is.EqualTo(typeof(bool)), "IsOn має бути типу bool");
        }

        // Перевіряє, що інтерфейс IEnergyConsumer існує та має необхідні члени
        [Test]
        public void IEnergyConsumer_InterfaceExists()
        {
            var type = typeof(IEnergyConsumer);
            Assert.That(type.IsInterface, Is.True, "IEnergyConsumer має бути інтерфейсом");

            var deviceNameProperty = type.GetProperty("DeviceName");
            var powerConsumptionProperty = type.GetProperty("PowerConsumption");
            var getEnergyUsageMethod = type.GetMethod("GetEnergyUsage");

            Assert.That(deviceNameProperty, Is.Not.Null, "IEnergyConsumer має містити властивість DeviceName");
            Assert.That(powerConsumptionProperty, Is.Not.Null, "IEnergyConsumer має містити властивість PowerConsumption");
            Assert.That(getEnergyUsageMethod, Is.Not.Null, "IEnergyConsumer має містити метод GetEnergyUsage(int hours)");

            Assert.That(deviceNameProperty.PropertyType, Is.EqualTo(typeof(string)), "DeviceName має бути типу string");
            Assert.That(powerConsumptionProperty.PropertyType, Is.EqualTo(typeof(int)), "PowerConsumption має бути типу int");
            Assert.That(getEnergyUsageMethod.ReturnType, Is.EqualTo(typeof(double)), "GetEnergyUsage має повертати double");
        }
    }
}

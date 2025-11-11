using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.Tests
{
    [TestFixture]
    public class DeviceTests
    {
        // Перевіряє, що Device є абстрактним класом та реалізує ISwitchable
        [Test]
        public void Device_IsAbstractClass()
        {
            var type = typeof(Device);
            Assert.That(type.IsAbstract, Is.True, "Device має бути абстрактним класом");
            Assert.That(typeof(ISwitchable).IsAssignableFrom(type), Is.True, "Device має реалізувати ISwitchable");
        }

        // Перевіряє, що Device має необхідні властивості Name та IsOn
        [Test]
        public void Device_HasRequiredProperties()
        {
            var type = typeof(Device);

            var nameProperty = type.GetProperty("Name");
            var isOnProperty = type.GetProperty("IsOn");

            Assert.That(nameProperty, Is.Not.Null, "Device має містити властивість Name");
            Assert.That(isOnProperty, Is.Not.Null, "Device має містити властивість IsOn");

            Assert.That(nameProperty.PropertyType, Is.EqualTo(typeof(string)), "Name має бути типу string");
            Assert.That(isOnProperty.PropertyType, Is.EqualTo(typeof(bool)), "IsOn має бути типу bool");
        }

        // Перевіряє, що метод PrintStatus існує
        [Test]
        public void Device_HasPrintStatusMethod()
        {
            var type = typeof(Device);
            var printStatusMethod = type.GetMethod("PrintStatus");

            Assert.That(printStatusMethod, Is.Not.Null, "Device має містити метод PrintStatus()");
            Assert.That(printStatusMethod.ReturnType, Is.EqualTo(typeof(void)), "PrintStatus має повертати void");
        }
    }
}

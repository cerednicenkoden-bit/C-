using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SmartHomeSystem;

namespace SmartHomeSystem.Tests
{
    [TestFixture]
    public class AirConditionerTests
    {
        private TextWriter _originalOut;

        [SetUp]
        public void SetUp()
        {
            _originalOut = Console.Out;
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetOut(_originalOut);
        }

        // Перевіряє, що AirConditioner наслідує Device та реалізує IEnergyConsumer
        [Test]
        public void AirConditioner_InheritsDeviceAndImplementsIEnergyConsumer()
        {
            var type = typeof(AirConditioner);
            Assert.That(typeof(Device).IsAssignableFrom(type), Is.True, "AirConditioner має наслідувати Device");
            Assert.That(typeof(IEnergyConsumer).IsAssignableFrom(type), Is.True, "AirConditioner має реалізувати IEnergyConsumer");
        }

        // Перевіряє правильність споживання енергії для AirConditioner (2000 Вт)
        [Test]
        public void AirConditioner_PowerConsumptionIs2000Watts()
        {
            var ac = new AirConditioner { Name = "Test AC" };
            Assert.That(ac.PowerConsumption, Is.EqualTo(2000), "AirConditioner має споживати 2000 Вт");
        }

        // Перевіряє, що TurnOn() виводить правильне повідомлення
        [Test]
        public void AirConditioner_TurnOn_PrintsCorrectMessage()
        {
            var ac = new AirConditioner { Name = "Тестовий кондиціонер" };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ac.TurnOn();

                Assert.That(ac.IsOn, Is.True);
                Assert.That(sw.ToString(), Does.Contain("Тестовий кондиціонер почав охолодження."));
            }
        }

        // Перевіряє, що TurnOff() виводить правильне повідомлення
        [Test]
        public void AirConditioner_TurnOff_PrintsCorrectMessage()
        {
            var ac = new AirConditioner { Name = "Тестовий кондиціонер" };
            ac.TurnOn();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ac.TurnOff();

                Assert.That(ac.IsOn, Is.False);
                Assert.That(sw.ToString(), Does.Contain("Тестовий кондиціонер зупинено."));
            }
        }

        // Перевіряє розрахунок споживання енергії для увімкненого кондиціонера
        [Test]
        public void AirConditioner_GetEnergyUsage_ReturnsCorrectValue()
        {
            var ac = new AirConditioner { Name = "Test" };
            ac.TurnOn();

            double energy = ac.GetEnergyUsage(5);
            double expected = 2000 * 5 / 1000.0; // 10.00 кВт·год

            Assert.That(energy, Is.EqualTo(expected).Within(0.01), "Неправильне значення споживання енергії");
        }
    }
}

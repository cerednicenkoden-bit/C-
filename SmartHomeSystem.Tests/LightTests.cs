using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.Tests
{
    [TestFixture]
    public class LightTests
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

        // Перевіряє, що Light наслідує Device та реалізує IEnergyConsumer
        [Test]
        public void Light_InheritsDeviceAndImplementsIEnergyConsumer()
        {
            var type = typeof(Light);
            Assert.That(typeof(Device).IsAssignableFrom(type), Is.True, "Light має наслідувати Device");
            Assert.That(typeof(IEnergyConsumer).IsAssignableFrom(type), Is.True, "Light має реалізувати IEnergyConsumer");
        }

        // Перевіряє правильність споживання енергії для Light (60 Вт)
        [Test]
        public void Light_PowerConsumptionIs60Watts()
        {
            var light = new Light { Name = "Test Light" };
            Assert.That(light.PowerConsumption, Is.EqualTo(60), "Light має споживати 60 Вт");
        }

        // Перевіряє, що TurnOn() встановлює IsOn = true та виводить правильне повідомлення
        [Test]
        public void Light_TurnOn_SetsIsOnTrueAndPrintsMessage()
        {
            var light = new Light { Name = "Тестова лампа" };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                light.TurnOn();

                Assert.That(light.IsOn, Is.True, "IsOn має бути true після TurnOn()");
                Assert.That(sw.ToString(), Does.Contain("Тестова лампа засвітилася."),
                    "TurnOn() має вивести правильне повідомлення");
            }
        }

        // Перевіряє, що TurnOff() встановлює IsOn = false та виводить правильне повідомлення
        [Test]
        public void Light_TurnOff_SetsIsOnFalseAndPrintsMessage()
        {
            var light = new Light { Name = "Тестова лампа" };
            light.TurnOn();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                light.TurnOff();

                Assert.That(light.IsOn, Is.False, "IsOn має бути false після TurnOff()");
                Assert.That(sw.ToString(), Does.Contain("Тестова лампа вимкнена."),
                    "TurnOff() має вивести правильне повідомлення");
            }
        }

        // Перевіряє розрахунок споживання енергії для увімкненої лампи
        [Test]
        public void Light_GetEnergyUsage_WhenOn_ReturnsCorrectValue()
        {
            var light = new Light { Name = "Test" };
            light.TurnOn();

            double energy = light.GetEnergyUsage(5);
            double expected = 60 * 5 / 1000.0; // 0.30 кВт·год

            Assert.That(energy, Is.EqualTo(expected).Within(0.01), "Розрахунок енергії для увімкненої лампи неправильний");
        }

        // Перевіряє, що вимкнена лампа не споживає енергію
        [Test]
        public void Light_GetEnergyUsage_WhenOff_ReturnsZero()
        {
            var light = new Light { Name = "Test" };

            double energy = light.GetEnergyUsage(5);

            Assert.That(energy, Is.EqualTo(0), "Вимкнена лампа не має споживати енергію");
        }

        // Перевіряє правильність виводу PrintStatus() для увімкненої лампи
        [Test]
        public void Light_PrintStatus_WhenOn_PrintsCorrectly()
        {
            var light = new Light { Name = "Тестова лампа" };
            light.TurnOn();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                light.PrintStatus();

                Assert.That(sw.ToString(), Does.Contain("Тестова лампа: увімкнено"),
                    "PrintStatus має показувати 'увімкнено'");
            }
        }

        // Перевіряє правильність виводу PrintStatus() для вимкненої лампи
        [Test]
        public void Light_PrintStatus_WhenOff_PrintsCorrectly()
        {
            var light = new Light { Name = "Тестова лампа" };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                light.PrintStatus();

                Assert.That(sw.ToString(), Does.Contain("Тестова лампа: вимкнено"),
                    "PrintStatus має показувати 'вимкнено'");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.Tests
{
    public class MotionSensorTests
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

        // Перевіряє, що MotionSensor наслідує Device але НЕ реалізує IEnergyConsumer
        [Test]
        public void MotionSensor_InheritsDeviceButNotIEnergyConsumer()
        {
            var type = typeof(MotionSensor);
            Assert.That(typeof(Device).IsAssignableFrom(type), Is.True, "MotionSensor має наслідувати Device");
            Assert.That(typeof(IEnergyConsumer).IsAssignableFrom(type), Is.False,
                "MotionSensor НЕ має реалізувати IEnergyConsumer");
        }

        // Перевіряє, що TurnOn() виводить правильне повідомлення
        [Test]
        public void MotionSensor_TurnOn_PrintsCorrectMessage()
        {
            var sensor = new MotionSensor { Name = "Тестовий датчик" };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                sensor.TurnOn();

                Assert.That(sensor.IsOn, Is.True);
                Assert.That(sw.ToString(), Does.Contain("Тестовий датчик активовано."));
            }
        }

        // Перевіряє, що TurnOff() виводить правильне повідомлення
        [Test]
        public void MotionSensor_TurnOff_PrintsCorrectMessage()
        {
            var sensor = new MotionSensor { Name = "Тестовий датчик" };
            sensor.TurnOn();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                sensor.TurnOff();

                Assert.That(sensor.IsOn, Is.False);
                Assert.That(sw.ToString(), Does.Contain("Тестовий датчик деактивовано."));
            }
        }
    }

}

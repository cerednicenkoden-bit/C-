using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace SmartHomeSystem.Tests
{
    [TestFixture]
    public class CoffeeMachineTests
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

        // Перевіряє, що CoffeeMachine наслідує Device та реалізує IEnergyConsumer
        [Test]
        public void CoffeeMachine_InheritsDeviceAndImplementsIEnergyConsumer()
        {
            var type = typeof(CoffeeMachine);
            Assert.That(typeof(Device).IsAssignableFrom(type), Is.True, "CoffeeMachine має наслідувати Device");
            Assert.That(typeof(IEnergyConsumer).IsAssignableFrom(type), Is.True, "CoffeeMachine має реалізувати IEnergyConsumer");
        }

        // Перевіряє правильність споживання енергії для CoffeeMachine (1000 Вт)
        [Test]
        public void CoffeeMachine_PowerConsumptionIs1000Watts()
        {
            var coffee = new CoffeeMachine { Name = "Test Coffee" };
            Assert.That(coffee.PowerConsumption, Is.EqualTo(1000), "CoffeeMachine має споживати 1000 Вт");
        }

        // Перевіряє, що TurnOn() виводить правильне повідомлення
        [Test]
        public void CoffeeMachine_TurnOn_PrintsCorrectMessage()
        {
            var coffee = new CoffeeMachine { Name = "Тестова кавомашина" };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                coffee.TurnOn();

                Assert.That(coffee.IsOn, Is.True);
                Assert.That(sw.ToString(), Does.Contain("Тестова кавомашина почала готувати каву."));
            }
        }

        // Перевіряє, що TurnOff() виводить правильне повідомлення
        [Test]
        public void CoffeeMachine_TurnOff_PrintsCorrectMessage()
        {
            var coffee = new CoffeeMachine { Name = "Тестова кавомашина" };
            coffee.TurnOn();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                coffee.TurnOff();

                Assert.That(coffee.IsOn, Is.False);
                Assert.That(sw.ToString(), Does.Contain("Тестова кавомашина завершила роботу."));
            }
        }

        // Перевіряє розрахунок споживання енергії для увімкненої кавомашини
        [Test]
        public void CoffeeMachine_GetEnergyUsage_ReturnsCorrectValue()
        {
            var coffee = new CoffeeMachine { Name = "Test" };
            coffee.TurnOn();

            double energy = coffee.GetEnergyUsage(5);
            double expected = 1000 * 5 / 1000.0; // 5.00 кВт·год

            Assert.That(energy, Is.EqualTo(expected).Within(0.01), "Неправильне значення споживання енергії");
        }
    }
}

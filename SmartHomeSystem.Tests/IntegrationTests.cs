using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace SmartHomeSystem.Tests
{
    [TestFixture]
    public class IntegrationTests
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

        // Комплексний тест: перевіряє весь сценарій роботи системи
        [Test]
        public void FullScenario_WorksCorrectly()
        {
            var controller = new SmartHomeController();

            var lamp = new Light { Name = "Лампа у вітальні" };
            var ac = new AirConditioner { Name = "Кондиціонер у спальні" };
            var coffee = new CoffeeMachine { Name = "Кавомашина на кухні" };
            var motion = new MotionSensor { Name = "Датчик руху у коридорі" };

            controller.AddDevice(lamp);
            controller.AddDevice(ac);
            controller.AddDevice(coffee);
            controller.AddDevice(motion);

            controller.AddEnergyDevice(lamp);
            controller.AddEnergyDevice(ac);
            controller.AddEnergyDevice(coffee);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Вмикаємо всі пристрої
                controller.TurnAllOn();
                Assert.That(lamp.IsOn && ac.IsOn && coffee.IsOn && motion.IsOn,
                    Is.True,
                    "Всі пристрої мають бути увімкнені");

                // Виводимо статус
                lamp.PrintStatus();
                ac.PrintStatus();
                coffee.PrintStatus();
                motion.PrintStatus();

                // Показуємо звіт
                controller.ShowEnergyReport(5);

                // Вимикаємо всі пристрої
                controller.TurnAllOff();
                Assert.That(lamp.IsOn || ac.IsOn || coffee.IsOn || motion.IsOn,
                    Is.False,
                    "Всі пристрої мають бути вимкнені");

                string output = sw.ToString();

                // Перевіряємо ключові частини виводу
                Assert.That(output, Does.Contain("засвітилася"));
                Assert.That(output, Does.Contain("почав охолодження"));
                Assert.That(output, Does.Contain("почала готувати каву"));
                Assert.That(output, Does.Contain("активовано"));
                Assert.That(output, Does.Contain("Звіт про споживання енергії за 5 год:"));
                Assert.That(output, Does.Contain("15,30 кВт·год"));
                Assert.That(output, Does.Contain("вимкнена"));
                Assert.That(output, Does.Contain("зупинено"));
                Assert.That(output, Does.Contain("завершила роботу"));
                Assert.That(output, Does.Contain("деактивовано"));
            }
        }
    }
}

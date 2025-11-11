using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace SmartHomeSystem.Tests
{
    [TestFixture]
    public class SmartHomeControllerTests
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

        // Перевіряє, що контролер може додавати пристрої
        [Test]
        public void Controller_CanAddDevices()
        {
            var controller = new SmartHomeController();
            var light = new Light { Name = "Test" };

            Assert.DoesNotThrow(() => controller.AddDevice(light),
                "AddDevice не має викидати виключення");
        }

        // Перевіряє, що TurnAllOn() вмикає всі додані пристрої
        [Test]
        public void Controller_TurnAllOn_TurnsOnAllDevices()
        {
            var controller = new SmartHomeController();
            var light = new Light { Name = "Лампа" };
            var ac = new AirConditioner { Name = "Кондиціонер" };

            controller.AddDevice(light);
            controller.AddDevice(ac);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                controller.TurnAllOn();

                Assert.That(light.IsOn, Is.True, "Лампа має бути увімкнена");
                Assert.That(ac.IsOn, Is.True, "Кондиціонер має бути увімкнений");

                string output = sw.ToString();
                Assert.That(output, Does.Contain("засвітилася"), "Має бути повідомлення про лампу");
                Assert.That(output, Does.Contain("почав охолодження"), "Має бути повідомлення про кондиціонер");
            }
        }

        // Перевіряє, що TurnAllOff() вимикає всі додані пристрої
        [Test]
        public void Controller_TurnAllOff_TurnsOffAllDevices()
        {
            var controller = new SmartHomeController();
            var light = new Light { Name = "Лампа" };
            var ac = new AirConditioner { Name = "Кондиціонер" };

            controller.AddDevice(light);
            controller.AddDevice(ac);
            controller.TurnAllOn();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                controller.TurnAllOff();

                Assert.That(light.IsOn, Is.False, "Лампа має бути вимкнена");
                Assert.That(ac.IsOn, Is.False, "Кондиціонер має бути вимкнений");

                string output = sw.ToString();
                Assert.That(output, Does.Contain("вимкнена"), "Має бути повідомлення про вимкнення лампи");
                Assert.That(output, Does.Contain("зупинено"), "Має бути повідомлення про зупинення кондиціонера");
            }
        }

        // Перевіряє правильність формату звіту про енергію
        [Test]
        public void Controller_ShowEnergyReport_PrintsCorrectFormat()
        {
            var controller = new SmartHomeController();
            var light = new Light { Name = "Лампа у вітальні" };

            controller.AddDevice(light);
            controller.AddEnergyDevice(light);
            controller.TurnAllOn();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                controller.ShowEnergyReport(5);

                string output = sw.ToString();
                Assert.That(output, Does.Contain("Звіт про споживання енергії за 5 год:"));
                Assert.That(output, Does.Contain("Лампа у вітальні: 0,30 кВт·год (потужність: 60 Вт)"));
                Assert.That(output, Does.Contain("Загальне споживання: 0,30 кВт·год"));
                Assert.That(output, Does.Contain("Вартість (~4 грн/кВт·год): 1,20 грн"));
            }
        }

        // Перевіряє правильність розрахунку загального споживання енергії для кількох пристроїв
        [Test]
        public void Controller_ShowEnergyReport_CalculatesTotalCorrectly()
        {
            var controller = new SmartHomeController();
            var light = new Light { Name = "Лампа у вітальні" };
            var ac = new AirConditioner { Name = "Кондиціонер у спальні" };
            var coffee = new CoffeeMachine { Name = "Кавомашина на кухні" };

            controller.AddDevice(light);
            controller.AddDevice(ac);
            controller.AddDevice(coffee);

            controller.AddEnergyDevice(light);
            controller.AddEnergyDevice(ac);
            controller.AddEnergyDevice(coffee);

            controller.TurnAllOn();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                controller.ShowEnergyReport(5);

                string output = sw.ToString();
                Assert.That(output, Does.Contain("Загальне споживання: 15,30 кВт·год"));
                Assert.That(output, Does.Contain("Вартість (~4 грн/кВт·год): 61,20 грн"));
            }
        }

        // Перевіряє, що звіт не включає пристрої, які не додані як IEnergyConsumer
        [Test]
        public void Controller_ShowEnergyReport_DoesNotIncludeNonEnergyDevices()
        {
            var controller = new SmartHomeController();
            var sensor = new MotionSensor { Name = "Датчик руху" };
            var light = new Light { Name = "Лампа" };

            controller.AddDevice(sensor);
            controller.AddDevice(light);
            controller.AddEnergyDevice(light);

            controller.TurnAllOn();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                controller.ShowEnergyReport(5);

                string output = sw.ToString();
                Assert.That(output, Does.Not.Contain("Датчик руху"),
                    "Датчик руху не має бути у звіті про енергію");
                Assert.That(output, Does.Contain("Лампа"),
                    "Лампа має бути у звіті про енергію");
            }
        }

        // Перевіряє, що вимкнені пристрої не споживають енергію у звіті
        [Test]
        public void Controller_ShowEnergyReport_WhenDevicesOff_ShowsZeroEnergy()
        {
            var controller = new SmartHomeController();
            var light = new Light { Name = "Лампа" };

            controller.AddDevice(light);
            controller.AddEnergyDevice(light);
            // НЕ вмикаємо пристрій

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                controller.ShowEnergyReport(5);

                string output = sw.ToString();
                Assert.That(output, Does.Contain("Лампа: 0,00 кВт·год"));
                Assert.That(output, Does.Contain("Загальне споживання: 0,00 кВт·год"));
            }
        }
    }
}

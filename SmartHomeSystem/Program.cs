using SmartHomeSystem;

// Створити об’єкт SmartHomeController.
// Створити пристрої:
// Light - "Лампа у вітальні"
// AirConditioner - "Кондиціонер у спальні"
// CoffeeMachine - "Кавомашина на кухні"
// MotionSensor - "Датчик руху у коридорі"

// Додати пристрої до контролера:
// усі як ISwitchable
// перші три як IEnergyConsumer


// Викликати методи:
// TurnAllOn()
// PrintStatus() для кожного
// ShowEnergyReport(5)
// TurnAllOff();


class Program
{
    static void Main(string[] args)
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

        controller.TurnAllOn();

        lamp.PrintStatus();
        ac.PrintStatus();
        coffee.PrintStatus();
        motion.PrintStatus();

        controller.ShowEnergyReport(5);

        controller.TurnAllOff();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public class SmartHomeController
    {
        public List<ISwitchable> devices = new List<ISwitchable>();
        public List<IEnergyConsumer> energyDevices = new List<IEnergyConsumer>();

        public void AddDevice(ISwitchable device)
        {
            devices.Add(device);
        }

        public void AddEnergyDevice(IEnergyConsumer energyDevice)
        {
            energyDevices.Add(energyDevice);
        }

        public void TurnAllOn()
        {
            // Implementation for turning all devices on
            foreach (var device in devices)
            {
                device.TurnOn();
            }
        }

        public void TurnAllOff()
        {
            // Implementation for turning all devices off
            foreach (var device in devices)
            {
                device.TurnOff();
            }
        }

        public void ShowEnergyReport(int hours)
        {
            // Звіт про споживання енергії за {hours} год:
            // {DeviceName}: {значення:F2} кВт·год (потужність: {PowerConsumption} Вт)
            // Загальне споживання: {всього:F2} кВт·год
            // Вартість (~4 грн/кВт·год): {всього * 4:F2} грн
            double totalConsumption = 0;
            Console.WriteLine($"Звіт про споживання енергії за {hours} год:");
            foreach (var device in energyDevices)
            {
                totalConsumption += device.GetEnergyUsage(hours);

                Console.WriteLine($"{device.DeviceName}: {device.GetEnergyUsage(hours):F2} кВт·год (потужність: {device.PowerConsumption} Вт)");
            }
            Console.WriteLine($"Загальне споживання: {totalConsumption:F2} кВт·год");
            Console.WriteLine($"Вартість (~4 грн/кВт·год): {totalConsumption * 4:F2} грн");
        }
    }
}

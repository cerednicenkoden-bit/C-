using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public interface IEnergyConsumer
    {
        string DeviceName { get; }
        int PowerConsumption { get; } // енергія = потужність (Вт) × години / 1000

        double GetEnergyUsage(int hours);
    }
}

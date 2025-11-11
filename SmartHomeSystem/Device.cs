using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public abstract class Device : ISwitchable
    {
        public string? Name { get; set; }
        public bool IsOn { get; protected set; } = false;

        public abstract void TurnOn();
        public abstract void TurnOff();

        public void PrintStatus()
        {
            switch (IsOn)
            {
                case true:
                    Console.WriteLine($"{Name}: увімкнено");
                    break;
                case false:
                    Console.WriteLine($"{Name}: вимкнено");
                    break;
            }
        }
    }
}

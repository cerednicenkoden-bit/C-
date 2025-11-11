using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public interface ISwitchable
    {
        bool IsOn { get; }
        void TurnOn();
        void TurnOff();
    }
}

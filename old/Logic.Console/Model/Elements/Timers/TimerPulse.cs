
namespace Logic.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TimerPulse : Element, IStateSimulation, ITimer
    {
        public TimerPulse()
            : base()
        {
            this.Children = new List<Element>();
        }

        public TimerPulse(float delay)
            : this()
        {
            this.Delay = delay;
        }

        public float Delay { get; set; }

        public ISimulation Simulation { get; set; }
    }
}

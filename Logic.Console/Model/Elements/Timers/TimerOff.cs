
namespace Logic.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TimerOff : Element, IStateSimulation, ITimer
    {
        public TimerOff()
            : base()
        {
            this.Children = new List<Element>();
        }

        public TimerOff(float delay)
            : this()
        {
            this.Delay = delay;
        }

        public float Delay { get; set; }

        public ISimulation Simulation { get; set; }
    }
}

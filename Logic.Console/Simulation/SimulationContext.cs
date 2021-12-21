
namespace Logic.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Logic.Model;

    public class SimulationContext
    {
        public System.Threading.Timer SimulationTimer { get; set; }
        public object SimulationTimerSync { get; set; }
        public IClock SimulationClock { get; set; }
        public SimulationCache Cache { get; set; }
    }
}

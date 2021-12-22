
namespace Logic.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AndGate : Element, IStateSimulation
    {
        public AndGate()
            : base()
        {
            this.Children = new List<Element>();
        }

        public ISimulation Simulation { get; set; }
    }
}


namespace Logic.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class OrGate : Element, IStateSimulation
    {
        public OrGate()
            : base()
        {
            this.Children = new List<Element>();
        }

        public ISimulation Simulation { get; set; }
    }
}

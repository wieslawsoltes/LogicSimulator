
namespace Logic.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface ISimulation
    {
        void Compile();
        void Calculate();
        void Reset();

        Element Element { get; set; }

        IClock Clock { get; set; }

        IState State { get; set; }
        bool? InitialState { get; set; }
        Tuple<IState, bool>[] StatesCache { get; set; }
        bool HaveCache { get; set; }

        Element[] DependsOn { get; set; }
    }
}

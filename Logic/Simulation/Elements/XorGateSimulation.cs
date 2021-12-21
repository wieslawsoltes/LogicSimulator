// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Logic.Simulation
{
    using Logic.Model;
    using Logic.Model.Core;
    using Logic.Simulation.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class XorGateSimulation : ISimulation
    {
        public XorGateSimulation()
            : base()
        {
            this.InitialState = null;
        }

        public Element Element { get; set; }

        public IClock Clock { get; set; }

        public IBoolState State { get; set; }
        public bool? InitialState { get; set; }
        public Tuple<IBoolState, bool>[] StatesCache { get; set; }
        public bool HaveCache { get; set; }

        public Element[] DependsOn { get; set; }

        public void Compile()
        {
            throw new NotImplementedException();
        }

        public void Calculate()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}

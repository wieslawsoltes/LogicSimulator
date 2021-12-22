// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Logic.Model
{
    using Logic.Model.Core;
    using Logic.Simulation.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    [DataContract]
    public class XnorGate : Element, IStateSimulation
    {
        public XnorGate() : base() { }

        public ISimulation simulation;

        [IgnoreDataMember]
        public ISimulation Simulation
        {
            get { return simulation; }
            set
            {
                if (value != simulation)
                {
                    simulation = value;

                    Notify("Simulation");
                }
            }
        }

        public override object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

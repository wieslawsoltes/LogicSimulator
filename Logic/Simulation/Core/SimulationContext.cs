// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Logic.Simulation.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SimulationContext
    {
        public System.Threading.Timer SimulationTimer { get; set; }
        public object SimulationTimerSync { get; set; }
        public IClock SimulationClock { get; set; }
        public SimulationCache Cache { get; set; }
    }
}

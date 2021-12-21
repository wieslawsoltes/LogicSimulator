﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Logic.Simulation.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IStateSimulation
    {
        ISimulation Simulation { get; set; }
    }
}

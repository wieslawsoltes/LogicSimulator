﻿
namespace Logic.Model
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

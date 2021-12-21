﻿
namespace Logic.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Clock : IClock
    {
        public Clock()
            : base()
        {
        }

        public Clock(long cycle, int resolution)
            : this()
        {
            this.Cycle = cycle;
            this.Resolution = resolution;
        }

        public long Cycle { get; set; }
        public int Resolution { get; set; }
    }
}

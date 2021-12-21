
namespace Logic.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IClock
    {
        long Cycle { get; set; }
        int Resolution { get; set; }
    }
}

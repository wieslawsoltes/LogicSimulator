﻿
namespace Logic.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Context : Element
    {
        public Context()
            : base()
        {
            this.Children = new List<Element>();
        }
    }
}

﻿
namespace Logic.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Project : Element
    {
        public Project()
            : base()
        {
            this.Children = new List<Element>();
        }
    }
}
// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Logic.ViewModels
{
    using Logic.ViewModels.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DashboardModelView : IView 
    {
        public DashboardModelView() { }

        public DashboardModelView(string name)
            : base()
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}

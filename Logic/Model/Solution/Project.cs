// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Logic.Model
{
    using Logic.Model.Core;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    [DataContract]
    public class Project : Element
    {
        public Project() : base() { }

        private Title title = new Title();

        [DataMember]
        public Title Title
        {
            get { return title; }
            set
            {
                if (value != title)
                {
                    title = value;
                    Notify("Title");
                }
            }
        }

        public override object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

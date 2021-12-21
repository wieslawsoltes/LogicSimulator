// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Logic.Model.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    [DataContract]
    public class Property : NotifyObject
    {
        public Property()
            : base()
        {
        }

        public Property(object data)
            : this()
        {
            this.data = data;
        }

        private object data;

        [DataMember]
        public object Data
        {
            get { return data; }
            set
            {
                if (value != data)
                {
                    data = value;
                    Notify("Data");
                }
            }
        }
    }
}

// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Logic.ViewModels.Core
{
    using Logic.Model;
    using Logic.Model.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPrintService
    {
        void Print(Element element);
        void Print(IEnumerable<Element> elements);
    }
}

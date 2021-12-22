﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Logic.ViewModels.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IZoomService
    {
        void ZoomIn();
        void ZoomOut();
        void ZoomToPoint(int delta, double x, double y);
        void ZoomToFit();
        void Pan(double x, double y);
        void Reset();
    }
}

﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Logic.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;

    public static class SnapToGrid
    {
        public static double Snap(double original, double snap, double offset)
        {
            return Snap(original - offset, snap) + offset;
        }

        public static double Snap(double original, double snap)
        {
            return original + ((Math.Round(original / snap) - original / snap) * snap);
        }
    }
}

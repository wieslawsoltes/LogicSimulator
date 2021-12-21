// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Logic.Chart
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Windows.Threading;

    public partial class Chart : UserControl
    {
        DispatcherTimer timer = null;

        public Chart()
        {
            InitializeComponent();

            StartAutoScrollTimer();
        }

        public void StartAutoScrollTimer()
        {
            if (timer != null)
            {
                timer.Stop();
                timer = null;
            }

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50.0);
            timer.Tick += (sender, e) =>
            {
                this.Scroll();
            };

            timer.Start();
        }

        public void StopAutoScrollTimer()
        {
            if (timer != null)
                timer.Stop();
        }

        public void Scroll()
        {
            scrollViewer.ScrollToRightEnd();
        }
    }
}

﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using Logic.Util;
using Logic.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Logic.Native
{
    public class NativeView : Canvas, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ViewViewModel _model;
        public ViewViewModel Model
        {
            get { return _model; }
            set
            {
                if (value != _model)
                {
                    _model = value;
                    InitializeModel(_model);
                    Notify("Model");
                }
            }
        }

        public NativeView()
            : base()
        {
            InitializeEvents();
            RenderOptions.SetBitmapScalingMode(
                this,
                BitmapScalingMode.HighQuality);
        }

        private void InitializeEvents()
        {
            base.DataContextChanged += (s, e) =>
            {
                if (base.DataContext != null
                    && base.DataContext is ViewViewModel)
                {
                    Model = base.DataContext as ViewViewModel;
                }
            };

            base.PreviewMouseLeftButtonDown += (s, e) =>
            {
                if (_model != null)
                {
                    _model.MouseLeftButtonDown(e.GetPosition(this).ToPoint2());
                }
            };

            base.PreviewMouseLeftButtonUp += (s, e) =>
            {
                if (_model != null)
                {
                    _model.MouseLeftButtonUp(e.GetPosition(this).ToPoint2());
                }
            };

            base.PreviewMouseMove += (s, e) =>
            {
                if (_model != null)
                {
                    _model.MouseMove(e.GetPosition(this).ToPoint2());
                }
            };

            base.PreviewMouseRightButtonDown += (s, e) =>
            {
                if (_model != null)
                {
                    _model.MouseRightButtonDown(e.GetPosition(this).ToPoint2());
                }
            };
        }

        public void InitializeModel(ViewViewModel model)
        {
            model.IsMouseCaptured = () =>
            {
                return this.IsMouseCaptured;
            };

            model.CaptureMouse = () =>
            {
                this.CaptureMouse();
            };

            model.ReleaseMouseCapture = () =>
            {
                this.ReleaseMouseCapture();
            };

            model.InvalidateVisual = () =>
            {
                this.InvalidateVisual();
            };
        }

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            if (_model != null)
            {
                _model.OnRender(dc);
            }
        }
    }
}

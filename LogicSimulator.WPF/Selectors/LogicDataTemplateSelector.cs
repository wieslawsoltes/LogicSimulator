﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace LogicSimulator.Selectors;

public class LogicDataTemplateSelector : DataTemplateSelector
{
    public override DataTemplate? SelectTemplate(object? item, DependencyObject container)
    {
        try
        {
            var key = item.GetType().Name + "DataTemplateKey";
            return (DataTemplate)Application.Current.FindResource(key);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Print("Exception: {0}", ex.Message);
        }
        return null;
    }
}
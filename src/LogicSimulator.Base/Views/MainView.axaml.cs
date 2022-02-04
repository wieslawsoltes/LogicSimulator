using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using LogicSimulator.Core;
using LogicSimulator.Core.Diagrams;
using LogicSimulator.Core.Tests;
using LogicSimulator.ViewModels;

namespace LogicSimulator.Views;

public class MainView : UserControl
{
    private readonly IScheduler _scheduler = Scheduler.Default;

    public MainView()
    {
        InitializeComponent();

        // Test Diagram #1 (Timers)
        DataContext = LogicDiagramTests.GetTestDigitalLogicDiagram1(_scheduler);

        // Test Diagram #2 (SR NOR latch)
        // this.DataContext = LogicDiagramTests.GetTestDigitalLogicDiagram2(scheduler);

        DetachedFromVisualTree += (sender, e) => CleanUp();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void CleanUp()
    {
        if (DataContext is DigitalLogicDiagram diagram)
        {
            diagram.Dispose();
        }
    }

    private async void menuItemFileOpenDiagram_Click(object? sender, RoutedEventArgs e)
    {
        CleanUp();

        try
        {
            var diagram = await Serializer.OpenDiagram();
            if (diagram != null)
            {
                diagram.Disposables = new Dictionary<Guid, IDisposable>();
                diagram.ObserveInputs(_scheduler, diagram.Disposables);
                diagram.ObserveElements(_scheduler, diagram.Disposables);

                DataContext = diagram;
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }

    private async void menuItemFileSaveDiagram_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (DataContext is DigitalLogicDiagram diagram)
            {
                await Serializer.SaveDiagram(diagram);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }

    private void menuItemFileExit_Click(object? sender, RoutedEventArgs e)
    {
        if (Application.Current?.ApplicationLifetime is IControlledApplicationLifetime lifetime)
        {
            lifetime.Shutdown();
        }
    }
}


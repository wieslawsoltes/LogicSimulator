using System;
using System.Reactive.Concurrency;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using LogicSimulator.Core.Diagrams;
using LogicSimulator.Core.Tests;
using LogicSimulator.ViewModels;

namespace LogicSimulator.Views
{
    public partial class MainWindow : Window
    {
        private IScheduler scheduler = Scheduler.Default;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            // Test Diagram #1 (Timers)
            this.DataContext = LogicDiagramTests.GetTestDigitalLogicDiagram1(scheduler);

            // Test Diagram #2 (SR NOR latch)
            //this.DataContext = LogicDiagramTests.GetTestDigitalLogicDiagram2(scheduler);

            this.Closed += (sender, e) => CleanUp();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void CleanUp()
        {
            var diagram = this.DataContext as DigitalLogicDiagram;
            if (diagram != null)
                diagram.Dispose();
        }

        private void menuItemFileOpenDiagram_Click(object sender, RoutedEventArgs e)
        {
            CleanUp();

            try
            {
                var diagram = Serializer.OpenDiagram();
                if (diagram != null)
                {
                    diagram.ObserveInputs(scheduler, diagram.Disposables);
                    diagram.ObserveElements(scheduler, diagram.Disposables);

                    this.DataContext = diagram;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void menuItemFileSaveDiagram_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var diagram = this.DataContext as DigitalLogicDiagram;
                if (diagram != null)
                {
                    Serializer.SaveDiagram(diagram);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void menuItemFileExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

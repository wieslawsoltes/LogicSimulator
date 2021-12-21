using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Windows;
using LogicSimulator.Core;
using LogicSimulator.Core.Diagrams;
using LogicSimulator.Core.Tests;
using LogicSimulator.Model;

namespace LogicSimulator
{
    public partial class MainWindow : Window
    {
        private readonly IScheduler _scheduler = Scheduler.Default;

        public MainWindow()
        {
            InitializeComponent();

            // Test Diagram #1 (Timers)
            this.DataContext = LogicDiagramTests.GetTestDigitalLogicDiagram1(_scheduler);

            // Test Diagram #2 (SR NOR latch)
            //this.DataContext = LogicDiagramTests.GetTestDigitalLogicDiagram2(scheduler);

            this.Closed += (sender, e) => CleanUp();
        }

        private void CleanUp()
        {
            var diagram = this.DataContext as DigitalLogicDiagram;
            if (diagram != null)
            {
                diagram.Dispose();
            }
        }

        private void menuItemFileOpenDiagram_Click(object sender, RoutedEventArgs e)
        {
            CleanUp();

            try
            {
                var diagram = Serializer.OpenDiagram();
                if (diagram != null)
                {
                    diagram.Disposables = new Dictionary<Guid, IDisposable>();
                    diagram.ObserveInputs(_scheduler, diagram.Disposables);
                    diagram.ObserveElements(_scheduler, diagram.Disposables);

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

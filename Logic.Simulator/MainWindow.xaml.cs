using Logic.Model;
using Logic.Model.Diagrams;
using Logic.Model.Rx;
using Logic.Tests;
using System.Reactive.Concurrency;
using System.Windows;

namespace Logic
{
    public partial class MainWindow : Window
    {
        private IScheduler scheduler = Scheduler.Default;

        public MainWindow()
        {
            InitializeComponent();

            // Test Diagram #1 (Timers)
            this.DataContext = LogicDiagramTests.GetTestDigitalLogicDiagram1(scheduler);

            // Test Diagram #2 (SR NOR latch)
            //this.DataContext = LogicDiagramTests.GetTestDigitalLogicDiagram2(scheduler);

            this.Closed += (sender, e) => CleanUp();
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

            var diagram = Serializer.OpenDiagram();
            if (diagram != null)
            {
                diagram.ObserveInputs(scheduler, diagram.Disposables);
                diagram.ObserveElements(scheduler, diagram.Disposables);

                this.DataContext = diagram;
            }
        }

        private void menuItemFileSaveDiagram_Click(object sender, RoutedEventArgs e)
        {
            var diagram = this.DataContext as DigitalLogicDiagram;
            if (diagram != null)
                Serializer.SaveDiagram(diagram);
        }

        private void menuItemFileExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

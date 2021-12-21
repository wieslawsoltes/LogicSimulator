using System.Windows;
using System.Windows.Controls;
using Logic.Model.Core;
using System.Windows.Controls.Primitives;

namespace Logic
{
    public partial class DiagramView : UserControl
    {
        public DiagramView()
        {
            InitializeComponent();
        }

        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var element = (sender as FrameworkElement).DataContext as DigitalLogic;
            if (element != null)
                MovelElement(e.HorizontalChange, e.VerticalChange, element);

            e.Handled = true;
        }

        private static void MovelElement(double dX, double dY, DigitalLogic element)
        {
            element.X += dX;
            element.Y += dY;

            foreach (var pin in element.Pins)
            {
                pin.X += dX;
                pin.Y += dY;
            }
        }
    }
}

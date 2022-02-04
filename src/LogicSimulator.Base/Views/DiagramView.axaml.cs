using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LogicSimulator.Views;

public class DiagramView : UserControl
{
    public DiagramView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}


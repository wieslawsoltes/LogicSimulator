using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LogicSimulator.Views;

public class ModelView : UserControl
{
    public ModelView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}


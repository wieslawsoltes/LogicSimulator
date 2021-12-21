using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;
using LogicSimulator.Core.Core;

namespace LogicSimulator.Selectors;

public class LogicDataTemplateSelector : IDataTemplate
{
    public IControl Build(object data)
    {
        var type = data.GetType();
        var key = type.Name + "DataTemplateKey";

        if (Application.Current is { })
        {
            Application.Current.TryFindResource(key, out var resource);
            if (resource is DataTemplate dataTemplate)
            {
                return dataTemplate.Build(data);
            }
        }

        return new TextBlock { Text = "Not Found: " + type.Name };
    }

    public bool Match(object data)
    {
        return data is LogicObject;
    }
}

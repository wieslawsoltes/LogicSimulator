using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;
using LogicSimulator.Core.Core;

namespace LogicSimulator.Selectors;

public class LogicDataTemplateSelector : IDataTemplate
{
    public IControl Build(object? data)
    {
        var type = data?.GetType();
        if (type is { })
        {
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

        return new TextBlock { Text = "Not found view as data is null." };
    }

    public bool Match(object? data)
    {
        return data is LogicObject;
    }
}

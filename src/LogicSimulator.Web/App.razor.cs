using Avalonia.ReactiveUI;
using Avalonia.Web.Blazor;

namespace LogicSimulator.Web;

public partial class App
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        WebAppBuilder.Configure<LogicSimulator.App>()
            .UseReactiveUI()
            .SetupWithSingleViewLifetime();
    }
}

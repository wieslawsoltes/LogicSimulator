using Avalonia;
using Avalonia.Data.Converters;
using LogicSimulator.Core.Core;

namespace LogicSimulator;

public static class Converters
{
    public static IValueConverter
        DigitalPinToPoint = new FuncValueConverter<DigitalPin?, Point>(x => x is null ? new Point() : new Point(x.X, x.Y));

    public static IValueConverter
        BoolIsTrue = new FuncValueConverter<bool?, bool>(x => x is true);

    public static IValueConverter
        BoolIsFalse = new FuncValueConverter<bool?, bool>(x => x is false);

    public static IValueConverter
        BoolIsNull = new FuncValueConverter<bool?, bool>(x => x is null);
}

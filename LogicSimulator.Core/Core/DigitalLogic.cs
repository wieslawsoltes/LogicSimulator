using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace LogicSimulator.Core.Core;

[DataContract(IsReference = true)]
public abstract class DigitalLogic : LogicObject
{
    private ObservableCollection<DigitalSignal> _inputs = new();
    private ObservableCollection<DigitalSignal> _outputs = new();
    private ObservableCollection<DigitalPin> _pins = new();

    [DataMember(EmitDefaultValue = true, IsRequired = false)]
    public virtual ObservableCollection<DigitalSignal> Inputs
    {
        get { return _inputs; }
        set
        {
            if (value != _inputs)
            {
                _inputs = value;
                Notify(nameof(Inputs));
            }
        }
    }

    [DataMember(EmitDefaultValue = true, IsRequired = false)]
    public virtual ObservableCollection<DigitalSignal> Outputs
    {
        get { return _outputs; }
        set
        {
            if (value != _outputs)
            {
                _outputs = value;
                Notify(nameof(Outputs));
            }
        }
    }

    [DataMember(EmitDefaultValue = true, IsRequired = false)]
    public virtual ObservableCollection<DigitalPin> Pins
    {
        get { return _pins; }
        set
        {
            if (value != _pins)
            {
                _pins = value;
                Notify(nameof(Pins));
            }
        }
    }

    public abstract void Calculate();
}
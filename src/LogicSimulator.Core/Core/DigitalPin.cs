using System.Runtime.Serialization;

namespace LogicSimulator.Core.Core;

[DataContract(IsReference = true)]
public class DigitalPin : LogicObject
{
    private DigitalSignal? _signal;

    [DataMember(EmitDefaultValue = false, IsRequired = false)]
    public DigitalSignal? Signal
    {
        get { return _signal; }
        set
        {
            if (value != _signal)
            {
                _signal = value;
                Notify(nameof(Signal));
            }
        }
    }
}
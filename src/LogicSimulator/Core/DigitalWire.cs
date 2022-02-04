using System.Runtime.Serialization;

namespace LogicSimulator.Core.Core;

[DataContract(IsReference = true)]
public class DigitalWire : LogicObject
{
    private DigitalSignal? _signal;
    private DigitalPin? _startPin;
    private DigitalPin? _endPin;

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

    [DataMember(EmitDefaultValue = false, IsRequired = false)]
    public DigitalPin? StartPin
    {
        get { return _startPin; }
        set
        {
            if (value != _startPin)
            {
                _startPin = value;
                Notify(nameof(StartPin));
            }
        }
    }

    [DataMember(EmitDefaultValue = false, IsRequired = false)]
    public DigitalPin? EndPin
    {
        get { return _endPin; }
        set
        {
            if (value != _endPin)
            {
                _endPin = value;
                Notify(nameof(EndPin));
            }
        }
    }
}
using System.Runtime.Serialization;

namespace LogicSimulator.Core.Core;

[DataContract(IsReference = true)]
public class DigitalSignal : LogicObject
{
    private bool? _state;
    private DigitalPin? _inputPin;
    private DigitalPin? _outputPin;

    public DigitalSignal() { }

    public DigitalSignal(bool state)
        : this()
    {
        _state = state;
    }

    [DataMember(EmitDefaultValue = false, IsRequired = false)]
    public bool? State
    {
        get { return _state; }
        set
        {
            if (value != _state)
            {
                _state = value;
                Notify(nameof(State));
            }
        }
    }

    [DataMember(EmitDefaultValue = false, IsRequired = false)]
    public DigitalPin? InputPin
    {
        get { return _inputPin; }
        set
        {
            if (value != _inputPin)
            {
                _inputPin = value;
                Notify(nameof(InputPin));
            }
        }
    }

    [DataMember(EmitDefaultValue = false, IsRequired = false)]
    public DigitalPin? OutputPin
    {
        get { return _outputPin; }
        set
        {
            if (value != _outputPin)
            {
                _outputPin = value;
                Notify(nameof(OutputPin));
            }
        }
    }
}
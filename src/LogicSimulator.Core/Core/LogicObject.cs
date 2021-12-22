using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace LogicSimulator.Core.Core;

[DataContract(IsReference = true)]
public abstract class LogicObject : INotifyPropertyChanged
{
    private Guid _id = Guid.Empty;
    private string _name = string.Empty;
    private double _x;
    private double _y;
    private double _z;

    protected void Notify(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [DataMember(EmitDefaultValue = false, IsRequired = false)]
    public Guid Id
    {
        get { return _id; }
        set
        {
            if (value != _id)
            {
                _id = value;
                Notify(nameof(Id));
            }
        }
    }

    [DataMember(EmitDefaultValue = false, IsRequired = false)]
    public string Name
    {
        get { return _name; }
        set
        {
            if (value != _name)
            {
                _name = value;
                Notify(nameof(Name));
            }
        }
    }

    [DataMember(EmitDefaultValue = false, IsRequired = false)]
    public double X
    {
        get { return _x; }
        set
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (value != _x)
            {
                _x = value;
                Notify(nameof(X));
            }
        }
    }

    [DataMember(EmitDefaultValue = false, IsRequired = false)]
    public double Y
    {
        get { return _y; }
        set
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (value != _y)
            {
                _y = value;
                Notify(nameof(Y));
            }
        }
    }

    [DataMember(EmitDefaultValue = false, IsRequired = false)]
    public double Z
    {
        get { return _z; }
        set
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (value != _z)
            {
                _z = value;
                Notify(nameof(Z));
            }
        }
    }
}
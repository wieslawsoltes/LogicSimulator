using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using LogicSimulator.Core.Core;

namespace LogicSimulator.Core.Diagrams;

[DataContract(IsReference = true)]
public class DigitalLogicDiagram : DigitalLogic
{
    private ObservableCollection<LogicObject> _elements = new();

    [IgnoreDataMember]
    public IDictionary<Guid, IDisposable>? Disposables { get; set; }

    [DataMember(EmitDefaultValue = true, IsRequired = false)]
    public ObservableCollection<LogicObject> Elements
    {
        get { return _elements; }
        set
        {
            if (value != _elements)
            {
                _elements = value;
                Notify(nameof(Elements));
            }
        }
    }

    public override void Calculate() { }

    public void Dispose()
    {
        if (Disposables != null)
        {
            foreach (var dispose in Disposables)
            {
                dispose.Value.Dispose();
            }
        }
    }
}

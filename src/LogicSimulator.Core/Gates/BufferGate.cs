using System.Linq;
using System.Runtime.Serialization;
using LogicSimulator.Core.Core;

namespace LogicSimulator.Core.Gates;

[DataContract(IsReference = true)]
public class BufferGate : DigitalLogic
{
    public override void Calculate()
    {
        if (Inputs.Count > 0 && Inputs.Count == Outputs.Count && Inputs.All(i => i.State.HasValue))
        {
            for (var i = 0; i < Inputs.Count; i++)
            {
                Outputs[i].State = Inputs[i].State;
            }
        }
    }
}
using System.Linq;
using System.Runtime.Serialization;
using LogicSimulator.Core.Core;

namespace LogicSimulator.Core.Gates;

[DataContract(IsReference = true)]
public class NotGate : DigitalLogic
{
    public override void Calculate()
    {
        if (Outputs.Count == 1 && Inputs.All(i => i.State.HasValue))
        {
            Outputs.First().State = Inputs.Count != 1 ? false : !Inputs.First().State;
        }
    }
}
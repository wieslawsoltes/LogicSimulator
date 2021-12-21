using System.Linq;
using System.Runtime.Serialization;
using LogicSimulator.Core.Core;

namespace LogicSimulator.Core.Gates;

[DataContract(IsReference = true)]
public class OrGate : DigitalLogic
{
    public override void Calculate()
    {
        if (Outputs.Count == 1 && Inputs.All(i => i.State.HasValue))
        {
            Outputs.First().State = Inputs.Count >= 2 && Inputs.Any(i => i.State != false);
        }
    }
}

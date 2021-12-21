using Logic.Model.Core;
using System.Linq;

namespace Logic.Model.Gates
{
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
}

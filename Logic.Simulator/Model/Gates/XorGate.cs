using Logic.Model.Core;
using System.Linq;

namespace Logic.Model.Gates
{
    public class XorGate : DigitalLogic
    {
        public override void Calculate()
        {   
            if (Outputs.Count == 1 && Inputs.All(i => i.State.HasValue))
            {
                Outputs.First().State = Inputs.Count < 2 ? false : Inputs.Count(i => i.State == true) % 2 != 0;
            }
        }
    }
}

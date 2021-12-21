using Logic.Model.Core;
using System.Linq;

namespace Logic.Model.Gates
{
    public class BufferGate : DigitalLogic
    {
        public override void Calculate()
        {
            if (Inputs.Count > 0 && (Inputs.Count == Outputs.Count) && Inputs.All(i => i.State.HasValue))
            {
                for (int i = 0; i < Inputs.Count; i++)
                {
                    Outputs[i].State = Inputs[i].State;
                }
            }
        }
    }
}

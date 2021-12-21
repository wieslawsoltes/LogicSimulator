namespace Logic.Model.Core
{
    public class DigitalPin : LogicObject
    {
        private DigitalSignal signal;

        public DigitalSignal Signal
        {
            get { return signal; }
            set
            {
                if (value != signal)
                {
                    signal = value;
                    Notify("Signal");
                }
            }
        }
    }
}

namespace Logic.Model.Core
{
    public class DigitalSignal : LogicObject
    {
        public DigitalSignal() { }

        public DigitalSignal(bool state)
            : this()
        {
            this.state = state;
        }

        private bool? state = null;
        private DigitalPin inputPin = null;
        private DigitalPin outputPin = null;

        public bool? State
        {
            get { return state; }
            set
            {
                if (value != state)
                {
                    state = value;
                    Notify("State");
                }
            }
        }

        public DigitalPin InputPin
        {
            get { return inputPin; }
            set
            {
                if (value != inputPin)
                {
                    inputPin = value;
                    Notify("InputPin");
                }
            }
        }

        public DigitalPin OutputPin
        {
            get { return outputPin; }
            set
            {
                if (value != outputPin)
                {
                    outputPin = value;
                    Notify("OutputPin");
                }
            }
        }
    }
}

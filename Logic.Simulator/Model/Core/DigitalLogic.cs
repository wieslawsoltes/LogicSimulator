using System.Collections.ObjectModel;

namespace Logic.Model.Core
{
    public abstract class DigitalLogic : LogicObject
    {
        private ObservableCollection<DigitalSignal> inputs = new ObservableCollection<DigitalSignal>();
        private ObservableCollection<DigitalSignal> outputs = new ObservableCollection<DigitalSignal>();
        private ObservableCollection<DigitalPin> pins = new ObservableCollection<DigitalPin>();

        public virtual ObservableCollection<DigitalSignal> Inputs
        {
            get { return inputs; }
            set
            {
                if (value != inputs)
                {
                    inputs = value;
                    Notify("Inputs");
                }
            }
        }

        public virtual ObservableCollection<DigitalSignal> Outputs
        {
            get { return outputs; }
            set
            {
                if (value != outputs)
                {
                    outputs = value;
                    Notify("Outputs");
                }
            }
        }

        public virtual ObservableCollection<DigitalPin> Pins
        {
            get { return pins; }
            set
            {
                if (value != pins)
                {
                    pins = value;
                    Notify("Pins");
                }
            }
        }

        public abstract void Calculate();
    }
}

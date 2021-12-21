using Logic.Model.Core;
using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Logic.Model.Timers
{
    public class TimerPulse : DigitalLogic
    {
        public TimerPulse()
            : base()
        {
        }

        public TimerPulse(double delay)
            : this()
        {
            this.delay = delay;
        }

        private double delay = double.NaN;

        public virtual double Delay
        {
            get { return delay; }
            set
            {
                if (value != delay)
                {
                    delay = value;

                    Notify("Delay");
                }
            }
        }

        private IDisposable disposable = null;
        private IScheduler scheduler = null;

        public override void Calculate()
        {
            if (Inputs.Count == 1 && Outputs.Count == 1)
            {
                if (Inputs.First().State == true)
                {
                    if (disposable == null)
                    {
                        // create timer
                        var observable = Observable.Timer(DateTimeOffset.Now.AddSeconds(delay), scheduler == null ? Scheduler.Default : scheduler);

                        // start pulse
                        Outputs.First().State = true;

                        // subcribe to timer
                        disposable = observable.Subscribe(x =>
                        {
                            // update output
                            if (Outputs.Count == 1)
                            {
                                // end pulse after time 'delay'
                                Outputs.First().State = false;
                            }

                            // dispose timer
                            disposable.Dispose();
                            disposable = null;
                        });
                    }
                }
            }
        }
    }
}

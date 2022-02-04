using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Runtime.Serialization;
using LogicSimulator.Core.Core;

namespace LogicSimulator.Core.Timers;

[DataContract(IsReference = true)]
public class TimerOnDelay : DigitalLogic
{
    private IDisposable? _disposable;
#pragma warning disable CS0649
    private IScheduler? _scheduler;
#pragma warning restore CS0649
    private double _delay = double.NaN;

    public TimerOnDelay()
    {
    }

    public TimerOnDelay(double delay)
        : this()
    {
        _delay = delay;
    }

    [DataMember(EmitDefaultValue = false, IsRequired = false)]
    public double Delay
    {
        get { return _delay; }
        set
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (value != _delay)
            {
                _delay = value;
                Notify(nameof(Delay));
            }
        }
    }

    public override void Calculate()
    {
        if (Inputs.Count == 1 && Outputs.Count == 1)
        {
            if (Inputs.First().State == true)
            {
                if (_disposable == null)
                {
                    // create timer
                    var observable = Observable.Timer(DateTimeOffset.Now.AddSeconds(_delay), _scheduler ?? Scheduler.Default);

                    // subscribe to timer
                    _disposable = observable.Subscribe(_ =>
                    {
                        // update output
                        if (Outputs.Count == 1)
                        {
                            Outputs.First().State = Inputs.Count != 1 ? false : Inputs.First().State;
                        }

                        // dispose timer
                        _disposable?.Dispose();
                        _disposable = null;
                    });
                }
            }
            else
            {
                // dispose timer
                _disposable?.Dispose();
                _disposable = null;

                // update output
                if (Outputs.Count == 1)
                {
                    Outputs.First().State = Inputs.Count != 1 ? false : Inputs.First().State;
                }
            }
        }
    }
}

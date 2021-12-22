﻿
namespace Logic.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TimerPulseSimulation : ISimulation
    {
        public TimerPulseSimulation()
            : base()
        {
            this.InitialState = null;
        }

        public Element Element { get; set; }

        public IClock Clock { get; set; }

        public IState State { get; set; }
        public bool? InitialState { get; set; }
        public Tuple<IState, bool>[] StatesCache { get; set; }
        public bool HaveCache { get; set; }

        public Element[] DependsOn { get; set; }

        public void Compile()
        {
            if (HaveCache)
                Reset();

            // only one input is allowed for timer
            var inputs = Element.Children.Cast<Pin>().Where(pin => pin.Connections != null && pin.Type == PinType.Input);

            if (inputs == null || inputs.Count() != 1)
            {
                if (SimulationSettings.EnableDebug)
                {
                    Console.WriteLine("No Valid Input for Id: {0} | State: {1}", Element.Id, State.State);
                }

                return;
            }

            // get all connected inputs with possible state
            var connections = inputs.First().Connections.Where(x => x.Item1.Type == PinType.Output);

            // set ISimulation dependencies (used for topological sort)
            DependsOn = connections.Where(x => x.Item1 != null).Select(y => y.Item1.Parent).Take(1).ToArray();

            if (SimulationSettings.EnableDebug)
            {
                foreach (var connection in connections)
                {
                    Console.WriteLine("Pin: {0} | Inverted: {1} | Parent: {2} | Type: {3}",
                    connection.Item1.Id,
                    connection.Item2,
                    (connection.Item1.Parent != null) ? connection.Item1.Parent.Id : UInt32.MaxValue,
                    connection.Item1.Type);
                }
            }

            // get all connected inputs with state
            var states = connections.Select(x => new Tuple<IState, bool>((x.Item1.Parent as IStateSimulation).Simulation.State, x.Item2)).ToArray();

            if (states.Length == 1)
            {
                StatesCache = states;
                HaveCache = true;
            }
            else
            {
                // invalidate state
                State = null;

                StatesCache = null;
                HaveCache = false;
            }
        }

        private bool IsEnabled;
        private bool IsReset;
        private long EndCycle;

        public void Calculate()
        {
            if (HaveCache)
            {
                // calculate new state
                var first = StatesCache[0];
                bool? enableState = first.Item2 ? !(first.Item1.State) : first.Item1.State;

                switch (enableState)
                {
                    case true:
                        {
                            if (IsEnabled)
                            {
                                if (Clock.Cycle >= EndCycle && State.State != false)
                                {
                                    IsEnabled = false;
                                    State.State = false;
                                    break;
                                }
                            }
                            else
                            {
                                if (IsReset == true)
                                {
                                    // Delay -> in seconds
                                    // Clock.Cycle
                                    // Clock.Resolution -> in milsisecond
                                    long cyclesDelay = (long)((Element as ITimer).Delay * 1000) / Clock.Resolution;
                                    EndCycle = Clock.Cycle + cyclesDelay;

                                    IsReset = false;

                                    if (Clock.Cycle >= EndCycle)
                                    {
                                        IsEnabled = false;
                                        State.State = false;
                                    }
                                    else
                                    {
                                        IsEnabled = true;
                                        State.State = true;
                                    }
                                }

                                break;
                            }
                        }
                        break;
                    case false:
                        {
                            IsReset = true;

                            if (IsEnabled)
                            {
                                if (Clock.Cycle >= EndCycle && State.State != false)
                                {
                                    State.State = false;
                                    IsEnabled = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case null:
                        {
                            IsReset = true;
                            IsEnabled = false;
                            State.State = null;
                        }
                        break;
                }

                if (SimulationSettings.EnableDebug)
                {
                    Console.WriteLine("Id: {0} | State: {1}", Element.Id, State.State);
                    Console.WriteLine("");
                }
            }
        }

        public void Reset()
        {
            HaveCache = false;
            StatesCache = null;
            State = null;
            Clock = null;
        }
    }
}

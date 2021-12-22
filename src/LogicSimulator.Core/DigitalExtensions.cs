using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using LogicSimulator.Core.Core;
using LogicSimulator.Core.Diagrams;

namespace LogicSimulator.Core;

// TODO: Handle all cases of NotifyCollectionChangedAction
// Add		One or more items were added to the collection.
// Remove	One or more items were removed from the collection.
// Replace	One or more items were replaced in the collection.
// Move	One or more items were moved within the collection.
// Reset	The content of the collection changed dramatically.
public static class DigitalExtensions
{
    public static void ObserveElements(this DigitalLogicDiagram diagram, IScheduler scheduler, IDictionary<Guid, IDisposable> disposables)
    {
        var q = diagram.Elements.Where(x => x is DigitalLogic).Cast<DigitalLogic>();
        foreach (var element in q)
            element.ObserveInputs(scheduler, disposables);
    }

    public static void ObserveInputs(this DigitalLogic logic, IScheduler scheduler, IDictionary<Guid, IDisposable> disposables)
    {
        var added = logic.Inputs.ObserveAddedValues().ObserveOn(scheduler).Subscribe(input =>
        {
            var dispose = input.FromPropertyChange("State").ObserveOn(scheduler).Subscribe(_ => logic.Calculate());
            disposables.Add(input.Id, dispose);
            logic.Calculate();
        });

        disposables.Add(Guid.NewGuid(), added);

        var removed = logic.Inputs.ObserveRemovedValues().ObserveOn(scheduler).Subscribe(input =>
        {
            var id = input.Id;
            disposables[id].Dispose();
            disposables.Remove(id);
            logic.Calculate();
        });

        disposables.Add(Guid.NewGuid(), removed);

        if (logic.Inputs.Count > 0)
        {
            foreach (var input in logic.Inputs)
            {
                var dispose = input.FromPropertyChange("State").ObserveOn(scheduler).Subscribe(_ => logic.Calculate());
                disposables.Add(input.Id, dispose);
            }

            logic.Calculate();
        }
    }
}

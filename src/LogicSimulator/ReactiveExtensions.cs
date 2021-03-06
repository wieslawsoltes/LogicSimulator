using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace LogicSimulator.Core;

public static class ReactiveExtensions
{
    private static IObservable<EventPattern<NotifyCollectionChangedEventArgs>> FromCollectionChange(this INotifyCollectionChanged collection)
    {
        return Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
            h => (s, e) => h(s, e),
            h => collection.CollectionChanged += h,
            h => collection.CollectionChanged -= h);
    }

    public static IObservable<object?> FromPropertyChange(this INotifyPropertyChanged propertyChange, string propertyName)
    {
        return Observable.FromEventPattern<PropertyChangedEventArgs>(propertyChange, "PropertyChanged")
            .Where(p => p.EventArgs.PropertyName == propertyName)
            .Select(p => p.Sender);
    }

    public static IObservable<T> ObserveAddedValues<T>(this ObservableCollection<T> collection)
    {
        return collection.FromCollectionChange()
            .Where(e => e.EventArgs.Action == NotifyCollectionChangedAction.Add)
            .SelectMany(e =>
            {
                Debug.Assert(e.EventArgs.NewItems != null, "e.EventArgs.NewItems != null");
                return e.EventArgs.NewItems.Cast<T>();
            });
    }

    public static IObservable<T?> ObserveRemovedValues<T>(this ObservableCollection<T> collection)
    {
        return collection.FromCollectionChange()
            .Where(e => e.EventArgs.Action == NotifyCollectionChangedAction.Remove)
            .SelectMany(e =>
            {
                Debug.Assert(e.EventArgs.OldItems != null, "e.EventArgs.OldItems != null");
                return e.EventArgs.OldItems.Cast<T>();
            });
    }
}

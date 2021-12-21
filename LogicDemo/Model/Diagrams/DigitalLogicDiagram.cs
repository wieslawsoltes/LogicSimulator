using Logic.Model.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Logic.Model.Diagrams
{
    public class DigitalLogicDiagram : DigitalLogic, IDigitalLogicDiagram
    {
        public IDictionary<Guid, IDisposable> Disposables = new Dictionary<Guid, IDisposable>();

        public void Dispose()
        {
            foreach (var dispose in Disposables)
                dispose.Value.Dispose();
        }

        private ObservableCollection<LogicObject> elements = new ObservableCollection<LogicObject>();

        public ObservableCollection<LogicObject> Elements
        {
            get { return elements; }
            set
            {
                if (value != elements)
                {
                    elements = value;
                    Notify("Elements");
                }
            }
        }

        public override void Calculate() { }
    }
}

using Logic.Model.Core;
using System.Collections.ObjectModel;

namespace Logic.Model.Diagrams
{
    public interface IDigitalLogicDiagram
    {
        ObservableCollection<LogicObject> Elements { get; set; }
    }
}

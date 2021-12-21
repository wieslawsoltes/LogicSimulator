using System.Collections.ObjectModel;

namespace Logic.Model.Core
{
    public interface IDigitalLogic
    {
        ObservableCollection<DigitalSignal> Inputs { get; set; }
        ObservableCollection<DigitalSignal> Outputs { get; set; }
        ObservableCollection<DigitalPin> Pins { get; set; }
    }
}

namespace Logic.Model.Core
{
    public interface IDigitalSignal
    {
        bool? State { get; set; }
        DigitalPin InputPin { get; set; }
        DigitalPin OutputPin { get; set; }
    }
}

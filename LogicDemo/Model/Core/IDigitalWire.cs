namespace Logic.Model.Core
{
    public interface IDigitalWire
    {
        DigitalSignal Signal { get; set; }
        DigitalPin StartPin { get; set; }
        DigitalPin EndPin { get; set; }
    }
}

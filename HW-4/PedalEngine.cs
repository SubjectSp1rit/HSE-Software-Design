namespace HW_4;

public class PedalEngine : IEngine
{
    public string PedalSize { get; }

    public PedalEngine(string pedalSize)
    {
        PedalSize = pedalSize;
    }

    public bool IsCompatible(Customer customer)
    {
        return customer.LegStrength > 5;
    }

    public override string ToString()
    {
        return "Педальный двигатель";
    }
}
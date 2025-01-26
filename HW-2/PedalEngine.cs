namespace HW_2;

// Педальный двигатель
public class PedalEngine : IEngine
{
    public double PedalSize { get; }

    public PedalEngine(double pedalSize)
    {
        PedalSize = pedalSize;
    }

    public bool CheckCompatibility(Customer customer)
    {
        return customer.LegStrength > 5;
    }

    public override string ToString()
    {
        return "Педальный двигатель";
    }
}
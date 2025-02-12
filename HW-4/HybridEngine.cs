namespace HW_4;

public class HybridEngine : IEngine
{
    public bool IsCompatible(Customer customer)
    {
        return customer.LegStrength <= 5 && customer.ArmStrength <= 5;
    }

    public override string ToString()
    {
        return "Гибридный двигатель";
    }
}
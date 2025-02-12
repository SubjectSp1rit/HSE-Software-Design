namespace HW_4;

public class HandEngine : IEngine
{
    public bool IsCompatible(Customer customer)
    {
        return customer.ArmStrength > 5;
    }

    public override string ToString()
    {
        return "Двигатель с ручным приводом";
    }
}
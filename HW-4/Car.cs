namespace HW_4;

public class Car
{
    public int SerialNumber { get; }
    public IEngine Engine { get; }

    public Car(int serialNumber, IEngine engine)
    {
        SerialNumber = serialNumber;
        Engine = engine;
    }

    public bool IsCompatible(Customer customer)
    {
        return Engine.IsCompatible(customer);
    }

    public override string ToString()
    {
        return $"Автомобиль #{SerialNumber} с {Engine}";
    }
}
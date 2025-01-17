namespace HW_1;

public class Car
{
    public int SerialNumber { get; }
    public Engine Engine { get; }

    public Car(int serialNumber, string pedalSize)
    {
        SerialNumber = serialNumber;
        Engine = new Engine(pedalSize);
    }

    public override string ToString()
    {
        return $"Машина {SerialNumber} с {Engine}";
    }
}
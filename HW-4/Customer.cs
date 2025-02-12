namespace HW_4;

public class Customer
{
    public string Name { get; }
    public int LegStrength { get; }
    public int ArmStrength { get; }
    public Car PurchasedCar { get; set; }

    public Customer(string name, int legStrength, int armStrength)
    {
        Name = name;
        LegStrength = legStrength;
        ArmStrength = armStrength;
    }

    public override string ToString()
    {
        string carInfo = PurchasedCar == null 
            ? "без автомобиля" 
            : $"с автомобилем #{PurchasedCar.SerialNumber} ({PurchasedCar.Engine})";
        return $"Покупатель: {Name}, сила ног: {LegStrength}, сила рук: {ArmStrength}, {carInfo}";
    }
}
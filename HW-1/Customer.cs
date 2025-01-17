namespace HW_1;

public class Customer
{
    public string Name { get; }
    public Car PurchasedCar { get; set; }

    public Customer(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return PurchasedCar == null
            ? $"Покупатель по имени {Name} еще не покупал машину."
            : $"Покупатель по имени {Name} владеет машиной {PurchasedCar}.";
    }
}
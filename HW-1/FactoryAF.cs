namespace HW_1;

public class FactoryAF
{
    private List<Car> Cars { get; } = new List<Car>();
    private List<Customer> Customers { get; } = new List<Customer>();

    public void AddCar(int serialNumber, string pedalSize)
    {
        Cars.Add(new Car(serialNumber, pedalSize));
    }

    public void AddCustomer(string name)
    {
        Customers.Add(new Customer(name));
    }

    public void SaleCar()
    {
        foreach (var customer in Customers)
        {
            if (Cars.Count > 0)
            {
                customer.PurchasedCar = Cars[0];
                Cars.RemoveAt(0);
            }
        }

        if (Cars.Count > 0)
        {
            Console.WriteLine("Оставшиеся машины будут уничтожены");
            Cars.Clear();
        }
    }

    public void PrintStatus()
    {
        Console.WriteLine("Машины в наличии:");
        foreach (var car in Cars)
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\nПокупатели:");
        foreach (var customer in Customers)
        {
            Console.WriteLine(customer);
        }
    }
}
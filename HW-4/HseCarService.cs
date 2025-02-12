namespace HW_4;

public class HseCarService
{
    private readonly ICarProvider carProvider;
    private readonly ICustomersProvider customersProvider;

    public HseCarService(ICarProvider carProvider, ICustomersProvider customersProvider)
    {
        this.carProvider = carProvider;
        this.customersProvider = customersProvider;
    }
    
    public void SellCars()
    {
        foreach (var customer in customersProvider.GetCustomers())
        {
            if (customer.PurchasedCar == null)
            {
                Car car = carProvider.GetSuitableCar(customer);
                if (car != null)
                {
                    customer.PurchasedCar = car;
                }
            }
        }
    }
}
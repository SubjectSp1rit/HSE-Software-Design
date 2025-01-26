namespace HW_2;

// Интерфейс провайдера автомобилей
public interface ICarProvider
{
    Car FindSuitableCar(Customer customer);
}

// Интерфейс провайдера покупателей
public interface ICustomersProvider
{
    IEnumerable<Customer> GetCustomers();
}

// Интерфейс фабрики автомобилей
public interface ICarFactory<TParams>
{
    Car CreateCar(TParams parameters, int serialNumber);
}

// Интерфейс двигателя
public interface IEngine
{
    bool CheckCompatibility(Customer customer);
    string ToString();
}
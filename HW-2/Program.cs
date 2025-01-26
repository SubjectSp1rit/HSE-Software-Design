namespace HW_2;

public class Program
{
    static void Main()
    {
        // Создание сервисов и фабрик
        var carService = new CarService();
        var customerStorage = new CustomerStorage();
        var hseService = new HseCarService(carService, customerStorage);
        var pedalFactory = new PedalCarFactory();
        var handFactory = new HandCarFactory();

        // Добавление покупателей
        customerStorage.AddCustomer(new Customer("Покупатель 1", 6, 4));
        customerStorage.AddCustomer(new Customer("Покупатель 2", 4, 6));
        customerStorage.AddCustomer(new Customer("Покупатель 3", 6, 6));
        customerStorage.AddCustomer(new Customer("Покупатель 4", 4, 4));

        // Добавление автомобилей
        carService.AddCars(pedalFactory, new PedalEngineParams { PedalSize = 15.5 }, 2);
        carService.AddCars(handFactory, EmptyEngineParams.Default, 2);

        // Вывод информации до продажи
        Console.WriteLine("=== До продажи ===");
        PrintCustomers(customerStorage.GetCustomers());
        
        // Продажа
        hseService.SellCars();

        // Вывод информации после продажи
        Console.WriteLine("\n=== После продажи ===");
        PrintCustomers(customerStorage.GetCustomers());
    }

    static void PrintCustomers(IEnumerable<Customer> customers)
    {
        foreach (var customer in customers)
        {
            var carInfo = customer.PurchasedCar != null 
                ? $"{customer.PurchasedCar.Engine} №{customer.PurchasedCar.SerialNumber}" 
                : "Без автомобиля";
            
            Console.WriteLine($"{customer.Name}: {carInfo}");
        }
    }
}
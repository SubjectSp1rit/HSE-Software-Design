namespace HW_4;

public class Program
{
    static void Main()
    {
        CarService carService = new CarService();
        CustomerStorage customerStorage = new CustomerStorage();

        HseCarService hseCarService = new HseCarService(carService, customerStorage);

        PedalCarFactory pedalFactory = new PedalCarFactory();
        HandCarFactory handFactory = new HandCarFactory();
        HybridCarFactory hybridFactory = new HybridCarFactory();

        customerStorage.AddCustomer(new Customer("Покупатель 1", legStrength: 6, armStrength: 4));
        customerStorage.AddCustomer(new Customer("Покупатель 2", legStrength: 4, armStrength: 6));
        customerStorage.AddCustomer(new Customer("Покупатель 3", legStrength: 6, armStrength: 6));
        customerStorage.AddCustomer(new Customer("Покупатель 4", legStrength: 4, armStrength: 4));

        carService.AddCar(pedalFactory, new PedalEngineParams("Medium"));
        carService.AddCar(handFactory, EmptyEngineParams.DEFAULT);
        carService.AddCar(hybridFactory, EmptyEngineParams.DEFAULT);
        carService.AddCar(pedalFactory, new PedalEngineParams("Large"));

        Console.WriteLine("Состояние до продажи автомобилей:");
        customerStorage.PrintCustomers();
        Console.WriteLine();
        carService.PrintCars();
        Console.WriteLine(new string('-', 40));

        hseCarService.SellCars();

        Console.WriteLine("\nСостояние после продажи автомобилей:");
        customerStorage.PrintCustomers();

        Console.ReadLine();
    }
}
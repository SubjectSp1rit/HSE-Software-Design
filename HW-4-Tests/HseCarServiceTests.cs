using Xunit;
using HW_4;

public class HseCarServiceTests
{
    /// <summary>
    /// - Покупатель 1 (сила ног 6, сила рук 4) должен получить автомобиль с педальным двигателем
    /// - Покупатель 2 (сила ног 4, сила рук 6) должен получить автомобиль с двигателем с ручным приводом
    /// - Покупатель 3 (сила ног 6, сила рук 6) получает первый подходящий автомобиль (в данном случае педальный)
    /// - Покупатель 4 (сила ног 4, сила рук 4) должен получить гибридный автомобиль
    /// Также проверяется, что каждому назначенному автомобилю присвоен уникальный номер.
    /// </summary>
    [Fact]
    public void SellCars_AssignsCorrectCarsToCustomers()
    {
        // Arrange
        var carService = new CarService();
        var customerStorage = new CustomerStorage();
        var hseCarService = new HseCarService(carService, customerStorage);
        
        var pedalFactory = new PedalCarFactory();
        var handFactory = new HandCarFactory();
        var hybridFactory = new HybridCarFactory();
        
        customerStorage.AddCustomer(new Customer("Покупатель 1", legStrength: 6, armStrength: 4));
        customerStorage.AddCustomer(new Customer("Покупатель 2", legStrength: 4, armStrength: 6));
        customerStorage.AddCustomer(new Customer("Покупатель 3", legStrength: 6, armStrength: 6));
        customerStorage.AddCustomer(new Customer("Покупатель 4", legStrength: 4, armStrength: 4));
        
        carService.AddCar(pedalFactory, new PedalEngineParams("Medium"));
        carService.AddCar(handFactory, EmptyEngineParams.DEFAULT);
        carService.AddCar(hybridFactory, EmptyEngineParams.DEFAULT);
        carService.AddCar(pedalFactory, new PedalEngineParams("Large"));

        // Act
        hseCarService.SellCars();
        var customers = customerStorage.GetCustomers().ToList();

        // Assert

        // Покупатель 1 должен получить автомобиль с педальным двигателем
        Assert.NotNull(customers[0].PurchasedCar);
        Assert.IsType<PedalEngine>(customers[0].PurchasedCar.Engine);

        // Покупатель 2 должен получить автомобиль с двигателем с ручным приводом
        Assert.NotNull(customers[1].PurchasedCar);
        Assert.IsType<HandEngine>(customers[1].PurchasedCar.Engine);

        // Покупатель 3 должен получить автомобиль с педальным двигателем (так как первый подходящий автомобиль – педальный)
        Assert.NotNull(customers[2].PurchasedCar);
        Assert.IsType<PedalEngine>(customers[2].PurchasedCar.Engine);

        // Покупатель 4 должен получить гибридный автомобиль
        Assert.NotNull(customers[3].PurchasedCar);
        Assert.IsType<HybridEngine>(customers[3].PurchasedCar.Engine);

        // Проверяем, что все выданные автомобили имеют уникальные порядковые номера
        var serialNumbers = customers.Select(c => c.PurchasedCar.SerialNumber).ToList();
        Assert.Equal(serialNumbers.Distinct().Count(), serialNumbers.Count);
    }

    /// <summary>
    /// Тестирует ситуацию, когда для покупателя отсутствует подходящий автомобиль
    /// В данном случае покупателю не должно быть назначено никакого автомобиля
    /// </summary>
    [Fact]
    public void SellCars_DoesNotAssignWhenNoSuitableCarAvailable()
    {
        // Arrange
        var carService = new CarService();
        var customerStorage = new CustomerStorage();
        var hseCarService = new HseCarService(carService, customerStorage);

        customerStorage.AddCustomer(new Customer("Покупатель 1", legStrength: 6, armStrength: 4));

        // Act
        hseCarService.SellCars();

        // Assert
        var customer = customerStorage.GetCustomers().First();
        Assert.Null(customer.PurchasedCar);
    }

    /// <summary>
    /// Тестирует, что повторный вызов SellCars не переназначает автомобиль покупателю,
    /// у которого уже был назначен автомобиль
    /// </summary>
    [Fact]
    public void SellCars_DoesNotReassignCarToCustomerWhoAlreadyHasOne()
    {
        // Arrange
        var carService = new CarService();
        var customerStorage = new CustomerStorage();
        var hseCarService = new HseCarService(carService, customerStorage);

        var pedalFactory = new PedalCarFactory();
        
        var customer = new Customer("Покупатель 1", legStrength: 6, armStrength: 4);
        customerStorage.AddCustomer(customer);

        carService.AddCar(pedalFactory, new PedalEngineParams("Medium"));

        // Act
        hseCarService.SellCars();
        var firstAssignedCar = customer.PurchasedCar;

        hseCarService.SellCars();

        // Assert
        Assert.NotNull(firstAssignedCar);
        Assert.Equal(firstAssignedCar, customer.PurchasedCar);
    }
}

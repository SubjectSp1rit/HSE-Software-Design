namespace HW_4;

public class CarService : ICarProvider
{
    private readonly List<Car> cars = new List<Car>();
    private int nextSerialNumber = 1;
    
    public void AddCar<TParams>(ICarFactory<TParams> factory, TParams engineParams)
    {
        Car newCar = factory.CreateCar(engineParams, nextSerialNumber);
        nextSerialNumber++;
        cars.Add(newCar);
    }
    
    public Car GetSuitableCar(Customer customer)
    {
        for (int i = 0; i < cars.Count; i++)
        {
            if (cars[i].IsCompatible(customer))
            {
                Car car = cars[i];
                cars.RemoveAt(i);
                return car;
            }
        }
        return null;
    }

    public void PrintCars()
    {
        if (cars.Count == 0)
        {
            Console.WriteLine("На складе нет автомобилей.");
        }
        else
        {
            Console.WriteLine("Автомобили на складе:");
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
namespace HW_2;

// Фабрика педальных автомобилей
public class PedalCarFactory : ICarFactory<PedalEngineParams>
{
    public Car CreateCar(PedalEngineParams parameters, int serialNumber)
    {
        return new Car(new PedalEngine(parameters.PedalSize), serialNumber);
    }
}

// Параметры для педального двигателя
public class PedalEngineParams
{
    public double PedalSize { get; set; }
}
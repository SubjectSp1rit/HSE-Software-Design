namespace HW_2;

// Фабрика автомобилей с ручным приводом
public class HandCarFactory : ICarFactory<EmptyEngineParams>
{
    public Car CreateCar(EmptyEngineParams parameters, int serialNumber)
    {
        return new Car(new HandEngine(), serialNumber);
    }
}

// Пустые параметры для ручного двигателя
public struct EmptyEngineParams
{
    public static readonly EmptyEngineParams Default = new();
}
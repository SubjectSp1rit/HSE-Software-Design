namespace HW_4;

public class HandCarFactory : ICarFactory<EmptyEngineParams>
{
    public Car CreateCar(EmptyEngineParams engineParams, int serialNumber)
    {
        IEngine engine = new HandEngine();
        return new Car(serialNumber, engine);
    }
}
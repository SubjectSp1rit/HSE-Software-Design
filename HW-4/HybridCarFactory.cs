namespace HW_4;

public class HybridCarFactory : ICarFactory<EmptyEngineParams>
{
    public Car CreateCar(EmptyEngineParams engineParams, int serialNumber)
    {
        IEngine engine = new HybridEngine();
        return new Car(serialNumber, engine);
    }
}
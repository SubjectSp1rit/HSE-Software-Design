namespace HW_4;

public class PedalCarFactory : ICarFactory<PedalEngineParams>
{
    public Car CreateCar(PedalEngineParams engineParams, int serialNumber)
    {
        IEngine engine = new PedalEngine(engineParams.PedalSize);
        return new Car(serialNumber, engine);
    }
}
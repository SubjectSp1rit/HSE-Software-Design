namespace HW_4;

public interface ICarFactory<TParams>
{
    Car CreateCar(TParams engineParams, int serialNumber);
}
namespace HW_1;

public class Program
{
    public static void Main()
    {
        var factory = new FactoryAF();

        // Добавление автомобилей
        factory.AddCar(1, "Большая");
        factory.AddCar(2, "Средняя");
        factory.AddCar(3, "Маленькая");

        // Добавление клиентов
        factory.AddCustomer("Максим");
        factory.AddCustomer("Денис");
        factory.AddCustomer("Олег");
        factory.AddCustomer("Наташа");

        Console.WriteLine("До SaleCar():");
        factory.PrintStatus();

        factory.SaleCar();

        Console.WriteLine("\nПосле SaleCar():");
        factory.PrintStatus();
    }
}
namespace Mini_Dz_1;

public class VeterinaryClinic : IVeterinaryClinic
{
    public bool CheckHealth(Animal animal)
    {
        Console.WriteLine($"Проводится медосмотр животного {animal.Name}.");
        Console.WriteLine("Введите 'y', если животное здорово, или 'n', если не здорово:");
        var input = Console.ReadLine();
        return input?.ToLower() == "y";
    }
}
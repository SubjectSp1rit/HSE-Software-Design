namespace Mini_Dz_1;

// Базовый класс для вещей, участвующих в инвентаризации
public class Thing : IInventory
{
    public string Name { get; set; }
    public int Number { get; set; }

    public Thing(string name, int number = 0)
    {
        Name = name;
        Number = number;
    }
}
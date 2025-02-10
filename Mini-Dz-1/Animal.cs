namespace Mini_Dz_1;

// Базовый класс для всех животных
public abstract class Animal : IAlive, IInventory
{
    public string Name { get; set; }
    public int Food { get; set; }
    public int Number { get; set; }

    protected Animal(string name, int food)
    {
        Name = name;
        Food = food;
    }
}
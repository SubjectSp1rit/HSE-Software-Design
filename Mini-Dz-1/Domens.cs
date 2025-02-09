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

public class Table : Thing
{
    public Table(string name, int number = 0) : base(name, number) { }

    public override string ToString()
    {
        return $"Стол: {Name}";
    }
}

public class Computer : Thing
{
    public Computer(string name, int number = 0) : base(name, number) { }

    public override string ToString()
    {
        return $"Компьютер: {Name}";
    }
}
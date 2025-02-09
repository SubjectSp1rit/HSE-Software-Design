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

// Абстрактный класс для травоядных
public abstract class Herbo : Animal
{
    /// <summary>
    /// Уровень добротности (от 0 до 10). Если добротность > 5 – посетители смогут интерактивно взаимодействовать с животным.
    /// </summary>
    public int Kindness { get; set; }

    protected Herbo(string name, int food, int kindness) : base(name, food)
    {
        Kindness = kindness;
    }
}

// Абстрактный класс для хищников
public abstract class Predator : Animal
{
    protected Predator(string name, int food) : base(name, food) { }
}

public class Monkey : Herbo
{
    public Monkey(string name, int food, int kindness) : base(name, food, kindness) { }

    public override string ToString()
    {
        return $"Обезьяна: {Name}, Еда: {Food} кг, Добротность: {Kindness}";
    }
}

public class Rabbit : Herbo
{
    public Rabbit(string name, int food, int kindness) : base(name, food, kindness) { }

    public override string ToString()
    {
        return $"Кролик: {Name}, Еда: {Food} кг, Добротность: {Kindness}";
    }
}

public class Tiger : Predator
{
    public Tiger(string name, int food) : base(name, food) { }

    public override string ToString()
    {
        return $"Тигр: {Name}, Еда: {Food} кг";
    }
}

public class Wolf : Predator
{
    public Wolf(string name, int food) : base(name, food) { }

    public override string ToString()
    {
        return $"Волк: {Name}, Еда: {Food} кг";
    }
}
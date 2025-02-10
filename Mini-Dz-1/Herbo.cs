namespace Mini_Dz_1;

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
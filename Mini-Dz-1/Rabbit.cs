namespace Mini_Dz_1;

public class Rabbit : Herbo
{
    public Rabbit(string name, int food, int kindness) : base(name, food, kindness) { }

    public override string ToString()
    {
        return $"Кролик: {Name}, Еда: {Food} кг, Добротность: {Kindness}";
    }
}
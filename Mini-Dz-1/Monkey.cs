namespace Mini_Dz_1;

public class Monkey : Herbo
{
    public Monkey(string name, int food, int kindness) : base(name, food, kindness) { }

    public override string ToString()
    {
        return $"Обезьяна: {Name}, Еда: {Food} кг, Добротность: {Kindness}";
    }
}
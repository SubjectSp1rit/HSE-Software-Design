namespace Mini_Dz_1;

public class Tiger : Predator
{
    public Tiger(string name, int food) : base(name, food) { }

    public override string ToString()
    {
        return $"Тигр: {Name}, Еда: {Food} кг";
    }
}
namespace Mini_Dz_1;

public class Wolf : Predator
{
    public Wolf(string name, int food) : base(name, food) { }

    public override string ToString()
    {
        return $"Волк: {Name}, Еда: {Food} кг";
    }
}
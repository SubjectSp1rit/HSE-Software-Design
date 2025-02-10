namespace Mini_Dz_1;

public class Table : Thing
{
    public Table(string name, int number = 0) : base(name, number) { }

    public override string ToString()
    {
        return $"Стол: {Name}";
    }
}
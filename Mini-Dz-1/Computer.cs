namespace Mini_Dz_1;

public class Computer : Thing
{
    public Computer(string name, int number = 0) : base(name, number) { }

    public override string ToString()
    {
        return $"Компьютер: {Name}";
    }
}
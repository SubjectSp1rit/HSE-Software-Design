namespace Mini_Dz_1;

// Абстрактный класс для хищников
public abstract class Predator : Animal
{
    protected Predator(string name, int food) : base(name, food) { }
}
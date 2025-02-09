namespace Mini_Dz_1;

public interface IAlive
{
    int Food { get; set; }
}

public interface IInventory
{
    int Number { get; set; }
    string Name { get; set; }
}

// Интерфейс для ветеринарной клиники
public interface IVeterinaryClinic
{
    /// <summary>
    /// Проверяет состояние здоровья животного.
    /// </summary>
    /// <param name="animal">Проверяемое животное</param>
    /// <returns>True, если животное здорово, иначе false</returns>
    bool CheckHealth(Animal animal);
}

// Интерфейс зоопарка для управления животными и вещами
public interface IZoo
{
    bool AddAnimal(Animal animal);
    void AddInventoryItem(IInventory item);
    int GetTotalFoodConsumption();
    IEnumerable<Animal> GetContactAnimals();
    IEnumerable<IInventory> GetInventoryItems();
}
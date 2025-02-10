namespace Mini_Dz_1;

// Интерфейс зоопарка для управления животными и вещами
public interface IZoo
{
    bool AddAnimal(Animal animal);
    void AddInventoryItem(IInventory item);
    int GetTotalFoodConsumption();
    IEnumerable<Animal> GetContactAnimals();
    IEnumerable<IInventory> GetInventoryItems();
}
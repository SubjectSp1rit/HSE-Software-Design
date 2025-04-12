namespace Mini_Dz_2.Domain.Entities;

public class Enclosure
{
    public Guid Id { get; private set; }
    public EnclosureType Type { get; private set; }
    public double Size { get; private set; }
    public int Capacity { get; private set; }

    private readonly List<Guid> _animalIds;

    public int CurrentAnimalCount => _animalIds.Count;

    public Enclosure(EnclosureType type, double size, int capacity)
    {
        Id = Guid.NewGuid();
        Type = type;
        Size = size;
        Capacity = capacity;
        _animalIds = new List<Guid>();
    }

    public bool AddAnimal(Guid animalId)
    {
        if (_animalIds.Count < Capacity)
        {
            _animalIds.Add(animalId);
            return true;
        }
        return false;
    }

    public bool RemoveAnimal(Guid animalId)
    {
        return _animalIds.Remove(animalId);
    }

    public void Clean()
    {
        // типо чистим вольер
    }
}
using Mini_Dz_2.Domain.Events;

namespace Mini_Dz_2.Domain.Entities;

public class Animal
{
    public Guid Id { get; private set; }
    public string Species { get; private set; }
    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Gender Gender { get; private set; }
    public string FavoriteFood { get; private set; }
    public AnimalStatus Status { get; private set; }
    public Guid EnclosureId { get; private set; }

    public Animal(string species, string name, DateTime birthDate, Gender gender, string favoriteFood, AnimalStatus status)
    {
        Id = Guid.NewGuid();
        Species = species;
        Name = name;
        BirthDate = birthDate;
        Gender = gender;
        FavoriteFood = favoriteFood;
        Status = status;
    }

    public void Feed()
    {
        // типо кормим животное
    }

    public void Heal()
    {
        Status = AnimalStatus.Healthy;
    }

    /// <summary>
    /// Перемещает животное в другой вольер и возвращает события перемещения животного
    /// </summary>
    public AnimalMovedEvent TransferTo(Guid newEnclosureId)
    {
        var oldEnclosureId = EnclosureId;
        EnclosureId = newEnclosureId;
        var evt = new AnimalMovedEvent(this.Id, oldEnclosureId, newEnclosureId, DateTime.UtcNow);
        return evt;
    }
}
namespace Mini_Dz_2.Domain.Events;

public class AnimalMovedEvent
{
    public Guid AnimalId { get; }
    public Guid OldEnclosureId { get; }
    public Guid NewEnclosureId { get; }
    public DateTime MovedAt { get; }

    public AnimalMovedEvent(Guid animalId, Guid oldEnclosureId, Guid newEnclosureId, DateTime movedAt)
    {
        AnimalId = animalId;
        OldEnclosureId = oldEnclosureId;
        NewEnclosureId = newEnclosureId;
        MovedAt = movedAt;
    }
}
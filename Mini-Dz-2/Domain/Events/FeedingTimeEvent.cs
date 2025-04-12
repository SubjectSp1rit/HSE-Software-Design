namespace Mini_Dz_2.Domain.Events;

public class FeedingTimeEvent
{
    public Guid FeedingScheduleId { get; }
    public Guid AnimalId { get; }
    public DateTime ScheduledTime { get; }

    public FeedingTimeEvent(Guid feedingScheduleId, Guid animalId, DateTime scheduledTime)
    {
        FeedingScheduleId = feedingScheduleId;
        AnimalId = animalId;
        ScheduledTime = scheduledTime;
    }
}
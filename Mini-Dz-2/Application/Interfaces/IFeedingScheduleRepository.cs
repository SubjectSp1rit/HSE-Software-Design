using Mini_Dz_2.Domain.Entities;

namespace Mini_Dz_2.Application.Interfaces;

public interface IFeedingScheduleRepository
{
    void Add(FeedingSchedule feedingSchedule);
    void Remove(Guid scheduleId);
    FeedingSchedule GetById(Guid scheduleId);
    IEnumerable<FeedingSchedule> GetAll();
    void Update(FeedingSchedule feedingSchedule);
}
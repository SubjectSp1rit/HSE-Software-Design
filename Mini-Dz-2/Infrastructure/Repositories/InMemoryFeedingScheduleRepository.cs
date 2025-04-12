using System.Collections.Concurrent;
using Mini_Dz_2.Domain.Entities;
using Mini_Dz_2.Application.Interfaces;

namespace Mini_Dz_2.Infrastructure.Repositories;

public class InMemoryFeedingScheduleRepository : IFeedingScheduleRepository
{
    private readonly ConcurrentDictionary<Guid, FeedingSchedule> _schedules = new ConcurrentDictionary<Guid, FeedingSchedule>();

    public void Add(FeedingSchedule feedingSchedule)
    {
        _schedules[feedingSchedule.Id] = feedingSchedule;
    }

    public IEnumerable<FeedingSchedule> GetAll()
    {
        return _schedules.Values;
    }

    public FeedingSchedule GetById(Guid scheduleId)
    {
        _schedules.TryGetValue(scheduleId, out var schedule);
        return schedule;
    }

    public void Remove(Guid scheduleId)
    {
        _schedules.TryRemove(scheduleId, out _);
    }

    public void Update(FeedingSchedule feedingSchedule)
    {
        _schedules[feedingSchedule.Id] = feedingSchedule;
    }
}
using Mini_Dz_2.Application.Interfaces;
using Mini_Dz_2.Domain.Entities;
using Mini_Dz_2.Domain.Events;

namespace Mini_Dz_2.Application.Services;

public class FeedingOrganizationService
{
    private readonly IFeedingScheduleRepository _feedingScheduleRepository;
    private readonly IAnimalRepository _animalRepository;

    public FeedingOrganizationService(IFeedingScheduleRepository feedingScheduleRepository, IAnimalRepository animalRepository)
    {
        _feedingScheduleRepository = feedingScheduleRepository;
        _animalRepository = animalRepository;
    }

    public FeedingSchedule AddFeedingSchedule(Guid animalId, DateTime feedingTime, string foodType)
    {
        var animal = _animalRepository.GetById(animalId) ?? throw new Exception("Животное не найдено при попытке покормить его");
        var feedingSchedule = new FeedingSchedule(animalId, feedingTime, foodType);
        _feedingScheduleRepository.Add(feedingSchedule);
        return feedingSchedule;
    }

    public void ChangeFeedingSchedule(Guid scheduleId, DateTime newFeedingTime, string newFoodType)
    {
        var schedule = _feedingScheduleRepository.GetById(scheduleId) ?? throw new Exception("Расписание кормежки не найдено");
        schedule.ChangeSchedule(newFeedingTime, newFoodType);
        _feedingScheduleRepository.Update(schedule);
    }

    public FeedingTimeEvent MarkFeedingCompleted(Guid scheduleId)
    {
        var schedule = _feedingScheduleRepository.GetById(scheduleId) ?? throw new Exception("Расписание кормежки не найдено");
        schedule.MarkAsCompleted();
        _feedingScheduleRepository.Update(schedule);
        var evt = new FeedingTimeEvent(schedule.Id, schedule.AnimalId, schedule.FeedingTime);
        return evt;
    }

    public IEnumerable<FeedingSchedule> GetAllSchedules()
    {
        return _feedingScheduleRepository.GetAll();
    }
}
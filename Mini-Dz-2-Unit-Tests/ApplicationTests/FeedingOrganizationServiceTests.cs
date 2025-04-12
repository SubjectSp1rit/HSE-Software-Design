using Mini_Dz_2.Application.Services;
using Mini_Dz_2.Application.Interfaces;
using Mini_Dz_2.Domain.Entities;
using Mini_Dz_2.Domain;
using Mini_Dz_2.Infrastructure.Repositories;

namespace Mini_Dz_2_Unit_Tests.ApplicationTests;

public class FeedingOrganizationServiceTests
{
    private readonly IFeedingScheduleRepository _scheduleRepository;
    private readonly IAnimalRepository _animalRepository;
    private readonly FeedingOrganizationService _service;

    public FeedingOrganizationServiceTests()
    {
        _scheduleRepository = new InMemoryFeedingScheduleRepository();
        _animalRepository = new InMemoryAnimalRepository();
        _service = new FeedingOrganizationService(_scheduleRepository, _animalRepository);
    }

    [Fact]
    public void AddFeedingSchedule_ShouldCreateAndStoreSchedule()
    {
        // Arrange
        var animal = new Animal("Bear", "Baloo", DateTime.Now, Gender.Male, "Honey", AnimalStatus.Healthy);
        _animalRepository.Add(animal);
        var feedingTime = DateTime.Now.AddHours(1);
        var foodType = "Fish";

        // Act
        var schedule = _service.AddFeedingSchedule(animal.Id, feedingTime, foodType);

        // Assert
        Assert.NotNull(schedule);
        Assert.Equal(animal.Id, schedule.AnimalId);
        Assert.Equal(feedingTime, schedule.FeedingTime);
        Assert.Equal(foodType, schedule.FoodType);
    }

    [Fact]
    public void ChangeFeedingSchedule_ShouldUpdateScheduleProperties()
    {
        // Arrange
        var animal = new Animal("Penguin", "Pingu", DateTime.Now, Gender.Male, "Fish", AnimalStatus.Healthy);
        _animalRepository.Add(animal);
        var feedingTime = DateTime.Now.AddHours(1);
        var schedule = _service.AddFeedingSchedule(animal.Id, feedingTime, "Small Fish");

        var newTime = feedingTime.AddHours(1);
        var newFood = "Big Fish";

        // Act
        _service.ChangeFeedingSchedule(schedule.Id, newTime, newFood);

        var updatedSchedule = _scheduleRepository.GetById(schedule.Id);
        // Assert
        Assert.Equal(newTime, updatedSchedule.FeedingTime);
        Assert.Equal(newFood, updatedSchedule.FoodType);
    }

    [Fact]
    public void MarkFeedingCompleted_ShouldSetCompletedAndReturnEvent()
    {
        // Arrange
        var animal = new Animal("Giraffe", "Melman", DateTime.Now, Gender.Male, "Leaves", AnimalStatus.Healthy);
        _animalRepository.Add(animal);
        var feedingTime = DateTime.Now.AddHours(2);
        var schedule = _service.AddFeedingSchedule(animal.Id, feedingTime, "Leaves");

        // Act
        var evt = _service.MarkFeedingCompleted(schedule.Id);
        var updatedSchedule = _scheduleRepository.GetById(schedule.Id);

        // Assert
        Assert.True(updatedSchedule.IsCompleted);
        Assert.Equal(schedule.Id, evt.FeedingScheduleId);
        Assert.Equal(schedule.AnimalId, evt.AnimalId);
        Assert.Equal(schedule.FeedingTime, evt.ScheduledTime);
    }
}
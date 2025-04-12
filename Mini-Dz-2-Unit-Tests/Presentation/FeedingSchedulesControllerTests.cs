using Microsoft.AspNetCore.Mvc;
using Mini_Dz_2.Application.Services;
using Mini_Dz_2.Domain.Entities;
using Mini_Dz_2.Domain;
using Mini_Dz_2.Infrastructure.Repositories;
using Mini_Dz_2.Presentation.Controllers;

namespace Mini_Dz_2_Unit_Tests.Presentation;

public class FeedingSchedulesControllerTests
{
    private readonly InMemoryFeedingScheduleRepository _scheduleRepository;
    private readonly InMemoryAnimalRepository _animalRepository;
    private readonly FeedingOrganizationService _feedingService;
    private readonly FeedingSchedulesController _controller;

    public FeedingSchedulesControllerTests()
    {
        _scheduleRepository = new InMemoryFeedingScheduleRepository();
        _animalRepository = new InMemoryAnimalRepository();
        _feedingService = new FeedingOrganizationService(_scheduleRepository, _animalRepository);
        _controller = new FeedingSchedulesController(_scheduleRepository, _feedingService);
    }

    [Fact]
    public void GetAll_ReturnsOkResult_WithListOfSchedules()
    {
        // Arrange
        var animal = new Animal("Penguin", "Pingu", DateTime.Now, Gender.Male, "Fish", AnimalStatus.Healthy);
        _animalRepository.Add(animal);
        var schedule = _feedingService.AddFeedingSchedule(animal.Id, DateTime.Now.AddHours(1), "Fish");
        // Act
        var result = _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var schedules = Assert.IsAssignableFrom<IEnumerable<FeedingSchedule>>(okResult.Value);
        Assert.Contains(schedules, s => s.Id == schedule.Id);
    }

    [Fact]
    public void GetById_ReturnsNotFound_WhenScheduleDoesNotExist()
    {
        // Act
        var result = _controller.GetById(Guid.NewGuid());

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}
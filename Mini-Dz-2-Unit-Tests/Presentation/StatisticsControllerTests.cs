using Microsoft.AspNetCore.Mvc;
using Mini_Dz_2.Application.Services;
using Mini_Dz_2.Infrastructure.Repositories;
using Mini_Dz_2.Presentation.Controllers;
using Mini_Dz_2.Domain.Entities;
using Mini_Dz_2.Domain;

namespace Mini_Dz_2_Unit_Tests.Presentation;

public class StatisticsControllerTests
{
    private readonly ZooStatisticsService _statisticsService;
    private readonly InMemoryAnimalRepository _animalRepository;
    private readonly InMemoryEnclosureRepository _enclosureRepository;
    private readonly StatisticsController _controller;

    public StatisticsControllerTests()
    {
        _animalRepository = new InMemoryAnimalRepository();
        _enclosureRepository = new InMemoryEnclosureRepository();
        _statisticsService = new ZooStatisticsService(_animalRepository, _enclosureRepository);
        _controller = new StatisticsController(_statisticsService);
    }

    [Fact]
    public void GetStatistics_ReturnsOkResult_WithStatisticsData()
    {
        // Arrange
        var enclosure = new Enclosure(EnclosureType.Herbivore, 100, 2);
        _enclosureRepository.Add(enclosure);
        var animal = new Animal("Giraffe", "Gigi", DateTime.Now, Gender.Female, "Leaves", AnimalStatus.Healthy);
        typeof(Animal).GetProperty("EnclosureId").SetValue(animal, enclosure.Id);
        enclosure.AddAnimal(animal.Id);
        _animalRepository.Add(animal);

        // Act
        var result = _controller.GetStatistics();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        dynamic stats = okResult.Value;
        Assert.Equal(1, (int)stats.TotalAnimals);
        Assert.Equal(1, (int)stats.TotalEnclosures);
        Assert.Equal(0, (int)stats.FreeEnclosures);
    }
}
using Mini_Dz_2.Application.Services;
using Mini_Dz_2.Application.Interfaces;
using Mini_Dz_2.Domain.Entities;
using Mini_Dz_2.Domain;
using Mini_Dz_2.Infrastructure.Repositories;

namespace Mini_Dz_2_Unit_Tests.ApplicationTests;

public class ZooStatisticsServiceTests
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IEnclosureRepository _enclosureRepository;
    private readonly ZooStatisticsService _service;

    public ZooStatisticsServiceTests()
    {
        _animalRepository = new InMemoryAnimalRepository();
        _enclosureRepository = new InMemoryEnclosureRepository();
        _service = new ZooStatisticsService(_animalRepository, _enclosureRepository);
    }

    [Fact]
    public void GetZooStatistics_ShouldReturnCorrectCounts()
    {
        // Arrange
        var enclosure1 = new Enclosure(EnclosureType.Herbivore, 100, 2);
        var enclosure2 = new Enclosure(EnclosureType.Predator, 80, 1);
        _enclosureRepository.Add(enclosure1);
        _enclosureRepository.Add(enclosure2);

        var animal1 = new Animal("Слон", "Бимбо", DateTime.Now, Gender.Female, "Трава", AnimalStatus.Healthy);
        var animal2 = new Animal("Жираф", "Мелман", DateTime.Now, Gender.Female, "Листья", AnimalStatus.Healthy);
        typeof(Animal).GetProperty("EnclosureId").SetValue(animal1, enclosure1.Id);
        typeof(Animal).GetProperty("EnclosureId").SetValue(animal2, enclosure1.Id);
        enclosure1.AddAnimal(animal1.Id);
        enclosure1.AddAnimal(animal2.Id);
        _animalRepository.Add(animal1);
        _animalRepository.Add(animal2);

        // Act
        var stats = _service.GetZooStatistics();

        // Assert
        Assert.Equal(2, stats.TotalAnimals);
        Assert.Equal(2, stats.TotalEnclosures);
        Assert.Equal(1, stats.FreeEnclosures);
    }
}
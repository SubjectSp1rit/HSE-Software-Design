using Mini_Dz_2.Application.Services;
using Mini_Dz_2.Application.Interfaces;
using Mini_Dz_2.Domain.Entities;
using Mini_Dz_2.Domain;
using Mini_Dz_2.Infrastructure.Repositories;

namespace Mini_Dz_2_Unit_Tests.ApplicationTests;

public class AnimalTransferServiceTests
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IEnclosureRepository _enclosureRepository;
    private readonly AnimalTransferService _service;

    public AnimalTransferServiceTests()
    {
        _animalRepository = new InMemoryAnimalRepository();
        _enclosureRepository = new InMemoryEnclosureRepository();
        _service = new AnimalTransferService(_animalRepository, _enclosureRepository);
    }

    [Fact]
    public void TransferAnimal_ShouldUpdateAnimalAndEnclosures()
    {
        // Arrange
        var animal = new Animal("Лев", "Лео", DateTime.Now, Gender.Male, "Мясцо", AnimalStatus.Healthy);
        var initialEnclosure = new Enclosure(EnclosureType.Predator, 100, 2);
        _enclosureRepository.Add(initialEnclosure);
        typeof(Animal).GetProperty("EnclosureId").SetValue(animal, initialEnclosure.Id);
        initialEnclosure.AddAnimal(animal.Id);
        _animalRepository.Add(animal);

        var targetEnclosure = new Enclosure(EnclosureType.Predator, 80, 2);
        _enclosureRepository.Add(targetEnclosure);

        // Act
        var evt = _service.TransferAnimal(animal.Id, targetEnclosure.Id);

        // Assert
        var updatedAnimal = _animalRepository.GetById(animal.Id);
        Assert.Equal(targetEnclosure.Id, updatedAnimal.EnclosureId);
        Assert.Equal(animal.Id, evt.AnimalId);
        Assert.Equal(initialEnclosure.Id, evt.OldEnclosureId);
        Assert.Equal(targetEnclosure.Id, evt.NewEnclosureId);

        var updatedInitial = _enclosureRepository.GetById(initialEnclosure.Id);
        var updatedTarget = _enclosureRepository.GetById(targetEnclosure.Id);
        Assert.Equal(0, updatedInitial.CurrentAnimalCount);
        Assert.Equal(1, updatedTarget.CurrentAnimalCount);
    }

    [Fact]
    public void TransferAnimal_ShouldThrowException_WhenTargetEnclosureIsFull()
    {
        // Arrange
        var animal = new Animal("Тигр", "Тигр", DateTime.Now, Gender.Male, "Мясо", AnimalStatus.Healthy);
        var initialEnclosure = new Enclosure(EnclosureType.Predator, 100, 2);
        _enclosureRepository.Add(initialEnclosure);
        typeof(Animal).GetProperty("EnclosureId").SetValue(animal, initialEnclosure.Id);
        initialEnclosure.AddAnimal(animal.Id);
        _animalRepository.Add(animal);

        var targetEnclosure = new Enclosure(EnclosureType.Predator, 80, 1);
        targetEnclosure.AddAnimal(Guid.NewGuid());
        _enclosureRepository.Add(targetEnclosure);

        // Act & Assert
        Assert.Throws<Exception>(() => _service.TransferAnimal(animal.Id, targetEnclosure.Id));
    }
}
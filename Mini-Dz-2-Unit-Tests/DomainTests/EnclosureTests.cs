using Mini_Dz_2.Domain;
using Mini_Dz_2.Domain.Entities;
using Mini_Dz_2.Domain.Events;

namespace Mini_Dz_2_Unit_Tests;

public class EnclosureTests
{
    [Fact]
    public void AddAnimal_ShouldSucceed_WhenCapacityAllows()
    {
        // Arrange
        var enclosure = new Enclosure(EnclosureType.Herbivore, 100.0, 2);
        var animalId = Guid.NewGuid();

        // Act
        bool added = enclosure.AddAnimal(animalId);

        // Assert
        Assert.True(added);
        Assert.Equal(1, enclosure.CurrentAnimalCount);
    }

    [Fact]
    public void AddAnimal_ShouldFail_WhenCapacityExceeded()
    {
        // Arrange
        var enclosure = new Enclosure(EnclosureType.Predator, 80.0, 1);
        var animalId1 = Guid.NewGuid();
        var animalId2 = Guid.NewGuid();
        enclosure.AddAnimal(animalId1);

        // Act
        bool added = enclosure.AddAnimal(animalId2);

        // Assert
        Assert.False(added);
        Assert.Equal(1, enclosure.CurrentAnimalCount);
    }

    [Fact]
    public void RemoveAnimal_ShouldSucceed_WhenAnimalExists()
    {
        // Arrange
        var enclosure = new Enclosure(EnclosureType.Bird, 50.0, 3);
        var animalId = Guid.NewGuid();
        enclosure.AddAnimal(animalId);

        // Act
        bool removed = enclosure.RemoveAnimal(animalId);

        // Assert
        Assert.True(removed);
        Assert.Equal(0, enclosure.CurrentAnimalCount);
    }

    [Fact]
    public void RemoveAnimal_ShouldFail_WhenAnimalDoesNotExist()
    {
        // Arrange
        var enclosure = new Enclosure(EnclosureType.Aquarium, 30.0, 5);
        var animalId = Guid.NewGuid();

        // Act
        bool removed = enclosure.RemoveAnimal(animalId);

        // Assert
        Assert.False(removed);
    }
}
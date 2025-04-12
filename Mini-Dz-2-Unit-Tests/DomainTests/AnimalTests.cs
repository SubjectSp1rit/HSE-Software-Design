using Mini_Dz_2.Domain;
using Mini_Dz_2.Domain.Entities;
using Mini_Dz_2.Domain.Events;

namespace Mini_Dz_2_Unit_Tests;

public class AnimalTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange
        var species = "Lion";
        var name = "Simba";
        var birthDate = new DateTime(2015, 01, 01);
        var gender = Gender.Male;
        var favoriteFood = "Meat";
        var status = AnimalStatus.Sick;

        // Act
        var animal = new Animal(species, name, birthDate, gender, favoriteFood, status);

        // Assert
        Assert.Equal(species, animal.Species);
        Assert.Equal(name, animal.Name);
        Assert.Equal(birthDate, animal.BirthDate);
        Assert.Equal(gender, animal.Gender);
        Assert.Equal(favoriteFood, animal.FavoriteFood);
        Assert.Equal(status, animal.Status);
        Assert.NotEqual(Guid.Empty, animal.Id);
    }

    [Fact]
    public void Heal_ShouldSetStatusToHealthy()
    {
        // Arrange
        var animal = new Animal("Elephant", "Dumbo", DateTime.Now, Gender.Female, "Fruits", AnimalStatus.Sick);

        // Act
        animal.Heal();

        // Assert
        Assert.Equal(AnimalStatus.Healthy, animal.Status);
    }

    [Fact]
    public void TransferTo_ShouldUpdateEnclosureIdAndReturnEvent()
    {
        // Arrange
        var animal = new Animal("Tiger", "Sheru", DateTime.Now, Gender.Male, "Meat", AnimalStatus.Healthy);
        var originalEnclosureId = animal.EnclosureId;
        var newEnclosureId = Guid.NewGuid();

        // Act
        AnimalMovedEvent evt = animal.TransferTo(newEnclosureId);

        // Assert
        Assert.Equal(originalEnclosureId, evt.OldEnclosureId);
        Assert.Equal(newEnclosureId, evt.NewEnclosureId);
        Assert.Equal(animal.Id, evt.AnimalId);
        Assert.Equal(newEnclosureId, animal.EnclosureId);
    }
}
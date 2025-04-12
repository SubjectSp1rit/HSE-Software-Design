using Mini_Dz_2.Domain.Entities;
using Mini_Dz_2.Domain;
using Mini_Dz_2.Infrastructure.Repositories;

namespace Mini_Dz_2_Unit_Tests.InfrastructureTests;

public class InMemoryRepositoryTests
{
    [Fact]
    public void InMemoryAnimalRepository_AddGetUpdateRemove()
    {
        // Arrange
        var repo = new InMemoryAnimalRepository();
        var animal = new Animal("Zebra", "Zed", DateTime.Now, Gender.Male, "Grass", AnimalStatus.Healthy);
        
        // Act & Assert
        repo.Add(animal);
        var fetchedAnimal = repo.GetById(animal.Id);
        Assert.NotNull(fetchedAnimal);
        Assert.Equal("Zebra", fetchedAnimal.Species);

        animal.Heal();
        repo.Update(animal);
        var updatedAnimal = repo.GetById(animal.Id);
        Assert.Equal(AnimalStatus.Healthy, updatedAnimal.Status);

        repo.Remove(animal.Id);
        var removedAnimal = repo.GetById(animal.Id);
        Assert.Null(removedAnimal);
    }

    [Fact]
    public void InMemoryEnclosureRepository_AddGetUpdateRemove()
    {
        // Arrange
        var repo = new InMemoryEnclosureRepository();
        var enclosure = new Enclosure(EnclosureType.Bird, 50, 5);
        
        // Act & Assert
        repo.Add(enclosure);
        var fetched = repo.GetById(enclosure.Id);
        Assert.NotNull(fetched);

        enclosure.AddAnimal(Guid.NewGuid());
        repo.Update(enclosure);
        var updated = repo.GetById(enclosure.Id);
        Assert.Equal(1, updated.CurrentAnimalCount);

        repo.Remove(enclosure.Id);
        var removed = repo.GetById(enclosure.Id);
        Assert.Null(removed);
    }

    [Fact]
    public void InMemoryFeedingScheduleRepository_AddGetUpdateRemove()
    {
        // Arrange
        var repo = new InMemoryFeedingScheduleRepository();
        var schedule = new FeedingSchedule(Guid.NewGuid(), DateTime.Now, "Berries");

        // Act & Assert
        repo.Add(schedule);
        var fetched = repo.GetById(schedule.Id);
        Assert.NotNull(fetched);
        Assert.Equal("Berries", fetched.FoodType);

        schedule.MarkAsCompleted();
        repo.Update(schedule);
        var updated = repo.GetById(schedule.Id);
        Assert.True(updated.IsCompleted);

        repo.Remove(schedule.Id);
        var removed = repo.GetById(schedule.Id);
        Assert.Null(removed);
    }
}
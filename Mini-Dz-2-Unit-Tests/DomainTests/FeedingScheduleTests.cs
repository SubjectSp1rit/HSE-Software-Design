using Mini_Dz_2.Domain;
using Mini_Dz_2.Domain.Entities;
using Mini_Dz_2.Domain.Events;

namespace Mini_Dz_2_Unit_Tests;

public class FeedingScheduleTests
{
    [Fact]
    public void ChangeSchedule_ShouldUpdateFeedingTimeAndFoodType()
    {
        // Arrange
        var animalId = Guid.NewGuid();
        var initialTime = DateTime.Now;
        var initialFood = "Grass";
        var schedule = new FeedingSchedule(animalId, initialTime, initialFood);

        var newTime = initialTime.AddHours(2);
        var newFood = "Fruits";

        // Act
        schedule.ChangeSchedule(newTime, newFood);

        // Assert
        Assert.Equal(newTime, schedule.FeedingTime);
        Assert.Equal(newFood, schedule.FoodType);
    }

    [Fact]
    public void MarkAsCompleted_ShouldSetIsCompletedToTrue()
    {
        // Arrange
        var animalId = Guid.NewGuid();
        var schedule = new FeedingSchedule(animalId, DateTime.Now, "Meat");

        // Act
        schedule.MarkAsCompleted();

        // Assert
        Assert.True(schedule.IsCompleted);
    }
}
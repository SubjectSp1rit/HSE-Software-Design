using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Mini_Dz_1;

/// <summary>
/// Заглушка для IVeterinaryClinic
/// </summary>
public class FakeVeterinaryClinic : IVeterinaryClinic
{
    private readonly bool _healthStatus;

    public FakeVeterinaryClinic(bool healthStatus)
    {
        _healthStatus = healthStatus;
    }

    public bool CheckHealth(Animal animal)
    {
        return _healthStatus;
    }
}

public class ZooTests
{
    [Fact]
    public void AddAnimal_HealthyAnimal_ReturnsTrueAndAddsAnimal()
    {
        // Arrange
        var fakeClinic = new FakeVeterinaryClinic(true);
        IZoo zoo = new Zoo(fakeClinic);
        var monkey = new Monkey("George", 5, 8);

        // Act
        bool result = zoo.AddAnimal(monkey);

        // Assert
        Assert.True(result);
        var animals = zoo.GetInventoryItems().Where(i => i is Animal).Cast<Animal>().ToList();
        Assert.Single(animals);
        Assert.Equal(1, monkey.Number);
    }

    [Fact]
    public void AddAnimal_UnhealthyAnimal_ReturnsFalseAndDoesNotAddAnimal()
    {
        // Arrange: зоопарк, возвращающей false (животное нездорово)
        var fakeClinic = new FakeVeterinaryClinic(false);
        IZoo zoo = new Zoo(fakeClinic);
        var tiger = new Tiger("Sheru", 10);

        // Act
        bool result = zoo.AddAnimal(tiger);

        // Assert: животное не добавлено
        Assert.False(result);
        var animals = zoo.GetInventoryItems().Where(i => i is Animal).Cast<Animal>().ToList();
        Assert.Empty(animals);
    }

    [Fact]
    public void GetTotalFoodConsumption_ReturnsCorrectSum()
    {
        // Arrange
        var fakeClinic = new FakeVeterinaryClinic(true);
        IZoo zoo = new Zoo(fakeClinic);
        var monkey = new Monkey("George", 5, 8);
        var rabbit = new Rabbit("Bunny", 2, 6);
        zoo.AddAnimal(monkey);
        zoo.AddAnimal(rabbit);

        // Act
        int totalFood = zoo.GetTotalFoodConsumption();

        // Assert: 5 + 2 = 7 кг
        Assert.Equal(7, totalFood);
    }

    [Fact]
    public void GetContactAnimals_ReturnsOnlyHerbivoresWithKindnessGreaterThanFive()
    {
        // Arrange
        var fakeClinic = new FakeVeterinaryClinic(true);
        IZoo zoo = new Zoo(fakeClinic);
        var monkey = new Monkey("George", 5, 8);  // Подходит: травоядное, добротность 8 (>5)
        var rabbit = new Rabbit("Bunny", 2, 4);    // Не подходит: добротность 4 (<=5)
        var tiger = new Tiger("Sheru", 10);          // Не подходит: хищник

        zoo.AddAnimal(monkey);
        zoo.AddAnimal(rabbit);
        zoo.AddAnimal(tiger);

        // Act
        var contactAnimals = zoo.GetContactAnimals().ToList();

        // Assert: только обезьяна должна быть в списке
        Assert.Single(contactAnimals);
        Assert.Contains(monkey, contactAnimals);
    }

    [Fact]
    public void AddInventoryItem_AssignsUniqueInventoryNumbers()
    {
        // Arrange
        var fakeClinic = new FakeVeterinaryClinic(true);
        IZoo zoo = new Zoo(fakeClinic);
        var table = new Table("Big Table");
        var computer = new Computer("Gaming PC");

        // Act
        zoo.AddInventoryItem(table);
        zoo.AddInventoryItem(computer);
        var items = zoo.GetInventoryItems().ToList();

        // Assert: проверяем, что номера присвоены и уникальны
        Assert.Equal(2, items.Count);
        Assert.Equal(1, table.Number);
        Assert.Equal(2, computer.Number);
    }

    [Fact]
    public void InventoryNumbersAreUniqueAcrossAnimalsAndItems()
    {
        // Arrange
        var fakeClinic = new FakeVeterinaryClinic(true);
        IZoo zoo = new Zoo(fakeClinic);
        var monkey = new Monkey("George", 5, 8);
        var table = new Table("Big Table");

        // Act
        zoo.AddAnimal(monkey);      // Получит номер 1
        zoo.AddInventoryItem(table); // Получит номер 2

        // Assert
        Assert.Equal(1, monkey.Number);
        Assert.Equal(2, table.Number);
    }

    [Fact]
    public void DIContainer_ResolvesServicesCorrectly()
    {
        // Arrange: настраиваем DI-контейнер
        var services = new ServiceCollection();
        services.AddSingleton<IVeterinaryClinic, VeterinaryClinic>();
        services.AddSingleton<IZoo, Zoo>();
        var provider = services.BuildServiceProvider();

        // Act
        var clinic = provider.GetService<IVeterinaryClinic>();
        var zoo = provider.GetService<IZoo>();

        // Assert: проверяем, что сервисы разрешились
        Assert.NotNull(clinic);
        Assert.NotNull(zoo);
    }
}
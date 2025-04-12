using Microsoft.AspNetCore.Mvc;
using Mini_Dz_2.Domain.Entities;
using Mini_Dz_2.Domain;
using Mini_Dz_2.Infrastructure.Repositories;
using Mini_Dz_2.Presentation.Controllers;

namespace Mini_Dz_2_Unit_Tests.Presentation;

public class AnimalsControllerTests
{
    private readonly InMemoryAnimalRepository _repo;
    private readonly AnimalsController _controller;

    public AnimalsControllerTests()
    {
        _repo = new InMemoryAnimalRepository();
        _controller = new AnimalsController(_repo);
    }

    [Fact]
    public void GetAll_ReturnsOkResult_WithListOfAnimals()
    {
        // Arrange
        var animal1 = new Animal("Lion", "Leo", DateTime.Now, Gender.Male, "Meat", AnimalStatus.Healthy);
        var animal2 = new Animal("Tiger", "Sheru", DateTime.Now, Gender.Male, "Meat", AnimalStatus.Healthy);
        _repo.Add(animal1);
        _repo.Add(animal2);

        // Act
        var result = _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var animals = Assert.IsAssignableFrom<IEnumerable<Animal>>(okResult.Value);
        Assert.Contains(animals, a => a.Id == animal1.Id);
        Assert.Contains(animals, a => a.Id == animal2.Id);
    }

    [Fact]
    public void GetById_ReturnsNotFound_WhenAnimalDoesNotExist()
    {
        // Act
        var result = _controller.GetById(Guid.NewGuid());

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void Create_AddsAnimalAndReturnsCreatedResult()
    {
        // Arrange
        var animal = new Animal("Elephant", "Dumbo", DateTime.Now, Gender.Female, "Grass", AnimalStatus.Healthy);

        // Act
        var result = _controller.Create(animal);
        
        // Assert
        var createdAtResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnedAnimal = Assert.IsType<Animal>(createdAtResult.Value);
        Assert.Equal(animal.Id, returnedAnimal.Id);
    }

    [Fact]
    public void Delete_RemovesAnimalAndReturnsNoContent()
    {
        // Arrange
        var animal = new Animal("Zebra", "Zed", DateTime.Now, Gender.Male, "Grass", AnimalStatus.Healthy);
        _repo.Add(animal);

        // Act
        var result = _controller.Delete(animal.Id);

        // Assert
        Assert.IsType<NoContentResult>(result);
        Assert.Null(_repo.GetById(animal.Id));
    }
}
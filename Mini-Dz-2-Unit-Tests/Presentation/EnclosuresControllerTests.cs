using Microsoft.AspNetCore.Mvc;
using Mini_Dz_2.Domain.Entities;
using Mini_Dz_2.Domain;
using Mini_Dz_2.Infrastructure.Repositories;
using Mini_Dz_2.Presentation.Controllers;

namespace Mini_Dz_2_Unit_Tests.Presentation;

public class EnclosuresControllerTests
{
    private readonly InMemoryEnclosureRepository _repo;
    private readonly EnclosuresController _controller;

    public EnclosuresControllerTests()
    {
        _repo = new InMemoryEnclosureRepository();
        _controller = new EnclosuresController(_repo);
    }

    [Fact]
    public void GetAll_ReturnsOkResult_WithListOfEnclosures()
    {
        // Arrange
        var enclosure1 = new Enclosure(EnclosureType.Herbivore, 100, 5);
        var enclosure2 = new Enclosure(EnclosureType.Predator, 80, 2);
        _repo.Add(enclosure1);
        _repo.Add(enclosure2);

        // Act
        var result = _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var enclosures = Assert.IsAssignableFrom<IEnumerable<Enclosure>>(okResult.Value);
        Assert.Contains(enclosures, e => e.Id == enclosure1.Id);
        Assert.Contains(enclosures, e => e.Id == enclosure2.Id);
    }

    [Fact]
    public void GetById_ReturnsNotFound_WhenEnclosureDoesNotExist()
    {
        // Act
        var result = _controller.GetById(Guid.NewGuid());

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void Create_AddsEnclosureAndReturnsCreatedResult()
    {
        // Arrange
        var enclosure = new Enclosure(EnclosureType.Bird, 50, 10);

        // Act
        var result = _controller.Create(enclosure);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnedEnclosure = Assert.IsType<Enclosure>(createdResult.Value);
        Assert.Equal(enclosure.Id, returnedEnclosure.Id);
    }

    [Fact]
    public void Delete_RemovesEnclosureAndReturnsNoContent()
    {
        // Arrange
        var enclosure = new Enclosure(EnclosureType.Aquarium, 30, 3);
        _repo.Add(enclosure);

        // Act
        var result = _controller.Delete(enclosure.Id);

        // Assert
        Assert.IsType<NoContentResult>(result);
        Assert.Null(_repo.GetById(enclosure.Id));
    }
}
using Microsoft.AspNetCore.Mvc;
using Mini_Dz_2.Application.Interfaces;
using Mini_Dz_2.Domain.Entities;

namespace Mini_Dz_2.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalsController(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Animal>> GetAll()
    {
        return Ok(_animalRepository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Animal> GetById(Guid id)
    {
        var animal = _animalRepository.GetById(id);
        if (animal == null) return NotFound();
        return Ok(animal);
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
        _animalRepository.Add(animal);
        return CreatedAtAction(nameof(GetById), new { id = animal.Id }, animal);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        _animalRepository.Remove(id);
        return NoContent();
    }
}
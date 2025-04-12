using Microsoft.AspNetCore.Mvc;
using Mini_Dz_2.Application.Interfaces;
using Mini_Dz_2.Domain.Entities;

namespace Mini_Dz_2.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnclosuresController : ControllerBase
{
    private readonly IEnclosureRepository _enclosureRepository;

    public EnclosuresController(IEnclosureRepository enclosureRepository)
    {
        _enclosureRepository = enclosureRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Enclosure>> GetAll()
    {
        return Ok(_enclosureRepository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Enclosure> GetById(Guid id)
    {
        var enclosure = _enclosureRepository.GetById(id);
        if (enclosure == null) return NotFound();
        return Ok(enclosure);
    }

    [HttpPost]
    public ActionResult Create(Enclosure enclosure)
    {
        _enclosureRepository.Add(enclosure);
        return CreatedAtAction(nameof(GetById), new { id = enclosure.Id }, enclosure);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        _enclosureRepository.Remove(id);
        return NoContent();
    }
}
using Microsoft.AspNetCore.Mvc;
using Mini_Dz_2.Application.Interfaces;
using Mini_Dz_2.Domain.Entities;
using Mini_Dz_2.Application.Services;

namespace Mini_Dz_2.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedingSchedulesController : ControllerBase
{
    private readonly IFeedingScheduleRepository _scheduleRepository;
    private readonly FeedingOrganizationService _feedingService;

    public FeedingSchedulesController(IFeedingScheduleRepository scheduleRepository, FeedingOrganizationService feedingService)
    {
        _scheduleRepository = scheduleRepository;
        _feedingService = feedingService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<FeedingSchedule>> GetAll()
    {
        return Ok(_scheduleRepository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<FeedingSchedule> GetById(Guid id)
    {
        var schedule = _scheduleRepository.GetById(id);
        if (schedule == null) return NotFound();
        return Ok(schedule);
    }

    [HttpPost]
    public ActionResult Create(Guid animalId, DateTime feedingTime, string foodType)
    {
        var schedule = _feedingService.AddFeedingSchedule(animalId, feedingTime, foodType);
        return CreatedAtAction(nameof(GetById), new { id = schedule.Id }, schedule);
    }

    [HttpPut("{id}")]
    public ActionResult Update(Guid id, DateTime newFeedingTime, string newFoodType)
    {
        _feedingService.ChangeFeedingSchedule(id, newFeedingTime, newFoodType);
        return NoContent();
    }

    [HttpPost("{id}/complete")]
    public ActionResult Complete(Guid id)
    {
        var evt = _feedingService.MarkFeedingCompleted(id);
        return Ok(evt);
    }
}
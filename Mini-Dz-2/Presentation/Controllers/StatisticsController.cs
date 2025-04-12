using Microsoft.AspNetCore.Mvc;
using Mini_Dz_2.Application.Services;


namespace Mini_Dz_2.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatisticsController : ControllerBase
{
    private readonly ZooStatisticsService _statsService;

    public StatisticsController(ZooStatisticsService statsService)
    {
        _statsService = statsService;
    }

    [HttpGet]
    public ActionResult GetStatistics()
    {
        var stats = _statsService.GetZooStatistics();
        return Ok(stats);
    }
}
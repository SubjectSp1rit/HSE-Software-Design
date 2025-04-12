using Mini_Dz_2.Application.Interfaces;
using Mini_Dz_2.Domain.Events;
using Mini_Dz_2.Domain.Entities;

namespace Mini_Dz_2.Application.Services;

public class ZooStatisticsService
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IEnclosureRepository _enclosureRepository;

    public ZooStatisticsService(IAnimalRepository animalRepository, IEnclosureRepository enclosureRepository)
    {
        _animalRepository = animalRepository;
        _enclosureRepository = enclosureRepository;
    }

    public ZooStatistics GetZooStatistics()
    {
        var animals = _animalRepository.GetAll().ToList();
        var enclosures = _enclosureRepository.GetAll().ToList();

        return new ZooStatistics
        {
            TotalAnimals = animals.Count,
            TotalEnclosures = enclosures.Count,
            FreeEnclosures = enclosures.Count(e => e.CurrentAnimalCount < e.Capacity)
        };
    }
}

public class ZooStatistics
{
    public int TotalAnimals { get; set; }
    public int TotalEnclosures { get; set; }
    public int FreeEnclosures { get; set; }
}
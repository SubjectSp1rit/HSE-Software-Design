using Mini_Dz_2.Domain.Entities;
using Mini_Dz_2.Application.Interfaces;
using System.Collections.Concurrent;

namespace Mini_Dz_2.Infrastructure.Repositories;

public class InMemoryAnimalRepository : IAnimalRepository
{
    private readonly ConcurrentDictionary<Guid, Animal> _animals = new ConcurrentDictionary<Guid, Animal>();

    public void Add(Animal animal)
    {
        _animals[animal.Id] = animal;
    }

    public IEnumerable<Animal> GetAll()
    {
        return _animals.Values;
    }

    public Animal GetById(Guid animalId)
    {
        _animals.TryGetValue(animalId, out var animal);
        return animal;
    }

    public void Remove(Guid animalId)
    {
        _animals.TryRemove(animalId, out _);
    }

    public void Update(Animal animal)
    {
        _animals[animal.Id] = animal;
    }
}
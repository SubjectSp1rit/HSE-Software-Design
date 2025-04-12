using Mini_Dz_2.Domain.Entities;

namespace Mini_Dz_2.Application.Interfaces;

public interface IAnimalRepository
{
    void Add(Animal animal);
    void Remove(Guid animalId);
    Animal GetById(Guid animalId);
    IEnumerable<Animal> GetAll();
    void Update(Animal animal);
}
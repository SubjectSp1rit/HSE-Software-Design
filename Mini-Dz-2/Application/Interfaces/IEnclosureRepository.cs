using Mini_Dz_2.Domain.Entities;

namespace Mini_Dz_2.Application.Interfaces;

public interface IEnclosureRepository
{
    void Add(Enclosure enclosure);
    void Remove(Guid enclosureId);
    Enclosure GetById(Guid enclosureId);
    IEnumerable<Enclosure> GetAll();
    void Update(Enclosure enclosure);
}
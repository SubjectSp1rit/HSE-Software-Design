using System.Collections.Concurrent;
using Mini_Dz_2.Domain.Entities;
using Mini_Dz_2.Application.Interfaces;

namespace Mini_Dz_2.Infrastructure.Repositories;

public class InMemoryEnclosureRepository : IEnclosureRepository
{
    private readonly ConcurrentDictionary<Guid, Enclosure> _enclosures = new ConcurrentDictionary<Guid, Enclosure>();

    public void Add(Enclosure enclosure)
    {
        _enclosures[enclosure.Id] = enclosure;
    }

    public IEnumerable<Enclosure> GetAll()
    {
        return _enclosures.Values;
    }

    public Enclosure GetById(Guid enclosureId)
    {
        _enclosures.TryGetValue(enclosureId, out var enclosure);
        return enclosure;
    }

    public void Remove(Guid enclosureId)
    {
        _enclosures.TryRemove(enclosureId, out _);
    }

    public void Update(Enclosure enclosure)
    {
        _enclosures[enclosure.Id] = enclosure;
    }
}
using Mini_Dz_2.Application.Interfaces;
using Mini_Dz_2.Domain.Events;
using Mini_Dz_2.Domain.Entities;

namespace Mini_Dz_2.Application.Services;

public class AnimalTransferService
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IEnclosureRepository _enclosureRepository;

    public AnimalTransferService(IAnimalRepository animalRepository, IEnclosureRepository enclosureRepository)
    {
        _animalRepository = animalRepository;
        _enclosureRepository = enclosureRepository;
    }

    /// <summary>
    /// Перемещает животное в другой вольер
    /// </summary>
    public AnimalMovedEvent TransferAnimal(Guid animalId, Guid targetEnclosureId)
    {
        var animal = _animalRepository.GetById(animalId) ?? throw new Exception("Животное не найдено");
        var targetEnclosure = _enclosureRepository.GetById(targetEnclosureId) ?? throw new Exception("Вольер не найден");
        var currentEnclosure = _enclosureRepository.GetById(animal.EnclosureId);

        if (targetEnclosure.CurrentAnimalCount >= targetEnclosure.Capacity)
            throw new Exception("Выбранный вольер полон");

        // если нашли животное - выдворяем его из текущего вольера
        if (currentEnclosure != null)
        {
            currentEnclosure.RemoveAnimal(animalId);
            _enclosureRepository.Update(currentEnclosure);
        }

        // потом добавляем животное в другой вольер
        if (!targetEnclosure.AddAnimal(animalId))
            throw new Exception("Не удалось добавить животное в вольер");

        _enclosureRepository.Update(targetEnclosure);
        var transferEvent = animal.TransferTo(targetEnclosureId);
        _animalRepository.Update(animal);
        
        return transferEvent;
    }
}
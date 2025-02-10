namespace Mini_Dz_1;

// Интерфейс для ветеринарной клиники
public interface IVeterinaryClinic
{
    /// <summary>
    /// Проверяет состояние здоровья животного.
    /// </summary>
    /// <param name="animal">Проверяемое животное</param>
    /// <returns>True, если животное здорово, иначе false</returns>
    bool CheckHealth(Animal animal);
}
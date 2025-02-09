namespace Mini_Dz_1;

public class Zoo : IZoo
    {
        private readonly List<Animal> _animals;
        private readonly List<IInventory> _inventoryItems;
        private readonly IVeterinaryClinic _clinic;

        public Zoo(IVeterinaryClinic clinic)
        {
            _animals = new List<Animal>();
            _inventoryItems = new List<IInventory>();
            _clinic = clinic;
        }

        /// <summary>
        /// Проводит проверку здоровья животного через ветеринарную клинику. Если животное здорово – добавляет его в зоопарк.
        /// </summary>
        public bool AddAnimal(Animal animal)
        {
            if (_clinic.CheckHealth(animal))
            {
                animal.Number = _inventoryItems.Count + 1;
                _animals.Add(animal);
                _inventoryItems.Add(animal);
                Console.WriteLine($"Животное {animal.Name} принято в зоопарк.");
                return true;
            }
            else
            {
                Console.WriteLine($"Животное {animal.Name} не не принято в зоопарк.");
                return false;
            }
        }

        /// <summary>
        /// Добавление инвентаризационного объекта
        /// </summary>
        public void AddInventoryItem(IInventory item)
        {
            if (item.Number == 0)
            {
                item.Number = _inventoryItems.Count + 1;
            }
            _inventoryItems.Add(item);
        }

        /// <summary>
        /// Возвращает суммарное количество килограммов еды, необходимое для всех животных.
        /// </summary>
        public int GetTotalFoodConsumption()
        {
            return _animals.Sum(a => a.Food);
        }

        /// <summary>
        /// Возвращает список животных, пригодных для контактного зоопарка (только травоядные с добротностью > 5).
        /// </summary>
        public IEnumerable<Animal> GetContactAnimals()
        {
            return _animals.OfType<Herbo>().Where(a => a.Kindness > 5);
        }

        /// <summary>
        /// Возвращает все объекты, находящиеся в зоопарке
        /// </summary>
        public IEnumerable<IInventory> GetInventoryItems()
        {
            return _inventoryItems;
        }
    }
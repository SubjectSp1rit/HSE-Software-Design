using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Mini_Dz_1;

public class Program
    {
        static void Main(string[] args)
        {
            // DI-контейнер
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var zoo = serviceProvider.GetService<IZoo>();

            // Инвентаризованные вещи зоопарка
            zoo.AddInventoryItem(new Table("Большой стол"));
            zoo.AddInventoryItem(new Computer("MacBook Air M3"));

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить животное");
                Console.WriteLine("2. Показать общее количество потребляемой еды (кг в день)");
                Console.WriteLine("3. Показать список животных для контактного зоопарка");
                Console.WriteLine("4. Показать список инвентаризационных предметов");
                Console.WriteLine("5. Выход");
                Console.Write("Ваш выбор: ");
                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddAnimal(zoo);
                        break;
                    case "2":
                        int totalFood = zoo.GetTotalFoodConsumption();
                        Console.WriteLine($"Общее количество еды, необходимое для животных: {totalFood} кг в день");
                        break;
                    case "3":
                        var contactAnimals = zoo.GetContactAnimals().ToList();
                        if (contactAnimals.Any())
                        {
                            Console.WriteLine("Животные, подходящие для контактного зоопарка:");
                            foreach (var animal in contactAnimals)
                            {
                                Console.WriteLine($"{animal.GetType().Name} - {animal.Name} (Инвентарный номер: {animal.Number})");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Нет животных, подходящих для контактного зоопарка.");
                        }
                        break;
                    case "4":
                        var items = zoo.GetInventoryItems().ToList();
                        if (items.Any())
                        {
                            Console.WriteLine("Инвентаризационные предметы:");
                            foreach (var item in items)
                            {
                                Console.WriteLine($"{item.GetType().Name} - {item.Name} (Инвентарный номер: {item.Number})");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Нет инвентаризационных предметов.");
                        }
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        /// <summary>
        /// Метод для добавления нового животного в зоопарк.
        /// </summary>
        private static void AddAnimal(IZoo zoo)
        {
            Console.WriteLine("Выберите тип животного для добавления:");
            Console.WriteLine("1. Обезьяна");
            Console.WriteLine("2. Кролик");
            Console.WriteLine("3. Тигр");
            Console.WriteLine("4. Волк");
            Console.Write("Ваш выбор: ");
            var typeChoice = Console.ReadLine();

            Animal animal = null;
            Console.Write("Введите имя животного: ");
            var name = Console.ReadLine();

            Console.Write("Введите количество еды (кг в день): ");
            int food;
            while (!int.TryParse(Console.ReadLine(), out food))
            {
                Console.Write("Некорректный ввод. Введите количество еды (кг в день): ");
            }

            // Уровень добротности для травоядных
            switch (typeChoice)
            {
                case "1":
                    Console.Write("Введите уровень добротности (от 0 до 10): ");
                    int kindnessMonkey;
                    while (!int.TryParse(Console.ReadLine(), out kindnessMonkey))
                    {
                        Console.Write("Некорректный ввод. Введите уровень добротности (от 0 до 10): ");
                    }
                    animal = new Monkey(name, food, kindnessMonkey);
                    break;
                case "2":
                    Console.Write("Введите уровень добротности (от 0 до 10): ");
                    int kindnessRabbit;
                    while (!int.TryParse(Console.ReadLine(), out kindnessRabbit))
                    {
                        Console.Write("Некорректный ввод. Введите уровень добротности (от 0 до 10): ");
                    }
                    animal = new Rabbit(name, food, kindnessRabbit);
                    break;
                case "3":
                    animal = new Tiger(name, food);
                    break;
                case "4":
                    animal = new Wolf(name, food);
                    break;
                default:
                    Console.WriteLine("Неверный выбор типа животного.");
                    return;
            }

            zoo.AddAnimal(animal);
        }

        /// <summary>
        /// Регистрирует сервисы в DI-контейнере
        /// </summary>
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<IVeterinaryClinic, VeterinaryClinic>();
            services.AddSingleton<IZoo, Zoo>();
        }
    }
using FairyTale.Entities;
using FairyTale.Turnip.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale.Turnip
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ICharacterService, CharacterService>()
                .AddSingleton<ICharacterService, GrandPaService>()
                .BuildServiceProvider();

            var characterService = serviceProvider.GetService<ICharacterService>();

            var turnipManager = new TurnipManager(characterService);

            turnipManager.onTurnipIsPulled += characterService.PullTurnip;

            turnipManager.onTurnipIsNotPulled += characterService.DragTurnip;

            turnipManager.Run();

            Console.WriteLine("Demonstration of the collection");

            Character grandPa = new Person
            {
                Name = "Ivan",
                Age = 95,
                CountLikes = 10000,
                Personality = "grandPa",
                Position = "Plants turnip",
                Salary = 100
            };

            Character grandMa = new Person
            {
                Name = "Anna",
                Age = 94,
                CountLikes = 500,
                Personality = "grandma",
                Position = "Love grandPa",
                Salary = 1000
            };

            Character grandDaughter = new Person
            {
                Name = "Masha",
                Age = 15,
                CountLikes = 10000,
                Personality = "grandDaughter",
                Position = "Very beautiful and energic",
                Salary = 2000
            };

            Character dog = new Animal()
            {
                Name = "Sharic",
                Age = 5,
                CountLikes = 100,
                Personality = "dog",
                Type = AnimalType.Dog,
                Strength = 50
            };

            Character cat = new Animal()
            {
                Name = "Sneshka",
                Age = 3,
                CountLikes = 150,
                Personality = "cat",
                Type = AnimalType.Cat,
                Strength = 100
            };

            Character mouse = new Animal()
            {
                Name = "Myri",
                Age = 1,
                CountLikes = 200,
                Personality = "mouse",
                Type = AnimalType.Mouse,
                Strength = 200000
            };

            Console.ReadKey();
        }
    }
}

using FairyTale.Entities;
using FairyTale.Turnip.Collections;
using FairyTale.Turnip.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale.Turnip
{
    sealed class TurnipManager
    {
        private readonly ICharacterService _characterService;
        GrandPaService grandPaService;
        string codeWord = String.Empty;

        public delegate string TurnipHandler(string str);
        public event TurnipHandler OnTurnipIsPulled = null;
        public event TurnipHandler OnTurnipIsNotPulled = null;

        public TurnipManager(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        private string IsTurnipPulledOut(string codeWord)
        {
            string result = String.Empty;

            if (codeWord == "mouseTurnip")
            {
                if (OnTurnipIsPulled != null)
                {
                    result = OnTurnipIsPulled(codeWord);
                }
            }
            else
            {
                if (OnTurnipIsNotPulled != null)
                {
                    result = OnTurnipIsNotPulled(codeWord);
                }
            }

            return result;
        }

        public void Run()
        {
            try
            {
                string isPulledOut = String.Empty;
                string memberCaller = String.Empty;

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

                Console.WriteLine("Welkom to the fairy tale of a turnip");

                grandPaService = (GrandPaService)_characterService;

                string plant = grandPaService.Plant();

                Console.WriteLine(plant);

                Console.WriteLine("Atter a while garndpa began to grab turnip");

                codeWord = grandPaService.TellWord(grandPa.Personality);

                isPulledOut = IsTurnipPulledOut(codeWord);

                Console.WriteLine(isPulledOut);

                memberCaller = grandPaService.CallCharacter(grandPa.Personality, grandMa.Personality);

                Console.WriteLine(memberCaller);

                codeWord = _characterService.TellWord(grandMa.Personality);

                isPulledOut = IsTurnipPulledOut(codeWord);

                Console.WriteLine(isPulledOut);

                memberCaller = _characterService.CallCharacter(grandMa.Personality, grandDaughter.Personality);

                Console.WriteLine(memberCaller);

                codeWord = _characterService.TellWord(grandDaughter.Personality);

                isPulledOut = IsTurnipPulledOut(codeWord);

                Console.WriteLine(isPulledOut);

                memberCaller = _characterService.CallCharacter(grandDaughter.Personality, dog.Personality);

                Console.WriteLine(memberCaller);

                codeWord = _characterService.TellWord(dog.Personality);

                isPulledOut = IsTurnipPulledOut(codeWord);

                Console.WriteLine(isPulledOut);

                memberCaller = _characterService.CallCharacter(dog.Personality, cat.Personality);

                Console.WriteLine(memberCaller);

                codeWord = _characterService.TellWord(cat.Personality);

                isPulledOut = IsTurnipPulledOut(codeWord);

                Console.WriteLine(isPulledOut);

                memberCaller = _characterService.CallCharacter(cat.Personality, mouse.Personality);

                Console.WriteLine(memberCaller);

                codeWord = _characterService.TellWord(mouse.Personality);

                isPulledOut = IsTurnipPulledOut(codeWord);

                Console.WriteLine(isPulledOut);

                Console.WriteLine("Yraaaa, the end is smile :)))");

                Console.WriteLine("Demonstration of the collection");

                TurnipCollection<Character> characters = new TurnipCollection<Character>();

                characters.Add(grandPa);
                characters.Add(grandMa);
                characters.Add(grandDaughter);
                characters.Add(dog);
                characters.Add(cat);
                characters.Add(mouse);

                foreach (var c in characters)
                {
                    Person person;
                    Animal animal;

                    if (c is Person)
                    {
                        person = (Person)c;
                        Console.WriteLine(c.Name + '\n' + c.Age + '\n' + c.CountLikes +
                            '\n' + c.Personality + '\n' + person.Position + '\n' + person.Salary + '\n');
                    }
                    else if (c is Animal)
                    {
                        animal = (Animal)c;
                        Console.WriteLine(c.Name + '\n' + c.Age + '\n' + c.CountLikes +
                            '\n' + c.Personality + '\n' + animal.Type + '\n' + animal.Strength + '\n');
                    }
                }

            }
            catch (Exception m)
            {
                Console.WriteLine(m);
            }
        }
    }
}

using FairyTale.Entities;
using FairyTale.Turnip.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale.Turnip
{
    class TurnipManager
    {
        private readonly ICharacterService _characterService;
        GrandPaService grandPaService;
        string codeWord = String.Empty;

        public delegate string TurnipHandler(string str);
        public event TurnipHandler onTurnipIsPulled = null;
        public event TurnipHandler onTurnipIsNotPulled = null;

        public TurnipManager(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        private string IsTurnipPulledOut(string codeWord)
        {
            string result = String.Empty;

            if (codeWord == "mouseTurnip")
            {
                if (onTurnipIsPulled != null)
                {
                    result = onTurnipIsPulled(codeWord);
                }
            }
            else
            {
                if (onTurnipIsNotPulled != null)
                {
                    result = onTurnipIsNotPulled(codeWord);
                }
            }

            return result;
        }

        public void Run()
        {
            try
            {
                string isPulledOut = String.Empty;
                string grandPa = "GrandPa";
                string grandMa = "GrandMa";
                string daughter = "Daughter";
                string dog = "Dog";
                string cat = "Cat";
                string mouse = "mouse";

                Console.WriteLine("Welkom to the fairy tale of a turnip");

                grandPaService = (GrandPaService)_characterService;

                grandPaService.Plant();

                Console.WriteLine("Atter a while garndpa began to grab turnip");

                codeWord = grandPaService.TellWord(grandPa);

                isPulledOut = IsTurnipPulledOut(codeWord);

                Console.WriteLine(isPulledOut);

                grandPaService.CallCharacter(grandPa, grandMa);

                codeWord = _characterService.TellWord(grandMa);

                isPulledOut = IsTurnipPulledOut(codeWord);

                Console.WriteLine(isPulledOut);

                _characterService.CallCharacter(grandMa, daughter);

                codeWord = _characterService.TellWord(daughter);

                isPulledOut = IsTurnipPulledOut(codeWord);

                Console.WriteLine(isPulledOut);

                _characterService.CallCharacter(daughter, dog);

                codeWord = _characterService.TellWord(dog);

                isPulledOut = IsTurnipPulledOut(codeWord);

                Console.WriteLine(isPulledOut);

                _characterService.CallCharacter(dog, cat);

                codeWord = _characterService.TellWord(cat);

                isPulledOut = IsTurnipPulledOut(codeWord);

                Console.WriteLine(isPulledOut);

                _characterService.CallCharacter(cat, mouse);

                codeWord = _characterService.TellWord(mouse);

                isPulledOut = IsTurnipPulledOut(codeWord);

                Console.WriteLine(isPulledOut);

            }
            catch (Exception m)
            {
                Console.WriteLine(m);
            }
        }
    }
}

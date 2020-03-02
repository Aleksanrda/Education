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

        private void IsTurnipPulledOut(string codeWord)
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
        }

        public void Run()
        {
            try
            {
                Console.WriteLine("Welkom to the fairy tale of a turnip");

                grandPaService = (GrandPaService)_characterService;

                grandPaService.Plant();

                Console.WriteLine("Atter a while garndpa began to grab turnip");

                codeWord = grandPaService.TellWord("grandPa");



            }
            catch (Exception m)
            {
                Console.WriteLine(m);
            }
        }
    }
}

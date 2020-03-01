using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale.Turnip.Services
{
    class CharacterService : ICharacterService
    {
        public string CallCharacter(string currentCharacter, string expectedCharacter)
        {
            return currentCharacter + " is calling " + expectedCharacter;
        }

        public string DragTurnip(string characterWord)
        {
            if (characterWord == null)
            {
                throw new ArgumentNullException(nameof(characterWord));
            }

            return "Turnip is not pulled out";
        }

        public string PullTurnip(string characterWord)
        {
            if (characterWord == null)
            {
                throw new ArgumentNullException(nameof(characterWord));
            }

            return "Turnip is pulled out";
        }

        public string TellWord(string character)
        {
            string characterWord = String.Empty;

            if (character == null)
            {
                throw new ArgumentNullException(nameof(character));
            }

            if (character == "mouse")
            {
                characterWord = "mouseTurnip";
            }
            else
            {
                characterWord = "notMouseTurnip";
            }

            return characterWord;
        }
    }
}

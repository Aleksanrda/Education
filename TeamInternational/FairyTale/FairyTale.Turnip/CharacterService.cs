using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale.Turnip
{
    class CharacterService : ICharacterService
    {
        public string CallCharacter(string currentCharacter, string expectedCharacter)
        {
            return currentCharacter + " is calling " + expectedCharacter;
        }

        public void PullTurnip(string characterWord, string codeWord)
        {
            if (characterWord == null)
            {
                throw new ArgumentNullException(nameof(characterWord));
            }

            if (characterWord == codeWord)
            {

            }
            else
            {

            }
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

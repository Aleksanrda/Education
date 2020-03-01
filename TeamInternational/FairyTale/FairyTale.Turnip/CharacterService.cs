using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale.Turnip
{
    class CharacterService : ICharacterService
    {
        public void PullTurnip(string userWord, string codeWord)
        {
            if(userWord == null)
            {
                throw new ArgumentNullException(nameof(userWord));
            }

            if(userWord == codeWord)
            {

            }
            else
            {

            }
        }
    }
}

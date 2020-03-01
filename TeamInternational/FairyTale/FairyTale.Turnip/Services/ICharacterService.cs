using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale.Turnip.Services
{
    public interface ICharacterService
    {
        string PullTurnip(string characterWord);

        string DragTurnip(string characterWord);

        string TellWord(string character);

        string CallCharacter(string currentCharacter, string expectedCharacter);
    }
}

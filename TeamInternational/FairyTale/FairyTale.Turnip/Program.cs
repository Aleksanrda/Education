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

            Console.ReadKey();
        }
    }
}

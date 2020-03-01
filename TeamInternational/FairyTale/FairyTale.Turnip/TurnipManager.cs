using FairyTale.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale.Turnip
{
    class TurnipManager
    {
        private readonly Person _grandPa;
        private readonly Person _grandMa;
        private readonly Person _grandDaughter;
        private readonly Animal _dog;
        private readonly Animal _cat;
        private readonly Animal _mouse;

        public TurnipManager(
            Person grandPa,
            Person grandMa,
            Person grandDaughter,
            Animal dog,
            Animal cat,
            Animal mouse)
        {
            _grandPa = grandPa;
            _grandMa = grandMa;
            _grandDaughter = grandDaughter,
            _dog = dog;
            _cat = cat;
            _mouse = mouse;
        }

        public void Run()
        {
            try
            {

            }
            catch (Exception m)
            {
                Console.WriteLine(m);
            }
        }
    }
}

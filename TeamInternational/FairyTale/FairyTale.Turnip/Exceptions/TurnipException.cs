using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale.Turnip.Exceptions
{
    class TurnipException : Exception
    {
        public TurnipException(string message) : base(message)
        {
        }
    }
}

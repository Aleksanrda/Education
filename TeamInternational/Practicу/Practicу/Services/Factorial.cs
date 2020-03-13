using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicу.Services
{
    class Factorial : IFactorial
    {
        public int GetFactorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * GetFactorial(n - 1);
            }
        }
    }
}

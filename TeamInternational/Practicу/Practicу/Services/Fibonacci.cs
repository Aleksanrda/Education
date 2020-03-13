using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicу.Services
{
    public class Fibonacci : IFibonacci
    {
        public int GetMemberFibonacci(int n)
        {
            int firstElement = 1;
            int secondElement = 1;
            int resultFibonacci = 0;

            if (n == 1 || n == 2)
            {
                return 1;
            }

            for (int i = 2; i <= n; i++)
            {
                resultFibonacci = firstElement + secondElement;
                firstElement = secondElement;
                secondElement = resultFibonacci;
            }

            return resultFibonacci;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1TP
{
    public class MathMethods
    {
        public int AverageVariance(int[] arrayOfNumbers)
        {
            int sum = 0;
            int averageVariance = 0;

            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                sum += arrayOfNumbers[i];
            }

            averageVariance = sum / arrayOfNumbers.Length;
            return averageVariance;
        }


    }
}

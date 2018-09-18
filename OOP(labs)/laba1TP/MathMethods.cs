using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1TP
{
    public class MathMethods
    {
        public double AverageVariance(double[] arrayOfNumbers)
        {
            double sum = 0;
            double averageVariance = 0;

            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                sum += arrayOfNumbers[i];
            }

            averageVariance = sum / arrayOfNumbers.Length;
            return averageVariance;
        }

        public double SelectiveDispersion(double[] arrayOfNumbers)
        {
            double selectiveDispersion = 0;
            double m = AverageVariance(arrayOfNumbers); //m is average variance

            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                selectiveDispersion += Math.Pow((arrayOfNumbers[i] - m), 2);
            }

            if (arrayOfNumbers.Length > 1)
            {
                selectiveDispersion /= arrayOfNumbers.Length - 1;
            }
            else
            {
                selectiveDispersion = 0;
            }

            return selectiveDispersion;
        }

        public double StandardDeviation(double[] arrayOfNumbers) //Стандартне відхилення
        {
            double selectiveDispersion = SelectiveDispersion(arrayOfNumbers);
            double standardDeviation = Math.Sqrt(selectiveDispersion);
            return standardDeviation;
        }

        public double GetMedian(double[] arrayOfNumbers)
        {
            double median = 0;

            Array.Sort(arrayOfNumbers);

            if (arrayOfNumbers.Length % 2 == 0)
            {
                median = arrayOfNumbers[(arrayOfNumbers.Length / 2 + arrayOfNumbers.Length / (2 + 1)) / 2];
            }
            else
            {
                median = arrayOfNumbers[(arrayOfNumbers.Length - 1) / 2];
            }

            return median;
        }
    }
}

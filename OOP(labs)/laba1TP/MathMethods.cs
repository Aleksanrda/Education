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
            double[] sortArr = new double[arrayOfNumbers.Length];

            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                sortArr[i] = arrayOfNumbers[i];
            }

            Array.Sort(sortArr);

            if (sortArr.Length % 2 == 0)
            {
                median = sortArr[(sortArr.Length / 2 + sortArr.Length / (2 + 1)) / 2];
            }
            else
            {
                median = sortArr[(sortArr.Length - 1) / 2];
            }

            return median;
        }

        public double GetMode(double[] arrayOfNumbers)
        {
            double mode = 0;
            int check = 0;
            int k = 0;

            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                for (int j = i + 1; j < arrayOfNumbers.Length; j++)
                {

                    if (arrayOfNumbers[i] == arrayOfNumbers[j])
                    {
                        k++;
                        if (k > check)
                        {
                            check = k;
                            mode = arrayOfNumbers[i];
                        }
                    }
                }
                k = 0;
            }

            return mode;
        }

        public double GetMax(double[] arrayOfNumbers)
        {
            double max = arrayOfNumbers[0];

            for (int i = 1; i < arrayOfNumbers.Length; i++)
            {
                if (max < arrayOfNumbers[i])
                {
                    max = arrayOfNumbers[i];
                }
            }

            return max;
        }

        public double GetMin(double[] arrayOfNumbers)
        {
            double min = arrayOfNumbers[0];

            for (int i = 1; i < arrayOfNumbers.Length; i++)
            {
                if (min > arrayOfNumbers[i])
                {
                    min = arrayOfNumbers[i];
                }
            }

            return min;
        }

        public double GetScope(double[] arrayOfNumbers) // розмах
        {
            double scope = 0;
            scope = GetMax(arrayOfNumbers) - GetMin(arrayOfNumbers);
            return scope;
        }
    }
}

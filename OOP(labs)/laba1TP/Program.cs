using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1TP
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = new double[] { 3, 3, 2, 1, 3, 4, 5, 5, 3};

            Console.WriteLine("Original array : ");

            foreach (var item in arr)
            {
                Console.Write(" " + item);
            }

            Console.WriteLine();

            MathMethods mathmethods = new MathMethods();

            double averageVariance = mathmethods.AverageVariance(arr);
            Console.WriteLine( "Average variance is " + averageVariance);

            double selectiveDispersion = mathmethods.SelectiveDispersion(arr);
            Console.WriteLine("Selective dispersion is " + selectiveDispersion);

            double standardDeviation = mathmethods.StandardDeviation(arr);
            Console.WriteLine("Standard deviation is " + standardDeviation);

            double median = mathmethods.GetMedian(arr);
            Console.WriteLine("Median is " + median);

            double mode = mathmethods.GetMode(arr);
            Console.WriteLine("Mode is " + mode);

            Console.ReadKey();
        }
    }
}

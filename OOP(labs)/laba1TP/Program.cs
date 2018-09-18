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
            double[] arr = new double[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };

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



            Console.ReadKey();
        }
    }
}

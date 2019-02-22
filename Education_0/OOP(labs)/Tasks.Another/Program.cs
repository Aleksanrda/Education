using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Another
{
    class Program
    {
        static void Main(string[] args)
        {
            //Store store = new Store();

            //Console.WriteLine("Input name of product");

            //string userInput = Console.ReadLine();

            //bool result = store.IsSearchInformation(userInput);

            //if(result)
            //{
            //   string outputInfo = store.WriteInfo(userInput);
            //    Console.WriteLine(outputInfo);
            //    Console.WriteLine(store[128975]);
            //}
            //else
            //{
            //    Console.WriteLine("Such product is absent in our shop");
            //}

            int[] arr = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };

            Console.WriteLine("Original array : ");
            foreach (var item in arr)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();

            arr.QuickSortArr(0, arr.Length - 1);

            Console.WriteLine();
            Console.WriteLine("Sorted array : ");

            foreach (var item in arr)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();


            Console.ReadKey();
        }
    }
}

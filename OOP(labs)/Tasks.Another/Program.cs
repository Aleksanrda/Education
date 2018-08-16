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
            Store store = new Store();

            Console.WriteLine("Input name of product");

            string userInput = Console.ReadLine();

            bool result = store.IsSearchInformation(userInput);
            
            if(result)
            {
               string outputInfo = store.WriteInfo(userInput);
                Console.WriteLine(outputInfo);
                Console.WriteLine(store[128975]);
            }
            else
            {
                Console.WriteLine("Such product is absent in our shop");
            }
            Console.ReadKey();
        }
    }
}

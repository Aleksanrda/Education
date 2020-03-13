using Practicу.Models;
using Practicу.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicу
{
    class Manager
    {
        private readonly IFibonacci _fibonacci;
        private readonly IFactorial _factorial;
        private readonly Linq _linq = new Linq();
        private readonly List<Animal> _animals;

        public Manager(IFibonacci fibonacci, IFactorial factorial, List<Animal> animals)
        {
            _fibonacci = fibonacci;
            _factorial = factorial;
            _animals = animals;
        }

        public void Run()
        {
            var fibonacciResult = _fibonacci.GetMemberFibonacci(3);
            var factorialResult = _factorial.GetFactorial(4);

            Console.WriteLine(fibonacciResult);
            Console.WriteLine(factorialResult);

            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var divisionResult = _linq.DivideNumbersIntoEvenAndOdd(numbers);

            foreach (var group in divisionResult)
            {
                Console.WriteLine("Group key {0} ", group.Key);

                foreach (var number in group)
                {
                    Console.WriteLine("{0}", number);
                }
            }

            var groupByMeal = _linq.GroupAnimalByFavouriteMeal(_animals);

            foreach (var group in groupByMeal)
            {
                Console.WriteLine("Favourite meal {0} ", group.Key);

                foreach (var animal in group)
                {
                    Console.WriteLine("{0}", animal.Name);
                }
            }
        }
    }
}









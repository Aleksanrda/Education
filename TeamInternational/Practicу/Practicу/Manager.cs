using Practicу.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicу
{
    class Manager
    {
        public List<long> Fibonacci()
        {
            //var sum = 1;
            //List<int> fibonacci = new List<int>();
            //fibonacci = fibonacci.Select(f => f > n).

            //return sum;
            Func<long, long, long, IEnumerable<long>> fib = null;
            fib = (n, m, cap) => n + m > cap ? Enumerable.Empty<long>()
                : Enumerable.Repeat(n + m, 1).Concat(fib(m, n + m, cap));

            var list = fib(0, 1, 10).ToList();

            foreach (var v in list)
            {
                Console.WriteLine(v);
            }
            return list;
        }



        public int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        public IEnumerable<IGrouping<Meal, Animal>> GroupAnimalsByMeal(List<Animal> animals)
        {
            var query = animals.GroupBy(a => a.FavouriteMeal).ToList();

            var animalGroups = from animal in animals
                               group animal by animal.FavouriteMeal;

            foreach (IGrouping<Meal, Animal> g in animalGroups)
            {
                Console.WriteLine(g.Key);
                foreach (var t in g)
                    Console.WriteLine(t.Name);
                Console.WriteLine();
            }

            return animalGroups;
        }
    }
}









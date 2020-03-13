using Practicу.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicу
{
    class Linq
    {
        public IEnumerable<IGrouping<int, int>> DivideNumbersIntoEvenAndOdd(int[] numbers)
        {

            var divisionResult = from n in numbers
                                 group n by n % 2;

            return divisionResult;
        }

        public IEnumerable<IGrouping<Meal, Animal>> GroupAnimalByFavouriteMeal(List<Animal> animals)
        {
            var result = from a in animals
                         group a by a.FavouriteMeal;

            return result;
        }
    }
}

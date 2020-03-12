using Practicу.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicу
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>()
        {
            new Animal()
            {
                Id = 1,
                Name = "Masha",
                Age = 10,
                FavouriteMeal = Meal.Beaver
            },
            new Animal()
            {
                Id = 2,
                Name = "Dasha",
                Age = 3,
                FavouriteMeal = Meal.Dog
            },
            new Animal()
            {
                Id = 3,
                Name = "Max",
                Age = 2,
                FavouriteMeal = Meal.Dog
            },
            new Animal()
            {
                Id = 4,
                Name = "Dima",
                Age = 20,
                FavouriteMeal = Meal.Dinosaur
            }
        };


            Console.ReadKey();
        }
    }
}

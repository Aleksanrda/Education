﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicу.Models
{
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Meal FavouriteMeal { get; set; }
    }
}

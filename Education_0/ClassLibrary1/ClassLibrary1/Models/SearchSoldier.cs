﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public class SearchSoldier
    {
        public SearchSoldier(Soldier soldier)
        {
            Soldier = soldier;
        }
       
        public Soldier Soldier { get; set; }

    }
}

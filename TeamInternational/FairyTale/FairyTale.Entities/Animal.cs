using System;
using System.Collections.Generic;
using System.Text;

namespace FairyTale.Entities
{
    public class Animal : Character
    {
        public AnimalType Type { get; set; }

        public int Strength { get; set; }
    }
}

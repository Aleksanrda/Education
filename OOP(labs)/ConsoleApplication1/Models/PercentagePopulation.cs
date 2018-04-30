using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2.Models
{
    public class PercentagePopulation
    {
        public PercentagePopulation(double countFreeRoom, int numberFlour)
        {
            CountFreeRoom = countFreeRoom;
            NumberFlour = numberFlour;
        }

        public double CountFreeRoom { get; set; }

        public int NumberFlour { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2.Models
{
    public class Room
    {
        public int NumberOfFloor { get; set; }
        public int NumberOfRoom { get; set; }
        public int CountOfPeopleInRoom { get; set; }
        //массив - множественное число
        // список вместо массива
        public List<string> Person { get; set; }
    }
}

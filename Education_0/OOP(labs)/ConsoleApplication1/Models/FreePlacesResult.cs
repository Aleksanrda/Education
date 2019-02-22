using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2.Models
{
    public class FreePlacesResult
    {
        public FreePlacesResult(Room room, int freeBeds)
        {
            Room = room;
            AmountFreeBeds = freeBeds;
        }

        public Room Room { get; set; }

        public int AmountFreeBeds { get; set; }
    }
}

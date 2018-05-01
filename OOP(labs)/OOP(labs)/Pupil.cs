using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_labs_
{
    public class Pupil
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public Birthday Birthday { get; set; } //????????????????
        public double AverageMark { get; set; }
    }

    public struct Birthday
    {
        public int Day;
        public int Month;
        public int Year;
    }

}

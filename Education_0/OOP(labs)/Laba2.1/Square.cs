using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2._1
{
    public class Square
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double W { get; set; }

        public Square()
        {
            X = 0;
            Y = 0;
            W = 4;
        }

        public Square(double x, double y, double w)
        {
            X = x;
            Y = y;
            W = w;
        }

    }
}

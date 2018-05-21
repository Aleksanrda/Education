using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2._1
{
    public class Square
    {
        public double X1;
        public double Y1;
        public double X2;
        public double Y2;
        public double X3;
        public double Y3;
        public double X4;
        public double Y4;

        public Square()
        {
            X1 = 4;
            Y1 = 0;
            X2 = -4;
            Y2 = 0;
            X3 = 0;
            Y3 = 4;
            X4 = 0;
            Y4 = -4;
        }

        public Square(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
            X4 = x4;
            Y4 = y4;
        }

    }
}

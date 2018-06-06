using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    public class PolygonColor : Polygon
    {
        protected string Color;

        public PolygonColor(float x, float y, string color, params Point[] points) : base(x, y, points)
        {
            Color = color;
        }


    }
}

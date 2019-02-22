using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Laba3
{
    public class PolygonColor : Polygon
    {
        protected string Color;

        public PolygonColor(float x, float y, string color, params Point[] points) : base(x, y, points)
        {
            Color = color;
        }

        public override string ToString()
        {
            return $"Class: poligon \nsquare={Square()}, \nperimeter={Perimeter()}, \ncolor = {Color}";
        }

    }
}

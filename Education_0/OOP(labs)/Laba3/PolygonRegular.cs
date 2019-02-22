using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Laba3
{
    public class PolygonRegular : Polygon
    {
        public PolygonRegular(Point center, int vertexes, float radius, float x, float y, params Point[] points) : base(x, y, points)
        {
            Points = Building(center, vertexes, radius);
        }
        public static Point[] Building(Point middle, int vertexes, float radius)
        {
            Point[] points = new Point[vertexes];
            float angle = (float)((Math.PI / 2) + (2 * Math.PI / vertexes));
            int c = 1;
            points[0] = new Point(middle.X, middle.Y + radius);
            while (c < vertexes)
            {
                points[c] = new Point((float)(radius * Math.Cos(angle)), (float)(radius * Math.Sin(angle)));
                angle += (float)(2 * Math.PI / vertexes);
                c++;
            }
            return points;
        }

      

    }
}

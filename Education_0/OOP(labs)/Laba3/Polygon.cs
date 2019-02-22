using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Laba3
{
    public class Polygon : Figure
    {
        internal Point[] Points;

        public Polygon(float x, float y, params Point[] points) : base(x, y)
        {
            if(!(Points == null))
            {
                Array.Copy(points, Points, points.Length);
            }

          
        }

        protected double Length(Point x, Point  y)
        {
            return (Math.Sqrt(Math.Pow((double)(x.X - y.X), 2) + Math.Pow((double)(x.Y - y.Y), 2)));
        }

        public override double Square()
        {
            double sum = 0;
            if (!(Points == null))
            {
                for (int i = 0; i < Points.Length - 1; i++)
                {
                    sum += (Points[i].X * Points[i + 1].Y - Points[i].Y * Points[i + 1].X);
                }
            }

            sum /= 2;
            return Math.Abs(sum);
        }

        public override double Perimeter()
        {
            double sum = 0;
            if(!(Points == null))
            {
                for (int i = 0; i < Points.Length - 1; i++)
                {
                    sum += Math.Sqrt((Points[i].X - Points[i + 1].X) * (Points[i].X - Points[i + 1].X) + (Points[i].Y - Points[i + 1].Y) * (Points[i].Y - Points[i + 1].Y));
                }
            }
            
            return sum;
        }


        public override void Move()
        {
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].Move();
            }
        }

        public override void Scale()
        {
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].Scale();
            }
        }

        public override string ToString()
        {
            return $"Class: poligon \nsquare={Square()}, \nperimeter={Perimeter()}";
        }

        

    }
}

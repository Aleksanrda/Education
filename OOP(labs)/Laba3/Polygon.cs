using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    public class Polygon : Figure
    {
        protected Point[] Points;

        public Polygon(double x, double y, params Point[] points) : base(x, y)
        {
            Array.Copy(points, Points, points.Length);
        }

        protected static double Length(Point x, Point  y)
        {
            return (Math.Sqrt(Math.Pow((double)(x.X - y.X), 2) + Math.Pow((double)(x.Y - y.Y), 2)));
        }

        public override double Square()
        {
            double sum = 0;

            for (int i = 0; i < Points.Length - 1; i++)
            {
                sum += (Points[i].X * Points[i + 1].Y - Points[i].Y * Points[i + 1].X);
            }

            sum /= 2;
            return Math.Abs(sum);
        }

        public override double Perimeter()
        {
            double sum = 0;

            for (int i = 0; i < Points.Length - 1; i++)
            {
                sum += Length(Points[i], Points[i + 1]);
            }

            sum += Length(Points[0], Points[Points.Length - 1]);
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
            return MessageBox.Show($"Class: poligon square={Square()}, perimeter={Perimeter()}");
        }

        //public override void Draw(Graphics graph, Pen pen)
        //{
        //    for (int i = 0; i < Points.Length; i++)
        //    {
        //        graph.DrawRectangle(pen, Points[i]);
        //        base.Draw(graph, pen);
        //    }
                       
        //}

    }
}

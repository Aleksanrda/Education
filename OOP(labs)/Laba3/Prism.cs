using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Laba3
{
    public class Prism : Figure
    {
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public int X3 { get; set; }
        public int Y3 { get; set; }
        public int X4 { get; set; }
        public int Y4 { get; set; }
        public Prism(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4): base ( x1, y1)
        {
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
            X4 = x4;
            Y4 = y4;

        }
        public override void Draw(Graphics graph, Pen pen)
        {
            graph.DrawLine(pen, X, Y, X2, Y2);
            graph.DrawLine(pen, X, Y, X3, Y3);
            graph.DrawLine(pen, X3, Y3, X4, Y4);
            graph.DrawLine(pen, X4, Y4, X2, Y2);

            base.Draw(graph, pen);
        }
        public override void Scale()
        {
            if (Y4 <= 200)
            {
                int scale = 2;
                X *= scale;
                Y *= scale;
                X2 *= scale;
                X3 *= scale;
                Y2 *= scale;
                Y3 *= scale;
                X4 *= scale;
                Y4 *= scale;
            }
            else
                MessageBox.Show("Stop increasing");

        }
        public override void Move()
        {
            if (Y4 < 360)
            {
                int move1 = 20;
                int move2 = 20;
                this.X = X + move1;
                this.Y = Y + move2;
                this.X2 = X2 + move1;
                this.Y2 = Y2 + move2;
                this.X3 = X3 + move1;
                this.Y3 = Y3 + move2;
                this.X4 = X4 + move1;
                this.Y4 = Y4 + move2;
            }
            else
                MessageBox.Show("Stop removing");
        }

        public override double Square()
        {
            double square = (Math.Sqrt(Math.Pow((X2 - X), 2) + Math.Pow((Y2 - Y), 2)) * Math.Sqrt(Math.Pow((X - X3), 2) + Math.Pow((Y - Y3), 2))) / 2;
            return square;
        }
        public override string ToString()
        {
           return ($"Class: prism \nPerimetr={Perimeter()} \nsquare={Square()} ");
        }
        public override double Perimeter()
        {
            double perimetr = (Math.Sqrt(Math.Pow((X2 - X), 2) + Math.Pow((Y2 - Y), 2)) + Math.Sqrt(Math.Pow((X - X3), 2) + Math.Pow((Y - Y3), 2))) * 2;
            return perimetr;
        }

    }
}

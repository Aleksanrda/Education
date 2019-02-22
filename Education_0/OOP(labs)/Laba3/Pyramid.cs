using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Laba3
{
    public class Pyramid : Figure
    {
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public int X3 { get; set; }
        public int Y3 { get; set; }
        public int X4 { get; set; }
        public int Y4 { get; set; }
        public Pyramid(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4): base ( x1, y1)
        {
            this.X2 = x2;
            this.Y2 = y2;
            this.X3 = x3;
            this.Y3 = y3;
            this.X4 = x4;
            this.Y4 = y4;

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
            if (X4 <= 200)
            {
                int scale = 2;
                this.X *= scale;
                this.Y *= scale;
                this.X2 *= scale;
                this.X3 *= scale;
                this.Y2 *= scale;
                this.Y3 *= scale;
                this.X4 *= scale;
                this.Y4 *= scale;
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
            double square = 1900;
            return square;
        }
        public override string ToString()
        {
            return ($"Class: piramid \nPerimetr={Perimeter()} \nsquare={Square()} ");
        }
        public override double Perimeter()
        {
            double perimetr = 600;
            return perimetr;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    public class Prism : Figure
    {
        public int x2 { get; set; }
        public int y2 { get; set; }
        public int x3 { get; set; }
        public int y3 { get; set; }
        public int x4 { get; set; }
        public int y4 { get; set; }
        public Prism(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4): base ( x1, y1)
        {
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
            this.x4 = x4;
            this.y4 = y4;

        }
        public override void Draw(Graphics graph, Pen pen)
        {
            graph.DrawLine(pen, X, Y, x2, y2);
            graph.DrawLine(pen, X, Y, x3, y3);
            graph.DrawLine(pen, x3, y3, x4, y4);
            graph.DrawLine(pen, x4, y4, x2, y2);

            base.Draw(graph, pen);
        }
        public override void Scale()
        {
            if (y4 <= 200)
            {
                int z = 2;
                this.X *= z;
                this.Y *= z;
                this.x2 *= z;
                this.x3 *= z;
                this.y2 *= z;
                this.y3 *= z;
                this.x4 *= z;
                this.y4 *= z;
            }
            else
                MessageBox.Show("Stop increasing");

        }
        public override void Move()
        {
            if (y4 < 360)
            {
                int z = 20;
                int m = 20;
                this.X = X + z;
                this.Y = Y + m;
                this.x2 = x2 + z;
                this.y2 = y2 + m;
                this.x3 = x3 + z;
                this.y3 = y3 + m;
                this.x4 = x4 + z;
                this.y4 = y4 + m;
            }
            else
                MessageBox.Show("Stop removing");
        }

        public override double Square()
        {
            double num = (Math.Sqrt(Math.Pow((x2 - X), 2) + Math.Pow((y2 - Y), 2)) * Math.Sqrt(Math.Pow((X - x3), 2) + Math.Pow((Y - y3), 2))) / 2;
            return num;
        }
        public override string ToString()
        {
           return MessageBox.Show($"Class: quadrate \na={Math.Sqrt(Math.Pow((x2 - X), 2) + Math.Pow((y2 - Y), 2)) } \nb={Math.Sqrt(Math.Pow((X - x3), 2) + Math.Pow((Y - y3), 2))}");
        }
        public override double Perimeter()
        {
            double num = (Math.Sqrt(Math.Pow((x2 - X), 2) + Math.Pow((y2 - Y), 2)) + Math.Sqrt(Math.Pow((X - x3), 2) + Math.Pow((Y - y3), 2))) * 2;
            return num;
        }

    }
}

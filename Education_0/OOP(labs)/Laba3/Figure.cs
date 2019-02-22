using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Laba3
{
    public abstract class Figure
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Figure(float x, float y)
        {
            X = x;
            Y = y;
        }

        public virtual double Square ()
        {
            double square = Math.Sqrt(Math.Pow((X - X), 2) + Math.Pow((Y - Y), 2));
            return square;
        }

        public virtual double Perimeter ()
        {
            double perimeter = Math.Sqrt(Math.Pow((X - X), 2) + Math.Pow((Y - Y), 2));
            return perimeter;
        }

        public virtual void Move()
        {
            if (Y < 350)
            {
                int movingCoordinate = 5;
                X += movingCoordinate;
                Y += movingCoordinate;
            }
            else
            {
                MessageBox.Show("Stop removing");
            }
                
        }

        public virtual void Scale()
        {
            if (X < 750)
            {
                int scaleNumber = 5;
                X *= scaleNumber;
                Y *= scaleNumber;
            }
            else
                MessageBox.Show("Stop increasing");
        }

        public  virtual void Draw(Graphics graph, Pen pen) { }
    }
}

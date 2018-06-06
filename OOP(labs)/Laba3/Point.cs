using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laba3
{
    public class Point : Figure
    {
        public Point(float x, float y) : base(x, y) { }

        public override string ToString()
        {
            return MessageBox.Show($"Class: point \na={X} \nb={Y}");
        }

    }
}

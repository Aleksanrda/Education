using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Pen pen;
        Pen penSh;
        Graphics graph;
        Point point;
        Polygon polygon;
        PolygonColor polygonColor;
        PolygonRegular polygonRegular;
        Pyramid pyramid;
        Prism prism;
        public Form1()
        {
            InitializeComponent();
            Init();
            Draw();
        }

        public void Init()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bmp);
            pen = new Pen(Color.Black);
            penSh = new Pen(Color.Black);
            penSh.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            point = new Point(150, 30);
            Point[] points = { new Point(0, 0), new Point(50, 30), new Point(40, 60) };
            polygon = new Polygon(250, 130, points); 
            polygonColor = new PolygonColor(30, 90, "red", points); 
            polygonRegular = new PolygonRegular(new Point(300, 500), 5, 5, 10, 200, points);
            pyramid = new Pyramid(330, 90, 430, 90, 300, 120, 400, 120);
            prism = new Prism(30, 90, 120, 90, 10, 120, 100, 120);
            
        }

        public virtual void Draw()
        {
            PointF[] pointsF = { new PointF(0, 0), new PointF(50, 30), new PointF(30, 60) };
            graph.DrawPolygon(penSh, pointsF);
            PointF[] pointsF2 = { new PointF(190, 200), new PointF(76, 30), new PointF(56, 89) };
            graph.DrawPolygon(pen, pointsF2);
            graph.FillPolygon(Brushes.GreenYellow, pointsF2);
            if (comboBox1.Text == "Point")
            {
                graph.DrawRectangle(penSh, point.X, point.Y, 0, 0);
            }

            else if (comboBox1.Text == "Polygon")
        {
            graph.DrawPolygon(penSh, pointsF);
        }
            else if (comboBox1.Text == "PolygonRegular")
                polygonRegular.Draw(graph, pen);
            else if (comboBox1.Text == "PolygonColor")
            {
                graph.DrawPolygon(pen, pointsF);
                graph.FillPolygon(Brushes.Red, pointsF);

            }

            else if (comboBox1.Text == "Pyramid")
            {
                graph.DrawLine(penSh, pyramid.X, pyramid.Y, pyramid.X2, pyramid.Y2);
                graph.DrawLine(penSh, pyramid.X, pyramid.Y, pyramid.X3, pyramid.Y3);
                graph.DrawLine(penSh, pyramid.X3, pyramid.Y3, pyramid.X4, pyramid.Y4);
                graph.DrawLine(penSh, pyramid.X4, pyramid.Y4, pyramid.X2, pyramid.Y2);
            }


            else if (comboBox1.Text == "Prism")
            {
                graph.DrawLine(pen, prism.X, prism.Y, prism.X2, prism.Y2);
                graph.DrawLine(pen, prism.X, prism.Y, prism.X3, prism.Y3);
                graph.DrawLine(pen, prism.X3, prism.Y3, prism.X4, prism.Y4);
                graph.DrawLine(pen, prism.X4, prism.Y4, prism.X2, prism.Y2);
            }

            else
            {
                var figure = new List<Figure>
        {
            point, polygon, polygonColor, polygonRegular, pyramid,prism
        };

                foreach (var figures in figure)
                {
                    figures.Draw(graph, pen);
                }
            }
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Point")
                MessageBox.Show($"Point= {point.Square()}");
            else if (comboBox1.Text == "Polygon")
                MessageBox.Show($"Polygon= {polygon.Square()}");
            else if (comboBox1.Text == "PolygonColor")
                MessageBox.Show($"Polygon color= {polygonColor.Square()}");
            else if (comboBox1.Text == "PolygonRegular")
                MessageBox.Show($"Regular polygon= {polygonRegular.Square()}");
            else if (comboBox1.Text == "Pyramid")
                MessageBox.Show($"Pyramid= {pyramid.Square()}");
            else if (comboBox1.Text == "Prism")
                MessageBox.Show($"Prism= {prism.Square()}");
            else if (comboBox1.Text == "Figure")
            {
                var figure = new List<Figure>
        {
            point, polygon, polygonColor, polygonRegular, prism, pyramid
        };
                MessageBox.Show($"Sum square= { point.Square() + polygon.Square() + polygonColor.Square() + polygonRegular.Square() + prism.Square() + pyramid.Square()}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Point")
            {
                Draw();
                graph.Clear(Color.White);
                point.Move();
                Draw();
            }
            else if (comboBox1.Text == "Polygon")
            {
                graph.Clear(Color.White);
                polygon.Move();
                Draw();
            }
            else if (comboBox1.Text == "PolygonColor")
            {
                graph.Clear(Color.White);
                polygonColor.Move();
                Draw();
            }
            else if (comboBox1.Text == "PolygonRegular")
            {
                graph.Clear(Color.White);
                polygonRegular.Move();
                Draw();
            }
            else if (comboBox1.Text == "Pyramid")
            {
                graph.Clear(Color.White);
                pyramid.Move();
                Draw();
            }
            else if (comboBox1.Text == "Prism")
            {
                graph.Clear(Color.White);
                prism.Move();
                Draw();
            }
            else if (comboBox1.Text == "Figure")
            {
                var figure = new List<Figure>
        {
            point, polygon, polygonColor, polygonRegular, pyramid, prism
        };
                foreach (var figures in figure)
                {
                    graph.Clear(Color.White);
                    figures.Move();
                }


                Draw();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Point")
                MessageBox.Show($"Point= {point.Perimeter()}");
            else if (comboBox1.Text == "Polygon")
                MessageBox.Show($"Polygon= {polygon.Perimeter()}");
            else if (comboBox1.Text == "PolygonColor")
                MessageBox.Show($"Polygon color= {polygonColor.Perimeter()}");
            else if (comboBox1.Text == "PolygonRegular")
                MessageBox.Show($"Regular polygon= {polygonRegular.Perimeter()}");
            else if (comboBox1.Text == "Pyramid")
                MessageBox.Show($"Pyramid= {pyramid.Perimeter()}");
            else if (comboBox1.Text == "Prism")
                MessageBox.Show($"Prism= {prism.Perimeter()}");
            else if (comboBox1.Text == "Figure")
            {
                var figure = new List<Figure>
        {
            point, polygon, polygonColor, polygonRegular, prism, pyramid
        };
                MessageBox.Show($"Sum perimeters= { point.Perimeter() + polygon.Perimeter() + polygonColor.Perimeter() + polygonRegular.Perimeter() + prism.Perimeter() + pyramid.Perimeter()}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Point")
            {
                graph.Clear(Color.White);
                point.Scale();
                Draw();
            }
            else if (comboBox1.Text == "Polygon")
            {
                graph.Clear(Color.White);
                polygon.Scale();
                Draw();
            }
            else if (comboBox1.Text == "PolygonColor")
            {
                graph.Clear(Color.White);
                polygonColor.Scale();
                Draw();
            }
            else if (comboBox1.Text == "PolygonRegular")
            {
                graph.Clear(Color.White);
                polygonRegular.Scale();
                Draw();
            }
            else if (comboBox1.Text == "Prism")
            {
                graph.Clear(Color.White);
                prism.Scale();
                Draw();
            }
            else if (comboBox1.Text == "Pyramid")
            {
                graph.Clear(Color.White);
                pyramid.Scale();
                Draw();
            }
            else if (comboBox1.Text == "Figure")
            {
                MessageBox.Show("Sorry :( ");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Point")
               MessageBox.Show(point.ToString());
            else if (comboBox1.Text == "Polygon")
                MessageBox.Show(polygon.ToString());
            else if (comboBox1.Text == "PolygonColor")
                MessageBox.Show(polygonColor.ToString());
            else if (comboBox1.Text == "PolygonRegular")
                MessageBox.Show(polygonRegular.ToString());
            else if (comboBox1.Text == "Pyramid")
                MessageBox.Show(pyramid.ToString());
            else if (comboBox1.Text == "Prism")
                MessageBox.Show(prism.ToString());
            else if (comboBox1.Text == "Figure")
            {
                MessageBox.Show("Picture consist of point, polygon, polygonColor and polygonRegular");
            }
        }
    }
}

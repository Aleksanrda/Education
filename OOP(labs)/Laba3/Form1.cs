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
            polygon = new Polygon(250, 130); //массив точкек
            polygonColor = new PolygonColor(30, 90, "red"); //массив точкек
            polygonRegular = new PolygonRegular(10, 20, );//массив точкек
            pyramid = new Pyramid(330, 90, 430, 90, 300, 120, 400, 120);
            prism = new Prism(30, 90, 120, 90, 10, 120, 100, 120);
        }

        public virtual void Draw()
        {
            if (comboBox1.Text == "Point")
            {
                graph.DrawRectangle(pen, point.X, point.Y, 0, 0);
            }

            else if (comboBox1.Text == "Polygon")
                graph.DrawRectangle(pen, polygon.X, polygon.Y)
            else if (comboBox1.Text == "PolygonRegular")
                graph.DrawRectangle(pen, polygonRegular.X, polygonRegular.Y); //
            else if (comboBox1.Text == "PolygonColor")//////
                graph.DrawRectangle(pen, polygonColor.X, polygonColor.Y);
            else if (comboBox1.Text == "Piramid")
            {
                graph.DrawLine(penSh, pyramid.X, pyramid.Y, pyramid.x2, pyramid.y2);
                graph.DrawLine(penSh, pyramid.X, pyramid.Y, pyramid.x3, pyramid.y3);
                graph.DrawLine(penSh, pyramid.x3, pyramid.y3, pyramid.x4, pyramid.y4);
                graph.DrawLine(penSh, pyramid.x4, pyramid.y4, pyramid.x2, pyramid.y2);
            }


            else if (comboBox1.Text == "Prism")
            {
                graph.DrawLine(pen, prism.X, prism.Y, prism.x2, prism.y2);
                graph.DrawLine(pen, prism.X, prism.Y, prism.x3, prism.y3);
                graph.DrawLine(pen, prism.x3, prism.y3, prism.x4, prism.y4);
                graph.DrawLine(pen, prism.x4, prism.y4, prism.x2, prism.y2);
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
            else if (comboBox1.Text == "PolygonRegulaar")
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
            else if (comboBox1.Text == "All")
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
                point.ToString();
            else if (comboBox1.Text == "Polygon")
                polygon.ToString();
            else if (comboBox1.Text == "PolygonColor")
                polygonColor.ToString();
            else if (comboBox1.Text == "PolygonRegular")
                polygonRegular.ToString();
            else if (comboBox1.Text == "Pyramid")
                pyramid.ToString();
            else if (comboBox1.Text == "Prism")
                prism.ToString();
            else if (comboBox1.Text == "Figure")
            {
                MessageBox.Show("Picture consist of point, polygon, polygonColor and polygonRegular");
            }
        }
    }
}

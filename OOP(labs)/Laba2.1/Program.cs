using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Класс "Отрезок" на 3
//Объявите класс «Отрезок», с полями x1, y1, x2, y2(координаты двух точек отрезка), +
//методами для перемещения отрезка,- вывода на экран, проверки попадания обоих точек в одинаковый квадрант,+ 
//и свойством для получения длины отрезка.+

//скрытые поля, конструкторы с параметрами и без параметров, методы, свойства.Методы и свойства должны обеспечивать непротиворечивый,
//полный, минимальный и удобный интерфейс класса.Проверяйте допустимость значений параметров перед выполнением кода методов.

namespace Laba2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SegmentUI segmentUI = new SegmentUI();

                Console.WriteLine("1 - Get information about length of segment ");

                Console.WriteLine("2 - You can move segment");

                Console.WriteLine("3 - You can check if points are in square");

                Console.WriteLine("4 - You can take data of coordinates");

                Console.WriteLine("5 - exit");

                int inputNumber = 0;
                while (inputNumber != 5)
                {
                    Console.WriteLine("Input one of number to get information you want, please ");

                    bool result = int.TryParse(Console.ReadLine(), out inputNumber);

                    while (result == false)
                    {
                        Console.WriteLine("Not valid");
                        Console.WriteLine("You input wrong data, please try enter number again");
                        result = int.TryParse(Console.ReadLine(), out inputNumber);
                    }

                    while (inputNumber < 1 && inputNumber > 5)
                    {
                        Console.WriteLine("You input wrong number, please enter number again");
                        result = int.TryParse(Console.ReadLine(), out inputNumber);
                    }

                    if (inputNumber == 1)
                    {
                        segmentUI.OutputGetLengthSegment();
                    }

                    else if (inputNumber == 2)
                    {
                        segmentUI.OutputMoveSegment();
                    }

                    else if (inputNumber == 3)
                    {

                        segmentUI.OutputCheckHitPointInSquare();
                    }

                    else if (inputNumber == 4)
                    {
                        segmentUI.OutputDisplayCoordinatesOfSegment();
                    }

                }

            }
            catch
            {
                Console.WriteLine("Error");
                Console.Read();
            }
        }
    }
}

















//public class Polygon
//{
//    private Point[] points;
//    private double Length(Point[] points)
//    {
//        double perimetr = 0;
//        for (int i = 0; i < points.Length - 2; i++)
//        {
//            var p1 = points[i];
//            var p2 = points[i + 1];
//            perimetr += Math.Sqrt(Math.Pow((double)points[i].X - (double)points[i + 1].X, 2) + Math.Pow((double)p1.Y - (double)p2.Y, 2));
//        }
//        return perimetr;
//    }

//    public double P { get { return Length(points); } }
//    public int N { get { return points.Length; } }
//    public Polygon(params Point[] points)
//    {
//        this.points = points;
//    }
//    public override string ToString()
//    {
//        return "Polygon:" + N;
//    }
//}
//public class Triangle : Polygon
//{
//    public Triangle(Point a, Point b, Point c) : base(a, b, c) { }

//    public override string ToString()
//    {
//        return "Triangle:" + base.N;
//    }
//}
//public class Square : Polygon
//{
//    public Square(Point a, Point b) : base(a, b) { }
//    public override string ToString()
//    {
//        return "Square:" + base.N;
//    }
//}public bool Intersect(BaseRect other)
//    {
//        if ((
//                       (this.x >= other.x && this.x <= other.w) || (this.w >= other.x && this.w <= other.w)
//                     ) && (
//                       (this.y >= other.y && this.y <= other.h) || (this.h >= other.y && this.h <= other.h)
//                     )
//                   || (
//                     (
//                       (other.x >= this.x && other.x <= this.w) || (other.w >= this.x && other.w <= this.w)
//                     ) && (
//                       (other.y >= this.y && other.y <= this.h) || (other.h >= this.y && other.h <= this.h)
//                     )
//                   )
//         ||
//           (
//             (
//               (this.x >= other.x && this.x <= other.w) || (this.w >= other.x && this.w <= other.w)
//             ) && (
//               (other.y >= this.y && other.y <= this.h) || (other.h >= this.y && other.h <= this.h)
//             )
//           ) || (
//             (
//               (other.x >= this.x && other.x <= this.w) || (other.w >= this.x && other.w <= this.w)
//             ) && (
//               (this.y >= other.y && this.y <= other.h) || (this.h >= other.y && this.h <= other.h)
//             )
//           ))
//        {
//    return true;
//}
//        return false;
//}
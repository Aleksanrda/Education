using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2._1
{
    public class Segment
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }

        public Segment(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public Segment()
        {
            X1 = 2;
            Y1 = 0;
            X2 = 0;
            Y2 = 2;
        }

        public double GetLengthSegment
        {
            get
            {
                return Math.Sqrt(Math.Pow((X1 - X2), 2) + Math.Pow((Y1 - Y2), 2));
            }

        }

        public void MoveSegment(int numberMove)
        {
            X1 += numberMove;
            Y1 += numberMove;
            X2 += numberMove;
            Y2 += numberMove;
        }

        //public void DisplaySegment() //
        //{
        //    // Bitmap img = new Bitmap(100, 100);
        //}

        Square firstSquare = new Square(); //??????????

        public bool CheckHitPointsInSquare()
        {
            if (X1 > firstSquare.X && X1 < firstSquare.W && Y1 > firstSquare.Y && Y1 < firstSquare.W
                && X2 > firstSquare.X && X2 < firstSquare.W && Y2 > firstSquare.Y && Y2 < firstSquare.W)
            {
                return true;
            }

            return false;
        }
    }
}



























//public void Save()
//{
//    string path = @"OOP(labs).txt"; /* Объявляем строковую переменную "path", 
//                                 * которая описывает путь к файлу */
//    string text = "";

//    try
//    {
//        Console.WriteLine();
//        Console.WriteLine("******считываем построчно********");
//        using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
//        {
//            string line;
//            while ((line = sr.ReadLine()) != null)
//            {
//                Console.WriteLine(line);
//            }
//            //sr.Close();
//        }

//        using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
//        {
//            sw.WriteLine(text);
//        }

//    }
//    catch
//    {
//        Console.WriteLine("Error");
//        Console.ReadKey();
//    }
//}
//public void Exit()
//{
//    Console.WriteLine("If you are sure, you want exit: write exit");
//    string keyWord = Console.ReadLine();
//    hostelManager.GetExit(keyWord);
//}

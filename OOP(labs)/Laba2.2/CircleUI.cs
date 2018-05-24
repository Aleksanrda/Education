using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2._2
{
    class CircleUI
    {
        private Circle circleUI;

        public CircleUI()
        {
            circleUI = new Circle();
        }

        public void OutputCircleLength()
        {
            double circleLength = circleUI.CircleLength;
            Console.WriteLine(circleLength);
        }

        public void OutputCircleSquare()
        {
            double circleSquare = circleUI.SquareOfCircle;
            Console.WriteLine(circleSquare);
        }

        public void OutputCheckPointInCircle()
        {
            bool result = circleUI.CheckPointInCircle();
            Console.WriteLine(result);
        }

        public void OutputMoveCircle()
        {
            int inputNumber = 0;
            Console.Write("Input number, please ");
            bool result = int.TryParse(Console.ReadLine(), out inputNumber);

            while (result == false)
            {
                Console.WriteLine("Not valid");
                Console.WriteLine("You input wrong data, please try enter number again");
                result = int.TryParse(Console.ReadLine(), out inputNumber);
            }

            circleUI.MoveCircle(inputNumber);
            OutputCircleData();
        }

        public void OutputScaling()
        {
            int inputNumber = 0;
            Console.Write("Input number, please ");
            bool result = int.TryParse(Console.ReadLine(), out inputNumber);

            while (result == false)
            {
                Console.WriteLine("Not valid");
                Console.WriteLine("You input wrong data, please try enter number again");
                result = int.TryParse(Console.ReadLine(), out inputNumber);
            }

            if (inputNumber <= 0)
            {
                throw new ArgumentException("Input number can not be negative number or equal 0");
                //error message
            }
            else
            {
                circleUI.Scaling(inputNumber);
                OutputCircleData();
            }

        }

        public void OutputCheckIsIntersect() 
        {
            Console.Write("Input (X.Y.R), please ");
            string[] coordinates = Console.ReadLine().Split('.');

            while (coordinates[0] == "" && coordinates[1] == "" && coordinates[2] == "")
            {
                Console.WriteLine("Not valid");
                Console.WriteLine("You input wrong data, please try enter number again");
                coordinates = Console.ReadLine().Split('.');
            }

            var circle2 = new Circle(int.Parse(coordinates[0]), int.Parse(coordinates[1]), int.Parse(coordinates[2]));

            bool result = circleUI.CheckIsIntersect(circle2);
            Console.WriteLine(result);
        }

        public void OutputCircleData()
        {
            Console.Write(circleUI.X1);
            Console.Write(" ");
            Console.Write(circleUI.Y1);
            Console.Write(" ");
            Console.WriteLine(circleUI.R);
        }

    }
}

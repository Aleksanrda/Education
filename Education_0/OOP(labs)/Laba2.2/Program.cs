using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2._2
{
    class Program
    {
        static void Main(string[] args)
        {        
            try
            {
                CircleUI circleUI = new CircleUI();

                Console.WriteLine("1 - Get information about length of circle ");

                Console.WriteLine("2 - Get information about square of circle");

                Console.WriteLine("3 - You can check if point is in circle");

                Console.WriteLine("4 - You can move circle");

                Console.WriteLine("5 - You can increase circle");

                Console.WriteLine("6 - You can check if first circle intersects with the other");

                Console.WriteLine("7 - exit");

                int inputNumber = 0;
                while (inputNumber != 7)
                {
                    Console.WriteLine("Input one of number to get information you want, please ");

                    bool result = int.TryParse(Console.ReadLine(), out inputNumber);

                    while (!result)
                    {
                        Console.WriteLine("Not valid");
                        Console.WriteLine("You input wrong data, please try enter number again");
                        result = int.TryParse(Console.ReadLine(), out inputNumber);
                    }

                    while (inputNumber < 1 && inputNumber > 6)
                    {
                        Console.WriteLine("You input wrong number, please enter number again");
                        result = int.TryParse(Console.ReadLine(), out inputNumber);
                    }

                    if (inputNumber == 1)
                    {
                        circleUI.OutputCircleLength();
                    }

                    else if (inputNumber == 2)
                    {
                        circleUI.OutputCircleSquare();
                    }

                    else if (inputNumber == 3)
                    {

                        circleUI.OutputCheckPointInCircle();
                    }

                    else if (inputNumber == 4)
                    {
                        circleUI.OutputMoveCircle();
                    }

                    else if (inputNumber == 5)
                    {
                        circleUI.OutputScaling();
                    }

                    else if (inputNumber == 6)
                    {
                        circleUI.OutputCheckIsIntersect();
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

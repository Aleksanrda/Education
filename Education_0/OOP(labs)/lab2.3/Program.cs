using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Объявите класс, который реализует односвязный рекурсивный список 
//Переопределить две любых операции.
//class RList
//{
//    public int info;
//    public RList next;

//    public RList(int i, RList n)
//    {
//        info = i;
//        next = n;
//    }
//}

//1,3 , 5, 10, 16, 22, 37, 38, 53
//Конструктор з одним параметром (число); +++++
//Конструктор копіювання; +++++++++
//Не рекурсивний метод додавання нового елемента останнім у список;++++++++++++++++++++
//Метод додавання нового елементу у список після елемента із заданим значенням;+++++++++++++++++++++++++
//Рекурсивний метод видалення n-ного за рахунком елемента;
//Метод видалення всіх елементів з від'ємними значеннями;+++++++++++++
//Рекурсивний метод друку всіх цілих елементів списку;++++++++++++++++=
//Метод сортування елементів списку за зменшенням числових значень;++++++++++++++++++++
//Індексатор з одним параметром, який дозволяє за значенням елемента знайти його порядковий номер у списку;+++++++++++

namespace lab2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //list.AddLast(-4);
            //list.AddLast(5);
            //list.AddLast(-8);
            //list.AddLast(0);

            try
            {
                UI list = new UI();

                Console.WriteLine("1 - Add element last");

                Console.WriteLine("2 - Add element after some value");

                Console.WriteLine("3 - Delete element");

                Console.WriteLine("4 - Delete negative elements");

                Console.WriteLine("5 - Print integer elements");

                Console.WriteLine("6 - Sort list in descending order");

                Console.WriteLine("7 - Search index using value");

                Console.WriteLine("8 - Print list");

                Console.WriteLine("9 - exit");

                int inputNumber = 0;
                while (inputNumber != 9)
                {
                    Console.WriteLine("Input one of number to get information you want, please ");

                    bool result = int.TryParse(Console.ReadLine(), out inputNumber);

                    while (result == false)
                    {
                        Console.WriteLine("Not valid");
                        Console.WriteLine("You input wrong data, please try enter number again");
                        result = int.TryParse(Console.ReadLine(), out inputNumber);
                    }

                    while (inputNumber < 1 && inputNumber > 9)
                    {
                        Console.WriteLine("You input wrong number, please enter number again");
                        result = int.TryParse(Console.ReadLine(), out inputNumber);
                    }

                    if (inputNumber == 1)
                    {
                        list.OutputAddLast();
                    }

                    else if (inputNumber == 2)
                    {
                        list.OutputAddAfterValue();
                    }

                    else if (inputNumber == 3)
                    {

                        list.OutputDeleteValue();
                    }

                    else if (inputNumber == 4)
                    {
                        list.OutputDeleteNegativeElements();
                    }

                    else if (inputNumber == 5)
                    {
                        list.OutputPrintIntegerNumber();
                    }

                    else if (inputNumber == 6)
                    {
                        list.OutputDescendingSort();
                    }

                    else if(inputNumber == 7)
                    {
                        list.OutputIndex();
                    }

                    else if(inputNumber == 8)
                    {
                        list.OutputPrintList();
                    }

                }

            }
            catch
            {
                Console.WriteLine("Error");
                Console.Read();
            }
            Console.ReadKey();
        }
    }
}

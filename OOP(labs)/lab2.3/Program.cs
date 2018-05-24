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
//Метод видалення всіх елементів з від'ємними значеннями;
//Рекурсивний метод друку всіх цілих елементів списку;
//Метод сортування елементів списку за зменшенням числових значень;
//Індексатор з одним параметром, який дозволяє за значенням елемента знайти його порядковий номер у списку;

namespace lab2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(8);
            list.AddLast(0);
            list.PrintList();
            list.AddAfterValue(10, 5);
            list.PrintList();
            Console.ReadKey();
        }
    }
}

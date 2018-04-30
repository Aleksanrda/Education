using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Atsd
{
    public class List
    {
        private readonly int[] data;
        int capacity = 5;
        int count = 0;
        // private const int _defaultCapacity = 5;
        public List(int capacity)
        {
            if (capacity <= 0)
            {
               throw new ArgumentException("Data is empty");
            }
        }

        public bool IsEmpty(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (count != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsFull(int capacity)
        {
            if (count != capacity)
            {
                return false;
            }
            return true;
        }

        public void AddData(int value)
        {
            if (count <= capacity)
            {
                data[count] = value;
                count++;
            }
        }

        public void DeleteData(int capacity, int value)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (data[i] == value)
                {
                    data[i] = 0;
                    count--;
                    break;
                }
            }
        }

        public bool Contains(int capacity, int value)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (data[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        public int Retrieve(int capacity, int value)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (data[i] == value)
                {
                    return value;
                }
            }
            return -100000;
        }

        public void MakeEmpty(int capacity)
        {
            for (int i = 0; i < count; i++)
            {
                data[i] = 0;
                count--;
            }
        }

        public void PrintData()
        {
            for (int i = 0; i < count; i++)
            {               
                    Console.WriteLine(data[i]);                
            }
        }


        public static void Heapify(int[] data,int pos, int n)
        {
            int temp;
            while (2 * pos + 1 < n)
            {
                int t = 2 * pos + 1; if (2 * pos + 2 < n && data[2 * pos + 2] >= data[t])
                {
                    t = 2 * pos + 2;
                }
                if (data[pos] <data[t]) { temp = data[pos]; data[pos] = data[t]; data[t] = temp; pos = t; } else break;
            }
        }
        public static void HeapMake(int[] data, int count)
        {
            for (int i = count - 1; i >= 0; i--)
            {
                Heapify(data, i, count);
            }
        }
        public static void HeapSort(int[] data, int capaity)
        {       
            int temp;
            // у тебя функция статическая, а поле count не статик.
            HeapMake(data, count);
            while (capaity > 0)
            {
                temp = data[0];
                data[0] = data[capaity - 1];
                data[capaity - 1] = temp;
                capaity--;
                Heapify(data, 0, capaity);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List data = new List(5);
            data.AddData(10);
            data.AddData(5);
            data.AddData(15);
            data.AddData(1);
            data.AddData(90);
            data.PrintData();

            data.HeapSort();
            data.PrintData();
            Console.ReadKey();
        }
    }

}

//public void Heapify(int[] data, int i, int max)
//{
//    int big_index, childLeft, childRight;
//    while (i < max)
//    {
//        big_index = i;
//        childLeft = 2 * i + 1;
//        childRight = childLeft + 1;

//        if (childLeft < max && data[childLeft] > data[big_index])
//        {
//            big_index = childLeft;
//        }
//         if (childRight < max && data[childRight] > data[big_index])
//        {
//            big_index = childRight;
//        }
//        if (big_index == i)
//        {
//            return;
//        }

//        Swap(i, big_index);
//        i = big_index;
//    }
//}

//public void BuildHeap(int[] data)
//{
//    for (int i = capacity / 2 - 1; i >= 0; i--)
//    {
//        Heapify(data, i, capacity); //creates a max heap
//    }


//    //for (int i = count - 1; i >= 0; i--)
//    //{
//    //    Swap(linkedlist.ElementAt(0), linkedlist[i]); //swap first and last node
//    //    Heapify(linkedlist, i, 0);
//    //}
//}

//public int[] HeapSort()
//{
//    BuildHeap(data);
//    var end = capacity - 1;

//    while (end >= 0)
//    {
//        Swap(0, end);
//        Heapify(data, 0, end);
//        end -= 1;
//    }
//    return data;
//}



//public void Swap(int a, int b)
//{
//    int c;
//    c = a;
//    a = b;
//    b = a;

//}
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
        public int[] data;
       // private const int _defaultCapacity = 5;
        public List(int capacity)
        {
            if(capacity <= 0)
            {
                Console.WriteLine("Data is empty");
            }
            else
            {
                data = new int [capacity];
            }
        }

        public bool IsEmpty(int capacity)
        {
            for(int i = 0; i < capacity; i++)
            {
                if(data[i] != 0)
                {
                    return false;
                }               
            }
            return true;
        }

        public bool IsFull(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (data[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }
        int capacity = 5;
        public void AddData(int value)
        {
            for(int i = 0; i < capacity; i++)
            {
                if(data[i] != 0)
                {
                    data[i] = value;
                    break;
                }
            }
        }

        public void DeleteData(int capacity, int value)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (data[i] == value)
                {
                    data[i] = 0;
                    break;
                }
            }
        }

        public bool Contains(int capacity, int value)
        {
            for (int i = 0; i < capacity; i++)
            {
                if(data[i] == value)
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
            for (int i = 0; i < capacity; i++)
            {
                if (data[i] != 0)
                {
                    data[i] = 0;
                }
            }
        }

        public void PrintData()
        {
            for (int i = 0; i < capacity; i++)
            {
                if (data[i] != 0)
                {
                    Console.WriteLine(data[i]);
                }
            }
        }

        public void Heapify(int[] data, int i, int max)
        {
            int big_index, childLeft, childRight;
            while (i < max)
            {
                big_index = i;
                childLeft = 2 * i + 1;
                childRight = childLeft + 1;
                var left = data[childLeft];
                if (childLeft < max && data[childLeft] > data[big_index])
                    big_index = childLeft;

                else if (childRight < max && data[childRight] > data[big_index])
                {
                    big_index = childRight;
                }
                else if (big_index == i)
                {
                    return;
                }

                Swap(i, big_index);
                i = big_index;
            }
        }

        public int[] HeapSort()
        {
            BuildHeap(data,capacity);
            var end = capacity - 1;

            while (end >= 0)
            {
                Swap(0, end);
                Heapify(data, 0, end);
                end -= 1;
            }
            return data;
        }
     
        public void BuildHeap(int[] data, int capacity)
        {
            for (int i = capacity / 2 - 1; i >= 0; i--)
            {
                Heapify(data, i, capacity); //creates a max heap
            }
            //for (int i = count - 1; i >= 0; i--)
            //{
            //    Swap(linkedlist.ElementAt(0), linkedlist[i]); //swap first and last node
            //    Heapify(linkedlist, i, 0);
            //}
        }

        public  void Swap(int a, int b)
        {
            int c;
            c = a;
            a = b;
            b = a;

        }

    }

    class program
    {
       static void main(string[] args)
        {
            List data = new List(5);
            data.AddData(10);
            data.AddData(5);
            data.AddData(15);
            data.AddData(24);
            data.AddData(90);
            data.PrintData();

            data.HeapSort();
            data.PrintData();
            Console.ReadKey();
        }
    }

















    //public class Node //класс узла, который представляет одиночный объект в списке
    //{
    //    public Node(int data)
    //    {
    //        Data = data;
    //    }

    //    public int Data { get; set; }

    //    public Node Next { get; set; }
    //}

    //public class LinkedList  //односвязный список
    //{
    //    Node head; //головной, первый элемент
    //    Node tail; //последний, хвостовой элемент
    //    int count;

    //   
    //    public void Add(int data) //List unsorted: item is always inserted at the end of a list.
    //    {
    //        Node current = head;
    //        Node newElement = new Node(data);

    //        if (head == null)
    //        {
    //            head = newElement;
    //        }
    //        else
    //        {
    //            tail.Next = newElement;
    //        }

    //        tail = newElement;
    //        count++;
    //    }
    //    public bool Remove(int data) //удаление элемента
    //    {
    //        Node current = head;
    //        Node previous = null;

    //        while (current != null)
    //        {
    //            if (current.Data == data)
    //            {
    //                if (previous != null) //если узел в середине или конце
    //                {
    //                    previous.Next = current.Next; //

    //                    if (current.Next == null)
    //                    {
    //                        tail = previous;
    //                    }
    //                }
    //                else
    //                {
    //                    head = head.Next;

    //                    if (head == null)
    //                    {
    //                        tail = null;
    //                    }

    //                }
    //                count--;
    //                return true;
    //            }

    //            previous = current;
    //            current = current.Next;

    //        }

    //        return false;
    //    }

    //    public int Count { get { return count; } } // list size
    //    public bool IsEmpty { get { return count == 0; } }

    //    public void clear() // make empty
    //    {
    //        head = null;
    //        tail = null;
    //        count = 0;
    //    }

    //    public bool IsFull()
    //    {
    //        bool result = false;
    //        Node current = head;

    //        if (current == null)
    //        {
    //            return true;
    //        }

    //        return result;
    //    }

    //    public bool Contains(int data) //проверяет наличие элемента
    //    {
    //        Node current = head;
    //        while (current != null)
    //        {

    //            if (current.Data == data)
    //            {
    //                return true;
    //            }

    //            current = current.Next;
    //        }

    //        return false;
    //    }

    //    public int Retrieve(int item)
    //    {
    //        Node current = head;
    //        while (current != null)
    //        {
    //            if (current.Data == item)
    //            {
    //                return current.Data;
    //            }
    //            else
    //            {
    //                current = current.Next;
    //            }
    //        }
    //        Console.WriteLine("item was not found, was not retrieved");
    //        return -10000;
    //    }

    //    public void PrintList()
    //    {
    //        if (count == 0)
    //        {
    //            Console.WriteLine("list is empty");
    //        }
    //        Node current = head;
    //        while (current != null)
    //        {

    //            Console.Write(current.Data);
    //            Console.Write(" ");
    //            current = current.Next;
    //        }
    //        Console.WriteLine();
    //    }
    //}



}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Atsd
{

    public class Node //класс узла, который представляет одиночный объект в списке
    {
        public Node(int data)
        {
            Data = data;
        }

        public int Data { get; set; }

        public Node Next { get; set; }
    }

    public class LinkedList  //односвязный список
    {
        Node head; //головной, первый элемент
        Node tail; //последний, хвостовой элемент
        int count;
        public bool Remove(int data) //удаление элемента
        {
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.Data == data)
                {
                    if (previous != null) //если узел в середине или конце
                    {
                        previous.Next = current.Next; //

                        if (current.Next == null)
                        {
                            tail = previous;
                        }
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                        {
                            tail = null;
                        }

                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;

            }

            return false;
        }

        public int Count { get { return count; } } // list size
        public bool IsEmpty { get { return count == 0; } }

        public void clear() // make empty
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool IsFull()
        {
            bool result = false;
            Node current = head;

            if(current == null)
            {
                return true;
            }

            return result;
        }

        public bool Contains(int data) //проверяет наличие элемента
        {
            Node current = head;
            while (current != null)
            {

                if (current.Data == data )
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public int Retrieve(int item)
        {
            Node current = head;
            while(current != null)
            {
                if(current.Data == item)
                {
                    return current.Data;
                }
                else
                {
                    current = current.Next;
                }
            }
            Console.WriteLine("item was not found, was not retrieved");
            return -10000;
        }
      
        public void AppendFirst(int data) //добавляет с начала списка
        {
            Node node = new Node(data);
            Node current = head;
          
            if (head == null)
            {
                head = node;
            }

            else if (data < head.Data)
            {

                // there is something in the list
                // now check to see if it belongs in front
                // System.out.println("add "+item +"before"+head.item);
                node.Next = head;
                head = node;
            }
            else
            {
                // otherwise, step down the list.  n will stop
                // at the node after the new node, and trailer will
                // stop at the node before the new node
                Node after = head.Next;
                Node before = head;
                while (after != null)
                {
                    if (data <after.Data )
                    {
                        break;
                    }
                    before = after;
                    after = after.Next;
                }
                // insert between before & after
                node.Next = before.Next;
                before.Next = node;



                count++;
            }
        }

        public void PrintList()
        {
            if (count == 0)
            {
                Console.WriteLine("list is empty");
            }
            Node current = head;
            while (current != null)
            {

                Console.Write(current.Data);
                Console.Write(" ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void GetSplitLinked(int loc)
        {
 
            LinkedList linkedlistFirst = new LinkedList();
            LinkedList linkedlistSecond = new LinkedList();

            if (head == null)
            {
                Console.WriteLine("list is empty");
            }

            Node current = head;

            for (int i = 0; i < loc; i++ )
            {
                linkedlistFirst.AppendFirst(current.Data);    
                current = current.Next;
                                
            }
            linkedlistFirst.PrintList();

            while (current != null)
            {
                linkedlistSecond.AppendFirst(current.Data);
                current = current.Next;
            }

            linkedlistSecond.PrintList();
        }

        public void GetCopyPartLinked(int k, int j)
        {
            LinkedList linkedlistСopy = new LinkedList();
            if (head == null)
            {
                Console.WriteLine("list is empty");
            }

            Node current = head;
          
            for(int i = 0; i < j+1; i++)
            {
                if(i > k-1)
                {
                    linkedlistСopy.AppendFirst(current.Data);
                    current = current.Next;
                }
                else
                {
                    current = current.Next;
                }
            }

            linkedlistСopy.PrintList();
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedlist = new LinkedList();
           
            linkedlist.AppendFirst(10);
            
            linkedlist.AppendFirst(30);

            linkedlist.AppendFirst(50);

            linkedlist.AppendFirst(40);

            linkedlist.AppendFirst(20);
            linkedlist.PrintList();

            linkedlist.GetSplitLinked(3);

            linkedlist.GetCopyPartLinked(1, 3);

            linkedlist.Remove(10);
            linkedlist.PrintList();
            Console.ReadKey();
        }
    }
}

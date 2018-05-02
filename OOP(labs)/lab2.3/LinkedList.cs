using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2._3
{
    class LinkedList
    {   //односвязный список

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

            if (current == null)
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

                if (current.Data == data)
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
            while (current != null)
            {
                if (current.Data == item)
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

        public void AppendFirst(int data) //добавляет с конца
        {
            Node node = new Node(data);
            Node current = head;

            if (head == null)
            {
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

    }
}

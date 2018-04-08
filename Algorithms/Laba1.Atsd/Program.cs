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

    public class LinkedList //: IEnumerable //односвязный список
    {
        Node head; //головной, первый элемент
        Node tail; //последний, хвостовой элемент
        int count;


        public void AddLast(int data)  //добавление элемента
        {

            Node node = new Node(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }

            tail = node;
            count++;
        }

        public bool Remove(int data) //удаление элемента
        {
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
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

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(int data) //проверяет наличие элемента
        {
            Node current = head;
            while (current != null)
            {

                if (current.Data.Equals(data))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        //      else {
        //	Node* previous = NULL, *following = first;
        //	while (following != NULL && following->data<item) {
        //		previous = following;
        //		following = following->next;
        //	}
        //	if (previous == NULL)
        //		first = new Node(item, first);
        //	else previous->next = new Node(item, following);
        //  count++;
        //}

        public void AppendFirst(int data) //добавляет с начала списка
        {
            Node node = new Node(data);
            Node current = head;
            var x = new object();
            var y = new object();

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
                    if (data.compareTo(after.data) < 0)
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

                Console.WriteLine(current);

                current = current.Next;
            }
        }




        public void Reverse(LinkedList<int> linkedlist)
        {
            if (head == null)
            {
                Console.WriteLine("list is empty");
            }
            while (head != null)
            {
                LinkedList<int> start = linkedlist.Head;

            }

        }



        public void ReverseCopy(LinkedList<int> linkedlist)
        {
            LinkedList<int> linkedlist1 = new LinkedList<int>();

            if (head == null)
            {
                Console.WriteLine("list is empty");
            }
            while (head != null)
            {
                linkedlist1.AddLast()
            }

        }












        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return ((IEnumerable)this).GetEnumerator();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    Node current = head;
        //    while (current != null)
        //    {
        //        yield return current.Data;
        //        current = current.Next;
        //    }
        //}

    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedlist = new LinkedList<int>();




            linkedlist.AddLast(10);
            linkedlist.PrintList();
            linkedlist.AddLast(50);

            linkedlist.AddLast(35);
            linkedlist.AddLast(60);


            Console.ReadKey();
        }
    }
}
//void List::printList()
//{
//    cout << "List content:\n";
//    if (count == 0)
//        cout << "list is empty.\n";
//    Node* p = first;
//    while (p != NULL)
//    {
//        cout << p->data << ", ";
//        p = p->next;
//    }//while
//    cout << endl;
//}//printList
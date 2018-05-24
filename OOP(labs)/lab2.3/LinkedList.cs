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

        public bool Contains(double data) //проверяет наличие элемента
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

        public double Retrieve(double item)
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

        //Не рекурсивний метод додавання нового елемента останнім у список;
        public void AddLast(double data)
        {
            Node node = new Node(data);

            if (head == null)
            {
                head = node;
            }

            else
            {
                Node after = head.Next;
                Node before = head;
                while (after != null)
                {
                    before = after;
                    after = after.Next;
                }

                node.Next = before.Next;
                before.Next = node;
            }

            count++;
        }

        //Метод додавання нового елементу у список після елемента із заданим значенням;
        public void AddAfterValue(double insertData, double value)
        {
            Node node = new Node(insertData);

            if (head == null)
            {
                head = node;
            }

            else
            {
                Node after = head.Next;
                Node before = head;
                while (after != null)
                {
                    if (value == before.Data)
                    {
                        break;
                    }
                // insert between before & after
                    before = after;
                    after = after.Next;
                }
                node.Next = before.Next;
                before.Next = node;
            }

            count++;
        }

        //Рекурсивний метод видалення n-ного за рахунком елемента;
        public void DeleteValue(int index) //------------------------
        {

        }

        //Метод видалення всіх елементів з від'ємними значеннями;
        public void DeleteNegativeElements()
        {

            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.Data < 0)
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;

                }

                previous = current;
                current = current.Next;
            }

        }

        //Рекурсивний метод друку всіх цілих елементів списку;
        public void PrintIntegerNumber()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                PrintIntegerNumber_Rec(head);
            }

        }

        private void PrintIntegerNumber_Rec(Node temp)
        {
            if (temp != null)
            {
                int g = (int)temp.Data;
                if (temp.Data - g == 0)
                {
                    Console.Write(temp.Data);
                    Console.Write(" ");
                    PrintIntegerNumber_Rec(temp.Next);
                }
                else
                {
                    PrintIntegerNumber_Rec(temp.Next);
                }
            }

        }

        //Метод сортування елементів списку за зменшенням числових значень;
        public void DescendingSort()
        {
            Node temp;
            Node previous = null;
            bool flag = false;
            Node current = head;

            if (head == null)
            {
                throw new ArgumentException("List is empty");
            }

            else
            {
                do
                {
                    flag = false;
                    current = head;

                    while (current.Next != null)
                    {
                        if (current.Data < current.Next.Data)
                        {
                            if (current == head)
                            {
                                temp = current;
                                current = current.Next;
                                temp.Next = current.Next;
                                current.Next = temp;
                                head = current;
                                flag = true;
                            }
                            else
                            {
                                temp = current;
                                current = temp.Next;
                                temp.Next = current.Next;
                                current.Next = temp;
                                previous.Next = current;
                                flag = true;
                            }
                        }
                        previous = current;
                        current = current.Next;
                    }

                }
                while (flag);
            }
        }

        //Індексатор з одним параметром, який дозволяє за значенням елемента знайти його порядковий номер у списку;
        public int this [int value]
        {
            get
            {
                if(head == null)
                {
                    throw new ArgumentException("List is empty");
                }

                for (int i = 1; i <= count; i++)
                {
                    if (head.Data == value)
                    {
                        return i;
                    }
                    else
                    {
                        head = head.Next;
                    }
                   
                }

                return -1000000;
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

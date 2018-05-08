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

        public List(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Data is empty");
            }

            data = new int[capacity];
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public bool IsFull()
        {
            return count == capacity;
        }

        public void AddData(int value)
        {
            if (count <= capacity)
            {
                data[count] = value;
                count++;
            }
        }

        public void DeleteData(int value)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (data[i] == value)
                {
                    if (data[i] != data[count - 1])
                    {
                        data[i] = data[count - 1];
                        data[count - 1] = 0;
                    }
                    else
                    {
                        data[i] = 0;
                    }

                    count--;
                    break;
                }
            }
        }

        public bool Search(int value)
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

        public int Retrieve(int value)
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

        public void MakeEmpty()
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
                Console.Write(data[i]);
                Console.Write(" ");
            }
        }

        public void BuildMinHeap() //начиная с позиции 0
        {
            for (int i = (count - 1) / 2; i >= 0; i--)
            {
                MinHeapify(i);
            }

            return;
        }

        public void MinHeapify(int index)
        {
            var left = 2 * index + 1;
            var right = left + 1;

            int Min = index;

            if (right < count && data[right] < data[Min])
            {
                Min = right;
            }

            if (left < count && data[left] < data[index])
            {
                Min = left;
            }

            if (Min != index)
            {
                int temp = data[Min];
                data[Min] = data[index];
                data[index] = temp;
                MinHeapify(Min);
            }

            return;
        }


        public void HeapSortDescendingOrder() //?????????????
        {
            int temp;
            BuildMinHeap();
            while (capacity > 0)
            {
                temp = data[0];
                data[0] = data[capacity - 1];
                data[capacity - 1] = temp;
                capacity--;
                MinHeapify(1);
            }
        }

        private void BuildMaxHeap() //с позиции 1
        {
            for (int i = count / 2; i > 0; i--)
            {
                MaxHeapify(i);
            }

            return;
        }

        public void MaxHeapify(int index)
        {
            var left = 2 * index;
            var right = 2 * index + 1;

            int max = index;
            if (left <= count && data[left - 1] > data[index - 1])
            {
                max = left;
            }

            if (right <= count && data[right - 1] > data[max - 1])
            {
                max = right;
            }

            if (max != index)
            {
                int temp = data[max - 1];
                data[max - 1] = data[index - 1];
                data[index - 1] = temp;
                MaxHeapify(max);
            }

            return;
        }

        public int DeleteTop()
        {
            BuildMaxHeap();
            int maximum = data[0];

            data[0] = data[count - 1];
            count--;
            MaxHeapify(1);
            return maximum;
        }

        public void HeapSortAscendingOrder() //????????????
        {
            int temp;
            BuildMaxHeap();
            while (capacity > 0)
            {
                temp = data[0];
                data[0] = data[capacity - 1];
                data[capacity - 1] = temp;
                capacity--;
                MaxHeapify(1);
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
            data.AddData(100);
            data.AddData(200);
            data.AddData(50);
            data.PrintData();
            Console.WriteLine();

            data.BuildMinHeap();
            data.PrintData();
            Console.WriteLine();

            data.HeapSortAscendingOrder();
            data.PrintData();
            Console.WriteLine();

            data.HeapSortDescendingOrder();
            data.PrintData();
            Console.WriteLine();

            int j = data.DeleteTop();
            Console.WriteLine(j);

            data.PrintData();
            Console.ReadKey();
        }
    }

}

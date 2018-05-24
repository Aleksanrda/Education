using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2._3
{
    public class Node
    {
        public Node(double data) //Конструктор з одним параметром (число);
        {
            Data = data;
        }

        public Node(Node data) // конструктор копирования???????
        {
            Data = data.Data;
        }

        public double Data { get; set; }

        public Node Next { get; set; }
    }
}

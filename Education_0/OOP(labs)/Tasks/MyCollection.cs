using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    //public class MyCollection
    //{
    //    private const int INIT_CAPACITY = 10;
    //    private string[] m;

    //    public MyCollection()
    //    {
    //        m = new string[INIT_CAPACITY];
    //        Count = 0;
    //        Func<IEnumerable<int>, int> r = a =>
    //        {
    //            var sum = 0;
    //            foreach (var item in a)
    //            {
    //                sum += item;
    //            }

    //            return sum;
    //        };
    //    }



    //    public int Count { private set; get; }
    //    public int Capacity { get; set; } /////////////
    //    public string this[int idx]
    //    {
    //        set { m[idx] = value; }
    //        get { return m[idx]; }
    //    }

    //    private string[] Copy()
    //    {
    //        string[] res = new string[m.Length];

    //        for (int i = 0; i < res.Length; i++)
    //        {
    //            res[i] = m[i];
    //        }
    //        return res;
    //    }
    //    private void Extend()
    //    {

    //        string[] res = Copy();
    //        m = new string[res.Length + 1];
    //        for (int i = 0; i < res.Length; i++)
    //            m[i] = res[i];
    //    }

    //    public void Insert(int i, string v)
    //    {

    //        if (Count == m.Length - 1)
    //            Extend();
    //        for (int j = m.Length - 1; j >= i + 1; j--)
    //        {
    //            m[j] = m[j - 1];
    //        }
    //        m[i] = v;
    //        Count++;
    //    }
    //    public void Remove(string v)
    //    {

    //        for (int i = 0; i < m.Length; i++)
    //        {
    //            if (m[i] == v)
    //            {
    //                RemoveAt(i);
    //                break;
    //            }
    //        }
    //    }
    //    public void RemoveAt(int i)
    //    {
    //        if (i >= 0 && i < m.Length)
    //        {
    //            for (int j = i + 1; j < m.Length; j++)
    //                m[j - 1] = m[j];
    //            Count--;

    //        }
    //    }
    //}

    public class P
    {
        public int X { get; }

        public int Y { get; }

        public P(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            P p = obj as P;
            if (p == null)
            {
                return false;
            }
            return (X == p.X) && (Y == p.Y);

        }

        public override int GetHashCode()
        {

            int hashcode = this.GetType().GetHashCode();

            return hashcode;
        }
    }


    class BaseRect
    {
        protected double x;
        protected double y;
        protected double w;
        protected double h;

        public BaseRect(double x, double y, double w, double h)
        {
            this.x = x;
            this.y = y;
            this.h = h;
            this.w = w;
        }

        public bool Intersect(BaseRect other)
        {
            if (((other.x + other.w) <= this.x)
            || ((other.y + other.h) <= this.y)
            || (other.x >= (this.x + this.w))
            || (other.y >= (this.y + this.h)))
            {
                return false;
            }
            return true;
        }
    }
    public class Polygon
    {
        protected Point[] points;
        protected virtual double Length()
        {
            double perimetr = 0;
            for (int i = 0; i < points.Length - 2; i++)
            {
                var p1 = points[i];
                var p2 = points[i + 1];
                perimetr += Math.Sqrt(Math.Pow((double)points[i].X - (double)points[i + 1].X, 2) + Math.Pow((double)p1.Y - (double)p2.Y, 2));
            }
            return perimetr;
        }

        public double P { get { return Length(); } }
        public int N { get { return points.Length; } }
        public Polygon(params Point[] points)
        {
            this.points = points;
        }
        public override string ToString()
        {
            return $"Polygon:{N}";
        }
    }
    public class Triangle : Polygon
    {
        public Triangle(Point a, Point b, Point c) : base(a, b, c) { }

        public override string ToString()
        {
            return "Triangle:" + base.N;
        }
    }
    public class Square : Polygon
    {
        public Square(Point a, Point b) : base(
            a,
            b,
            new Point(b.X, a.Y),
            new Point(b.Y, a.X))
        { }


        public override string ToString()
        {
            return "Square:" + base.N;
        }
    }
    public class Point
    {
        public int X { set; get; }
        public int Y { set; get; }
        public Point(int x, int y) { }
    }

    class CustomException : Exception { }

    //static void T()
    //{
    //    try
    //    {
    //        M();
    //    }
    //    catch (IndexOutOfRangeException)
    //    {
    //        throw new CustomException();
    //    }
    //    catch (ArgumentException)
    //    {
    //        throw new CustomException();
    //    }
    //}


    //delegate double Function(double x);

    //static double SuperFun(double x, params Function[] functions)
    //{
    //    var result = x;
    //    for (var i = 0; i < functions.Length; i++)
    //    {
    //        result = functions[i](result);
    //    }

    //    return result;
    //}

    //static int[] Map(int[] arr, F f)
    //{
    //    int[] array = new int[arr.Length];
    //    for (int i = 0; i < array.Length; i++)
    //    {
    //        int result = f(arr[i]);
    //        array[i] = result;
    //    }
    //    return array;
    //}

    //static int[] Zip(int[] a, int[] b, Func f)
    //{
    //    int[] array = new int[a.Length];
    //    for (int i = 0; i < a.Length; i++)
    //    {
    //        int result = f(a[i], b[i]);
    //        array[i] = result;
    //    }
    //    return array;
    //}

    //delegate bool Pred(int x, int y);
    //static Point[] Join(int[] x, int[] y, Pred p)
    //{
    //    Point[] array = new Point[x.Length * y.Length];
    //    int n = 0;
    //    for (int i = 0; i < x.Length; i++)
    //    {
    //        for (int j = 0; j < y.Length; j++)
    //        {
    //            bool result = p(x[i], y[j]);
    //            if (result)
    //            {
    //                array[n] = new Point { X = x[i], Y = y[j] };
    //                n++;
    //            }
    //        }

    //    }


    //    var tets = new Point[n];
    //    for (var i = 0; i < n; i++)
    //    {
    //        tets[i] = array[i];
    //    }
    //    return tets;
    //}

    class E
    {
        public static event EventHandler StartEvent;
        public event EventHandler FinishEvent;
        public E()
        {
            StartEvent(this, null);
        }
        ~E()
        {
            FinishEvent(this, null);
        }
    }

    //public delegate void MyHandler(int n);

    //public class Counter
    //{
    //    int n;
    //    public int N
    //    {

    //        get
    //        {
    //            return n;
    //        }
    //        set
    //        {
    //            bool primeNumber = true;
    //            for (int i = 2; i <= value / 2; i++)
    //            {
    //                if (value % i == 0 && value == 1)
    //                {
    //                    primeNumber = false;
    //                    break;
    //                }
    //            }
    //            if(primeNumber)
    //            {
    //                Prime(value);
    //            }
    //            n = value;
    //        }
    //    }
    //    public event MyHandler Prime;
    //    public Counter() { }

    //}
    public class MyCollection
    {
        private const int INIT_CAPACITY = 10;
        private string[] m;

        public int Count { private set; get; }
        public int Capacity { get; set; }
        public string this[int idx]
        {
            set { m[idx] = value; }
            get { return m[idx]; }
        }

        private string[] Copy()
        {
            string[] res = new string[m.Length];

            for (int i = 0; i < res.Length; i++)
            {
                res[i] = m[i];
            }
            return res;
        }
        private void Extend()
        {

            string[] res = Copy();
            m = new string[res.Length + 1];
            for (int i = 0; i < res.Length; i++)
                m[i] = res[i];
        }

        public void Insert(int i, string v)
        {

            if (Count == m.Length - 1)
                Extend();
            for (int j = m.Length - 1; j >= i + 1; j--)
            {
                m[j] = m[j - 1];
            }
            m[i] = v;
            Count++;
        }
        public void Remove(string v)
        {

            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] == v)
                {
                    RemoveAt(i);
                    break;
                }
            }
        }
        public void RemoveAt(int i)
        {
            if (i >= 0 && i < m.Length)
            {
                for (int j = i + 1; j < m.Length; j++)
                    m[j - 1] = m[j];
                Count--;

            }
        }
    }


    //Я сравнил со своим


    //Многое не совпадает


    //    В Insert
    //if(Count == m.Length)


    //Потом


    //    B RemoveAt
    //m[Count] = null;

    //В самом конце метода пропиши

    //+ у тебя Capacity никогда не меняется


    //А должно


    //Нет конструктора самого класса MyCollection

    //    Capacity при создании объекта равно INIT_CAPACITY
    //Но если ты используешь метод Extend(), то оно должно увеличиваться на один

    public class Collection<T>
    {
        private T[] arr;
        public int Count { private set; get; }
        public Collection(T[] arr) { this.arr = arr; }

    }

    public bool Remove(T val)
    {
        var item = Head;
        var previous = Head;
        while (true)
        {
            if (item == null)
            {
                return false;
            }
            if ((item.Value.Equals( val)))
            {
                if (item.Next == null)
                {
                    previous.Next = null;
                    return true;
                }
                previous.Next = item.Next;
                return true;
            }
            previous = item;
            item = item.Next;
        }
       
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {

            //var counter = new Counter(5);

            //counter.Prime += x => Console.WriteLine(x);
            //counter.N = 4;
            //counter.N = 3;
            //counter.N = 17;
            //counter.N = 32;
            //counter.N = 33;
            ////2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199
            //counter.N = 1;

            //counter.N = 2;
            //counter.N = 3;
            //counter.N = 5;
            //counter.N = 7;
            //counter.N = 11;
            //counter.N = 13;
            //counter.N = 17;
            //counter.N = 19;
            //counter.N = 23;
            //counter.N = 29;
            //counter.N = 31;
            //counter.N = 59;
            //counter.N = 103;
            //counter.N = 3571;

            var res = NotEquals<int>(7, 8);
            Console.ReadKey();
        }
        static bool NotEquals<T>(T first, T second) where T : IComparable<T>
        {
            if (first.CompareTo(second) == 0)
            {
                return false;
            }
            return true;
        }

        static int IndexOf<T>(T value, T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(value))
                {
                    return i;
                }
                return -1;
            }

        }

        static T Max<T>(T[] m) where T : IComparable
        {
            T max = m[0];
            for (int i = 1; i < m.Length; i++)
            {
                if (m[i].CompareTo(max) > 0)
                {
                    max = m[i];
                }
            }
            return max;
        }

        static T[] Zip<T>(T[] a, T[] b, BinOp<T> op)
        {
            T[] array = new T[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                T result = op(a[i], b[i]);
                array[i] = result;
            }
            return array;
        }

        static R Agregate<T, R>(IEnumerable<T> list, R seed, Func<R, T, R> op)
        {
            R result = seed;
            foreach (T v in list)
            {
                result = op(result, v);
            }
            return result;
        }

        static Func<T1, T3> Super<T1, T2, T3>(Func<T2, T3> f1, Func<T1, T2> f2)
        {
            Func<T1, T3> f = Abrakadabra => f1(f2(Abrakadabra));
            return f;
        }

        public delegate T MyDelegate<T>(T a, T b);


        static List<int> Indexes<T>(List<T> lst, T x)
        {
            int n = 0;
            var col = new List<int>();
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].Equals(x))
                {
                    col[n] = i;
                    n++;
                }
            }
            return col;
        }
    }
    class MyList<T> : List<T>
    {

        public void Except(List<T> z)
        {
            for (int i = 0; i < z.Count; i++)
            {
                for (int j = 0; j < z.Count; j++)
                {
                    if (z[j].GetType() != this[i].GetType())
                    {
                        continue;
                    }
                    if (z[j].Equals(this[i]))
                    {
                        this.Remove(i);
                    }
                }
            }
        }
    }

    class IntCollection : List<int>
    {
        public int Low { get; set; }
        public int Up { get; set; }

        public IntCollection(int low, int up)
        {
            Low = low;
            Up = up;
        }

        public void Add(int item)
        {
            if (item > Low && item < Up)
            {
                base.Add(item);
            }
        }
    }
}

class MyList : CList
{
    public MyList(char data, CList next)
    {
        this.Data = data;
        this.Next = next;
    }

    public virtual string ToString()
    {
        string result = this.Data.ToString();
        var item = this.Next;

        while (true)
        {
            if (item == null)
            {
                break;
            }
            if (item == this)
            {
                break;
            }
            string temp = item.Data.ToString();
            result += temp;
            item = item.Next;
        }
        return result;
    }
}


public delegate void MyHandler(int n);

public class Counter
{
    int n;
    public int N
    {

        get
        {
            return n;
        }
        set
        {
            bool primeNumber = true;
            if (value == 1)
            {
                n = value;
                return;
            }
            for (int i = 2; i <= Math.Sqrt(value); i++)
            {
                if (value % i == 0)
                {
                    primeNumber = false;
                    break;
                }
            }
            if (primeNumber)
            {
                if (Prime != null)
                    Prime(value);
            }
            n = value;
        }
    }
    public event MyHandler Prime;
    public Counter(int n)
    {
        N = n;
    }

}
public delegate void BangHandler(DateTime t);
public class A
{

    public void Fire()
    {
        Bang(DateTime.Now);
    }
    public event BangHandler Bang;
}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale.Turnip.Collections
{
    class TurnipCollection<T> : IEnumerable<T>
    {
        T[] array = null;

        public TurnipCollection()
        {
            array = new T[0];
        }

        public int Count
        {
            get { return array.Length; }
        }

        public void Add(T elem)
        {
            T[] arr = new T[array.Length + 1];
            array.CopyTo(arr, 0);
            arr[arr.Length] = elem;
            array = arr;
        }

        public T this[int index]
        {
            get { return array[index]; }
        }

        int position = -1;

        public void Reset()
        {
            position = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                if (position< array.Length - 1)
                {
                    position++;
                    yield return array[position];
                }
                else
                {
                    Reset();
                    yield break;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}

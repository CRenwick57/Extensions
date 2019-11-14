using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> list, Random rng)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static int CountIf<T>(this IList<T> list, T target)
        {
            int count = 0;
            foreach (T t in list)
            {
                if (t.Equals(target))
                    count++;
            }

            return count;
        }

        public static int CountIfIn<T>(this IList<T> list, T[] target)
        {
            int count = 0;
            foreach (T t in list)
            {
                if (target.Contains(t))
                    count++;
            }
            return count;
        }

        public static int CountIfIn<T>(this IList<T> list, IList<T> target)
        {
            int count = 0;
            foreach (T t in list)
            {
                if (target.Contains(t))
                    count++;
            }
            return count;
        }

        public static T Pop<T>(this IList<T> list, int index = 0)
        {
            T value = list[index];
            list.RemoveAt(index);
            return value;
        }

        public static IList<int> Slice(this IList<int> list, int start, int end = 0, int step = 1)
        {
            IList<int> res = new List<int>();
            if (step == 0)
                step = 1;
            if (step < 0)
            {
                if (end >= start)
                    end = 0;
                for (int i = start; i > end; i += step)
                {
                    res.Add(list[i]);
                }
            }
            else
            {
                if (end <= start)
                    end = list.Count;
                for (int i = start; i < end; i += step)
                    res.Add(list[i]);
            }
            return res;
        }

        public static void Extend<T>(this IList<T> thisList, IList<T> list)
        {
            foreach (T element in list)
                thisList.Add(element);
        }

        public static void Extend<T>(this IList<T> thisList, T[] arr)
        {
            foreach (T element in arr)
                thisList.Add(element);
        }
    }
}

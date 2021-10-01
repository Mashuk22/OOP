using System;

namespace laba4
{
    class Program
    {
        class List
        {
            public static List operator +(List l1, int item)
            {
                return (l1.Add(item));
            }
            public static List operator --(List l1)
            {
                return (l1.RemoveAt(0));
            }
            public static bool operator ==(List l1, List l2)
            {
                return (l1.SequenceEquals(l2));
            }
            public static bool operator !=(List l1, List l2)
            {
                return (!l1.SequenceEquals(l2));
            }
            public static List operator *(List l1, List l2)
            {
                return (l1.Concat(l2));
            }
        }

        static void Main(string[] args)
        {

        }
    }
}

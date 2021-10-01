using System;
using System.Collections.Generic;

namespace laba4
{
    public class List
    {

        public static class Owner
        {
            public static int id = 1;
            public static string name = "Ivan";
            public static string univercity = "BSTU";
        }
        public static class Date
        {
            public static DateTime date = new DateTime(2021, 9, 30);
        }

        public List<string> list;

        public List(List<string> list)
        {
            this.list = list;
        }
        public List()
        {
            list = new List<string>();
        }
        public static void Print(List list)
        {
            for (int item = 0; list.list.Count > item; item++)
            {
                Console.Write(list.list[item] + " ");
            }
            Console.WriteLine();
        }
       
        public static void Test(List l1, List l2)
        {
            l1 = l1 * l2;
            List.Print(l1);
            l1 = l1 + "Spoon";
            List.Print(l1);
            Console.WriteLine(l1 != l2);
            l1--;
            List.Print(l1);
            Console.WriteLine(l1 != l1);
            
            
        }
        
        public static List operator +(List l1, string item)
        {
            l1.list.Insert(0, item);
            return (l1);
        }

        public static List operator ++(List l1)
        {
            return l1;
        }
        public static List operator --(List l1)
        {
            l1.list.RemoveAt(0);
            return (l1);
        }
        public static bool operator !=(List l1, List l2)
        {
            if (l1.list.Count != l2.list.Count)
            {
                return true;
            }
            for (int item = 0; l1.list.Count < item; item++)
            {
                if (l1.list[item] != l2.list[item])
                {
                    return true;
                }
            }
            return (false);
        }
        public static bool operator ==(List l1, List l2)
        {
            return !(l1 != l2);
        }

        public static List operator *(List l1, List l2)
        {
            for (int item = 0; l2.list.Count > item; item++)
            {
                l1.list.Add(l2.list[item]);
            }

            return (l1);
        }
    }

    public static class StatisticOperation
    {
        public static string RanAnim(this string str)
        {
            var rand = new Random();
            
            string[] animArr = { "Cat", "Dog", "Parrot", "mouse", "frog" };
            return (str.Insert(0,animArr[rand.Next(5)]));
        }
        public static void Repeated(this List list)
        {
            List<string> str = new List<string>();
            for (int index = 0; list.list.Count > index; index++)
            {
                if (str.Count == 0)
                {
                    str.Add(list.list[index]);
                    continue;
                }
                for (int strIndex = 0; str.Count > strIndex; strIndex++)
                {
                    if (str[strIndex] == list.list[index])
                    {
                        Console.WriteLine(list.list[index]);
                        break;
                    }
                }
                str.Add(list.list[index]);
            }

        }
        public static int UpperCaseCounter(this List list)
        {
            int counter = 0;
            for (int index = 0; list.list.Count > index; index++)
            {
                if (char.IsUpper(list.list[index][0]))
                {
                    counter++;
                }
            }
            return counter;
        }
        public static int Sum(List l1, List l2)
        {
            Console.WriteLine("Sum");
            return (l1.list.Count + l2.list.Count);
        }
        public static int Diff(List l1, List l2)
        {
            Console.WriteLine("Diff");
            return (+(l1.list.Count - l2.list.Count));
        }
        public static int Lenght(List l1)
        {
            Console.WriteLine("Lenght");
            return (l1.list.Count);
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            List l1 = new List(new List<string> { "Cat", "Dog", "Parrot" });
            List l2 = new List(new List<string> { "Parrot", "mouse", "frog" });

            List.Test(l1, l2);


            Console.WriteLine(StatisticOperation.Sum(l1, l2));
            Console.WriteLine(StatisticOperation.Diff(l1, l2));
            Console.WriteLine(StatisticOperation.Lenght(l1));
            Console.WriteLine("Uppercase words \n" + StatisticOperation.UpperCaseCounter(l1));
            Console.WriteLine("Repeated words");
            StatisticOperation.Repeated(l1);
            string str = "";
            Console.WriteLine("Random animal is - "+StatisticOperation.RanAnim(str));

            Console.Read();
        }
        
    }
}

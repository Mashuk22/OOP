using System;
using System.Collections.Generic;
using System.IO;

namespace laba4
{


    public interface IGen<T>{

        List<T> Add(List<T> x, T y);

        void PrintAll(List<T> list);
        
        List<T> Remove(List<T> l1);
    }

    public class Owner
    {
        public int id = 1;
        public string name = "Ivan";
        public string univercity = "BSTU";
    }

    public class AllOwners<T> where T: Owner
    {
        public System.Collections.Generic.List<T> List = new System.Collections.Generic.List<T>();
        public void AddOwner(T elem)
        {
            List.Insert(0, elem);
            
        }
    }
    

    public class List<T>: IGen<T>  
    {
        public Owner owner = new Owner();
        
        public static class Date
        {
            public static DateTime date = new DateTime(2021, 9, 30);

        }


        public List<T> Add(List<T> x, T y)
        {
            x.list.Insert(0, y);
            return x;
        }

        public void PrintAll(List<T> list)
        {
            for (int item = 0; list.list.Count > item; item++)
            {
                Console.Write(list.list[item] + " ");
            }
            Console.WriteLine();
        }
        
        public List<T> Remove(List<T> l1)
        {
            l1.list.RemoveAt(0);
            return (l1);
        }

        public System.Collections.Generic.List<T> list;

        public List(System.Collections.Generic.List<T> list)
        {
            this.list = list;
        }
        public List()
        {
            list = new System.Collections.Generic.List<T>();
        }
   

        public static void Print(List<T> list)
        {
            for (int item = 0; list.list.Count > item; item++)
            {
                Console.Write(list.list[item] + " ");
            }
            Console.WriteLine();
        }
       
        public static void Test(List<T> l1, List<T> l2)
        {
            l1 = l1 * l2;
            l1.PrintAll(l1);
            Console.WriteLine(l1 != l2);
            l1--;
            l1.PrintAll(l1);
            //Console.WriteLine(l1 != l1);
        }
        
        public static List<T> operator +(List<T> l1, T item) 
        {
            l1.list.Insert(0, item);
            return (l1);
        }

        public static List<T> operator ++(List<T> l1)
        {
            return l1;
        }
        public static List<T> operator --(List<T> l1)
        {
            l1.list.RemoveAt(0);
            return (l1);
        }
        public static bool operator !=(List<T> l1, List<T> l2)
        {
            if (l1.list.Count != l2.list.Count)
            {
                return true;
            }
           // for (int item = 0; l1.list.Count < item; item++)
           // {
           //     if (l1.list[item] != l2.list[item])
           //     {
           //        return true;
           //    }
           //}
            return (false);
        }
        public static bool operator ==(List<T> l1, List<T> l2)
        {
            return !(l1 != l2);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static List<T> operator *(List<T> l1, List<T> l2)
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

        public static int LastNum(this string str)
        {
            int LastNum = -1;
            int Num = 0;
            bool isDight = false;
            for (int i=0; i< str.Length; i++)
            {
               
                if (Char.IsDigit(str[i]))
                {
                 
                    Num = (Num * 10) + int.Parse(str[i].ToString());
                    LastNum = Num;
                    isDight = true;
                }
                else if (isDight)
                {
                    Num = 0;
                    isDight = false;
                }
            }
            if (LastNum != -1)
            {
                return LastNum;
            }
            else 
            {
                return (-1);
            }
        }
        public static string RanAnim(this string str)
        {
            var rand = new Random();
            
            string[] animArr = { "Cat", "Dog", "Parrot", "mouse", "frog" };
            return (str.Insert(0,animArr[rand.Next(5)]));
        }
        public static void Repeated(this List<string> list)
        {
            System.Collections.Generic.List<string> str = new System.Collections.Generic.List<string>();
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
        public static int UpperCaseCounter(this List<string> list)
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
        public static int Sum<T>(List<T> l1, List<T> l2)
        {
            Console.WriteLine("---Sum---");
            return (l1.list.Count + l2.list.Count);
        }
        public static int Diff<T>(List<T> l1, List<T> l2)
        {
            Console.WriteLine("---Diff---");
            return (+(l1.list.Count - l2.list.Count));
        }
        public static int Lenght<T>(List<T> l1)
        {
            Console.WriteLine("---Lenght---");
            return (l1.list.Count);
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            void Lab4()
            {
                string str = "fsd123ffsdfds3123fsd";
                Console.WriteLine("Last num is - " + str.LastNum());
                List<string> l1 = new List<string>();
                List<string>  l2 = new List<string>();

                List<string>.Test(l1, l2);


                Console.WriteLine(StatisticOperation.Sum(l1, l2));
                Console.WriteLine(StatisticOperation.Diff(l1, l2));
                Console.WriteLine(StatisticOperation.Lenght(l1));
                Console.WriteLine("Uppercase words \n" + StatisticOperation.UpperCaseCounter(l1));
                Console.WriteLine("Repeated words");
                StatisticOperation.Repeated(l1);
                str = "";
                Console.WriteLine("Random animal is - "+ str.RanAnim());
                Console.WriteLine(l1.owner.name);
                
            }
            if (false) Lab4();

            void Lab8()
            {

                System.Collections.Generic.List<string> list1 = new System.Collections.Generic.List<string> { "Cat", "Dog", "Parrot" };
                System.Collections.Generic.List<string> list2 = new System.Collections.Generic.List<string> { "Parrot", "mouse", "frog" };
                List<string> l1 = new List<string>(list1);
                List<string> l2 = new List<string>(list2);

                List<string>.Test(l1, l2);
                
                Console.WriteLine();


                try
                {
                    System.Collections.Generic.List<int> ilist1 = new System.Collections.Generic.List<int> { 1, 2, 3 };
                    System.Collections.Generic.List<int> ilist2 = new System.Collections.Generic.List<int> { 3, 4, 5 };
                    List<int> il1 = new List<int>(ilist1); 
                    List<int> il2 = new List<int>(ilist2);

                    List<int>.Test(il1, il2);

                    il2.Remove(il2);
                    il2.Remove(il2);
                    il2.Remove(il2);
                    il2.Remove(il2);

                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка!!!");
                    
                }
                finally
                {
                    Console.WriteLine("Обработа ошибок завершена");
                }

                Console.WriteLine();

                Owner o1 = new Owner();
                Owner o2 = new Owner();
                Owner o3 = new Owner();
                Owner o4 = new Owner();

                AllOwners<Owner> ownerCollection1 = new AllOwners<Owner>();
                ownerCollection1.AddOwner(o1);
                ownerCollection1.AddOwner(o2);
                ownerCollection1.AddOwner(o3);
                ownerCollection1.AddOwner(o4);

                AllOwners<Owner> ownerCollection2 = new AllOwners<Owner>();
                ownerCollection2.AddOwner(o1);
                ownerCollection2.AddOwner(o2);
                ownerCollection2.AddOwner(o3);
                ownerCollection2.AddOwner(o4);


                System.Collections.Generic.List<AllOwners<Owner>> olist1 = new System.Collections.Generic.List<AllOwners<Owner>> { ownerCollection1};
                System.Collections.Generic.List<AllOwners<Owner>> olist2 = new System.Collections.Generic.List<AllOwners<Owner>> { ownerCollection2 };
                List<AllOwners<Owner>> ol1 = new List<AllOwners<Owner>>(olist1);
                List<AllOwners<Owner>> ol2 = new List<AllOwners<Owner>>(olist2);

                List<AllOwners<Owner>>.Test(ol1, ol2);
                
                Console.WriteLine();

                string writePath = @"C:\text.txt";
                try
                {
                    using(StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                        foreach (dynamic elem in l1.list)
                        {
                            sw.WriteLine(elem);
                        }
                    }
                    
                    Console.WriteLine("Запись выполнена");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                

                using (StreamReader sr = new StreamReader(writePath, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }


            }

            Lab8();

            Console.Read();
        }
        
    }
}

using System;
using System.Linq;
using System.Text;
namespace laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            task1();
            task2();
            task3();
            task4();


            (int, int, int, char) task5(int[] arr, string str)
            {
                return (arr.Max(), arr.Min(), arr.Sum(), str[0]);
            }
            int[] mas = { 4, 5, 2, 1, 3 };
            string txt = "hello";

            Console.WriteLine(task5(mas, txt));

            task6();
        }

        static void task1()
        {
            bool a = true;
            byte b = 255;
            sbyte c = -128;
            short d = 32767;
            ushort e = 65535;
            int f = 2147483647;
            uint g = 4294967295;
            long h = 9223372036854775807;
            ulong i = 18446744073709551615;
            float j = 1.38f;
            double k = 3.308;
            decimal l = 1.28m;
            char m = 'A';
            string n;
            object o = 3.14;
            dynamic p = "dinamic";

            Console.WriteLine("введите строку для вывода");
            n = Console.ReadLine();
            Console.WriteLine($"{a}\n{b}\n{c}\n{d}\n{e}\n{f}\n{g}\n{h}\n{i}\n{j}\n{k}\n{l}\n{m}\n{n}\n{o}\n{p}");
            Console.WriteLine("----------Conversions---------");

            int intnum;
            byte con1 = 0;
            Console.WriteLine("введите int для преобразования в byte");
            intnum = Convert.ToInt32(Console.ReadLine()); //conversion 5
            try
            {
                con1 = checked((byte)intnum);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

            long longnum = 123;
            short con2 = (short)longnum;

            double dnum = 4.0;
            decimal con3 = (decimal)dnum;

            int intnum1 = 3;
            char con4 = (char)intnum1;

            Console.WriteLine(intnum + " from string to int");
            Console.WriteLine(con1 + " from int to byte");
            Console.WriteLine(con2);
            Console.WriteLine(con3);
            Console.WriteLine(con4);


            char charnum = 'd';
            int charToInt = charnum;

            float flnum = 3.14f;
            double flToDouble = flnum;

            long lnum = 213;
            float longToFloat = lnum;

            ushort usnum = 222;
            uint ushortToUint = usnum;

            byte bytenum = 13;
            decimal byteToDecimal = bytenum;

            Console.WriteLine("charToInt " + charToInt);
            Console.WriteLine("flToDouble " + flToDouble);
            Console.WriteLine("longToFloat " + longToFloat);
            Console.WriteLine("ushortToUint " + ushortToUint);
            Console.WriteLine("byteToDecimal " + byteToDecimal);

            int pack = 1111;
            Object obj = pack;
            int unpack = (int)obj;
            Console.WriteLine(unpack);


            var Var1 = 12;
            var Var2 = "abc";
            Console.WriteLine("Var1 - {0}\nVar2 - {1}", Var1.GetType(), Var2.GetType());




            int? x = null;
            if (x.HasValue)
                Console.WriteLine(x.Value);
            else
                Console.WriteLine("x is equal to null");

        }
        static void task2()
        {
            string AAA = "assdfsdfdd";
            string aaa = "aad";
            var Coomp = AAA.CompareTo(aaa);
            bool aA = (AAA == aaa);
            AAA.Equals("aad");
            Console.WriteLine("------------  " + Coomp);

            string s1 = "hello";
            string s2 = "world";
            string s3 = s1 + " " + s2;
            string s4 = String.Concat(s3, "!!!");
            Console.WriteLine(s4);

            s2 = s1;
            s2 = "hi";
            Console.WriteLine("COPY");
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine();

            string substr = s4.Substring(6);
            Console.WriteLine(substr);


            string[] words = s4.Split(new char[] { ' ' });

            foreach (string s in words)
            {
                Console.WriteLine(s);
            }

            s4 = s4.Insert(6, "human's ");
            Console.WriteLine(s4);

            s4 = s4.Remove(s4.Length - 3);
            Console.WriteLine(s4);

            Console.WriteLine();

            int number = 2;
            Console.WriteLine($"laboratory number {number} in progress");

            s1 = "abcd";
            s2 = "";
            s3 = null;

            Console.WriteLine("String s1 {0}.", Test(s1));
            Console.WriteLine("String s2 {0}.", Test(s2));
            Console.WriteLine("String s3 {0}.", Test(s3));

            String Test(string s)
            {
                if (String.IsNullOrEmpty(s))
                    return "is null or empty";
                else
                    return String.Format("(\"{0}\") is neither null nor empty", s);
            }

            StringBuilder sb = new StringBuilder("aaa bbbb cc ddd");
            Console.WriteLine(sb);
            sb.Replace("cc ", "");
            Console.WriteLine(sb);
            sb.Remove(4, 5);
            Console.WriteLine(sb);
            sb.Append("!");
            sb.Insert(0, "!");
            Console.WriteLine(sb);

        }
        static void task3()
        {
            int[,] array = { { 0, 1, 2 }, { 3, 4, 5 } }; ;
            int rows = array.GetUpperBound(0) + 1;
            int columns = array.GetUpperBound(1) + 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }

            string[] strArray = { "a", "bb", "ccc", "dddd" };
            foreach (string i in strArray)
                Console.Write($"{i} ");
            Console.WriteLine();
            Console.WriteLine(strArray.Length);


            Console.WriteLine("Enter the position and value");

            int position = int.Parse(Console.ReadLine());
            string value = Console.ReadLine();

            strArray[position] = value;
            foreach (string i in strArray)
                Console.Write($"{i} \n");
            Console.WriteLine("--------------------");



            int arrRows = 3;
            int temp = 3;
            int[][] intarr = new int[arrRows][];
            var rand = new Random();

            for (int i = 0; i < arrRows; i++)
            {

                intarr[i] = new int[temp];

                for (int j = 1; j < temp; j++)
                {
                    intarr[i][j] = rand.Next(10);
                    Console.Write($"{intarr[i][j]} \t");
                }
                temp = temp + 1;
                Console.WriteLine();
            }
            var implint = new[] { 1, 10, 100, 1000 };
            var implstr = new[] { "hello", null, "world" };
            Console.WriteLine(implint);
            Console.WriteLine(implstr);

        }
        static void task4()
        {
            (int, string, char, string, ulong) tuple = (19, "Ivan", 'M', "Sergeecich", 64);
            Console.WriteLine(tuple);

            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item3);
            Console.WriteLine(tuple.Item4);

            (var age, var name, var lname, var sname, var longInt) = tuple;
            Console.WriteLine("unpacking 1");
            Console.WriteLine(lname);

            (int, string, char, string, ulong) tuple2 = (20, "Petr", 'M', "Sergich", 64);
            var (age1, name1, lname1, sname1, longInt1) = tuple2;
            Console.WriteLine("unpacking 2");
            Console.WriteLine(name1);

            Console.WriteLine(tuple == tuple2);
        }
        static void task6()
        {

            void check()
            {
                try
                {
                    checked
                    {
                        int a = 2147483647;
                        int b = 10;
                        int maxcheck = checked(a * b);
                        Console.WriteLine(maxcheck);
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Переполнение");
                }

            }
            void uncheck()
            {
                unchecked
                {
                    int maxuncheck = (int)214748364700;
                    Console.WriteLine(maxuncheck);
                }

            }

            check();
            uncheck();
        }


    }
}



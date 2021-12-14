using System;
using System.Collections.Generic;
using System.Linq;


namespace lab9
{
    class Program
    {
       
        public delegate int Oper(int x, int y);
        static void Main(string[] args)
        {
            Oper sum = (x, y) => x + y;
            Oper mult = (x, y) => x * y;
            Console.WriteLine($"Сумма через лямбду: { sum(5, 5) }\n");
            Console.WriteLine($"Умножение через лямбду: { mult(5, 5) }\n");


            List<int> list1 = new List<int>(){ 1, 2, 3 };
            List<int> list2 = new List<int>(){ 4, 5, 6 };
            List<int> list3 = new List<int>(){ 2, 4, 6 };

            Programmer proger = new Programmer(list1);
            
            proger.Remove += RemoveMessage;
            proger.Mutate += Message;
            proger.Mutate += MutateMessage;

            proger.Add(list2);
            foreach (int elem in list2) { Console.WriteLine(elem); }
            Console.WriteLine();


            proger.RemoveLabs(list3);
            foreach (int elem in list3) { Console.WriteLine(elem); }
            Console.WriteLine();

            Console.WriteLine("Вывод принятых лаб:");
            foreach (int elem in proger.Labs) { Console.WriteLine(elem); }

            Func<string, string> textRedact;

            string myString = "    Hello, My Dear, Friend  ";
            Console.WriteLine(myString);

            textRedact = RemoveSpaces;
            myString = textRedact(myString);
            Console.WriteLine(myString);

            textRedact += RemoveCommas;
            myString = textRedact(myString);
            Console.WriteLine(myString);

            textRedact = ToLowerCase;
            myString = textRedact(myString);
            Console.WriteLine(myString);

            textRedact = ToUpperCase;
            myString = textRedact(myString);
            Console.WriteLine(myString);

            textRedact = AddAuthor;
            myString = textRedact(myString);
            Console.WriteLine(myString);

            Console.Read();


        }
        private static void RemoveMessage(string message, List<int> list)
        {
            Console.WriteLine($"Лаба под номером {list[0]} была списана и будет удалена");
            list.RemoveAt(0);
        }

        private static void MutateMessage(string message, List<int> list)
        {
            Console.WriteLine($"Список списанных лаб был перемешан!");
            list.Reverse();
        }

        private static void Message(string message, List<int> list)
        {
            Console.WriteLine(message);
            
        }

        private static string RemoveCommas(string message)
        {
            message = message.Replace(",", "");
            return message;
        }
        private static string RemoveSpaces(string message)
        {
            message = message.Trim();
            return message;
        }

        private static string ToUpperCase(string message)
        {
            message = message.ToUpper();
            return message;
        }
        private static string AddAuthor(string message)
        {
            message = message.Insert(0, "Ivan Mashuk: ");
            return message;
        }
        private static string  ToLowerCase(string message)
        {
            message = message.ToLower();
            return message;
        }
    }
}

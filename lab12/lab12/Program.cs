using System;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Type myType = typeof(MyClass);

            Reflector.AssemblyName(myType); 
            Reflector.IfPublicCunstructor(myType);

            var typeMethods = Reflector.GetPublicMethods(myType);
            Console.WriteLine($"Все Публичные методы класса {myType}:");
            foreach (var item in typeMethods)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var typeInterfases = Reflector.GetInterfaces(myType);
            Console.WriteLine($"Все интерфесы класса {myType}:");
            foreach (var item in typeInterfases)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var typeFields = Reflector.GetFields(myType);
            Console.WriteLine($"Все поля и свойства класса {myType}:");
            foreach (var item in typeFields)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Введите тип параметра по которому хотите найти метод");
            string selectParam = Console.ReadLine();
            Reflector.MethodByParams(myType, selectParam);

            Console.WriteLine($"Вызов метода класса {myType}");
            string selectMethod = Console.ReadLine();
            Type[] methodParams = new Type[] { typeof(String), typeof(Int32) };
            Reflector.Invoke(myType, selectMethod, methodParams);

            Console.WriteLine();
            Reflector.Create(typeof(MyClass));
        }
    }
    public class MyClass : IComparable
    {
        public string Name { get; set; }
        public int age;

        public MyClass(int a)
        {
            Console.WriteLine(a);
        }
        public MyClass()
        {
            Console.WriteLine("Сработал конструктор");
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public void SayHi(string hiPhrase, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(hiPhrase);
            }
           
        }
        private void SayNothing()
        {

        }
    }
}


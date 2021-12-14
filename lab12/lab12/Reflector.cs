using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace lab12
{
    public static class Reflector
    {
        public static void AssemblyName(Type type)
        {
            Console.WriteLine($"Имя сборки класса {type}: {type.Assembly}\n");
        }

        public static void IfPublicCunstructor(Type type)
        {
            foreach (var item in type.GetConstructors())
            {
                if(item.IsPublic == true)
                {
                    Console.WriteLine($"{type} - Публичный конструктор есть\n");
                    return;
                }
            }
            Console.WriteLine($"{type} - Публичного конструктора нет\n");
        }

        public static IEnumerable<string> GetPublicMethods(Type type)
        {
            List<string> methodStr = new List<string>() ;
            foreach (var item in type.GetMethods())
            {
                if (item.IsPublic == true)
                {
                    methodStr.Add(item.Name);
                }
            } 
            return methodStr;
        }

        public static IEnumerable<string> GetFields(Type type)
        {
            List<string> methodStr = new List<string>();
            foreach (var item in type.GetFields())
            {
                methodStr.Add(item.Name);
            }
            foreach (var item in type.GetProperties())
            {
                methodStr.Add(item.Name);
            }
            return methodStr;
        }

        public static IEnumerable<string> GetInterfaces(Type type)
        {
            List<string> methodStr = new List<string>();
            foreach (var item in type.GetInterfaces())
            {
                methodStr.Add(item.Name);
            }
            return methodStr;
        }

        public static object Create(Type type)
        {
            return Activator.CreateInstance(type);
        }


        public static void MethodByParams(Type type, string needParam)
        {
            foreach (var item in type.GetMethods())
            {
                var paremetrs = item.GetParameters();
                foreach (var param in paremetrs)
                {
                    if (param.ParameterType.Name == needParam)
                    {
                        Console.WriteLine($"Метод '{item.Name}' класса '{type}' имеет параметр '{needParam}'");
                        break;
                    }
                }
            }
            Console.WriteLine();
            return;     
        }

        public static void Invoke(Type obj, string methodName, Type[] args)
        {
            
            Type type = obj;
            string filePath = @"C:\Users\Unik\OOP\text.txt";
            string fileInf = "";
            string strParams = "parameters";

            using (StreamReader sr = new StreamReader(filePath, Encoding.Default))
                fileInf = sr.ReadToEnd();

            int index = fileInf.IndexOf(strParams);

            List<string> paramsList = new List<string>();
            string currentParam = "";
            for (int i = index + strParams.Length + 2; i < fileInf.Length; i++)
            {
                if (fileInf[i] == ' ' || fileInf[i] == '\n')
                {
                    paramsList.Add(currentParam);
                    currentParam = "";
                }
                else
                    currentParam += fileInf[i];
            }

            var method = type.GetMethod(methodName);
            string stringParam1 = "";
            int stringParam2;
            stringParam1 = paramsList.First();
            stringParam2 = Convert.ToInt32( paramsList.Last());

            object objWord = Activator.CreateInstance(type);
            if (paramsList.Count() != 0)
                method.Invoke(objWord, new object[] { stringParam1, stringParam2 });
            else
                method.Invoke(objWord, new object[] { });
            
        }

    }
}

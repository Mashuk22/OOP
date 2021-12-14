using System;
using System.IO;
using System.Text;

namespace laba13
{
    public static class MISLog
    {
        public static void WriteLogInfo()
        {
            string logPath = Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISlogfile.txt");
            try
            {
                using (StreamWriter sw = new StreamWriter(logPath, false, Encoding.Default))
                {
                    sw.WriteLine("<=========================================== MISLog ===================================================>");
                    sw.WriteLine($"Имя файла лога: {Path.GetFileName(logPath)}");
                    sw.WriteLine($"Полный путь лога: {logPath}");
                    sw.WriteLine($"Время записи лога: {DateTime.Now}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void WriteInLog(string message)
        {
            string logPath = Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISlogfile.txt");
            try
            {
                using (StreamWriter sw = new StreamWriter(logPath, true, Encoding.Default))
                {
                    sw.WriteLine(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static string ReadLog()
        {
            string logPath = Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISlogfile.txt");
            try
            {
                StreamReader sr = new StreamReader(logPath);
                return sr.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return String.Empty;
            }
        }

        public static void SearchLog()
        {
            string logPath = Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISlogfile.txt");
            string logFile = MISLog.ReadLog(); // Содержит лог
            FileInfo logFileInfo = new FileInfo(logPath);
            DateTime lastHour = DateTime.Now;
            lastHour.AddHours(-1);                                              // записи за последний час

            if (logFileInfo.LastWriteTime < lastHour)                           // выводим только записи за час
            {
                string writes = "\n=";                                          // подстрока, считающая кол-во записей
                int i = 0, j = -1, count = -1; 
                while (i != -1)                                                 // механизм подсчета вхождений подстроки
                {
                    i = logFile.IndexOf(writes, j + 1);
                    j = i;
                    count++;
                }

                Console.WriteLine("Записей за текущий час: " + (count - 1));    // -1 т.к. в конце есть еще одна "\n="
                Console.WriteLine("Вывод этих записей: ");
                Console.WriteLine(logFile);
            }
        }
    }
}
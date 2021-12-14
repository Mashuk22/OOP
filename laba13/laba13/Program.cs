using System;

namespace laba13
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MISLog.WriteLogInfo();

                MISDiskInfo.DiskInfo();

                MISFileInfo.GetFileInfo();

                MISDirInfo.GetDirInfo();

                MISFileManager.MISFiles();
                MISFileManager.MakeArchive();
                MISFileManager.MISInspect();

                MISLog.ReadLog();
                MISLog.SearchLog();
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine("Директорий не найден: " + e.StackTrace);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Файл уже существует: " + e.Message +": " +e.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }
    }
}
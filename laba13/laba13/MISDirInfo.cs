using System;
using System.IO;

namespace laba13
{
    public static class MISDirInfo
    {
        public static void GetDirInfo()
        {
            string path = Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\");
            string DirInfoLog = "";

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            if (directoryInfo.Exists)
            {
                DirInfoLog = "\n<=========================================== MISDirInfo ==============================================>" +
                             "\nКоличество файлов:        " + directoryInfo.GetFiles().Length +
                             "\nВремя создания:           " + directoryInfo.LastWriteTime +
                             "\nКол-во поддиректориев:    " + directoryInfo.GetDirectories().Length +
                             "\nРодительский директорий:  " + directoryInfo.Parent.Name;
            }

            if (directoryInfo.Exists)
            {
                Console.WriteLine("\nКоличество файлов: " + directoryInfo.GetFiles().Length);
                Console.WriteLine("\nВремя создания: " + directoryInfo.LastWriteTime);
                Console.WriteLine("\nКол-во поддиректориев: " + directoryInfo.GetDirectories().Length);
                Console.WriteLine("\nРодительский директорий: " + directoryInfo.Parent.Name);
            }

            MISLog.WriteInLog(DirInfoLog);
        }
    }
}
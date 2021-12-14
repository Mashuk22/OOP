using System;
using System.IO;

namespace laba13
{
    public static class MISFileInfo
    {
        public static void GetFileInfo()
        {
            string path = Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISlogfile.txt");
            string fileInfoLog = "";
            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
            {
                fileInfoLog = "\n<=========================================== MISFileInfo =============================================>" +
                              "\nПолный путь:              " + path +
                              "\nИмя файла:                " + fileInfo.Name +
                              "\nРазмер файла:             " + fileInfo.Length + " KB" +
                              "\nРасширение:               " + fileInfo.Extension +
                              "\nДата изменения:           " + fileInfo.LastWriteTime;
            }

            if (fileInfo.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInfo.Name);
                Console.WriteLine("Время создания: {0}", fileInfo.CreationTime);
                Console.WriteLine("Размер: {0}", fileInfo.Length);
            }

            MISLog.WriteInLog(fileInfoLog);
        }
    }
}
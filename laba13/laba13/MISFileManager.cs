using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace laba13
{
    public static class MISFileManager
    {
        public static void MISInspect()
        {
            string classLogInfo = "\n<======================================   MISFileManager   ===========================================>\n";
            string inspectLog = "";

            DriveInfo[] drives = DriveInfo.GetDrives();
            DirectoryInfo directory = new DirectoryInfo(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13");

            directory.Create();
            directory.CreateSubdirectory(@"MISInspect");

            DirectoryInfo MISInspectFiles = new DirectoryInfo(Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISInspect\MISFiles"));
            if (MISInspectFiles.Exists)
                MISInspectFiles.Delete(true);

            string filePath = Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISInspect\MISdirinfo.txt");
            FileInfo fileInfo = new FileInfo(filePath);
            using (StreamWriter sw = fileInfo.CreateText())
            {
                sw.WriteLine("Happy New Year!");
                sw.Close();
            }


            string renamePath = Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISInspect\MISdirinfoRENAMED.txt");
            FileInfo renameBuf = new FileInfo(renamePath);
            renameBuf.Delete();

            fileInfo.CopyTo(renamePath);
            fileInfo.Delete();


            DirectoryInfo inspectDirInfo = new DirectoryInfo(Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISInspect"));
            string files = "";
            for (int i = 0; i < inspectDirInfo.GetFiles().Length; i++)
                files += inspectDirInfo.GetFiles()[i].Name + "; ";

            string directories = "";
            for (int i = 0; i < inspectDirInfo.GetDirectories().Length; i++)
                directories += inspectDirInfo.GetDirectories()[i];

            if (inspectDirInfo.Exists)
                inspectLog = classLogInfo +
                             "\nФайлы:                    " + files +
                             "\nПоддиректории:            " + directories +
                             "\nРодительский директорий:  " + inspectDirInfo.Parent.Name;


            MISLog.WriteInLog(inspectLog);
        }

        public static void MISFiles()
        {
            string MISFilesPath =
                Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISFiles");
            string MISInspectFilesPath =
                Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISInspect\MISFiles");
            string MISUnzipPath =
                Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISInspect\MISUnzip");
            string ZipPath =
                Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISInspect\MISFiles.zip");
            string musicPath =
                Path.GetFullPath(@"\\Mac\Home\Music\Music");

            DirectoryInfo MISFiles = new DirectoryInfo(MISFilesPath);
            DirectoryInfo MISInspectFiles = new DirectoryInfo(MISInspectFilesPath);
            DirectoryInfo MISUnzip = new DirectoryInfo(MISUnzipPath);

            // Создаем папки ,если их нет
            if (!MISFiles.Exists)
            {
                MISFiles.Create();
            }

            if (MISUnzip.Exists)
            {
                MISUnzip.Delete(true);
            }

            if (File.Exists(ZipPath))
            {
                File.Delete(ZipPath);
            }

            DirectoryInfo musicDirInfo = new DirectoryInfo(musicPath);
            FileInfo[] fileMusic = musicDirInfo.GetFiles();
            foreach (var file in fileMusic)
            {
                if (file.Extension == ".mp3" || file.Extension == ".mp4")
                {
                    file.CopyTo(Path.Combine(MISFilesPath, file.Name), true);
                }
            }

            if (MISInspectFiles.Exists)
            {
                MISInspectFiles.Delete(true);
            }

            if (MISFiles.Exists)
            {
                MISFiles.MoveTo(MISInspectFilesPath);
            }

        }

        public static void MakeArchive()
        {
            string MISFilesPath =
                Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISFiles");
            string MISInspectFilesPath =
                Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISInspect\MISFiles");
            string MISInspectUnzipPath =
                Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISInspect\MISUnzip");
            string ZipPath =
                Path.GetFullPath(@"\\Mac\Home\Documents\Unik\ООП\Labs\OOP\laba13\laba13\MISInspect\MISFiles.zip");

            // Архивируем
            DirectoryInfo MISFiles = new DirectoryInfo(MISFilesPath);
            ZipFile.CreateFromDirectory(MISInspectFilesPath, ZipPath);


            // Если остался Inspect(Files), то удаляем его
            DirectoryInfo MISInspectFiles = new DirectoryInfo(MISInspectFilesPath);
            if (MISInspectFiles.Exists)
            {
                MISInspectFiles.Delete(true);
            }

            // Создаем папку для архивации
            DirectoryInfo MISInspectUnzip = new DirectoryInfo(MISInspectUnzipPath);
            if (MISInspectUnzip.Exists)
            {
                MISInspectUnzip.Delete(true);
            }
            MISInspectUnzip.Create();

            // Разархивация
            using (ZipArchive archive = ZipFile.OpenRead(ZipPath))
            {
                var result = from entry in archive.Entries
                             where !String.IsNullOrEmpty(entry.Name)
                             select entry;
                foreach (var entry in result)
                {
                    entry.ExtractToFile(Path.Combine(MISInspectUnzipPath, entry.Name));
                }
            }

        }
    }
}
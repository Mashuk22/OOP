using System;
using System.IO;

namespace laba13
{
    public static class MISDiskInfo
    {
        public static void DiskInfo()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            string DiskInfo = "";

            foreach (DriveInfo drive in allDrives)
            {
                if (drive.IsReady)
                {
                    DiskInfo += $"\n<=========================================== MISDisk ({drive.Name}) =============================================>" +
                      "\nИмя диска:                " + drive.Name +
                      "\nФайловая система:         " + drive.DriveFormat +
                      "\nДоступное место:          " + drive.AvailableFreeSpace / 1024 / 1024 + " MB" +
                      "\nРазмер диска:             " + drive.TotalSize / 1024 / 1024 + " MB" +
                      "\nМетка тома диска:         " + drive.VolumeLabel + "\n";
                }

                Console.WriteLine("Drive {0}", drive.Name);
                Console.WriteLine("  Drive type: {0}", drive.DriveType);
                if (drive.IsReady)
                {
                    Console.WriteLine("  Volume label: {0}", drive.VolumeLabel);
                    Console.WriteLine("  File system: {0}", drive.DriveFormat);
                    Console.WriteLine(
                        "  Available space to current user:{0, 15} bytes",
                        drive.AvailableFreeSpace);

                    Console.WriteLine(
                        "  Total available space:          {0, 15} bytes",
                        drive.TotalFreeSpace);

                    Console.WriteLine(
                        "  Total size of drive:            {0, 15} bytes ",
                        drive.TotalSize);
                }
                else
                {
                    Console.WriteLine("  Drive is not ready");
                }
            }

            MISLog.WriteInLog(DiskInfo);
        }
    }
}
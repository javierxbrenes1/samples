using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    public class DriveClass
    {
        public void AccessInfoDrive()
        {
            DriveInfo[] drivesInfo = DriveInfo.GetDrives();

            foreach (var driveInfo in drivesInfo)
            {
                Console.WriteLine("Drive {0}", driveInfo.Name);
                Console.WriteLine("file type: {0}", driveInfo.DriveType);

                if (driveInfo.IsReady)
                {
                    Console.WriteLine(" Volume label: {0}", driveInfo.VolumeLabel);
                    Console.WriteLine(" File system: {0}", driveInfo.DriveFormat);
                    Console.WriteLine(" Available space to current user:{0, 15} bytes",driveInfo.AvailableFreeSpace);
                    Console.WriteLine(" Total available space: {0, 15} bytes",driveInfo.TotalFreeSpace);
                    Console.WriteLine(" Total size of drive: {0, 15} bytes ",driveInfo.TotalSize);
                }
            }
        }

        public void createDirectories()
        {
            var directory = Directory.CreateDirectory(@"E:\directory");

            var directoryInfo = new DirectoryInfo(@"E:\directoryInfo");
            directoryInfo.Create();

        }


        public void security()
        {
            DirectoryInfo di = new DirectoryInfo("TestDirectory");
            di.Create();
            DirectorySecurity ds = di.GetAccessControl();
            ds.AddAccessRule( new FileSystemAccessRule("everyone", FileSystemRights.ReadAndExecute, AccessControlType.Allow));
            di.SetAccessControl(ds);


        }

        public void callListDirectoriesMethod()
        {
            DirectoryInfo di = new DirectoryInfo(@"c:\Program Files");
            ListDirectories(di, "*a*", 5, 0);
        }

        public void ListDirectories(DirectoryInfo di, string searchPattern, int maxLevel, int currentLevel)
        {
            if (currentLevel >= maxLevel)
            {
                return;
            }

            string i = new string('-', currentLevel);
            try
            {
                DirectoryInfo[] subd = di.GetDirectories(searchPattern);

                foreach (DirectoryInfo subD in subd)
                {
                    Console.WriteLine(i + subD.Name);
                    ListDirectories(subD, searchPattern, maxLevel, currentLevel + 1);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine(i + "Can't access: " + di.Name);
                return;
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(i + "Can't find: " + di.Name);
                return;
            }
        }

        public void WorkingWithPaths()
        {
            string folder = @"C:\temp";
            string fileName = "test.dat";

            string fullPanth = Path.Combine(folder, fileName);

        }


        public void CompressAFile()
        {
            string folder = @"E:\Examen de certificacion C#";
            string uncompressedFilePath = Path.Combine(folder, "uncompressed.dat");
            string compressedFilePath = Path.Combine(folder, "compressed.zip");
            byte[] dataToCompress = Enumerable.Repeat((byte)'a', 1024 * 1024).ToArray();

            using (FileStream ufs = File.Create(uncompressedFilePath))
            {
                ufs.Write(dataToCompress, 0, dataToCompress.Length);

            }

            using (FileStream compressedFileStream = File.Create(compressedFilePath))
            {
                using (System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(compressedFileStream, 
                    System.IO.Compression.CompressionMode.Compress)) 
                {
                    zip.Write(dataToCompress, 0, dataToCompress.Length);
                }
            }


            FileInfo uf = new FileInfo(uncompressedFilePath);
            FileInfo cf = new FileInfo(compressedFilePath);


            Console.WriteLine(uf.Length);
            Console.WriteLine(cf.Length);

        }

        public void burrefered()
        {
            string path = @"c:\temp\bufferedStream.txt";
            using (FileStream fileStream = File.Create(path))
            {
                using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                {
                    using (StreamWriter streamWriter = new StreamWriter(bufferedStream))
                    {
                        streamWriter.WriteLine("A line of text.");
                    }
                }
            }
        }
    }
}

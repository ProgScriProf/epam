using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
    public static class ConfigFile
    {
        public const string Extension = ".cfg";

        public static void CreateConfig(string root, string pathBackup)
        {
            using (StreamWriter sw = new StreamWriter($"{pathBackup}{Extension}"))
            {
                SavePathFiles(root, pathBackup, sw);
            }
        }
        private static void SavePathFiles(string root, string pathBackup, StreamWriter sw, string subDir = "")
        {
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(root, subDir));

            foreach (var file in dir.GetFiles())
            {
                sw.WriteLine($"{file.FullName}>{Path.Combine(pathBackup, subDir, file.Name)}");
            }
            foreach (var folder in dir.GetDirectories())
            {
                SavePathFiles(root, pathBackup, sw, Path.Combine(subDir, folder.Name));
            }
        }

        public static void CopyConfig(string oldPath, string newPath)
        {
            if (!File.Exists($"{newPath}{Extension}"))
            {
                File.Copy($"{oldPath}{Extension}", $"{newPath}{Extension}");
            }
        }

        public static void ChangeStringRef(string pathConfig, string file, string path)
        {
            string[] files = File.ReadAllLines($"{pathConfig}{Extension}");

            using (StreamWriter sw = new StreamWriter($"{pathConfig}{Extension}"))
            {
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].StartsWith(file))
                    {
                        sw.Write(file);
                        sw.Write(">");
                        sw.WriteLine(path);
                    }
                    else
                    {
                        sw.WriteLine(files[i]);
                    }
                }
            }
        }

        public static void ChangeStringInput(string pathConfig, string oldPath, string newPath)
        {
            string[] files = File.ReadAllLines($"{pathConfig}{Extension}");

            using (StreamWriter sw = new StreamWriter($"{pathConfig}{Extension}"))
            {
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].StartsWith(oldPath))
                    {
                        sw.Write(newPath);
                        sw.Write(">");
                        sw.WriteLine(files[i].Remove(0, oldPath.Length + 1));
                    }
                    else
                    {
                        sw.WriteLine(files[i]);
                    }
                }
            }
        }

        public static void DeleteString(string pathConfig, string file)
        {
            string[] files = File.ReadAllLines($"{pathConfig}{Extension}");

            using (StreamWriter sw = new StreamWriter($"{pathConfig}{Extension}"))
            {
                for (int i = 0; i < files.Length; i++)
                {
                    if (!files[i].StartsWith(file))
                    {
                        sw.WriteLine(files[i]);
                    }
                }
            }
        }

        public static void AddString(string pathConfig, string sourse, string path)
        {
            using (StreamWriter sw = new StreamWriter($"{pathConfig}{Extension}", true))
            {
                sw.WriteLine($"{sourse}>{path}");
            }
        }
    }
}

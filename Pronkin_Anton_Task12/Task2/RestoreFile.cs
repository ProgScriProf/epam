using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
    class RestoreFile
    {
        private string _path;

        public RestoreFile(string path)
        {
            _path = path;
        }

        public string GetBackup()
        {
            StringBuilder res = new StringBuilder();

            string p = Path.Combine(Path.GetDirectoryName(_path), WatchFiles.BackupFolderName);
            DirectoryInfo di = new DirectoryInfo(p);
            int number = 1;
            foreach (var file in di.GetFiles())
            {
                if (file.Extension == ConfigFile.Extension)
                {
                    res.Append($"{number++}.  {file.Name.Remove(file.Name.Length - 4)}\n");
                }
            }
            return res.ToString();
        }

        public void Restore(int n)
        {
            string p = Path.Combine(Path.GetDirectoryName(_path), WatchFiles.BackupFolderName);
            DirectoryInfo di = new DirectoryInfo(p);
            int number = 1;
            foreach (var file in di.GetFiles())
            {
                if (file.Extension == ConfigFile.Extension)
                {
                    if (number++ == n)
                    {
                        RestoreFiles(file.FullName);
                        return;
                    }
                }
            }
        }

        private void RestoreFiles(string configPath)
        {
            foreach (var file in Directory.GetFiles(_path))
            {
                try
                {
                    File.Delete(file);
                }
                catch
                {
                    // Невозможно удалить файл
                }
            }
            foreach (var dir in Directory.GetDirectories(_path))
            {
                Directory.Delete(dir);
            }


            string[] files = File.ReadAllLines(configPath);
            foreach (var file in files)
            {
                string[] f = Regex.Split(file, ">");

                // Создаем каталоги и подкаталоги для файлов
                try
                {
                    string last = Path.GetDirectoryName(f[0]);
                    while (!Directory.Exists(Path.GetDirectoryName(f[0])))
                    {
                        string last2 = Path.GetDirectoryName(last);
                        if (Directory.Exists(last2))
                        {
                            Directory.CreateDirectory(last);
                            last = Path.GetDirectoryName(f[0]);
                        }
                        last = last2;
                    }

                    File.Copy(f[1], f[0]);
                }
                catch
                {
                    // Невозможно скопировать файл
                }
            }
        }
    }
}

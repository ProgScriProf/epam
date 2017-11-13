using System;
using System.IO;
using System.Text;

namespace Task2
{
    public class WatchFiles
    {
        private string _root;
        private string _rootBackup;
        private string _lastBackup;

        public const string BackupFolderName = "MyBackup";
 
        // Получение названия для новой папки с бекпом
        private string GetFolderDateName()
        {
            DateTime cur = DateTime.Now;
            return $"{cur.Year}.{cur.Month}.{cur.Day} {cur.Hour}-{cur.Minute}-{cur.Second}";
        }
        private void Log(string info)
        {
            // Пока просто на консоль
            Console.WriteLine($"[{DateTime.Now}] {info}");
        }
        public WatchFiles(string path)
        {
            _root = path;
            _rootBackup = Path.Combine(Path.GetDirectoryName(_root), BackupFolderName);
            if (!Directory.Exists(_rootBackup))
            {
                Directory.CreateDirectory(_rootBackup);
            }

            string curDate = GetFolderDateName();
            _lastBackup = Path.Combine(_rootBackup, curDate);
            SaveAllFiles(GetFolderDateName(), "");

            ConfigFile.CreateConfig(_root, _lastBackup);
            
            StartWatch();
        }

        private string NewConfig()
        {
            string newBackup = Path.Combine(_rootBackup, GetFolderDateName());
            ConfigFile.CopyConfig(_lastBackup, newBackup);
            return newBackup;
        }

        // Сохраняем все файлы
        private void SaveAllFiles(string curDate, string path)
        {
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_root, path));
            
            // Сохраняем файлы в папке
            foreach(var file in dir.GetFiles("*.*"))
            {
                string newPath = Path.Combine(_rootBackup, curDate, path);

                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                string newFilePath = Path.Combine(newPath, file.Name);
                if (!File.Exists(newFilePath))
                {
                    file.CopyTo(newFilePath);
                }
            }
            // Идем по всем подпапкам и так же сохраняем
            foreach(var folder in dir.GetDirectories())
            {
                if (!Directory.Exists(folder.FullName))
                {
                    Directory.CreateDirectory(folder.FullName);
                }

                SaveAllFiles(curDate, Path.Combine(path, folder.Name));
            }
        }

        // Запуск отслеживания
        private void StartWatch()
        {
            FileSystemWatcher f = new FileSystemWatcher(_root)
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.LastWrite,
                IncludeSubdirectories = true/*,
                Filter = "*.txt"            */                 
            };
            f.Created += OnCreated;
            f.Deleted += OnDelete;
            f.Renamed += OnRename;
            f.Changed += OnChange;

            f.EnableRaisingEvents = true;       
        }

        private void OnRename(object sender, RenamedEventArgs e)
        {
            Log($"Rename \"{e.OldFullPath}\" > \"{e.FullPath}\"");

            // Копируем конфиг
            string newBackup = NewConfig();

            // Заменяем в нем имя файла
            ConfigFile.ChangeStringInput(newBackup, e.OldFullPath, e.FullPath);

            _lastBackup = newBackup;
        }

        private void OnDelete(object sender, FileSystemEventArgs e)
        {
            Log($"Delete \"{e.FullPath}\"");

            // Копируем конфиг
            string newBackup = NewConfig();

            // Удаляем строку
            ConfigFile.DeleteString(newBackup, e.FullPath);

            _lastBackup = newBackup;
        }

        private void OnChange(object sender, FileSystemEventArgs e)
        {
            Log($"Change \"{e.FullPath}\"");

            string newBackup = NewConfig();
            Directory.CreateDirectory(newBackup);

            // Копируем измененный файл
            string tp = e.FullPath.Remove(0, _root.Length + 1);
            string newPath = Path.Combine(newBackup, tp);

            if (!File.Exists(newPath))
            {
                File.Copy(e.FullPath, newPath);
            }

            // Копируем конфиг
            ConfigFile.CopyConfig(_lastBackup, newBackup);

            // Заменяем в нем расположение измененного файла
            ConfigFile.ChangeStringRef(newBackup, e.FullPath, newPath);

            _lastBackup = newBackup;
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            Log($"Create \"{e.FullPath}\"");

            // Копируем конфиг
            string newBackup = NewConfig();
            Directory.CreateDirectory(newBackup);

            // Копируем измененный файл
            string tp = e.FullPath.Remove(0, _root.Length + 1);
            string newPath = Path.Combine(newBackup, tp);

            if (!File.Exists(newPath))
            {
                File.Copy(e.FullPath, newPath);
            }

            // Вставляем строку
            ConfigFile.AddString(newBackup, e.FullPath, newPath);

            _lastBackup = newBackup;
        }
    }
}

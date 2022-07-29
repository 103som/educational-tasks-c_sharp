using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using System.Collections.ObjectModel;

namespace FileManager
{
    class FileManager
    {
        /// <summary>
        /// Словарь со всеми доступными операциями.
        /// </summary>
        public static readonly ReadOnlyDictionary<AvaliableOperations, string> allAvaliableOperations = new ReadOnlyDictionary<AvaliableOperations, string>
        (
            new Dictionary<AvaliableOperations, string>
            {
                {AvaliableOperations.CreateTxtFile, "F1 Создание"},
                {AvaliableOperations.DisplayTxtFile, "F2 Вывод"},
                {AvaliableOperations.ConcatenationFiles, "F3 Конкатенация"},
                {AvaliableOperations.CopyFile, "F4 Копирование"},
                {AvaliableOperations.TransposeFile, "F5 Транспонирование"},
                {AvaliableOperations.DisplayWithMaskCurrentDirectory, "F6 Вывод по маске файлов текущей директории"},
                {AvaliableOperations.DisplayWithMaskAllDirectories, "F7 Вывод по маске файлов текущей директории и всех поддиректорий"},
                {AvaliableOperations.CopyAndCreateForDirectory, "F8 Копирование по маске всех файлов директории и поддиректорий в другую"},
                {AvaliableOperations.DeleteTxtFile, "F9 Удаление"},
                {AvaliableOperations.AddExtraFilePath, "F11 Дополнение введенного пути или имени файла до полного имени каталога или файла"},
            }
        );

        /// <summary>
        /// Все доступные операции.
        /// </summary>
        public enum AvaliableOperations
        {
            CreateTxtFile = 1,
            DisplayTxtFile,
            ConcatenationFiles,
            CopyFile,
            TransposeFile,
            DisplayWithMaskCurrentDirectory,
            DisplayWithMaskAllDirectories,
            CopyAndCreateForDirectory,
            DeleteTxtFile,
            AddExtraFilePath
        }

        /// <summary>
        /// Панель.
        /// </summary>
        Panel panel = new Panel();

        /// <summary>
        /// Консольное окно.
        /// </summary>
        ConsoleWindow window = new ConsoleWindow();

        /// <summary>
        /// Запускает приложение.
        /// </summary>
        public void StartWorking()
        {
            window.DisplayStartMenu();
            while (true)
            {
                panel.DisplayAllObjectsInCurrentDirectory();

                ConsoleKey userKey = Console.ReadKey().Key;
                try
                {

                    switch (userKey)
                    {
                        case ConsoleKey.UpArrow:
                            window.Clear(3);
                            panel.GoUp();
                            break;
                        case ConsoleKey.DownArrow:
                            window.Clear(3);
                            panel.GoDown();
                            break;
                        case ConsoleKey.Enter:
                            window.Clear(3);
                            ChangeDirectory();
                            break;
                        case ConsoleKey.F1:
                            CreateNewObject();
                            break;
                        case ConsoleKey.F9:
                            Delete();
                            break;
                        case ConsoleKey.F2:
                            ReadAndWriteFileInConsole();
                            break;
                        case ConsoleKey.F4:
                            Copy();
                            break;
                        case ConsoleKey.F5:
                            TransposeFile();
                            break;
                        case ConsoleKey.F3:
                            ConcatenationAndWritingFiles();
                            break;
                        case ConsoleKey.F6:
                            DisplayWithMaskAllFilesInCurrentDirectory();
                            break;
                        case ConsoleKey.F7:
                            DisplayWithMaskAllFilesInCurrentDirectoryAndUnderDirectories();
                            break;
                        case ConsoleKey.F8:
                            CopyAllFilesToOtherDirectory();
                            break;
                    }
                }
                catch
                {

                }

                panel.DisplayAllObjectsInCurrentDirectory();
            }
        }

        /// <summary>
        /// Копирует файл.
        /// </summary>
        private void Copy()
        {
            if (panel.CurDirectory == null)
                return;

            window.Clear(5);

            FileSystemInfo newObj = panel.AllObjects[panel.ActiveObjectIndex];
            if (newObj is DirectoryInfo || newObj == null)
            {
                window.DisplayMessage("Выбран некорректный объект для данной операции");
                return;
            }

            string fullPath = window.AskingForFullFilePath();
            try
            {
                System.IO.File.Copy(panel.AllObjects[panel.ActiveObjectIndex].FullName, Path.Combine(fullPath, panel.AllObjects[panel.ActiveObjectIndex].Name));
                panel.SetObjects(panel.CurDirectory);
            }
            catch (Exception e)
            {
                window.Clear(5);
                window.DisplayMessage(e.Message);
            }
        }

        /// <summary>
        /// Транспонирует файл.
        /// </summary>
        private void TransposeFile()
        {
            if (panel.CurDirectory == null)
                return;

            window.Clear(5);

            FileSystemInfo newObj = panel.AllObjects[panel.ActiveObjectIndex];
            if (newObj is DirectoryInfo || newObj == null)
            {
                window.DisplayMessage("Выбран некорректный объект для данной операции");
                return;
            }

            FileInfo fileInfo = new FileInfo(panel.AllObjects[panel.ActiveObjectIndex].FullName);

            string fullPath = window.AskingForFullFilePath();
            try
            {
                fileInfo.MoveTo(Path.Combine(fullPath, panel.AllObjects[panel.ActiveObjectIndex].Name));
                panel.SetObjects(panel.CurDirectory);
            }
            catch (Exception e)
            {
                window.Clear(5);
                window.DisplayMessage(e.Message);
            }
        }

        /// <summary>
        /// Удаляет файл.
        /// </summary>
        private void Delete()
        {
            window.DisplayHelpDeleteMessage();
            // Если находимся в дисках.
            if (panel.CurDirectory == null)
                return;

            FileSystemInfo file = panel.AllObjects[panel.ActiveObjectIndex];
            try
            {
                if (file is DirectoryInfo)
                    ((DirectoryInfo)file).Delete(true);
                else
                    ((FileInfo)file).Delete();

                panel.SetObjects(panel.CurDirectory);
            }
            catch (Exception e)
            {
                window.Clear(5);
                window.DisplayMessage(e.Message);
            }
        }

        /// <summary>
        /// Создает директорию.
        /// </summary>
        /// <param name="userSolution"> true - txt file, false - директория.</param>
        private void CreateDirectory((bool, string) userSolution)
        {
            try
            {
                string dirFullName = Path.Combine(panel.CurDirectory.FullName, userSolution.Item2);
                DirectoryInfo newDirectory = new DirectoryInfo(dirFullName);
                if (!newDirectory.Exists)
                    newDirectory.Create();
                else
                {
                    window.Clear(2);
                    window.DisplayMessage("Папка с таким именем уже существует.");
                }
                panel.SetObjects(panel.CurDirectory);
            }
            catch (Exception e)
            {
                window.Clear(5);
                window.DisplayMessage(e.Message);
            }
        }

        /// <summary>
        /// Создает файл.
        /// </summary>
        /// <param name="userSolution"> true - txt file, false - директория.</param>
        private void CreateFile((bool, string) userSolution)
        {
            try
            {
                window.Clear(3);
                string encoding = window.AskingForEncoding();
                string fileFullName = Path.Combine(panel.CurDirectory.FullName, userSolution.Item2);
                fileFullName += ".txt";

                if (encoding == "UTF8")
                    System.IO.File.WriteAllText(fileFullName, null, Encoding.UTF8);
                if (encoding == "UTF32")
                    System.IO.File.WriteAllText(fileFullName, null, Encoding.UTF32);
                else
                    System.IO.File.WriteAllText(fileFullName, null, Encoding.ASCII);

                panel.SetObjects(panel.CurDirectory);
            }
            catch (Exception e)
            {
                window.Clear(5);
                window.DisplayMessage(e.Message);
            }
        }

        /// <summary>
        /// Создает новый объект.
        /// </summary>
        private void CreateNewObject()
        {
            // Если находимся в дисках.
            if (panel.CurDirectory == null)
                return;

            (bool, string) userSolution = window.AskingForFileOrDirectoryName();

            if (userSolution.Item1)
                CreateFile(userSolution);
            else
                CreateDirectory(userSolution);
        }

        /// <summary>
        /// Выводит все файлы в текущей директории, удовлетворяющие введенной маске.
        /// </summary>
        private void DisplayWithMaskAllFilesInCurrentDirectory()
        {
            string userMask = window.ReadUserMask();

            try
            {
                FileSystemInfo newDirectory = panel.AllObjects[panel.ActiveObjectIndex];
                if (!(newDirectory is DirectoryInfo))
                    return;

                string[] files = Directory.GetFiles(panel.AllObjects[panel.ActiveObjectIndex].FullName, userMask);

                if (files == null)
                {
                    window.DisplayEmptyMessage();
                    return;
                }

                Console.Clear();
                foreach (string str in files)
                    Console.WriteLine(str);

                ContinueWorking();
            }
            catch (Exception e)
            {
                window.Clear(5);
                window.DisplayMessage(e.Message);
            }
        }

        /// <summary>
        /// Копирует все файлы в другую директорию.
        /// </summary>
        private void CopyAllFilesToOtherDirectory()
        {
            string pathTo = window.AskingForFullFilePath();

            window.Clear(5);
            bool remake = window.RemakeOrDont();

            CopyDir(panel.AllObjects[panel.ActiveObjectIndex].FullName, pathTo, remake);
        }

        /// <summary>
        /// Копирует директорию.
        /// </summary>
        /// <param name="FromDir"> Путь директории, которую копируем.</param>
        /// <param name="ToDir"> Путь директории, куда копируем.</param>
        /// <param name="remake"> true - пересоздаем ли уже имеющиеся объекты, false - нет.</param>
        private void CopyDir(string FromDir, string ToDir, bool remake)
        {
            try
            {
                bool check = false;
                try
                {
                    Directory.CreateDirectory(ToDir);
                }
                catch
                {
                    check = true;
                }

                if (check != true)
                {
                    foreach (string s1 in Directory.GetFiles(FromDir))
                    {
                        string s2 = Path.Combine(ToDir, Path.GetFileName(s1));
                        if (System.IO.File.Exists(s2))
                        {
                            // Не пересоздаем.
                            if (!remake)
                                continue;
                        }

                        System.IO.File.Copy(s1, s2);
                    }
                }

                foreach (string s in Directory.GetDirectories(FromDir))
                {
                    bool checkTwo = false;
                    try
                    {
                        Path.GetFileName(s);
                    }
                    catch
                    {
                        checkTwo = true;
                    }

                    if (checkTwo)
                        continue;

                    CopyDir(s, Path.Combine(ToDir, Path.GetFileName(s)), remake);
                }
            }
            catch (Exception e)
            {
                window.Clear(6);
                window.DisplayMessage(e.Message);
            }
        }

        /// <summary>
        /// Выводит все файлы, удовлетворяющие маске, в текущей директории и ее поддиректориях
        /// </summary>
        private void DisplayWithMaskAllFilesInCurrentDirectoryAndUnderDirectories()
        {
            string userMask = window.ReadUserMask();
            try
            {
                FileSystemInfo newDirectory = panel.AllObjects[panel.ActiveObjectIndex];
                if (!(newDirectory is DirectoryInfo))
                    return;

                string[] fullFilesPath = Directory.GetFiles(panel.AllObjects[panel.ActiveObjectIndex].FullName, userMask, SearchOption.AllDirectories);

                if (fullFilesPath == null)
                {
                    window.DisplayEmptyMessage();
                    return;
                }

                Console.Clear();
                foreach (string str in fullFilesPath)
                    Console.WriteLine(str);

                ContinueWorking();
            }
            catch (Exception e)
            {
                window.Clear(5);
                window.DisplayMessage(e.Message);
            }
        }

        /// <summary>
        /// Меняет директорию.
        /// </summary>
        private void ChangeDirectory()
        {
            FileSystemInfo newDirectory = panel.AllObjects[panel.ActiveObjectIndex];
            if (newDirectory != panel.CurDirectory)
            {
                if (!(newDirectory is DirectoryInfo))
                {
                    try
                    {
                        Process.Start(((FileInfo)newDirectory).FullName);
                    }
                    catch (Exception e)
                    {
                        window.Clear(5);
                        window.DisplayMessage(e.Message);
                    }

                    return;
                }
            }
            else
                newDirectory = (new DirectoryInfo(panel.CurDirectory.FullName).Parent);

            panel.CurDirectory = newDirectory;

            if (newDirectory != null)
                panel.SetObjects(newDirectory);
            else
                panel.SetDiscs();
        }

        /// <summary>
        /// Считывает файл и затем выводит его содержимое в консоль.
        /// </summary>
        private void ReadAndWriteFileInConsole()
        {
            if (panel.CurDirectory == null)
                return;

            window.Clear(5);

            FileSystemInfo newObj = panel.AllObjects[panel.ActiveObjectIndex];
            string curFileName = newObj.Extension;
            if (curFileName != ".txt" || newObj is DirectoryInfo || newObj == null)
            {
                window.DisplayMessage("Выбран не файл типа txt, выберете другой для данной операции.");
                return;
            }

            if (((FileInfo)newObj).Length > 10000)
            {
                window.DisplayMessage("Файл больше 10000 символов(слишком большой), выберете поменьше.");
                return;
            }

            string encoding = window.AskingForEncoding();

            Console.Clear();

            try
            {
                string[] lines = null;

                var curEncoding = Encoding.UTF8;

                if (encoding == "UTF8")
                    curEncoding = Encoding.UTF8;
                if (encoding == "UTF32")
                    curEncoding = Encoding.UTF32;
                else
                    curEncoding = Encoding.ASCII;


                lines = System.IO.File.ReadAllLines(panel.AllObjects[panel.ActiveObjectIndex].FullName, curEncoding);

                foreach (string line in lines)
                    Console.WriteLine(line, curEncoding);
            }
            catch (Exception e)
            {
                window.DisplayMessage(e.Message);
            }

            ContinueWorking();
        }

        /// <summary>
        /// Возобновляет работу приложения(после вывод файла в "новом окне").
        /// </summary>
        private void ContinueWorking()
        {
            Console.WriteLine("\nДля продолжения работы нажмите 'ENTER'");
            while (true)
            {
                ConsoleKey userKey = Console.ReadKey().Key;
                if (userKey == ConsoleKey.Enter)
                    break;
            }
            Console.Clear();

            window.DisplayStartMenu();
            panel.DisplayAllObjectsInCurrentDirectory();
        }

        /// <summary>
        /// Конкатенация и вывод в консоль файлов.
        /// </summary>
        private void ConcatenationAndWritingFiles()
        {
            string ans = null;
            window.ConcatenationMessage();
            while (true)
            {
                string userInput = window.AskingForFullFilePathVersionForCincatination(1);
                if (userInput == "")
                    break;

                try
                {
                    FileSystemInfo newObj = new FileInfo(userInput);
                    string curFileName = newObj.Extension;
                    if (curFileName != ".txt" || newObj == null)
                    {
                        window.DisplayMessage(1, "Выбран не файл типа txt, выберете другой для данной операции.");
                        return;
                    }

                    if (((FileInfo)newObj).Length > 10000)
                    {
                        window.DisplayMessage(1, "Файл больше 10000 символов(слишком большой), выберете поменьше.");
                        return;
                    }

                    ans += System.IO.File.ReadAllText(userInput, Encoding.UTF8);
                }
                catch (Exception e)
                {
                    window.DisplayMessage(1, e.Message);
                }

                window.Clear(2);
            }

            if (ans == null)
                return;

            Console.Clear();
            Console.Write(ans, Encoding.UTF8);

            ContinueWorking();
        }

    }
}

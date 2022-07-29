using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Collections.ObjectModel;

namespace FileManager
{
    class Panel
    {
        #region Params

        /// <summary>
        /// Координаты начала панели.
        /// </summary>
        public static (int, int) Coords = (0, 9);

        /// <summary>
        /// Высота панели.
        /// </summary>
        public static int PanelHeight = 16;

        /// <summary>
        /// Ширина панели.
        /// </summary>
        public static int PanelWidth = Console.LargestWindowWidth * 2 / 3 - 1;
        #endregion

        /// <summary>
        /// Размер окна.
        /// </summary>
        private const int WINDOW_SIZE = 10;

        /// <summary>
        /// "Окно", нужно при выводе в консоль, иметация очереди.
        /// </summary>
        private List<int> displayWindowIndexes = new List<int>(WINDOW_SIZE);

        /// <summary>
        /// Текущая директория.
        /// </summary>
        private FileSystemInfo curDirectory = null;
        public FileSystemInfo CurDirectory
        {
            get
            {
                return curDirectory;
            }

            set
            {
                try
                {
                    curDirectory = value;
                }
                catch
                {
                    throw new Exception("Произошла ошибка при попытке изменении директории");
                }
            }
        }

        /// <summary>
        /// Массив всех объектов.
        /// </summary>
        private List<FileSystemInfo> allObjects = new List<FileSystemInfo>();
        public List<FileSystemInfo> AllObjects
        {
            get
            {
                return allObjects;
            }
        }

        /// <summary>
        /// Индекс объекта, на котором мы сейчас находимся.
        /// </summary>
        private int activeObjectIndex;
        public int ActiveObjectIndex
        {
            get
            {
                return activeObjectIndex;
            }

            set
            {
                if (activeObjectIndex < 0 || activeObjectIndex >= allObjects.Count)
                    throw new IndexOutOfRangeException();

                activeObjectIndex = value;
            }
        }

        /// <summary>
        /// Конструктор(изначально загружаем диски).
        /// </summary>
        public Panel()
        {
            SetDiscs();
        }

        /// <summary>
        /// Загрузка дисков.
        /// </summary>
        public void SetDiscs()
        {
            if (allObjects.Count != 0)
            {
                allObjects.Clear();
                displayWindowIndexes.Clear();
            }

            foreach (DriveInfo disk in DriveInfo.GetDrives())
            {
                if (disk.IsReady)
                    allObjects.Add(new DirectoryInfo(disk.Name));
            }

            for (int i = 0; i < Math.Min(allObjects.Count, WINDOW_SIZE); ++i)
                displayWindowIndexes.Add(i);

            curDirectory = null;
        }

        /// <summary>
        /// Обновление массива объектов.
        /// </summary>
        /// <param name="curDirectory"></param>
        public void SetObjects(FileSystemInfo curDirectory)
        {
            if (allObjects.Count != 0)
            {
                allObjects.Clear();
                displayWindowIndexes.Clear();
            }

            allObjects.Add(curDirectory);
            activeObjectIndex = 0;

            this.curDirectory = curDirectory;

            foreach (string directory in Directory.GetDirectories(curDirectory.FullName))
                allObjects.Add(new DirectoryInfo(directory));

            foreach (string file in Directory.GetFiles(curDirectory.FullName))
                allObjects.Add(new FileInfo(file));

            for (int i = 0; i < Math.Min(AllObjects.Count, WINDOW_SIZE); ++i)
                displayWindowIndexes.Add(i);
        }

        /// <summary>
        /// Переход к объекту выше в той же директории.
        /// </summary>
        public void GoUp()
        {
            if (displayWindowIndexes.Count == 0)
                throw new Exception("Произошла ошибка, размер количества файлов равен нулю.");

            if (displayWindowIndexes[0] == 0)
            {
                if (activeObjectIndex != 0)
                    --activeObjectIndex;

                return;
            }

            for (int i = 0; i < displayWindowIndexes.Count; ++i)
                --displayWindowIndexes[i];
            --activeObjectIndex;
        }

        /// <summary>
        /// Переход к объекту ниже в той же директории.
        /// </summary>
        public void GoDown()
        {

            if (displayWindowIndexes.Count == 0)
                throw new Exception("Произошла ошибка, размер количества файлов равен нулю.");

            if (displayWindowIndexes[displayWindowIndexes.Count - 1] == allObjects.Count - 1)
            {
                if (activeObjectIndex != (allObjects.Count - 1))
                    ++activeObjectIndex;

                return;
            }

            for (int i = 0; i < displayWindowIndexes.Count; ++i)
                ++displayWindowIndexes[i];

            ++activeObjectIndex;
        }

        /// <summary>
        /// Очищение внутренней составляющей панели.
        /// </summary>
        private void ClearingSquare()
        {
            for (int i = Coords.Item1 + 1; i < PanelHeight - 1; ++i)
            {
                string str = null;
                for (int j = Coords.Item2; j < PanelWidth - 1; ++j)
                    str += ' ';

                Console.SetCursorPosition(Coords.Item1 + 1, Coords.Item2 + i);
                Console.Write(str);
            }
        }

        /// <summary>
        /// Вывод всех объектов текущей директории.
        /// </summary>
        public void DisplayAllObjectsInCurrentDirectory()
        {
            ClearingSquare();

            for (int i = 0; i < displayWindowIndexes.Count; ++i)
            {
                if (displayWindowIndexes[i] == activeObjectIndex)
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.SetCursorPosition(Coords.Item1 + 1, Coords.Item2 + i + 1);

                if (displayWindowIndexes[i] == 0 && curDirectory != null)
                    Console.Write("...");
                else
                    Console.Write(allObjects[displayWindowIndexes[i]].Name);

                if (displayWindowIndexes[i] == activeObjectIndex)
                    Console.ResetColor();
            }

            return;
        }
    }
}

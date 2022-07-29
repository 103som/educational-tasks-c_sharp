using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    /// <summary>
    /// Класс, имитирующий работу консольного окна.
    /// </summary>
    class ConsoleWindow
    {
        static ConsoleWindow()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Console.LargestWindowWidth * 2 / 3, Console.LargestWindowHeight * 2 / 3);
            Console.SetBufferSize(Console.LargestWindowWidth * 2 / 3, Console.LargestWindowHeight * 2 / 3);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Вывод прямоугольного контура в консоль.
        /// </summary>
        /// <param name="posX"> X координата.</param>
        /// <param name="posY"> Y координата.</param>
        /// <param name="sizeX"> Ширина.</param>
        /// <param name="sizeY"> Высота.</param>
        public void PrintContour(int posX, int posY, int sizeX, int sizeY)
        {
            int rightPosX = posX + sizeX;
            int downPosY = posY + sizeY;

            for (int i = posY; i <= downPosY; ++i)
            {
                for (int j = posX; j <= rightPosX; ++j)
                {
                    Console.SetCursorPosition(j, i);

                    if (i == posY && j == posX)
                    {
                        Console.Write("╔");
                    }
                    else if (i == posY && j == rightPosX)
                    {
                        Console.Write("╗");
                    }
                    else if (i == downPosY && j == posX)
                    {
                        Console.Write("╚");
                    }

                    else if (i == downPosY && j == rightPosX)
                    {
                        Console.Write("╝");
                    }
                    else if ((i == posY && posX < rightPosX) || ((i == downPosY && posX < rightPosX)))
                    {
                        Console.Write("═");
                    }
                    else
                    {
                        Console.Write("║");
                        Console.SetCursorPosition(rightPosX, i);
                        Console.Write("║");
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="posX"> X координата.</param>
        /// <param name="posY"> Y координата.</param>
        /// <param name="message"> Сообщение для вывода в консоль.</param>
        public void PrintText(int posX, int posY, string message)
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(message);
        }

        /// <summary>
        /// Вывод стартового набора изображений(они не перерисовываются).
        /// </summary>
        public void DisplayStartMenu()
        {
            (new ConsoleWindow()).PrintContour(0 + 7, 0, 20, 2);
            Console.SetCursorPosition(2 + 7, 1);
            Console.Write(FileManager.allAvaliableOperations[FileManager.AvaliableOperations.CreateTxtFile]);

            (new ConsoleWindow()).PrintContour(21 + 7, 0, 20, 2);
            Console.SetCursorPosition(23 + 7, 1);
            Console.Write(FileManager.allAvaliableOperations[FileManager.AvaliableOperations.DisplayTxtFile]);

            (new ConsoleWindow()).PrintContour(42 + 7, 0, 20, 2);
            Console.SetCursorPosition(44 + 7, 1);
            Console.Write(FileManager.allAvaliableOperations[FileManager.AvaliableOperations.ConcatenationFiles]);

            (new ConsoleWindow()).PrintContour(63 + 7, 0, 20, 2);
            Console.SetCursorPosition(65 + 7, 1);
            Console.Write(FileManager.allAvaliableOperations[FileManager.AvaliableOperations.CopyFile]);

            (new ConsoleWindow()).PrintContour(84 + 7, 0, 20, 2);
            Console.SetCursorPosition(85 + 7, 1);
            Console.Write(FileManager.allAvaliableOperations[FileManager.AvaliableOperations.TransposeFile]);

            (new ConsoleWindow()).PrintContour(105 + 7, 0, 46, 2);
            Console.SetCursorPosition(107 + 7, 1);
            Console.Write(FileManager.allAvaliableOperations[FileManager.AvaliableOperations.DisplayWithMaskCurrentDirectory]);

            (new ConsoleWindow()).PrintContour(0 + 7, 3, 67, 2);
            Console.SetCursorPosition(2 + 7, 4);
            Console.Write(FileManager.allAvaliableOperations[FileManager.AvaliableOperations.DisplayWithMaskAllDirectories]);

            (new ConsoleWindow()).PrintContour(67 + 8, 3, 83, 2);
            Console.SetCursorPosition(73 + 8, 4);
            Console.Write(FileManager.allAvaliableOperations[FileManager.AvaliableOperations.CopyAndCreateForDirectory]);

            (new ConsoleWindow()).PrintContour(70, 6, 15, 2);
            Console.SetCursorPosition(72, 7);
            Console.Write(FileManager.allAvaliableOperations[FileManager.AvaliableOperations.DeleteTxtFile]);

            (new ConsoleWindow()).PrintContour(0, 9, Panel.PanelWidth, Panel.PanelHeight);
        }

        /// <summary>
        /// Получение от пользователя пути к файлу или директории.
        /// </summary>
        /// <returns> (true - если файл txt, иначе false), (путь к объекту).</returns>
        public (bool, string) AskingForFileOrDirectoryName()
        {
            Console.SetCursorPosition(1, Panel.Coords.Item1 + Panel.PanelHeight + 1 + 9);
            Console.Write("Для создания текстового файла введите 'txt'(иначе будет создана папка).");
            string userInput = Console.ReadLine();

            Console.SetCursorPosition(1, Panel.Coords.Item1 + Panel.PanelHeight + 2 + 9);
            bool isItTxt = true;

            if (userInput.ToLower() == "txt")
            {
                Console.Write("Введите название будущего txt файла(<= 200 символов), или нажмите 'Enter' и я сам его выберу.");
            }
            else
            {
                Console.Write("Введите название будущей папки(<= 200 символов), или нажмите 'Enter' и я сам его выберу.");
                isItTxt = false;
            }

            string userChoice = Console.ReadLine();
            if (userChoice == "" || userChoice.Length > 200)
                return (isItTxt, "Onii-chan baka");

            // Проверить на корректность.
            return (isItTxt, userChoice);
        }

        /// <summary>
        /// Очищение нужного количества строк в консольном окне.
        /// </summary>
        /// <param name="stringCount"> Количество строк к очистке.</param>
        public void Clear(int stringCount)
        {
            string helpStr = null;
            for (int i = 0; i <= 200; ++i)
                helpStr += ' ';

            for (int i = 0; i < stringCount; ++i)
            {
                Console.SetCursorPosition(1, Panel.Coords.Item1 + Panel.PanelHeight + 1 + i + 9);
                Console.Write(helpStr);
            }
        }

        /// <summary>
        /// Вывод сообщение в консоль.
        /// </summary>
        /// <param name="str"> Входная строка.</param>
        public void DisplayMessage(string str)
        {
            Console.SetCursorPosition(1, Panel.Coords.Item1 + Panel.PanelHeight + 1 + 9);
            Console.Write(str);
        }

        /// <summary>
        /// Вывод сообщение в консоль, начиная с нужной строки.
        /// </summary>
        /// <param name="strsDown"> Смещение при выводе.</param>
        /// <param name="str"> Входная строка.</param>
        public void DisplayMessage(int strsDown, string str)
        {
            Console.SetCursorPosition(1, Panel.Coords.Item1 + Panel.PanelHeight + 1 + 9 + strsDown);
            Console.Write(str);
        }

        /// <summary>
        /// Получает требуемую кодировку файла.
        /// </summary>
        /// <returns> Нужную кодировку.</returns>
        public string AskingForEncoding()
        {
            while (true)
            {
                Console.SetCursorPosition(1, Panel.Coords.Item1 + Panel.PanelHeight + 1 + 9);
                Console.Write("Выберете кодировку(вам нужно нажать на одну из указанных клавиш): UTF8 - '1', UTF32 - '2', ASCII - '3'.");
                string userInput = Console.ReadLine();

                if (userInput == "1")
                    return ("UTF8");

                if (userInput == "2")
                    return ("UTF32");

                if (userInput == "3")
                    return ("ASCII");
                Clear(1);
            }
        }

        /// <summary>
        /// Выводит в консоль сообщени-подсказку.
        /// </summary>
        public void DisplayHelpDeleteMessage()
        {
            Console.SetCursorPosition(1, Panel.Coords.Item1 + Panel.PanelHeight + 1 + 9);
            Console.Write("P.S.(Для удаления элемента сделайте его выбранным а затем нажмите F10. Ой, поздно написал.)");
        }

        /// <summary>
        /// Запрашивает путь к файлу.
        /// </summary>
        /// <returns> Путь к файлу.</returns>
        public string AskingForFullFilePath()
        {
            Console.SetCursorPosition(1, Panel.Coords.Item1 + Panel.PanelHeight + 1 + 9);
            Console.Write("Введите полный путь ведущий к нужной директории.");

            return (Console.ReadLine());
        }

        /// <summary>
        /// Запрашивает путь к файлу(Выводит сообщение о запросе со смещением строк).
        /// </summary>
        /// <param name="strsDown"> Смещение строк.</param>
        /// <returns> Путь к файлу.</returns>
        public string AskingForFullFilePath(int strsDown)
        {
            Console.SetCursorPosition(1, Panel.Coords.Item1 + Panel.PanelHeight + 1 + 9 + strsDown);
            Console.Write("Введите полный путь ведущий к нужной директории.");

            return (Console.ReadLine());
        }

        /// <summary>
        /// Выводит в консоль сообщение с просьбой ввести полные пути текстовых файлов.
        /// </summary>
        public void ConcatenationMessage()
        {
            Console.SetCursorPosition(1, Panel.Coords.Item1 + Panel.PanelHeight + 1 + 9);
            Console.Write("Вводите полные пути текстовых файлов для конкатинирования, для того, чтобы закончить ввод - нажмите 'TAB'");
        }

        /// <summary>
        /// Считывает маску, введенную пользователем.
        /// </summary>
        /// <returns> Маску.</returns>
        public string ReadUserMask()
        {
            Console.SetCursorPosition(1, Panel.Coords.Item1 + Panel.PanelHeight + 1 + 9);
            Console.Write("Введите вашу маску для поиска по ней.");

            return (Console.ReadLine());
        }

        /// <summary>
        /// Выводит в консоль сообщение о пустоте директории.
        /// </summary>
        public void DisplayEmptyMessage()
        {
            Console.SetCursorPosition(2, Panel.Coords.Item1 + Panel.PanelHeight + 1 + 9);
            Console.Write("Директория пуста.");
        }

        /// <summary>
        /// Запрашивает способ работы с файлами при копировании директорий.
        /// </summary>
        /// <returns> true - перезаписывать, false - не трогать.</returns>
        public bool RemakeOrDont()
        {
            while (true)
            {
                Console.SetCursorPosition(1, Panel.Coords.Item1 + Panel.PanelHeight + 1 + 9);
                Console.Write("Если хотите сохранить файлы с такими же названиями в другой директории, то введите 'Да', иначе введите 'Нет'.");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "да")
                    return true;

                if (userInput.ToLower() == "нет")
                    return false;
                Clear(5);
            }
        }

        /// <summary>
        /// Доп версия вышеописанной функции.
        /// </summary>
        public string AskingForFullFilePathVersionForCincatination(int strsDown)
        {
            Console.SetCursorPosition(1, Panel.Coords.Item1 + Panel.PanelHeight + 1 + 9 + strsDown);
            Console.Write("Введите полный путь к файлу.");

            return (Console.ReadLine());
        }
    }
}

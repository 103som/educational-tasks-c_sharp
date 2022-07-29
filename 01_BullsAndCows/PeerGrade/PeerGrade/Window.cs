using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageNamespace;

namespace WindowNamespace
{
    /// <summary>
    /// Класс, имитирующий работу окна(отвечает за ввод и вывод сообщений в консоль).
    /// </summary>
    class Window
    {
        /// <summary>
        /// Язык окна.
        /// </summary>
        private Language language = new Language();

        public void SetLanguage(string language)
        {
            this.language.SetInterfaceLanguage(language);
        }

        public string GetLanguage()
        {
            return language.GetInterfaceLanguage();
        }

        /// <summary>
        /// Смена языка игры с русского на английский и наоборот.
        /// </summary>
        public void ChangeLanguageEngRu()
        {
            if (language.GetInterfaceLanguage() == Language.EngLanguage)
                language.SetInterfaceLanguage(Language.RuLanguage);
            else if (language.GetInterfaceLanguage() == Language.RuLanguage)
                language.SetInterfaceLanguage(Language.EngLanguage);
        }

        /// <summary>
        /// Вывод в консоль правил игры.
        /// </summary>
        public void WriteGameRules()
        {
            if (language.GetInterfaceLanguage() == Language.RuLanguage)
            {
                Console.WriteLine("Суть игры в том что я загадываю число, а вы должны его отгадать, но не волнуйтесь, есть пара условий, облегчающих вам игру!");
                Console.WriteLine("1) Если вы угадали хоть какие-то цифры, содержащиеся в числе, но не на тех позициях, то я сообщу вам об этом.");
                Console.WriteLine("2) Если вы угадали цифры, находящиеся на своих местах, я также сообщу об этом.");
            }
            else if (language.GetInterfaceLanguage() == Language.EngLanguage)
            {
                Console.WriteLine("The essence of the game is that I randomly generate number, and you have to guess it, " +
                                  "but don't worry, there are a couple of conditions that make it easier for you to play !");
                Console.WriteLine("1) If you guessed at least some digits contained in the number, but in the wrong positions, then I will inform you about it.");
                Console.WriteLine("2) If you guessed the numbers in their places, I will also report this.");
            }

            Console.WriteLine("------------------------------------");
        }

        /// <summary>
        /// Вывод в консоль приветственного сообщения при первом запуске игры.
        /// </summary>
        public void WriteEnteringGameMessage()
        {
            if (language.GetInterfaceLanguage() == Language.RuLanguage)
                Console.WriteLine("Добро пожаловать в игру, сейчас я объясню правила и другие функции для комфортного игрового процесса.");
            else if (language.GetInterfaceLanguage() == Language.EngLanguage)
                Console.WriteLine("Welcome to the game, now I will explain the rules and other functions for comfortable game process.");

            Console.WriteLine("------------------------------------");
        }

        /// <summary>
        /// Вывод в консоль настроек игры.
        /// </summary>
        public void WriteSettings()
        {
            if (language.GetInterfaceLanguage() == Language.RuLanguage)
            {
                Console.WriteLine("Допустимые настройки игры:");
                Console.WriteLine("1 пункт: В игре присутствует возможность смены языка.");
                Console.WriteLine("2 пункт: (Специально для проффессионалов) вы можете играть не только в десятичной системе счисления," +
                    " но также в любой другой <= 36ричной, а то дальше уже буков не хватит. xd");
            }
            else if (language.GetInterfaceLanguage() == Language.EngLanguage)
            {
                Console.WriteLine("Valid Game Settings:");
                Console.WriteLine("1 station: In this game there is an ability to change the game language.");
                Console.WriteLine("2 station: (Special for pro-gamers) you can play not only in decimal number system, " +
                                  "but also in any other <= 36 number system, otherwise there won't be enough letters. xd");
            }
            Console.WriteLine("------------------------------------");
        }

        /// <summary>
        /// Вывод сообщения о победе в игре.
        /// </summary>
        public void WriteWinnigMessage()
        {
            if (language.GetInterfaceLanguage() == Language.RuLanguage)
                Console.WriteLine("Юхуууу, вы выйграли! Поздравляю!!!!");
            else if (language.GetInterfaceLanguage() == Language.EngLanguage)
                Console.WriteLine("Yeahhh, you won! Congrats!!!!");
        }

        /// <summary>
        /// Вывод в консоль сообщения с просьбой игрока ввести число.
        /// </summary>
        public void WriteAskingNumMessage()
        {
            if (language.GetInterfaceLanguage() == Language.RuLanguage)
                Console.WriteLine("Пожалуйста, введите ваше число.");
            else if (language.GetInterfaceLanguage() == Language.EngLanguage)
                Console.WriteLine("Please, enter your num.");
        }

        /// <summary>
        /// Считывает систему счисления.
        /// </summary>
        /// <returns> Система счисления, введенная пользователем.</returns>
        public string ReadingNumberSys()
        {
            if (language.GetInterfaceLanguage() == Language.RuLanguage)
                Console.WriteLine("Введите систему счисления, в которой хотите сыграть (<= 36)," +
                    " или ничего не вводите и нажмите ENTER - для случайной генерации системы счисления.");
            else if (language.GetInterfaceLanguage() == Language.EngLanguage)
                Console.WriteLine("Enter the number system, in which you want to play (<= 36), " +
                    "or don't write anything and press ENTER to randomly generate the number system.");
            return Console.ReadLine();
        }

        /// <summary>
        /// Считывает размер числа.
        /// </summary>
        /// <returns>Размер числа, введенный пользователем.</returns>
        public string ReadingNumSize()
        {
            if (language.GetInterfaceLanguage() == Language.RuLanguage)
                Console.WriteLine("Введите размер загаданного числа, или ничего не вводите и нажмите ENTER - для случайной генерации размера.");
            else if (language.GetInterfaceLanguage() == Language.EngLanguage)
                Console.WriteLine("Enter the size of the generating number, or don't write anything and press ENTER  to randomly generate the size.");
            return Console.ReadLine();
        }

        /// <summary>
        /// Считывает игровой язык.
        /// </summary>
        /// <returns> Игровой язык, введенный пользователем.</returns>
        public string ReadingGameLanguage()
        {
            if (language.GetInterfaceLanguage() == Language.RuLanguage)
                Console.WriteLine("Введите язык игры('RU' или 'ENG'), или нажмите 'ENTER' для сохранения текущего языка.");
            else if (language.GetInterfaceLanguage() == Language.EngLanguage)
                Console.WriteLine("Enter game language('RU' or 'ENG'), or press 'ENTER' for saving current language.");
            return Console.ReadLine();
        }

        /// <summary>
        /// Считывание введенного игроком сообщения.
        /// </summary>
        /// <returns> Сообщение, введенное игроком.</returns>
        public string ReadingPlayerMessage()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Вывод в консоль сообщения, просящего ввести корректные данные.
        /// </summary>
        public void AskingPlayerForCorrectInput()
        {
            if (language.GetInterfaceLanguage() == Language.RuLanguage)
                Console.WriteLine("Вы ввели некорретные данные, попробуйте еще раз или нажмите 'ENTER' для выбора параметра по умолчанию.");
            else if (language.GetInterfaceLanguage() == Language.EngLanguage)
                Console.WriteLine("You have entered incorrect data, please try again or press 'ENTER' for selectig default option.");

            Console.WriteLine("------------------------------------");
        }

        /// <summary>
        /// Вывод в консоль сообщения о количестве угаданных пользователем коров и быков.
        /// </summary>
        /// <param name="cowsCnt"> Количество коров.</param>
        /// <param name="bullsCnt"> Количество быков.</param>
        public void WriteGuessedCowsAndBullsCnt(int cowsCnt, int bullsCnt)
        {
            if (language.GetInterfaceLanguage() == Language.RuLanguage)
                if (cowsCnt != 0)
                    Console.WriteLine("Поздравляю, вы угадали: " + cowsCnt + " коров(чисел, присутствующих на любых позициях)!");
                else
                    Console.WriteLine("Увы, вы ни угадали ни одного быка(числа, на любой позиции), попробуйте еще раз.");
            else if (language.GetInterfaceLanguage() == Language.EngLanguage)
                if (cowsCnt != 0)
                    Console.WriteLine("Congrats, you guessed: " + cowsCnt + " cows(numbers on any positions)!");
                else
                    Console.WriteLine("Argghh, you haven't guessed a single cow(number, on any position), try again.");

            if (language.GetInterfaceLanguage() == Language.RuLanguage)
                if (bullsCnt != 0)
                    Console.WriteLine("Поздравляю, вы угадали: " + bullsCnt + " быков(чисел на своих позициях)!");
                else
                    Console.WriteLine("Увы, вы ни угадали ни одной коровы(числа на своей позиции), попробуйте еще раз.");
            else if (language.GetInterfaceLanguage() == Language.EngLanguage)
                if (bullsCnt != 0)
                    Console.WriteLine("Congrats, you guessed: " + bullsCnt + " bulls(numbers on their positions)!");
                else
                    Console.WriteLine("Argghh, you haven't guessed a single cow(number on it's positon), try again.");

            Console.WriteLine("------------------------------------");
        }

        /// <summary>
        /// Вывод в консоль предложение сыграть еще раз.
        /// </summary>
        public void WriteAskingForOneMoreGameMessage()
        {
            if (language.GetInterfaceLanguage() == Language.RuLanguage)
                Console.WriteLine("Хотите сыграть еще разок?(Ответьте 'Да' или 'Нет')");
            else if (language.GetInterfaceLanguage() == Language.EngLanguage)
                Console.WriteLine("Wanna play one more time?(Answer 'Yes' or 'No')");
        }

        /// <summary>
        /// Вывод в консоль сообщения, завершающего игру.
        /// </summary>
        public void WriteEndingGameMessage()
        {
            if (language.GetInterfaceLanguage() == Language.RuLanguage)
                Console.WriteLine("Спасибо за игру!");
            else if (language.GetInterfaceLanguage() == Language.EngLanguage)
                Console.WriteLine("Thank you for playing!");
            Console.ReadLine();
        }

        /// <summary>
        /// Вывод в консоль сообщения с просьбой ввести корректное отгадываемое число.
        /// </summary>
        public void AskingForCorrectGuessingNum()
        {
            if (language.GetInterfaceLanguage() == Language.RuLanguage)
                Console.WriteLine("Вы ввели некорректное число, попробуйте еще раз.");
            else if (language.GetInterfaceLanguage() == Language.EngLanguage)
                Console.WriteLine("You have entered incorrect number, please try again.");
            Console.WriteLine("------------------------------------");
        }

        /// <summary>
        /// Вывод в консоль игровых параметров.
        /// </summary>
        /// <param name="sysPos"> Система счисления.</param>
        /// <param name="numSize"> Количество символов в числе.</param>
        public void WriteGameParams(int sysPos, int numSize)
        {
            if (language.GetInterfaceLanguage() == Language.RuLanguage)
            {
                Console.WriteLine("Игра начинается со следующими параметрами:");
                Console.WriteLine("Язык: RU");
                Console.WriteLine("Система счисления: " + sysPos);
                Console.WriteLine("Размер числа: " + numSize);
            }
            else if (language.GetInterfaceLanguage() == Language.EngLanguage)
            {
                Console.WriteLine("Game starts with the following params:");
                Console.WriteLine("Language: ENG");
                Console.WriteLine("Numbet System: " + sysPos);
                Console.WriteLine("Num size: " + numSize);
            }
        }

        /// <summary>
        /// Вывод в консоль вариации сообщения о неправильных входных данных.
        /// </summary>
        public void WriteAlternativeWrongInputMessage()
        {

            if (language.GetInterfaceLanguage() == Language.RuLanguage)
                Console.WriteLine("Не удалось распознать ввод, попробуйте еще раз.");
            else if (language.GetInterfaceLanguage() == Language.EngLanguage)
                Console.WriteLine("Failed to recognize the input, please try again.");
        }
    }
}

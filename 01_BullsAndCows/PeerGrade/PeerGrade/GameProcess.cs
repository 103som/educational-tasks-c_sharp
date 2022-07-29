using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowNamespace;
using LanguageNamespace;
using RandomNumberNamespace;

namespace GameProccesNamespace
{
    /// <summary>
    /// Класс, отвечающий за логику игры(использует остальные побочные классы).
    /// </summary>
    class GameProcess
    {
        /// <summary>
        /// Игровое окно.
        /// </summary>
        private Window window = new Window();
        
        /// <summary>
        /// Загадываемое число.
        /// </summary>
        private RandomNumber gueesedNum = new RandomNumber();
        
        /// <summary>
        /// Проверяет корректность введенной системы счисления.
        /// </summary>
        /// <param name="convertNumberSys"> Введенная пользователем система счисления.</param>
        /// <returns> Bool результат проверки.</returns>
        public bool NumSysChecking(string convertNumberSys)
        {
            int numberSys;
            if (!int.TryParse(convertNumberSys, out numberSys))
                return false;

            return (numberSys >= 2 && numberSys <= 36);
        }

        /// <summary>
        /// Проверяет корректность введенного пользователем размера числа.
        /// </summary>
        /// <param name="convertNumberSys">Введенный пользователем размер числа.</param>
        /// <returns> Bool результат проверки.</returns>
        public bool NumSizeChecking(string convertNumberSys)
        {
            int numSize;
            if (!int.TryParse(convertNumberSys, out numSize))
                return false;

            return (numSize >= 1 && numSize <= gueesedNum.GetSysPos());
        }

        /// <summary>
        /// Проверяет является ли передаваемая переменная одним из существующих языков.
        /// </summary>
        /// <param name="language"> Введенный пользователем язык игры.</param>
        /// <returns> Bool результат проверки.</returns>
        public bool LanguageChecking(string language)
        {
            return (language == Language.EngLanguage || language == Language.RuLanguage);
        }

        /// <summary>
        /// Обрабатывает введенный пользователем язык.
        /// </summary>
        public void EnteringPlayerLanguage()
        {
            while (true)
            {
                /// Ввод пользователем языка и проверка на желания пользователя оставить текущий язык(в моей проге
                /// нажатие ENTER означает сохранение параметра настроек неизменным (написано в правилах)).
                string playerLanguage = window.ReadingGameLanguage().ToUpper();
                if (string.IsNullOrEmpty(playerLanguage))
                    break;

                /// Если пользователь решил сменить язык, то вызываем функцию у window и меняем его.
                if (LanguageChecking(playerLanguage))
                {
                    if (playerLanguage != window.GetLanguage())
                        window.ChangeLanguageEngRu();
                    break;
                }

                /// Вывод сообщения о повторном введении корректного числа.
                window.AskingPlayerForCorrectInput();
            }
        }

        /// <summary>
        /// Обрабатывает введеную пользователем систему счисления.
        /// </summary>
        public void EnteringNumSys()
        {
            while (true)
            {
                string numSys = window.ReadingNumberSys();
                if (string.IsNullOrEmpty(numSys))
                {
                    gueesedNum.SetSysPos(gueesedNum.GenerateRandomNumSys());
                    break;
                }

                if (NumSysChecking(numSys))
                {
                    gueesedNum.SetSysPos(int.Parse(numSys));
                    break;
                }

                window.AskingPlayerForCorrectInput();
            }
        }

        /// <summary>
        /// Обрабатывает введенный пользователем размер числа.
        /// </summary>
        public void EnteringNumSize()
        {
            while (true)
            {
                string numSize = window.ReadingNumSize();
                if (string.IsNullOrEmpty(numSize))
                {
                    gueesedNum.SetNumSize(gueesedNum.GenerateRandomNumSize());
                    break;
                }

                if (NumSizeChecking(numSize))
                {
                    gueesedNum.SetNumSize(int.Parse(numSize));
                    break;
                }

                window.AskingPlayerForCorrectInput();
            }
        }

        /// <summary>
        /// Игра с пользователем(считывание его чиcла и дальнейшая обработка).
        /// </summary>
        public void PlayingWithUser()
        {
            while (true)
            {
                window.WriteAskingNumMessage();

                /// Считывание числа пользователя.
                string playerNum = window.ReadingPlayerMessage().ToUpper();
                if (!CheckingCorrectPlayerNumInput(playerNum))
                {
                    window.AskingForCorrectGuessingNum();
                    continue;
                }

                /// Проверка победы игрока.
                if (CheckPlayerWin(playerNum))
                {
                    window.WriteWinnigMessage();
                    break;
                }

                /// Подсчет кол-ва коров и быков .
                Tuple<int, int> cowsAndBulls = CountingCowsAndBulls(playerNum);
                window.WriteGuessedCowsAndBullsCnt(cowsAndBulls.Item1, cowsAndBulls.Item2);
            }
        }

        /// <summary>
        /// Проверяет корректность введеного пользователем числа(при отгадывании).
        /// </summary>
        /// <param name="playerNum"> Число, введенное пользователем.</param>
        /// <returns> Bool результат проверки.</returns>
        public bool CheckingCorrectPlayerNumInput(string playerNum)
        {
            /// Если число начинается с нуля, или число отрицательное, или длина не совпадает с длиной загаданного числа.
            int sysPos = gueesedNum.GetSysPos();
            if (playerNum.Length < 1 || playerNum[0] == '-' || (playerNum[0] == '0' && playerNum.Length != 1) 
                || playerNum.Length != gueesedNum.GetNum().Length)
                return false;

            /// Проверка на соответствие всех символов числа, выбранной системе счисления, + проверка на повторяющиеся символы.
            SortedSet<char> checkRepetitiveNums = new SortedSet<char>();
            for (int i = 0; i < playerNum.Length; ++i)
            {
                int help = checkRepetitiveNums.Count;
                checkRepetitiveNums.Add(playerNum[i]);
                if (checkRepetitiveNums.Count == help)
                    return false;

                int curPos = 0;
                if (playerNum[i] >= '0' && playerNum[i] <= '9')
                    curPos = playerNum[i] - '0';
                else if (playerNum[i] >= 'a' && playerNum[i] <= 'z')
                    curPos = playerNum[i] - 'a' + 10;
                else if (playerNum[i] >= 'A' && playerNum[i] <= 'Z')
                    curPos = playerNum[i] - 'A' + 10;
                else
                    return false;

                if (curPos >= sysPos)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Считает количество 'быков' и 'коров'.
        /// </summary>
        /// <param name="playerNum"> Число, введенное пользователем.</param>
        /// <returns> Возвращает кол-во коров и быков.</returns>
        public Tuple<int, int> CountingCowsAndBulls(string playerNum)
        {
            int cowsCnt = 0, bullsCnt = 0;

            /// Создание и заполнение списка уникальных цифр и букв числа(нужно для дальнейшего подсчета быков), 
            /// использую set для опт. временной ассимптотики.
            SortedSet<int> symbolsCount = new SortedSet<int>();
            for (int i = 0; i < gueesedNum.GetNum().Length; ++i)
                symbolsCount.Add(gueesedNum.GetNum()[i]);

            for (int i = 0; i < playerNum.Length; ++i)
            {
                /// Подсчет коров.
                if (playerNum[i] == gueesedNum.GetNum()[i])
                    ++bullsCnt;
                
                /// Подсчет быков(если элемент из строки пользователя встречается в нашем "словаре", то увеличиваем кол-во быков.
                if (gueesedNum.GetNum().Contains(playerNum[i]))
                    ++cowsCnt;
            }

            /// Поскольку сейчас в cowsCnt хранятся все символы совпадающие в числе пользователя и загаданном числе, то нужно вычесть
            /// угаданные на своих позициях числа.
            cowsCnt -= bullsCnt;

            return Tuple.Create<int, int>(cowsCnt, bullsCnt);
        }

        /// <summary>
        /// Проверяет угадал ли загаданное число игрок.
        /// </summary>
        /// <param name="playerNum"> Число, введенное пользователем.</param>
        /// <returns> Bool результат проверки.</returns>
        public bool CheckPlayerWin(string playerNum)
        {
            if (playerNum == gueesedNum.GetNum())
                return true;

            return false;
        }

        /// <summary>
        /// Проверяет хочет ли пользователь выйти из игры.
        /// </summary>
        /// <returns> Первый параметр:отвечает удалось ли распознать, что ввел пользователь,
        /// второй:хочет ли пользователь завершить игру. </returns>
        public Tuple<bool, bool> CheckingPlayerDecision()
        {
            /// Перевод всех символов сообщения к вернему регистру.
            string playerDecision = window.ReadingPlayerMessage().ToUpper();

            if (window.GetLanguage() == Language.EngLanguage)
            {
                if (playerDecision == "YES")
                    return Tuple.Create<bool, bool>(true, true);

                if (playerDecision == "NO")
                    return Tuple.Create<bool, bool>(true, false);
            }
            else if (window.GetLanguage() == Language.RuLanguage)
            {
                if (playerDecision == "ДА")
                    return Tuple.Create<bool, bool>(true, true);

                if (playerDecision == "НЕТ")
                    return Tuple.Create<bool, bool>(true, false);
            }

            return Tuple.Create<bool, bool>(false, false);
        }

        /// <summary>
        /// Вывод приветственного сообщения при первом запуске игры.
        /// </summary>
        private void StartingGameMessages()
        {
            window.WriteEnteringGameMessage();
            window.WriteGameRules();
            window.WriteSettings();
        }

        /// <summary>
        /// Проверяет, хочет ли пользователь завершить игру.
        /// </summary>
        /// <returns> Возвращает false, если пользователь хочет завершить игру, иначе true.</returns>
        public bool ChekingToContinuePlaying()
        {
            while (true)
            {
                Tuple<bool, bool> playerDecision = CheckingPlayerDecision();

                if (playerDecision.Item1 == false)
                {
                    window.WriteAlternativeWrongInputMessage();
                    continue;
                }
                else if (playerDecision.Item2 == false)
                {
                    window.WriteEndingGameMessage();
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Запускает игру.
        /// </summary>
        public void PlayGame()
        {
            StartingGameMessages();

            while (true)
            {
                EnteringPlayerLanguage();
                EnteringNumSys();
                EnteringNumSize();
                gueesedNum.SetNum(gueesedNum.GenerateRandomNum());
                
                window.WriteGameParams(gueesedNum.GetSysPos(), gueesedNum.GetNumSize());

                PlayingWithUser();

                window.WriteAskingForOneMoreGameMessage();
                if (!ChekingToContinuePlaying())
                    return;
            }
        }
    }
}

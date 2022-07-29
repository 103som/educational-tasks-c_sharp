using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace RandomNumberNamespace
{
    /// <summary>
    /// Класс, отвечающий за случайное число(генерируемое компьютером).
    /// </summary>
    class RandomNumber
    {
        /// <summary>
        /// Система счисления.
        /// </summary>
        private int sysPos;

        /// <summary>
        /// Генерируемое число.
        /// </summary>
        private string num;

        /// <summary>
        /// Размер числа.
        /// </summary>
        private int numSize;

        /// <summary>
        /// Создание числа по умолчанию.
        /// </summary>
        public RandomNumber()
        {
            sysPos = 10;
            numSize = 4;
            num = GenerateRandomNum();
        }

        /// <summary>
        /// Генерирует случайное число(которое пользователь в дальнейшем должен отгадать).
        /// </summary>
        /// <returns> Сгенерированное число.</returns>
        public string GenerateRandomNum()
        {
            Random random = new Random();
            /// Создаю set для проверки, была ли уже данная цифра в числе.
            SortedSet<char> setForCheckingDigits = new SortedSet<char>();

            string curNum = null;
            for (int i = 0; i < numSize; ++i)
            {
                int curSetSize;
                int value;
                char addingValue;

                /// В данном цикле сначала запоминаю количество уже имеющихся уникальных цифр 
                /// и затем сравниваю с полученным количеством после добавления очередной цифры,
                /// если количество не изменилось, значит цифра уже встречалась => не выходим из цикла, иначе осуществляем выход.
                do
                {
                    /// Проверка на случай, если число содержит более 2 цифр, то первая цифра не может быть нулем.
                    if (numSize >= 2 && i == 0)
                        value = random.Next(1, (int)sysPos);
                    else
                        value = random.Next(0, (int)sysPos);

                    addingValue = (char)('0' + value);
                    if (value >= 10)
                        addingValue = (char) ('A' + (value - 10));
                    curSetSize = setForCheckingDigits.Count;
                    setForCheckingDigits.Add(addingValue);
                } while (curSetSize == setForCheckingDigits.Count);

                curNum += addingValue;
            }

            /// Возврат полученного числа.
            return curNum;
        }

        /// <summary>
        /// Генерирует случайную систему счисления.
        /// </summary>
        /// <returns> Система счисления.</returns>
        public int GenerateRandomNumSys()
        {
            Random random = new Random();
            return random.Next(2, 37);
        }


        /// <summary>
        /// Генерирует случайный размер загаданного числа.
        /// </summary>
        /// <returns> Размер числа.</returns>
        public int GenerateRandomNumSize()
        {
            Random random = new Random();
            return random.Next(1, sysPos + 1);
        }

        public int GetSysPos()
        {
            return sysPos;
        }

        public void SetSysPos(int sysPos)
        {
            this.sysPos = sysPos;
        }

        public string GetNum()
        {
            return num;
        }

        public void SetNum(string num)
        {
            this.num = num;
        }

        public int GetNumSize()
        {
            return numSize;
        }

        public void SetNumSize(int numSize)
        {
            this.numSize = numSize;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixNamespace;
using Application;

namespace WindowNamespace
{
    class Window
    {
        /// <summary>
        /// Выводит матрицу в консоль.
        /// </summary>
        /// <param name="matrix"> Матрица.</param>
        public void WritingMatrix(Matrix matrix)
        {
            for (int i = 0; i < matrix.GetMatrix().Count; ++i)
            {
                for (int j = 0; j < matrix.GetMatrix()[i].Count; ++j)
                    Console.Write(String.Format("{0,10}", matrix.GetMatrix()[i][j]));
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Выводит в консоль сообщение с просьбой ввести число.
        /// </summary>
        public void WriteAskingForNumMessage()
        {
            Console.WriteLine("Введите ваше число для арифметической операции(число не превосходит по модулю 100).");
        }

        /// <summary>
        /// Выводит в консоль сообщение с просьбой выбрать тип операции.
        /// </summary>
        public void WriteAskingForOperationTypeMessage()
        {
            Console.WriteLine("Сейчас нужно выбрать операцию, которую хотите произвести.");
            Console.WriteLine("Для нахождения следа матрицы - Введите 1");
            Console.WriteLine("Для нахождения определителя - Введите 2");
            Console.WriteLine("Для решения СЛАУ - Введите 3");
            Console.WriteLine("Для осуществления транспонирования матрицы - Введите 4");
            Console.WriteLine("Для умножения матрицы на число - Введите 5");
            Console.WriteLine("Для нахождения суммы двух матриц - Введите 6");
            Console.WriteLine("Для нахождения разности двух матриц - Введите 7");
            Console.WriteLine("Для нахождения произведения двух матриц - Введите 8");
        }

        /// <summary>
        /// Выводит в косноль сообщение о ошибке ввода.
        /// </summary>
        public void WriteIncorrectInputMessage()
        {
            Console.WriteLine("Введены некорректные данные, попробуйте еще раз.");
            Console.WriteLine("------------------------------------------");
        }

        /// <summary>
        /// Выводит в консоль сообщение о ошибке ввода(Альтенативная версия).
        /// </summary>
        public void WriteIncorrectInputMessageAlternative()
        {
            Console.WriteLine("Не получилось распознать ввод, попробуйте еще раз.");
            Console.WriteLine("------------------------------------------");
        }

        /// <summary>
        /// Выводит в консоль сообщение об ошибке распознавания матрицы.
        /// </summary>
        public void WriteIncorrectMatrixInputMessage()
        {
            Console.WriteLine("Не удалось считать матрицу(друг, ты что-то ввел не так, прочитай правила ввода).");
            Console.WriteLine("(Напоминание: Элементы матрицы по модулю не превосходят 100).");
            Console.WriteLine("------------------------------------------");
        }

        /// <summary>
        /// Выводит в консоль сообщение с просьбой ввести матрицу.
        /// </summary>
        /// <param name="fromConsole"> Если true - то сообщение о вводе из консоли, иначе из файла.</param>
        public void WriteAskingForMatrixMessage(int inputType)
        {
            if (inputType == (int)Application.Application.ReadingMatrixOption.FromConsole)
            {
                Console.WriteLine("Введите матрицу в консоль.");
                Console.WriteLine("Также напомню, что вводить элементы нужно РОВНО ЧЕРЕЗ 1 ПРОБЕЛ, БЕЗ ПРОБЕЛА В КОНЦЕ СТРОКИ.");
            }
            else if (inputType == (int)Application.Application.ReadingMatrixOption.FromFile)
            {
                Console.WriteLine("Введите матрицу в текстовый документ(matrix.txt).");
                Console.WriteLine("Также напомню, что вводить элементы нужно РОВНО ЧЕРЕЗ 1 ПРОБЕЛ, БЕЗ ПРОБЕЛА В КОНЦЕ СТРОКИ.");
            }
            else
                Console.WriteLine("А вот и сгенерированная матрица, не обманул:).");
        }

        /// <summary>
        /// Выводит в консоль сообщение с просьбой выбрать способ ввода матрицы.
        /// </summary>
        public void WriteAskingForWayToInputMatrixMessage()
        {
            Console.WriteLine("Выберите способ ввода матрицы(Для ввода с консоли введите - 1, для ввода с файла - 2).");
            Console.WriteLine("P.S.(Путь к файлу: " + new Application.Application().PATH_TO_TXT_FILE + ").");
            Console.WriteLine("Лень придумывать матрицу для теста? Понимаю и облегчаю жизнь, вводим 'R' и не паримся:).");
        }

        /// <summary>
        /// Выводит в консоль сообщение с просьбой выбрать размерность матрицы.
        /// </summary>
        public void WriteAskingForDimensionMessage()
        {
            Console.WriteLine("Введите размерность матрицы(Сначала кол-во строк, затем кол-во столбцов, не больше 20).");
        }

        /// <summary>
        /// Выводит в консоль приветственное сообщение(при первом запуске приложения).
        /// </summary>
        public void WriteGreetingsMessage()
        {
            Console.WriteLine("Здравствуйте, спасибо, что решили использовать наш продукт.");
        }

        /// <summary>
        /// Считывает введенное игроком число.
        /// </summary>
        /// <returns> Введенное игроком число.</returns>
        public string ReadingPlayersNum()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Выводит в консоль найденный след матрицы.
        /// </summary>
        /// <param name="trace"> След матрицы.</param>
        public void WriteTrace(double trace)
        {
            Console.WriteLine("След марицы: " + trace);
        }

        /// <summary>
        /// Выводит в консоль результат операции транспонирования матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица.</param>
        public void WriteTransposeMatrix(Matrix matrix)
        {
            Console.WriteLine("Транспонированная матрица:\n");
            WritingMatrix(matrix);
        }

        /// <summary>
        /// Выводит в консоль результат суммирования матриц.
        /// </summary>
        /// <param name="matrix"> Матрица.</param>
        public void WriteMatrixSum(Matrix matrix)
        {
            Console.WriteLine("Сумма матриц:\n");
            WritingMatrix(matrix);
        }

        /// <summary>
        /// Выводит в консоль результат вычитания матриц.
        /// </summary>
        /// <param name="matrix"> Матрица.</param>
        public void WriteMatrixSub(Matrix matrix)
        {
            Console.WriteLine("Разность матриц:\n");
            WritingMatrix(matrix);
        }

        /// <summary>
        /// Выводит в консоль результат произведения матриц.
        /// </summary>
        /// <param name="matrix"> Матрица.</param>
        public void WriteMatrixMul(Matrix matrix)
        {
            Console.WriteLine("Произведение матриц:\n");
            WritingMatrix(matrix);
        }

        /// <summary>
        /// Выводит в консоль результат умножения матрицы на число.
        /// </summary>
        /// <param name="matrix"> Матрица.</param>
        public void WriteMatrixWithNumMul(Matrix matrix)
        {
            Console.WriteLine("Произведение матрицы с числом:");
            WritingMatrix(matrix);
        }

        /// <summary>
        /// Выводит в консоль найденный определитель(детерменант).
        /// </summary>
        /// <param name="determinate"> Определитель(детерменант).</param>
        public void WriteDeterminate(double determinate)
        {
            Console.WriteLine("Определитель(детерминант) матрицы: " + determinate);
        }

        /// <summary>
        /// Выводит в консоль сообщение о ошибке соотношения размеров(при равных размерах).
        /// </summary>
        public void WriteErrorEqualSize()
        {
            Console.WriteLine("Вы вввели некорректные данные, матрицы должны быть одинакового размера!!!");
        }

        /// <summary>
        /// Выводит в консоль сообщение о ошибке соотношения размеров(при равных размерах).
        /// </summary>
        public void WriteErrorNotEqualSize()
        {
            Console.WriteLine("Вы вввели некорректные данные(Кол-во столбцов Первой матрицы должно быть равно кол-во строк Второй матрицы)!!!!!");
        }

        /// <summary>
        /// Выводит в консоль найденное решение СЛАУ(системы линейных алгебраических уравнений).
        /// </summary>
        /// <param name="gaussResultMatrix"> Полученная X матрица.</param>
        public void WriteSLAE((double, List<double>)gaussResultMatrix)
        {
            if (gaussResultMatrix.Item1 == 0)
            {
                Console.WriteLine("Система не имеет решений.");
                return;
            }
            else if (gaussResultMatrix.Item1 == double.PositiveInfinity)
            {
                Console.WriteLine("Система имеет бесконечное число решений.");
                return;
            }
            
            Console.WriteLine("Решение СЛАУ(системы линейный алгебраических уравнений):\n");

            for (int i = 0; i < gaussResultMatrix.Item2.Count; ++i)
                Console.WriteLine("x" + (i + 1) + " = {0:0.####}", gaussResultMatrix.Item2[i]);
        }

        /// <summary>
        /// Выводит в консоль предложение продолжить работу.
        /// </summary>
        public void WriteEndingMessage()
        {
            Console.WriteLine("Для продолжения работы с приложением - Введите 'C', для выхода - абсолютно любой другой символ.");
        }

        /// <summary>
        /// Выводит в консоль сообщение с просьбой ввести кол-во строк.
        /// </summary>
        /// <param name="isItSquare"> true - если матрица квадртная, иначе false.</param>
        public void WriteAskingForRowsMessage(bool isItSquare = false)
        {
            if (isItSquare)
                Console.Write("P.S(Для данной операции матрица квадртаная, поэтому кол-во столбцов = кол-во строк), строк: ");
            else
                Console.Write("Строк: ");
        }

        /// <summary>
        /// Выводит в консоль сообщение с просьбой ввести кол-во столбцов.
        /// </summary>
        /// <param name="isItSquare"> true - если матрица квадртная, иначе false.</param>
        public void WriteAskingForColumnsMessage(bool isItSquare = false)
        {
            if (isItSquare)
                Console.Write("P.S(Для данной операции матрица квадртаная, поэтому кол-во столбцов = кол-во строк), столбцов: ");
            else
                Console.Write("Столбцов: ");
        }

        /// <summary>
        /// Выводит в консоль информацию о возможности рандомной генерации строк.
        /// </summary>
        public void WriteRandomGenerationMessage()
        {
            Console.WriteLine("(P.S. Для генерации параметров по умолчанию - Введите 'R' ).");
        }

        /// <summary>
        /// Выводит размер матрицы.
        /// </summary>
        /// <param name="n"> Количество строк.</param>
        /// <param name="m"> Количество столбцов.</param>
        public void WriteSize(int n, int m)
        {
            Console.WriteLine("N = " + n + "\nM = " + m);
        }

        /// <summary>
        /// Очищает консоль.
        /// </summary>
        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixNamespace;
using System.Collections.ObjectModel;
using WindowNamespace;
using System.IO;

namespace Application
{
    class Application
    {
        /// <summary>
        /// Путь к файлу Matrix.txt.
        /// </summary>
        public string PATH_TO_TXT_FILE = Environment.CurrentDirectory + "\\Matrix.txt";

        /// <summary>
        /// Игровое окно.
        /// </summary>
        private Window window = new Window();

        /// <summary>
        /// Специальный словарь, нужный для понимания обозначения констант.
        /// </summary>
        static readonly ReadOnlyDictionary<AvaliableOperations, string> allAvaliableOperations = new ReadOnlyDictionary<AvaliableOperations, string>
        (
            new Dictionary<AvaliableOperations, string>
            {
                {AvaliableOperations.FindTrace, "Нахождение следа матрицы"},
                {AvaliableOperations.Transpose, "Транспонирование матрицы"},
                {AvaliableOperations.SumWithMatrix, "Нахождение суммы матриц"},
                {AvaliableOperations.SubWithMatrix, "Нахождение разности матриц"},
                {AvaliableOperations.MulWithMatrix, "Нахождение произведения матриц"},
                {AvaliableOperations.MulWithNum, "Нахождение произведения матрицы на число"},
                {AvaliableOperations.FindDeterminate, "Нахождение определителя"},
                {AvaliableOperations.SLAE, "Решение СЛАУ"}
            }
        );

        /// <summary>
        /// Доступные операции, First - индекс начала списка, Last - индекс конца списка, 
        /// NonSquareMatrix - индекс, с которого начинаются неквадратные матрицы,
        /// MatrixWithNumOperations - индекс, после которого идут операции, задействующие одну матрицу и число,
        /// TwoMatrixOperations - индекс, с которого начинаются операции, использующие 2 матрицы.
        /// </summary>
        enum AvaliableOperations
        {
            First = 1,
            FindTrace = First,
            FindDeterminate,
            NonSquareMatrix,
            SLAE = NonSquareMatrix,
            Transpose,
            MatrixWithNumOperations,
            MulWithNum = MatrixWithNumOperations,
            TwoMatrixOperations,
            SumWithMatrix = TwoMatrixOperations,
            SubWithMatrix,
            MulWithMatrix,
            Last = MulWithMatrix
        }

        /// <summary>
        /// Режим считывания данных:
        /// 1 - с консоли, 2 - с текстового файла.
        /// </summary>
        public enum ReadingMatrixOption
        {
            FromConsole = 1,
            FromFile = 2,
            RandomGeneration = 3
        }

        /// <summary>
        /// Обрабатывает запос пользователя(на требуемую операцию).
        /// </summary>
        private int ReadingWantedOperation()
        {
            window.WriteAskingForOperationTypeMessage();

            int operationType = -1;
            while (!int.TryParse(window.ReadingPlayersNum(), out operationType))
            {
                if (operationType >= (int)AvaliableOperations.First && operationType <= (int)AvaliableOperations.Last)
                    break;
                
                window.WriteIncorrectInputMessage();
            }

            return operationType;
        }

        /// <summary>
        /// Проверка элементов матрицы на корректность(соответствуют требуемому числовому диапазону).
        /// </summary>
        /// <param name="matrix"> Проверяемая матрица.</param>
        /// <param name="n"> Количество строк.</param>
        /// <param name="m"> Количество столбцов.</param>
        /// <returns>true - если данные корректны, false - если нет.</returns>
        private bool CheckMatrixForCorrectInput(Matrix matrix, int n, int m)
        {
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    double curElement = matrix.GetMatrixElement(i, j);
                    if (curElement < Matrix.MIN_VALUE || curElement > Matrix.MAX_VALUE)
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Считывает матрицу с консоли.
        /// </summary>
        /// <param name="matrix"> Матрица.</param>
        /// <param name="n"> Количество строк.</param>
        /// <param name="m"> Количество столбцов.</param>
        /// <returns> Если матрица считалась, то первый элемет - true, иначе - false. Второй элемент - считанная матрица.</returns>
        private (bool, Matrix) ReadMatrixDataFromConsole(Matrix matrix, int n, int m)
        {
            for (int i = 0; i < n; ++i)
            {
                string enteringString = window.ReadingPlayersNum();
                string[] temp = enteringString.Split(' ');

                if (temp.Length != m)
                    return (false, matrix);

                for (int j = 0; j < m; ++j)
                {
                    double curElement = -1.0;
                    if (!double.TryParse(temp[j], out curElement) || Math.Abs(curElement) > 100)
                        return (false, matrix);

                    matrix.SetMatrixElement(i, j, curElement);
                }
            }

            return (true, matrix);
        }

        /// <summary>
        /// Считывает матрицу с файла.
        /// </summary>
        /// <param name="matrix"> Матрица.</param>
        /// <param name="n"> Количество строк.</param>
        /// <param name="m"> Количество столбцов.</param>
        /// <returns> Если матрица считалась, то первый элемет - true, иначе - false. Второй элемент - считанная матрица.</returns>
        private (bool, Matrix) ReadMatrixDataFromFile(Matrix matrix, int n, int m)
        {
            string[] lines = File.ReadAllLines(PATH_TO_TXT_FILE).Take(10).ToArray();
            if (lines.Length != n)
                return (false, matrix);

            for (int i = 0; i < n; i++)
            {
                string[] temp = lines[i].Split(' ');
                if (temp.Length != m)
                    return (false, matrix);

                for (int j = 0; j < m; j++)
                {
                    double curElement = -1.0;
                    if (!double.TryParse(temp[j], out curElement) || Math.Abs(curElement) > 100)
                        return (false, matrix);

                    matrix.SetMatrixElement(i, j, curElement);
                }
            }

            // Очищение файла(при желании можно легко добавить).
            //File.WriteAllText(PATH_TO_TXT_FILE, String.Empty);

            return (true, matrix);
        }


        /// <summary>
        /// Считывание матрицы, заданного ранее размера.
        /// </summary>
        /// <param name="inputType"> Тип считывания(с консоли или с окна).</param>
        /// <param name="n"> Количество строк.</param>
        /// <param name="m"> Количество столбцов.</param>
        /// <returns> Если матрица считалась, то первый элемет - true, иначе - false. Второй элемент - считанная матрица.</returns>
        private (bool, Matrix) ReadingMatrixData(int inputType, int n, int m)
        {
            (bool, Matrix) temp;

            window.WriteAskingForMatrixMessage(inputType);

            if (inputType == (int)ReadingMatrixOption.FromConsole)
                temp = ReadMatrixDataFromConsole(new Matrix(n, m), n, m);
            else if (inputType == (int)ReadingMatrixOption.FromFile)
                temp = ReadMatrixDataFromFile(new Matrix(n, m), n, m);
            else
                temp = (true, new Matrix(n, m).RandomMatrixGeneration(n, m));

            if (temp.Item1 == false)
                return (false, temp.Item2);

            if (CheckMatrixForCorrectInput(temp.Item2, n, m))
            {
                // Если рандомная генерация матрицы, то выводим ее в консоль, чтобы понять, что сгенерировано.
                if (inputType == (int)ReadingMatrixOption.RandomGeneration)
                    window.WritingMatrix(temp.Item2);

                return (true, temp.Item2);
            }

            return (false, temp.Item2);
        }

        /// <summary>
        /// Считывает матрицу.
        /// </summary>
        /// <param name="isSquare"> Является ли матрица квадратичной.</param>
        /// <returns> Считанная матрица.</returns>
        private Matrix ReadingMatrix(bool isSquare)
        {
            (int, int) size;

            if (isSquare)
                size = ReadingMatrixSize(true);
            else
                size = ReadingMatrixSize(false);

            while (true)
            {
                int fromMatrixInput = ReadingWayToInputMatrix();

                (bool, Matrix) temp = ReadingMatrixData(fromMatrixInput, size.Item1, size.Item2);
                if (temp.Item1 == false)
                {
                    window.WriteIncorrectMatrixInputMessage();
                    continue;
                }

                return temp.Item2;
            }

            // Выброс исключения(не должны сюда никогда попасть).
            throw new Exception("Unexpected");
        }


        /// <summary>
        /// Определяет способ ввода матрицы(считывает число пользователя).
        /// </summary>
        /// <returns> Способ ввода матрицы.</returns>
        private int ReadingWayToInputMatrix()
        {
            while (true)
            {
                window.WriteAskingForWayToInputMatrixMessage();

                // Проверка на рандомную генерацию матрицы.
                string userInput = window.ReadingPlayersNum();
                if (userInput.ToUpper() == "R" || userInput.ToUpper() == "К")
                    return (int)ReadingMatrixOption.RandomGeneration;

                // Проверка на корректность введенного значения(есть enum содержащий значения).
                int userSolutionToInputMatrix;
                if (!int.TryParse(userInput, out userSolutionToInputMatrix)
                    || !(userSolutionToInputMatrix == (int)ReadingMatrixOption.FromConsole 
                        || userSolutionToInputMatrix == (int)ReadingMatrixOption.FromFile))
                {
                    window.WriteIncorrectInputMessageAlternative();
                    continue;
                }

                return userSolutionToInputMatrix;
            }
        }

        /// <summary>
        /// Ввод размера матрицы(кол-во строк и столбцов), если матрица квадратная, то вводим только один параметр.
        /// </summary>
        /// <param name="isItSquare"> true - если матрица квадртаная, иначе false.</param>
        /// <returns> Кол-во столбцов и кол-во строк.</returns>
        private (int rows, int columns) ReadingMatrixSize(bool isItSquare = false)
        {
            while (true)
            {
                window.WriteAskingForDimensionMessage();
                window.WriteRandomGenerationMessage();

                int n = ReadNumber(true, isItSquare);

                int m = n;
                if (!isItSquare)
                    m = ReadNumber(false, false);

                window.WriteSize(n, m);

                return (n, m);
            }
        }

        /// <summary>
        /// Считывает введенное пользователем число.
        /// </summary>
        /// <param name="isRows"> Является ли данное число размером строки.</param>
        /// <param name="isItSquare">Является ли данное число размером столбца.</param>
        /// <returns> Считанное или рандомно сгенерированное число(В зависимости от ввода пользователя).</returns>
        private int ReadNumber(bool isRows, bool isItSquare)
        {
            while (true)
            {
                if (isRows)
                    window.WriteAskingForRowsMessage(isItSquare);
                else
                    window.WriteAskingForColumnsMessage(isItSquare);

                string userNum = window.ReadingPlayersNum();

                if (userNum.ToUpper() == "R" || userNum.ToUpper() == "К")
                    return (new Random().Next(Matrix.MIN_SIZE, Matrix.MAX_SIZE));

                /// Если не рандомная генерация, то пытаемся распознать ввод.
                int n = 0;
                if (int.TryParse(userNum, out n) && 
                    n >= Matrix.MIN_SIZE && n <= Matrix.MAX_SIZE)
                {
                    return n;
                }

                window.WriteIncorrectInputMessage();
            }

            // Выброс исключения, не должны никогда сюда попасть.
            throw new Exception("Unexpected");
        }

        /// <summary>
        /// Возвращает тип операции, которую хочет произвести пользователь.
        /// </summary>
        /// <returns> Тип операции.</returns>
        private int ReadingOperationType()
        {
            while (true)
            {
                int operationType;
                if (!int.TryParse(window.ReadingPlayersNum(), out operationType) ||
                    operationType < (int)AvaliableOperations.First || operationType > (int)AvaliableOperations.Last)
                {
                    window.WriteIncorrectInputMessageAlternative();
                    continue;
                }

                return operationType;
            }
        }

        /// <summary>
        /// Выполняет переданную операцию.
        /// </summary>
        /// <param name="operationType"> Тип операции.</param>
        /// <param name="lhs"> Left hand side(matrix).</param>
        /// <param name="rhs"> Right hand side(matrix).</param>
        /// <param name="num"> Число, нужное для операции.</param>
        private void ExecuteOperation(int operationType, Matrix lhs, Matrix rhs, double num)
        {
            switch (operationType)
            {
                case (int)AvaliableOperations.FindTrace:
                    {
                        window.WriteTrace(lhs.FindTrace());
                        break;
                    }

                case (int)AvaliableOperations.Transpose:
                    {
                        window.WriteTransposeMatrix(lhs.T());
                        break;
                    }

                case (int)AvaliableOperations.SumWithMatrix:
                    {
                        try
                        {
                            Matrix temp = lhs + rhs;
                        }
                        catch
                        {
                            window.WriteErrorEqualSize();
                            return;
                        }

                        window.WriteMatrixSum(lhs + rhs);
                        break;
                    }

                case (int)AvaliableOperations.SubWithMatrix:
                    {
                        try
                        {
                            Matrix temp = lhs - rhs;
                        }
                        catch
                        {
                            window.WriteErrorEqualSize();
                            return;
                        }

                        window.WriteMatrixSub(lhs - rhs);
                        break;
                    }

                case (int)AvaliableOperations.MulWithMatrix:
                    {
                        try
                        {
                            Matrix temp = lhs * rhs;
                        }
                        catch
                        {
                            window.WriteErrorNotEqualSize();
                            return;
                        }
                        
                        window.WriteMatrixMul(lhs * rhs);
                        break;
                    }

                case (int)AvaliableOperations.MulWithNum:
                    {
                        window.WriteMatrixWithNumMul(lhs * num);
                        break;
                    }

                case (int)AvaliableOperations.FindDeterminate:
                    {
                        window.WriteDeterminate(lhs.FindDeterminate());
                        break;
                    }

                case (int)AvaliableOperations.SLAE:
                    {
                        window.WriteSLAE(lhs.gauss());
                        break;
                    }
            }

        }
        /// <summary>
        /// Возвращает введенное пользователем число.
        /// </summary>
        /// <returns> Введенное пользователем число.</returns>
        private double ReadingPlayersNumForАrithmetic()
        {
            while (true)
            {
                window.WriteAskingForNumMessage();

                double playersNum;
                if (!double.TryParse(window.ReadingPlayersNum(), out playersNum) || Math.Abs(playersNum) > 100)
                {
                    window.WriteIncorrectInputMessage();
                    continue;
                }

                return playersNum;
            }
        }
        
        /// <summary>
        /// Проверяет, хочет ли пользователь завершить работу приложения.
        /// </summary>
        /// <returns> true - да, false - нет.</returns>
        private bool CheckEndWorking()
        {
            var cur = Console.ReadKey(true).Key;
            if (cur == ConsoleKey.C)
                return false;

            return true;
        }

        /// <summary>
        /// Основное тело работы преложения, вызывает другие private методы класса.
        /// </summary>
        public void Run()
        {
            window.WriteGreetingsMessage();

            while (true)
            {
                window.WriteAskingForOperationTypeMessage();

                // Тип операции.
                int operationType = ReadingOperationType();

                double num = 1;
                if (operationType >= (int)AvaliableOperations.MatrixWithNumOperations && 
                    operationType < (int)AvaliableOperations.TwoMatrixOperations)
                    num = ReadingPlayersNumForАrithmetic();

                // Является ли матрица для текущей операции квадратной.
                bool isSquare = (operationType < (int)AvaliableOperations.NonSquareMatrix);
                Matrix lhs = ReadingMatrix(isSquare);

                Matrix rhs = null;
                if (operationType >= (int)AvaliableOperations.TwoMatrixOperations)
                    rhs = ReadingMatrix(false);

                ExecuteOperation(operationType, lhs, rhs, num);

                window.WriteEndingMessage();
                if (CheckEndWorking())
                    return;

                window.ClearConsole();
            }
        }
    }
}

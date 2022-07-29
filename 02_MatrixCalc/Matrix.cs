using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixNamespace
{
    class Matrix
    {
        /// <summary>
        /// Минимальное допустимое значение числа в матрице.
        /// </summary>
        public const double MIN_VALUE = -1000;

        /// <summary>
        /// Максимальное значение числа в матрице.
        /// </summary>
        public const double MAX_VALUE = 1000;

        /// <summary>
        /// Минимальный размер кол-ва строк или столбцов в матрице.
        /// </summary>
        public const int MIN_SIZE = 1;

        /// <summary>
        /// Максимальный размер кол-ва строк или столбцов в матрице.
        /// </summary>
        public const int MAX_SIZE = 10;

        /// <summary>
        /// Констана, использующаяся при вычислении СЛАУ(для алгоритма Гауса).
        /// </summary>
        private const double EPS = 1E-9;

        /// <summary>
        /// Матрица.
        /// </summary>
        private List<List<double>> matrix = new List<List<double>>();

        /// <summary>
        /// Создание матрицы n x m, по умолчанию инициализируется нулями.
        /// </summary>
        /// <param name="n"> Количество строк.</param>
        /// <param name="m"> Количество столбцов.</param>
        public Matrix(int n, int m)
        {
            for (int i = 0; i < n; ++i)
            {
                matrix.Add(new List<double>());
                for (int j = 0; j < m; ++j)
                    matrix[i].Add(0);
            }
        }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Matrix() { }

        /// <summary>
        /// Конструктор, клонирующий матрицу.
        /// </summary>
        /// <param name="matrix"> Матрица, которую хотим присвоить.</param>
        public Matrix(List<List<double>> matrix)
        {
            this.matrix = matrix;
        }

        /// <summary>
        /// Возвращает матрицу.
        /// </summary>
        /// <returns> Матрица.</returns>
        public List<List<double>> GetMatrix()
        {
            return matrix;
        }

        /// <summary>
        /// Устанавливает полю матрица переданное значение.
        /// </summary>
        /// <param name="matrix"> Матрица, значение которой хотим установить.</param>
        public void SetMatrix(List<List<double>> matrix)
        {
            this.matrix = matrix;
        }

        /// <summary>
        /// Возвращает значение элемента в переданной ячейке.
        /// </summary>
        /// <param name="row"> Строка.</param>
        /// <param name="column"> Столбец.</param>
        /// <returns> Значение элемента в переданной ячейке.</returns>
        public double GetMatrixElement(int row, int column)
        {
            return matrix[row][column];
        }

        /// <summary>
        /// Устанавливает требуемой ячейке переданное значение.
        /// </summary>
        /// <param name="row"> Строка.</param>
        /// <param name="column"> Столбец.</param>
        /// <param name="value"> Значение.</param>
        public void SetMatrixElement(int row, int column, double value)
        {
            matrix[row][column] = value;
        }

        /// <summary>
        /// Изменяет значение строки матрицы на переданное.
        /// </summary>
        /// <param name="row"> Номер строки.</param>
        /// <param name="changeRow"> Новое значение.</param>
        public void SetMatrixRow(int row, List<double> changeRow)
        {
            matrix[row] = changeRow;
        }

        /// <summary>
        /// Изменяет значение столбца матрицы на переданное.
        /// </summary>
        /// <param name="row"> Номер столбца.</param>
        /// <param name="changeRow"> Новое значение.</param>
        public void SetMatrixColumn(int column, List<double> changeColumn)
        {
            matrix[column] = changeColumn;
        }

        /// <summary>
        /// Возвращает строку матрицы по переданному номеру.
        /// </summary>
        /// <param name="row"> Номер строки.</param>
        /// <returns> Строка с переданным индексом.</returns>
        public List<double> GetMatrixRow(int row)
        {
            return matrix[row];
        }

        /// <summary>
        /// Возвращает столбец матрицы по переданному номеру.
        /// </summary>
        /// <param name="row"> Номер столбца.</param>
        /// <returns> Столбец с переданным индексом.</returns>
        public List<double> GetMatrixColumn(int column)
        {
            return matrix[column];
        }

        /// <summary>
        /// Возвращает матрицу, заполненную случайными числами (-100;100), размера N x M.
        /// </summary>
        /// <param name="n"> Количество строк.</param>
        /// <param name="m"> Количество столбцов.</param>
        /// <returns> Сгенерированная матрица.</returns>
        public Matrix RandomMatrixGeneration(int n, int m)
        {
            Matrix curMatrix = new Matrix(n, m);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                    curMatrix.matrix[i][j] = new Random().Next(-100, 100);
            }

            return curMatrix;
        }


        /// <summary>
        /// Оператор сложения для матриц.
        /// </summary>
        /// <param name="lhs"> left hand side(matrix).</param>
        /// <param name="rhs"> right hand side(matrix).</param>
        /// <returns> Сумма матриц.</returns>
        public static Matrix operator +(Matrix lhs, Matrix rhs)
        {
            // Выброс исключения, если передана матрица нулевого размера.
            if (lhs.matrix.Count == 0 || lhs.matrix[0].Count == 0 || rhs.matrix.Count == 0 || rhs.matrix[0].Count == 0)
                throw new Exception("Переданы матрицы нулевого размера.");

            // Выброс исключения, если матрицы не соотносятся по размерности.
            if (lhs.matrix.Count != rhs.matrix.Count || lhs.matrix[0].Count != rhs.matrix[0].Count)
                throw new Exception("Переданы матрицы разного размера.");

            Matrix result = new Matrix();
            for (int i = 0; i < lhs.matrix.Count; ++i)
            {
                result.matrix.Add(new List<double>());

                for (int j = 0; j < lhs.matrix[i].Count; ++j)
                    result.matrix[i].Add(lhs.matrix[i][j] + rhs.matrix[i][j]);
            }

            return result;
        }

        /// <summary>
        /// Оператор вычитания для матриц.
        /// </summary>
        /// <param name="lhs"> left hand side(matrix).</param>
        /// <param name="rhs"> right hand side(matrix).</param>
        /// <returns> Разность матриц.</returns>
        public static Matrix operator -(Matrix lhs, Matrix rhs)
        {
            // Выброс исключения, если передана матрица нулевого размера.
            if (lhs.matrix.Count == 0 || lhs.matrix[0].Count == 0 || rhs.matrix.Count == 0 || rhs.matrix[0].Count == 0)
                throw new Exception("Переданы матрицы нулевого размера.");

            // Выброс исключения, если матрицы не соотносятся по размерности.
            if (lhs.matrix.Count != rhs.matrix.Count || lhs.matrix[0].Count != rhs.matrix[0].Count)
                throw new Exception("Переданы матрицы разного размера.");

            Matrix result = new Matrix();
            for (int i = 0; i < lhs.matrix.Count; ++i)
            {
                result.matrix.Add(new List<double>());

                for (int j = 0; j < lhs.matrix[i].Count; ++j)
                    result.matrix[i].Add(lhs.matrix[i][j] - rhs.matrix[i][j]);
            }

            return result;
        }

        /// <summary>
        /// Оператор умножения для матриц.
        /// </summary>
        /// <param name="lhs"> left hand side(matrix).</param>
        /// <param name="rhs"> right hand side(matrix).</param>
        /// <returns> Произведение матриц.</returns>
        public static Matrix operator *(Matrix lhs, Matrix rhs)
        {
            // Выброс исключения, если передана матрица нулевого размера.
            if (lhs.matrix.Count == 0 || lhs.matrix[0].Count == 0 || rhs.matrix.Count == 0 || rhs.matrix[0].Count == 0)
                throw new Exception("Передана матрицы нулевого размера.");

            // Выброс исключения, если матрицы не соотносятся по размерности.
            if (lhs.matrix[0].Count != rhs.matrix.Count)
                throw new Exception("Матрицы не соотносятся по размености.");

            Matrix result = new Matrix(lhs.matrix.Count, rhs.matrix[0].Count);
            for (int i = 0; i < lhs.matrix.Count; ++i)
            {
                for (int j = 0; j < rhs.matrix[0].Count; ++j)
                {
                    for (int k = 0; k < lhs.matrix[0].Count; ++k)
                        result.matrix[i][j] += (lhs.matrix[i][k] * rhs.matrix[k][j]);
                }
            }

            return result;
        }

        /// <summary>
        /// Оператор умножения матрицы на число.
        /// </summary>
        /// <param name="lhs"> left hand side(matrix).</param>
        /// <param name="rhs"> Число, на которое умножаем.</param>
        /// <returns> Произведение матрицы на число.</returns>
        public static Matrix operator *(Matrix lhs, double num)
        {
            // Выброс исключения, если передана матрица нулевого размера.
            if (lhs.matrix.Count == 0 || lhs.matrix[0].Count == 0)
                throw new Exception("Передана матрица нулевого размера.");

            Matrix result = new Matrix();
            for (int i = 0; i < lhs.matrix.Count; ++i)
            {
                result.matrix.Add(new List<double>());

                for (int j = 0; j < lhs.matrix[i].Count; ++j)
                    result.matrix[i].Add(num * lhs.matrix[i][j]);
            }

            return result;
        }

        /// <summary>
        /// Транспонирует матрицу.
        /// </summary>
        /// <returns> Транспонированная матрица.</returns>
        public Matrix T()
        {
            // Выброс исключения, если передана матрица нулевого размера.
            if (this.matrix.Count == 0 || this.matrix[0].Count == 0)
                throw new Exception("Нулевая матрица.");

            Matrix result = new Matrix();
            for (int i = 0; i < this.matrix[0].Count; ++i)
                result.matrix.Add(new List<double>());

            for (int i = 0; i < this.matrix[0].Count; ++i)
            {
                for (int j = 0; j < this.matrix.Count; ++j)
                    result.matrix[i].Add(this.matrix[j][i]);
            }

            return result;
        }

        /// <summary>
        /// Находит след матрицы.
        /// </summary>
        /// <returns> След матрицы.</returns>
        public double FindTrace()
        {
            // Выброс исключения, если передана матрица нулевого размера.
            if (this.matrix.Count == 0 || this.matrix[0].Count == 0)
                throw new Exception("Нулевая матрица.");

            // Выброс исключения, если передана неквадратная матрица.
            if (this.matrix.Count != this.matrix[0].Count)
                throw new Exception("Передана неквадратная матрица.");

            double ans = 0;
            for (int i = 0; i < this.matrix.Count; ++i)
                ans += this.matrix[i][i];

            return ans;
        }

        /// <summary>
        /// Определяет знак элементов при вычислении определителя(детерменанта).
        /// </summary>
        /// <param name="i"> Первый элемент.</param>
        /// <param name="j"> Второй элемент.</param>
        /// <returns> 1 - если положительный, -1 - если отрицательный.</returns>
        private int SignOfElement(int i, int j)
        {
            if ((i + j) % 2 == 0)
                return 1;

            return -1;
        }

        /// <summary>
        /// Определяет подматрицу, соответствующую данному элементу.
        /// </summary>
        /// <param name="i"> Левая граница.</param>
        /// <param name="j"> Правая граница.</param>
        /// <returns> Подматрица, соответствующую данному элементу.</returns>
        private Matrix CreateSmallerMatrix(int i, int j)
        {
            int order = int.Parse(System.Math.Sqrt(matrix.Count * matrix[0].Count).ToString());
            Matrix output = new Matrix(order - 1, order - 1);

            int x = 0, y = 0;
            for (int m = 0; m < order; ++m, ++x)
            {
                if (m != i)
                {
                    y = 0;

                    for (int n = 0; n < order; ++n)
                    {
                        if (n != j)
                        {
                            output.matrix[x][y] = matrix[m][n];
                            ++y;
                        }
                    }
                }
                else
                    --x;
            }

            return output;
        }

        /// <summary>
        /// Находит значение определителя с помощью рекурсии.
        /// </summary>
        /// <returns> Значение определителя.</returns>
        public double FindDeterminate()
        {
            int order = int.Parse(Math.Sqrt(matrix.Count * matrix[0].Count).ToString());
            if (order > 2)
            {
                double value = 0;

                for (int j = 0; j < order; j++)
                {
                    Matrix Temp = this.CreateSmallerMatrix(0, j);
                    value = value + this.matrix[0][j] * (SignOfElement(0, j) * Temp.FindDeterminate());
                }

                return value;
            }
            else if (order == 2)
                return ((matrix[0][0] * matrix[1][1]) - (matrix[1][0] * matrix[0][1]));
            
            return (matrix[0][0]);
        }

        /// <summary>
        /// Решает СЛАУ(система линейных алгебраических уравнений) через алгоритм Гауса.
        /// </summary>
        /// <returns> Решение СЛАУ(системы линейных алгебраических уравнений).</returns>
        public (double, List<double>) gauss()
        {
            // Далее следует алгоритм, который можно посмотреть на википедии, 
            // как и смысл его реализации(поэтому не комментирую).

            // Выброс исключения, если передана матрица нулевого размера.
            if (this.matrix.Count == 0 || this.matrix[0].Count == 0)
                throw new Exception("Нулевая матрица.");

            int n = (int)this.matrix.Count;
            int m = (int)this.matrix[0].Count - 1;
            
            List<int> where = new List<int>();
            for (int i = 0; i < m; ++i)
                where.Add(-1);

            for (int col = 0, row = 0; col < m && row < n; ++col)
            {
                int sel = row;
                for (int i = row; i < n; ++i)
                    if (Math.Abs(this.matrix[i][col]) > Math.Abs(this.matrix[sel][col]))
                        sel = i;

                if (Math.Abs(this.matrix[sel][col]) < Matrix.EPS)
                    continue;

                for (int i = col; i <= m; ++i)
                {
                    var temp = this.matrix[sel][i];
                    this.matrix[sel][i] = this.matrix[row][i];
                    this.matrix[row][i] = temp;
                }

                where[col] = row;

                for (int i = 0; i < n; ++i)
                {
                    if (i != row)
                    {
                        double c = this.matrix[i][col] / this.matrix[row][col];
                        for (int j = col; j <= m; ++j)
                            this.matrix[i][j] -= this.matrix[row][j] * c;
                    }
                }

                ++row;
            }

            List<double> ans = new List<double>();
            for (int i = 0; i < m; ++i)
                ans.Add(0);

            for (int i = 0; i < m; ++i)
            {
                if (where[i] != -1)
                    ans[i] = this.matrix[where[i]][m] / this.matrix[where[i]][i];
            }

            for (int i = 0; i < n; ++i)
            {
                double sum = 0;
                for (int j = 0; j < m; ++j)
                    sum += ans[j] * this.matrix[i][j];

                if (Math.Abs(sum - this.matrix[i][m]) > Matrix.EPS)
                    return (0, ans);
            }

            for (int i = 0; i < m; ++i)
                if (where[i] == -1)
                    return (double.PositiveInfinity, ans);

            return (1, ans);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;

namespace Peergrade2
{
    class Program
    {
        /// <summary>
        /// Точка входа
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// Создание объекта приложения.
            Application.Application app = new Application.Application();

            /// Вызов главной функции, где и происходит работа всей программы.
            app.Run();
        }
    }
}

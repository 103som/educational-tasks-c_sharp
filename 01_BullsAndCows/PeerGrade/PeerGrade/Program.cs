using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProccesNamespace;

namespace PeerGradeNamespace
{
    class Program
    {
        /// <summary>
        /// Вызывает начало игры.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// Создание игрового процесса, в котором происходят все действия.
            GameProcess game = new GameProcess();
            game.PlayGame();
        }
    }
}

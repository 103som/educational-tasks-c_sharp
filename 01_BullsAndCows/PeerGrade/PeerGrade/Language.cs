using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageNamespace
{
    /// <summary>
    /// Класс для работы с языком(в данной версии игры предусмотрено 2 языка русский и английский).
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Константа, позволяющая получить русский язык.
        /// </summary>
        public const string RuLanguage = "RU";

        /// <summary>
        /// Константа, позволяющая получить английский язык.
        /// </summary>
        public const string EngLanguage = "ENG";
        
        /// <summary>
        /// Поле класса, отвечающее за интерфейс игры.
        /// </summary>
        private string interfaceLanguage;

        /// <summary>
        /// Измененяет игровой язык на заданный.
        /// </summary> 
        /// <param name="language"> Язык, который хотите задать.</param>
        public void SetInterfaceLanguage(string language)
        {
            interfaceLanguage = language;
        }

        /// <summary> Возвращает текущий язык игровой сессии.
        /// </summary> 
        /// <returns> Текущий язык игровой сессии.</returns>
        public string GetInterfaceLanguage()
        {
            return interfaceLanguage;
        }

        /// <summary>
        /// Установка по умолчанию русского языка.
        /// </summary>
        public Language()
        {
            interfaceLanguage = RuLanguage;
        }
    }

}

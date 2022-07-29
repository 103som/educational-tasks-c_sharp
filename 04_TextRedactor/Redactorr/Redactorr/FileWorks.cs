using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Redactorr
{
    class FileWorks
    {
        /// <summary>
        /// Создает пустой файл и возвращает его.
        /// </summary>
        /// <param name="name"> Имя файла.</param>
        /// <returns> Пустой файл, с заданным именем.</returns>
        public static TabPage CreateFile(string fileName)
        {
            TabPage newFile = new TabPage(fileName);
            RichTextBox tb = new RichTextBox();
            tb.Dock = DockStyle.Fill;
            newFile.Controls.Add(tb);

            return newFile;
        }

        /// <summary>
        /// Открывает файл.
        /// </summary>
        /// <param name="filePath"> Путь к файлу.</param>
        /// <returns> Содержимое файла в форме TabPage.</returns>
        public static TabPage OpenFile(ref string filePath)
        {
            OpenFileDialog openDocument = new OpenFileDialog();
            openDocument.Title = "Открыть текстовый документ";

            // Фильтр для названия файла.
            openDocument.Filter = "plain text |*.txt|Rich Text|*.rtf"; ;

            RichTextBox newRichTextBox = new RichTextBox();
            newRichTextBox.Dock = DockStyle.Fill;

            if (openDocument.ShowDialog() == DialogResult.OK)
            {
                newRichTextBox.Text = File.ReadAllText(openDocument.FileName);

                filePath = openDocument.FileName;
            }
            else
                return null;

            TabPage newFile = new TabPage(openDocument.SafeFileName);
            newFile.Controls.Add(newRichTextBox);

            return newFile;
        }

        /// <summary>
        /// Находит представление текущей строки в RTF формате.
        /// </summary>
        /// <param name="s"> Исходная строка.</param>
        /// <returns> Строка в RTF формате.</returns>
        static string GetRtfUnicodeEscapedString(string s)
        {
            var sb = new StringBuilder();
            foreach (var c in s)
            {
                if (c <= 0x7f)
                    sb.Append(c);
                else
                    sb.Append("\\u" + Convert.ToUInt32(c) + "?");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Сохраняет файл.
        /// </summary>
        /// <param name="text"> Содержимое файла.</param>
        /// <param name="filePath"> Путь к файлу</param>
        public static void SaveFile(string text, string filePath)
        {
            if (filePath == null)
                throw new ArgumentException("Передан некорректный путь.");

            File.WriteAllText(filePath, text);
        }

        /// <summary>
        /// Сохраняет файл в нужном формате.
        /// </summary>
        /// <param name="text"> Содержимое файла.</param>
        /// <param name="filePath"> Путь к файлу.</param>
        /// <param name="isItTxtFile"> True - если файл сохранен в txt формате, false - если в rtf.</param>
        public static void SaveFileAs(string text, ref string filePath, bool isItTxtFile)
        {
            SaveFileDialog saveAsDocument = new SaveFileDialog();
            saveAsDocument.Title = "Сохранить документ как...";
            saveAsDocument.FileName = "Текстовый документ";

            if (isItTxtFile)
                saveAsDocument.Filter = "Текстовые файлы (*.txt) |*.txt| Все файлы (*.*)|*.*";
            else
                saveAsDocument.Filter = "Текстовые файлы (*.rtf) |*.rtf| Все файлы (*.*)|*.*";

            if (saveAsDocument.ShowDialog() == DialogResult.OK)
            {
                filePath = saveAsDocument.FileName;
                File.WriteAllText(filePath, text);
            }
        }

        /// <summary>
        /// Удаляет файл.
        /// </summary>
        /// <param name="filePath"> Путь к файлу.</param>
        public static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}

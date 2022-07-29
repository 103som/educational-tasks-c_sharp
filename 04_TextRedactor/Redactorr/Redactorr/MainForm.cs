using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Input;

namespace Redactorr
{
    /// <summary>
    /// Основная форма приложения.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            // Инициализация компонентов.
            InitializeComponent();

            // Добавление возможности выбора цвета шрифта.
            fontDialog1.ShowColor = true;

            // По умолчанию задаем интервал автосохранения, равный 1 секунде.
            autoSaveInterval = 1;
        }

        /// <summary>
        /// Все пути открытых файлов.
        /// </summary>
        List<string> docPathes = new List<string>();


        /// <summary>
        /// Текущий номер нового файла по счету.
        /// </summary>
        int tbCnt = 1; 

        /// <summary>
        /// Создание нового файла.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void fileNew_Click(object sender, EventArgs e)
        {
            AddNewFileToPanel(FileWorks.CreateFile("new " + tbCnt), null);
        }

        /// <summary>
        /// Открывает файл при нажатии на кнопку.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void fileOpen_Click(object sender, EventArgs e)
        {
            string path = null;
            TabPage newPage = FileWorks.OpenFile(ref path);

            if (newPage != null)
                AddNewFileToPanel(newPage, path);
        }

        /// <summary>
        /// Сохраняет файл при нажатаии на кнопку.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void fileSave_Click(object sender, EventArgs e)
        {
            if (TabControl.SelectedTab == null)
                return;

            string path = docPathes[TabControl.SelectedTab.TabIndex];
            if (path != null)
                FileWorks.SaveFile(TabControl.SelectedTab.Controls[0].Text, path);
            else
                fileSaveAs_Click(sender, e);
        }

        /// <summary>
        /// Сохраняет файл в выбранном типе при нажатии на кнопку.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void fileSaveAs_Click(object sender, EventArgs e)
        {
            if (TabControl.SelectedTab == null)
                return;

            string path = docPathes[TabControl.SelectedTab.TabIndex];
            FileWorks.SaveFileAs(TabControl.SelectedTab.Controls[0].Text, ref path, true);

            TabControl.SelectedTab.Text = Path.GetFileName(path);
            docPathes[TabControl.SelectedTab.TabIndex] = path;
        }

        /// <summary>
        /// Вырезает выделенный текст при нажатии на кнопку.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void mEditCut_Click(object sender, EventArgs e)
        {
            RichTextBox cur = null;

            if (TabControl.TabCount != 0)
            {
                cur = TabControl.SelectedTab.Controls[0] as RichTextBox;
                cur.Cut();
            }
        }

        /// <summary>
        /// Копирует выделенный текст при нажатии на кнопку.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void mEditCopy_Click(object sender, EventArgs e)
        {
            RichTextBox cur = null;

            if (TabControl.TabCount != 0)
            {
                cur = TabControl.SelectedTab.Controls[0] as RichTextBox;
                cur.Copy();
            }
        }

        /// <summary>
        /// Вставляет выделенный текст при нажатии на кнопку.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void mEditInsert_Click(object sender, EventArgs e)
        {
            RichTextBox cur = null;

            if (TabControl.TabCount != 0)
            {
                cur = TabControl.SelectedTab.Controls[0] as RichTextBox;
                cur.Paste();
            }
        }

        /// <summary>
        /// Добавляет новый файл на панель с файлами.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void AddNewFileToPanel(TabPage newPage, string filePath)
        {
            TabControl.TabPages.Add(newPage);
            TabControl.SelectedTab = newPage;

            if (isDarkForm)
            {
                TabControl.SelectedTab.Controls[0].BackColor = Color.Black;
                TabControl.SelectedTab.Controls[0].ForeColor = Color.White;
            }
            else
            {
                TabControl.SelectedTab.Controls[0].BackColor = Color.White;
                TabControl.SelectedTab.Controls[0].ForeColor = Color.Black;
            }

            docPathes.Add(filePath);
            ++tbCnt;

            Control cur = TabControl.SelectedTab.Controls[0];
            cur.MouseDown += new MouseEventHandler(tabControl1_MouseClick);
        }

        /// <summary>
        /// Сохраняет файлы перед завершением работы окна по желанию пользователя.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult message = MessageBox.Show($"Хотите ли вы сохранять документы перед выходом?", "Выход из программы", MessageBoxButtons.YesNoCancel);
            if (message == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            if (message == DialogResult.No)
                return;

            int i = -1;
            foreach (TabPage file in TabControl.TabPages)
            {
                ++i;

                if (docPathes[i] == null)
                {
                    DialogResult newMessage = MessageBox.Show($"Сохранить {file.Text} перед выходом?", "Выход из программы", MessageBoxButtons.YesNoCancel);

                    string path = docPathes[i];
                    if (newMessage == DialogResult.Yes)
                        FileWorks.SaveFileAs(file.Controls[0].Text, ref path, true);

                    TabControl.SelectedTab.Text = Path.GetFileName(path);

                    continue;
                }


                string str = File.ReadAllText(docPathes[i]);
                if (file.Controls[0].Text.Length != str.Length || file.Controls[0].Text != str)
                {
                    DialogResult newMessage = MessageBox.Show($"Сохранить {file.Text} перед выходом?", "Выход из программы", MessageBoxButtons.YesNoCancel);

                    if (newMessage == DialogResult.Yes)
                        FileWorks.SaveFile(file.Controls[0].Text, docPathes[i]);

                    continue;
                }
            }
        }

        /// <summary>
        /// Отвечает за периодическое сохранение файлов.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (TabControl.Controls.Count == 0)
                return;

            foreach (var filePath in docPathes)
            {
                if (filePath != null)
                    FileWorks.SaveFile(TabControl.SelectedTab.Controls[0].Text, filePath);
            }
        }

        /// <summary>
        /// Интервал сохранения файлов.
        /// </summary>
        public static int autoSaveInterval { get; set; }

        /// <summary>
        /// Выставляет интервал сохранения по желанию пользователя.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void settingsAutoSave_Click(object sender, EventArgs e)
        {
            IntervalSetting intervalSetting = new IntervalSetting();

            timer.Stop();
            intervalSetting.ShowDialog();

            timer.Start();
            timer.Interval = autoSaveInterval  * 60 * 1000;
        }

        /// <summary>
        /// True - если сейчас темная тема, false - если светлая.
        /// </summary>
        bool isDarkForm = false;

        /// <summary>
        /// Меняет текущую цветовую тему на противоположную.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void settingsThemeChange_Click(object sender, EventArgs e)
        {

            isDarkForm = !isDarkForm;

            foreach (Control curMember in this.Controls)
            {
                if (isDarkForm)
                {
                    curMember.BackColor = Color.Black;
                    curMember.ForeColor = Color.White;
                }
                else
                {
                    curMember.BackColor = Color.White;
                    curMember.ForeColor = Color.Black;
                }

                if (curMember is TabControl)
                {
                    curMember.BackColor = Color.Black;

                    TabControl curControl = curMember as TabControl;

                    foreach(TabPage element in curControl.Controls)
                    {
                        if (isDarkForm)
                        {
                            element.Controls[0].BackColor = Color.Black;
                            element.Controls[0].ForeColor = Color.White;

                        }
                        else
                        {
                            element.Controls[0].BackColor = Color.White;
                            element.Controls[0].ForeColor = Color.Black;

                        }
                    }
                }
            }
        }

        /// <summary>
        /// Открытие контекстного меню.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.contextMenuStrip1.Show(this.TabControl, e.Location);
        }

        /// <summary>
        /// Выделение всего текста в текущем файле.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void elToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox curRichTextBox = TabControl.SelectedTab.Controls[0] as RichTextBox;
            curRichTextBox.SelectionStart = 0;
            curRichTextBox.SelectionLength = curRichTextBox.Text.Length;
            curRichTextBox.Focus();
        }

        /// <summary>
        /// Удаляет выделенный текст.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void CutDedicatedFragment_Click(object sender, EventArgs e)
        {
            RichTextBox cur = null;

            if (TabControl.TabCount != 0)
            {
                cur = TabControl.SelectedTab.Controls[0] as RichTextBox;
                cur.Cut();
            }
        }

        /// <summary>
        /// Копирует выделенный текст.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void CopyDedicatedFragment_Click(object sender, EventArgs e)
        {
            RichTextBox cur = null;

            if (TabControl.TabCount != 0)
            {
                cur = TabControl.SelectedTab.Controls[0] as RichTextBox;
                cur.Copy();
            }
        }

        /// <summary>
        /// Вставляет текст из буфера обмена.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void InsertDedicatedFragment_Click(object sender, EventArgs e)
        {
            RichTextBox cur = null;

            if (TabControl.TabCount != 0)
            {
                cur = TabControl.SelectedTab.Controls[0] as RichTextBox;
                cur.Paste();
            }
        }

        /// <summary>
        /// Вставляет из буфера.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void PutFormToDedicatedText_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;


            if (TabControl.TabCount != 0)
            {
                RichTextBox curRichTextBox = TabControl.SelectedTab.Controls[0] as RichTextBox;

                if (curRichTextBox.SelectedText != null)
                {
                    curRichTextBox.SelectionFont = fontDialog1.Font;
                    curRichTextBox.SelectionColor = fontDialog1.Color;
                }
            }
        }

        /// <summary>
        /// Меняет тип выделенного текста.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void mFormatFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;


            if (TabControl.TabCount != 0)
            {
                RichTextBox curRichTextBox = TabControl.SelectedTab.Controls[0] as RichTextBox;

                if (curRichTextBox.SelectedText != null)
                {
                    curRichTextBox.SelectionFont = fontDialog1.Font;
                    curRichTextBox.SelectionColor = fontDialog1.Color;
                }
            }
        }

        /// <summary>
        /// Обработка нажатия горячих клавиш.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        /// <returns> Bool системный result.</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.N))
            {
                AddNewFileToPanel(FileWorks.CreateFile("new " + tbCnt), null);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.B))
            {
                MainForm newMainForm = new MainForm();
                newMainForm.Show();
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                if (TabControl.SelectedTab == null)
                    return base.ProcessCmdKey(ref msg, keyData);

                string path = docPathes[TabControl.SelectedTab.TabIndex];
                if (path != null)
                    FileWorks.SaveFile(TabControl.SelectedTab.Controls[0].Text, path);
                else
                {
                    if (TabControl.SelectedTab == null)
                        return base.ProcessCmdKey(ref msg, keyData);

                    string pathh = docPathes[TabControl.SelectedTab.TabIndex];
                    FileWorks.SaveFileAs(TabControl.SelectedTab.Controls[0].Text, ref pathh, true);

                    TabControl.SelectedTab.Text = Path.GetFileName(pathh);
                    docPathes[TabControl.SelectedTab.TabIndex] = pathh;
                }
            }
            else if (keyData == (Keys.Control | Keys.Q))
            {
                foreach (TabPage tabPage in TabControl.TabPages)
                {
                    if (tabPage == null)
                        continue;

                    string path = docPathes[tabPage.TabIndex];
                    if (path != null)
                        FileWorks.SaveFile(tabPage.Controls[0].Text, path);
                    else
                    {
                        if (tabPage == null)
                            continue;

                        string pathh = docPathes[tabPage.TabIndex];
                        FileWorks.SaveFileAs(tabPage.Controls[0].Text, ref pathh, true);

                        tabPage.Text = Path.GetFileName(pathh);
                        docPathes[tabPage.TabIndex] = pathh;
                    }
                }
            }
            else if (keyData == (Keys.Control | Keys.U))
            {
                this.Close();
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

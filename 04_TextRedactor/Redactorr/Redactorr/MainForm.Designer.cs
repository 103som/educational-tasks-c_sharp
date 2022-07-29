
namespace Redactorr
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.elToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutDedicatedFragment = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyDedicatedFragment = new System.Windows.Forms.ToolStripMenuItem();
            this.InsertDedicatedFragment = new System.Windows.Forms.ToolStripMenuItem();
            this.PutFormToDedicatedText = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mFile = new System.Windows.Forms.ToolStripMenuItem();
            this.fileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mEditCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.mEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mEditInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.mFormatTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.mFormatFont = new System.Windows.Forms.ToolStripMenuItem();
            this.mSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsAutoSave = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsThemeChange = new System.Windows.Forms.ToolStripMenuItem();
            this.mHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mHelpAboutProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.горячиеКлавишиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crtlWСоздатьНовуюВкладкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlSСохранитьТекущуюВкладкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlQСохранитьВсеВкладкифайлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlUЗакрытьДанноеОкноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusPanel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLinesCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusPanel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusWordsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elToolStripMenuItem,
            this.CutDedicatedFragment,
            this.CopyDedicatedFragment,
            this.InsertDedicatedFragment,
            this.PutFormToDedicatedText});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(356, 114);
            // 
            // elToolStripMenuItem
            // 
            this.elToolStripMenuItem.Name = "elToolStripMenuItem";
            this.elToolStripMenuItem.Size = new System.Drawing.Size(355, 22);
            this.elToolStripMenuItem.Text = "Выбрать весь текст";
            this.elToolStripMenuItem.Click += new System.EventHandler(this.elToolStripMenuItem_Click);
            // 
            // CutDedicatedFragment
            // 
            this.CutDedicatedFragment.Name = "CutDedicatedFragment";
            this.CutDedicatedFragment.Size = new System.Drawing.Size(355, 22);
            this.CutDedicatedFragment.Text = "Вырезать выделенный фрагмент";
            this.CutDedicatedFragment.Click += new System.EventHandler(this.CutDedicatedFragment_Click);
            // 
            // CopyDedicatedFragment
            // 
            this.CopyDedicatedFragment.Name = "CopyDedicatedFragment";
            this.CopyDedicatedFragment.Size = new System.Drawing.Size(355, 22);
            this.CopyDedicatedFragment.Text = "Копировать выделенный фрагмент";
            this.CopyDedicatedFragment.Click += new System.EventHandler(this.CopyDedicatedFragment_Click);
            // 
            // InsertDedicatedFragment
            // 
            this.InsertDedicatedFragment.Name = "InsertDedicatedFragment";
            this.InsertDedicatedFragment.Size = new System.Drawing.Size(355, 22);
            this.InsertDedicatedFragment.Text = "Вставить сохранённый в буфере обмена фрагмент";
            this.InsertDedicatedFragment.Click += new System.EventHandler(this.InsertDedicatedFragment_Click);
            // 
            // PutFormToDedicatedText
            // 
            this.PutFormToDedicatedText.Name = "PutFormToDedicatedText";
            this.PutFormToDedicatedText.Size = new System.Drawing.Size(355, 22);
            this.PutFormToDedicatedText.Text = "Задать формат выделенного фрагмента текста";
            this.PutFormToDedicatedText.Click += new System.EventHandler(this.PutFormToDedicatedText_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mFile,
            this.mEdit,
            this.mFormat,
            this.mSettings,
            this.mHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip";
            // 
            // mFile
            // 
            this.mFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileNew,
            this.fileOpen,
            this.fileSave,
            this.fileSaveAs});
            this.mFile.Name = "mFile";
            this.mFile.Size = new System.Drawing.Size(48, 20);
            this.mFile.Text = "Файл";
            // 
            // fileNew
            // 
            this.fileNew.Name = "fileNew";
            this.fileNew.Size = new System.Drawing.Size(180, 22);
            this.fileNew.Text = "Создать";
            this.fileNew.Click += new System.EventHandler(this.fileNew_Click);
            // 
            // fileOpen
            // 
            this.fileOpen.Name = "fileOpen";
            this.fileOpen.Size = new System.Drawing.Size(180, 22);
            this.fileOpen.Text = "Открыть";
            this.fileOpen.Click += new System.EventHandler(this.fileOpen_Click);
            // 
            // fileSave
            // 
            this.fileSave.Name = "fileSave";
            this.fileSave.Size = new System.Drawing.Size(180, 22);
            this.fileSave.Text = "Сохранить";
            this.fileSave.Click += new System.EventHandler(this.fileSave_Click);
            // 
            // fileSaveAs
            // 
            this.fileSaveAs.Name = "fileSaveAs";
            this.fileSaveAs.Size = new System.Drawing.Size(180, 22);
            this.fileSaveAs.Text = "Сохранить как";
            this.fileSaveAs.Click += new System.EventHandler(this.fileSaveAs_Click);
            // 
            // mEdit
            // 
            this.mEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mEditCancel,
            this.mEditCut,
            this.mEditCopy,
            this.mEditInsert});
            this.mEdit.Name = "mEdit";
            this.mEdit.Size = new System.Drawing.Size(59, 20);
            this.mEdit.Text = "Правка";
            // 
            // mEditCancel
            // 
            this.mEditCancel.Name = "mEditCancel";
            this.mEditCancel.Size = new System.Drawing.Size(180, 22);
            this.mEditCancel.Text = "Отменить";
            // 
            // mEditCut
            // 
            this.mEditCut.Name = "mEditCut";
            this.mEditCut.Size = new System.Drawing.Size(180, 22);
            this.mEditCut.Text = "Вырезать";
            this.mEditCut.Click += new System.EventHandler(this.mEditCut_Click);
            // 
            // mEditCopy
            // 
            this.mEditCopy.Name = "mEditCopy";
            this.mEditCopy.Size = new System.Drawing.Size(180, 22);
            this.mEditCopy.Text = "Копировать";
            this.mEditCopy.Click += new System.EventHandler(this.mEditCopy_Click);
            // 
            // mEditInsert
            // 
            this.mEditInsert.Name = "mEditInsert";
            this.mEditInsert.Size = new System.Drawing.Size(180, 22);
            this.mEditInsert.Text = "Вставить";
            this.mEditInsert.Click += new System.EventHandler(this.mEditInsert_Click);
            // 
            // mFormat
            // 
            this.mFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mFormatTransfer,
            this.mFormatFont});
            this.mFormat.Name = "mFormat";
            this.mFormat.Size = new System.Drawing.Size(62, 20);
            this.mFormat.Text = "Формат";
            // 
            // mFormatTransfer
            // 
            this.mFormatTransfer.Name = "mFormatTransfer";
            this.mFormatTransfer.Size = new System.Drawing.Size(183, 22);
            this.mFormatTransfer.Text = "Перенос по словам";
            // 
            // mFormatFont
            // 
            this.mFormatFont.Name = "mFormatFont";
            this.mFormatFont.Size = new System.Drawing.Size(183, 22);
            this.mFormatFont.Text = "Шрифт";
            this.mFormatFont.Click += new System.EventHandler(this.mFormatFont_Click);
            // 
            // mSettings
            // 
            this.mSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsAutoSave,
            this.settingsThemeChange});
            this.mSettings.Name = "mSettings";
            this.mSettings.Size = new System.Drawing.Size(79, 20);
            this.mSettings.Text = "Настройки";
            // 
            // settingsAutoSave
            // 
            this.settingsAutoSave.Name = "settingsAutoSave";
            this.settingsAutoSave.Size = new System.Drawing.Size(165, 22);
            this.settingsAutoSave.Text = "Автосохранение";
            this.settingsAutoSave.Click += new System.EventHandler(this.settingsAutoSave_Click);
            // 
            // settingsThemeChange
            // 
            this.settingsThemeChange.Name = "settingsThemeChange";
            this.settingsThemeChange.Size = new System.Drawing.Size(165, 22);
            this.settingsThemeChange.Text = "Смена темы";
            this.settingsThemeChange.Click += new System.EventHandler(this.settingsThemeChange_Click);
            // 
            // mHelp
            // 
            this.mHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mHelpAboutProgram});
            this.mHelp.Name = "mHelp";
            this.mHelp.Size = new System.Drawing.Size(65, 20);
            this.mHelp.Text = "Справка";
            // 
            // mHelpAboutProgram
            // 
            this.mHelpAboutProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.горячиеКлавишиToolStripMenuItem});
            this.mHelpAboutProgram.Name = "mHelpAboutProgram";
            this.mHelpAboutProgram.Size = new System.Drawing.Size(180, 22);
            this.mHelpAboutProgram.Text = "О программе";
            // 
            // горячиеКлавишиToolStripMenuItem
            // 
            this.горячиеКлавишиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crtlWСоздатьНовуюВкладкуToolStripMenuItem,
            this.ctrlBToolStripMenuItem,
            this.ctrlSСохранитьТекущуюВкладкуToolStripMenuItem,
            this.ctrlQСохранитьВсеВкладкифайлыToolStripMenuItem,
            this.ctrlUЗакрытьДанноеОкноToolStripMenuItem});
            this.горячиеКлавишиToolStripMenuItem.Name = "горячиеКлавишиToolStripMenuItem";
            this.горячиеКлавишиToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.горячиеКлавишиToolStripMenuItem.Text = "Горячие клавиши";
            // 
            // crtlWСоздатьНовуюВкладкуToolStripMenuItem
            // 
            this.crtlWСоздатьНовуюВкладкуToolStripMenuItem.Name = "crtlWСоздатьНовуюВкладкуToolStripMenuItem";
            this.crtlWСоздатьНовуюВкладкуToolStripMenuItem.Size = new System.Drawing.Size(319, 22);
            this.crtlWСоздатьНовуюВкладкуToolStripMenuItem.Text = "Crtl + N - Создать новую вкладку";
            // 
            // ctrlBToolStripMenuItem
            // 
            this.ctrlBToolStripMenuItem.Name = "ctrlBToolStripMenuItem";
            this.ctrlBToolStripMenuItem.Size = new System.Drawing.Size(319, 22);
            this.ctrlBToolStripMenuItem.Text = "Ctrl + B - Создать новое окно";
            // 
            // ctrlSСохранитьТекущуюВкладкуToolStripMenuItem
            // 
            this.ctrlSСохранитьТекущуюВкладкуToolStripMenuItem.Name = "ctrlSСохранитьТекущуюВкладкуToolStripMenuItem";
            this.ctrlSСохранитьТекущуюВкладкуToolStripMenuItem.Size = new System.Drawing.Size(319, 22);
            this.ctrlSСохранитьТекущуюВкладкуToolStripMenuItem.Text = "Ctrl + S - Сохранить текущую вкладку(файл)";
            // 
            // ctrlQСохранитьВсеВкладкифайлыToolStripMenuItem
            // 
            this.ctrlQСохранитьВсеВкладкифайлыToolStripMenuItem.Name = "ctrlQСохранитьВсеВкладкифайлыToolStripMenuItem";
            this.ctrlQСохранитьВсеВкладкифайлыToolStripMenuItem.Size = new System.Drawing.Size(319, 22);
            this.ctrlQСохранитьВсеВкладкифайлыToolStripMenuItem.Text = "Ctrl + Q - Сохранить все вкладки(файлы)";
            // 
            // ctrlUЗакрытьДанноеОкноToolStripMenuItem
            // 
            this.ctrlUЗакрытьДанноеОкноToolStripMenuItem.Name = "ctrlUЗакрытьДанноеОкноToolStripMenuItem";
            this.ctrlUЗакрытьДанноеОкноToolStripMenuItem.Size = new System.Drawing.Size(319, 22);
            this.ctrlUЗакрытьДанноеОкноToolStripMenuItem.Text = "Ctrl + U - Закрыть данное окно";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusPanel1,
            this.statusLinesCount,
            this.statusPanel2,
            this.statusWordsCount,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusPanel1
            // 
            this.statusPanel1.Name = "statusPanel1";
            this.statusPanel1.Size = new System.Drawing.Size(109, 17);
            this.statusPanel1.Text = "Количество строк:";
            // 
            // statusLinesCount
            // 
            this.statusLinesCount.Name = "statusLinesCount";
            this.statusLinesCount.Size = new System.Drawing.Size(13, 17);
            this.statusLinesCount.Text = "0";
            // 
            // statusPanel2
            // 
            this.statusPanel2.Name = "statusPanel2";
            this.statusPanel2.Size = new System.Drawing.Size(110, 17);
            this.statusPanel2.Text = "  Количество слов:";
            // 
            // statusWordsCount
            // 
            this.statusWordsCount.Name = "statusWordsCount";
            this.statusWordsCount.Size = new System.Drawing.Size(13, 17);
            this.statusWordsCount.Text = "0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 60000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // TabControl
            // 
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 24);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(800, 404);
            this.TabControl.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mFile;
        private System.Windows.Forms.ToolStripMenuItem fileNew;
        private System.Windows.Forms.ToolStripMenuItem fileOpen;
        private System.Windows.Forms.ToolStripMenuItem fileSave;
        private System.Windows.Forms.ToolStripMenuItem mEdit;
        private System.Windows.Forms.ToolStripMenuItem mFormat;
        private System.Windows.Forms.ToolStripMenuItem mSettings;
        private System.Windows.Forms.ToolStripMenuItem fileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mEditCancel;
        private System.Windows.Forms.ToolStripMenuItem mEditCut;
        private System.Windows.Forms.ToolStripMenuItem mEditCopy;
        private System.Windows.Forms.ToolStripMenuItem mEditInsert;
        private System.Windows.Forms.ToolStripMenuItem mFormatTransfer;
        private System.Windows.Forms.ToolStripMenuItem mFormatFont;
        private System.Windows.Forms.ToolStripMenuItem mHelp;
        private System.Windows.Forms.ToolStripMenuItem mHelpAboutProgram;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusPanel1;
        private System.Windows.Forms.ToolStripStatusLabel statusLinesCount;
        private System.Windows.Forms.ToolStripStatusLabel statusPanel2;
        private System.Windows.Forms.ToolStripStatusLabel statusWordsCount;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem settingsAutoSave;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem settingsThemeChange;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem elToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CutDedicatedFragment;
        private System.Windows.Forms.ToolStripMenuItem CopyDedicatedFragment;
        private System.Windows.Forms.ToolStripMenuItem InsertDedicatedFragment;
        private System.Windows.Forms.ToolStripMenuItem PutFormToDedicatedText;
        public System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.ToolStripMenuItem горячиеКлавишиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crtlWСоздатьНовуюВкладкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctrlBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctrlSСохранитьТекущуюВкладкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctrlQСохранитьВсеВкладкифайлыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctrlUЗакрытьДанноеОкноToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}


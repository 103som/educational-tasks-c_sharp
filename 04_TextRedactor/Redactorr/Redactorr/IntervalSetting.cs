using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Redactorr
{
    /// <summary>
    /// Класс, нужный для настройки интервалов.
    /// </summary>
    public partial class IntervalSetting : Form
    {
        public IntervalSetting()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Настрйока интервалов текста.
        /// </summary>
        /// <param name="sender"> Вызвало событие.</param>
        /// <param name="e"> Аргумент вызванного события.</param>
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            lInterval.Text = trackBar.Value.ToString();
            MainForm.autoSaveInterval = trackBar.Value;
        }
    }
}

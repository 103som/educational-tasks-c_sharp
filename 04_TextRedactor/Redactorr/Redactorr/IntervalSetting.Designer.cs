
namespace Redactorr
{
    partial class IntervalSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.label = new System.Windows.Forms.Label();
            this.lInterval = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(12, 51);
            this.trackBar.Maximum = 60;
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(275, 45);
            this.trackBar.TabIndex = 0;
            this.trackBar.Value = 10;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label.Location = new System.Drawing.Point(12, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(290, 25);
            this.label.TabIndex = 1;
            this.label.Text = "Интервал автосохранения(минут):";
            // 
            // lInterval
            // 
            this.lInterval.AutoSize = true;
            this.lInterval.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lInterval.Location = new System.Drawing.Point(126, 99);
            this.lInterval.Name = "lInterval";
            this.lInterval.Size = new System.Drawing.Size(32, 25);
            this.lInterval.TabIndex = 2;
            this.lInterval.Text = "10";
            // 
            // IntervalSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 143);
            this.Controls.Add(this.lInterval);
            this.Controls.Add(this.label);
            this.Controls.Add(this.trackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IntervalSetting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Выбор интервала автосохранения";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label lInterval;
    }
}
namespace lab12
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Start = new System.Windows.Forms.Label();
            this.Start_b = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Start
            // 
            this.Start.AutoSize = true;
            this.Start.BackColor = System.Drawing.Color.Transparent;
            this.Start.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Start.ForeColor = System.Drawing.Color.Blue;
            this.Start.Location = new System.Drawing.Point(22, 515);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(14, 19);
            this.Start.TabIndex = 0;
            this.Start.Text = " ";
            // 
            // Start_b
            // 
            this.Start_b.AutoSize = true;
            this.Start_b.BackColor = System.Drawing.Color.Transparent;
            this.Start_b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Start_b.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Start_b.ForeColor = System.Drawing.Color.Blue;
            this.Start_b.Location = new System.Drawing.Point(44, 13);
            this.Start_b.Name = "Start_b";
            this.Start_b.Size = new System.Drawing.Size(68, 25);
            this.Start_b.TabIndex = 1;
            this.Start_b.Text = "Старт";
            this.Start_b.Click += new System.EventHandler(this.Start_b_Click_1);
            this.Start_b.MouseEnter += new System.EventHandler(this.Start_b_MouseEnter_1);
            this.Start_b.MouseLeave += new System.EventHandler(this.Start_b_MouseLeave_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(988, 549);
            this.Controls.Add(this.Start_b);
            this.Controls.Add(this.Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Ежик";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Start;
        private System.Windows.Forms.Label Start_b;
    }
}


namespace OD_Launcher
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Btn_Minimize = new System.Windows.Forms.Button();
            this.Btn_Exit = new System.Windows.Forms.Button();
            this.Output_Log = new System.Windows.Forms.TextBox();
            this.UpdateBar = new System.Windows.Forms.ProgressBar();
            this.Btn_Play = new System.Windows.Forms.Button();
            this.Lbl_Status = new System.Windows.Forms.Label();
            this.Lbl_Title = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // Btn_Minimize
            // 
            this.Btn_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_Minimize.FlatAppearance.BorderSize = 0;
            this.Btn_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Minimize.Image = global::OD_Launcher.Properties.Resources.minimize_window_26px;
            this.Btn_Minimize.Location = new System.Drawing.Point(666, 253);
            this.Btn_Minimize.Name = "Btn_Minimize";
            this.Btn_Minimize.Size = new System.Drawing.Size(33, 38);
            this.Btn_Minimize.TabIndex = 0;
            this.Btn_Minimize.UseMnemonic = false;
            this.Btn_Minimize.UseVisualStyleBackColor = false;
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_Exit.FlatAppearance.BorderSize = 0;
            this.Btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Exit.Image = global::OD_Launcher.Properties.Resources.close_window_26px;
            this.Btn_Exit.Location = new System.Drawing.Point(705, 253);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(33, 38);
            this.Btn_Exit.TabIndex = 1;
            this.Btn_Exit.UseMnemonic = false;
            this.Btn_Exit.UseVisualStyleBackColor = false;
            // 
            // Output_Log
            // 
            this.Output_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Output_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Output_Log.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Output_Log.Location = new System.Drawing.Point(400, 294);
            this.Output_Log.Multiline = true;
            this.Output_Log.Name = "Output_Log";
            this.Output_Log.ReadOnly = true;
            this.Output_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Output_Log.Size = new System.Drawing.Size(338, 153);
            this.Output_Log.TabIndex = 2;
            this.Output_Log.Text = "kkkkkkkkkkkkkkkkkkkkkkkkk\r\n\r\nsda\r\nsd\r\nads\r\nasd\r\nasd\r\nas\r\nda\r\nsd\r\nads\r\nas\r\nda\r\nda\r" +
    "\nsd\r\nas\r\nd";
            this.Output_Log.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // UpdateBar
            // 
            this.UpdateBar.Location = new System.Drawing.Point(400, 453);
            this.UpdateBar.Name = "UpdateBar";
            this.UpdateBar.Size = new System.Drawing.Size(338, 23);
            this.UpdateBar.TabIndex = 3;
            this.UpdateBar.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // Btn_Play
            // 
            this.Btn_Play.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Btn_Play.Enabled = false;
            this.Btn_Play.Location = new System.Drawing.Point(400, 482);
            this.Btn_Play.Name = "Btn_Play";
            this.Btn_Play.Size = new System.Drawing.Size(81, 23);
            this.Btn_Play.TabIndex = 4;
            this.Btn_Play.Text = "Play";
            this.Btn_Play.UseVisualStyleBackColor = false;
            this.Btn_Play.Click += new System.EventHandler(this.Btn_Play_Click);
            // 
            // Lbl_Status
            // 
            this.Lbl_Status.AutoSize = true;
            this.Lbl_Status.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Status.Location = new System.Drawing.Point(673, 485);
            this.Lbl_Status.Name = "Lbl_Status";
            this.Lbl_Status.Size = new System.Drawing.Size(65, 20);
            this.Lbl_Status.TabIndex = 5;
            this.Lbl_Status.Text = "Status?";
            this.Lbl_Status.Click += new System.EventHandler(this.Lbl_Status_Click);
            // 
            // Lbl_Title
            // 
            this.Lbl_Title.AutoSize = true;
            this.Lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Title.Font = new System.Drawing.Font("Meiryo UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Title.ForeColor = System.Drawing.Color.DarkOrange;
            this.Lbl_Title.Location = new System.Drawing.Point(379, 241);
            this.Lbl_Title.Name = "Lbl_Title";
            this.Lbl_Title.Size = new System.Drawing.Size(283, 50);
            this.Lbl_Title.TabIndex = 6;
            this.Lbl_Title.Text = "Orbital Drop";
            this.Lbl_Title.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OD_Launcher.Properties.Resources.Launcher_TysonTan4;
            this.ClientSize = new System.Drawing.Size(750, 530);
            this.Controls.Add(this.Lbl_Title);
            this.Controls.Add(this.Lbl_Status);
            this.Controls.Add(this.Btn_Play);
            this.Controls.Add(this.UpdateBar);
            this.Controls.Add(this.Output_Log);
            this.Controls.Add(this.Btn_Exit);
            this.Controls.Add(this.Btn_Minimize);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Minimize;
        private System.Windows.Forms.Button Btn_Exit;
        private System.Windows.Forms.TextBox Output_Log;
        private System.Windows.Forms.ProgressBar UpdateBar;
        private System.Windows.Forms.Button Btn_Play;
        private System.Windows.Forms.Label Lbl_Status;
        private System.Windows.Forms.Label Lbl_Title;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}


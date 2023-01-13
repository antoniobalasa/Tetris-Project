namespace ProiectTetris2
{
    partial class Form1
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
            this.usernametb = new System.Windows.Forms.TextBox();
            this.passwordtb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inchide = new System.Windows.Forms.Button();
            this.vizita = new System.Windows.Forms.Button();
            this.Inscrie = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernametb
            // 
            this.usernametb.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.usernametb.Location = new System.Drawing.Point(154, 182);
            this.usernametb.Name = "usernametb";
            this.usernametb.Size = new System.Drawing.Size(257, 29);
            this.usernametb.TabIndex = 0;
            // 
            // passwordtb
            // 
            this.passwordtb.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordtb.Location = new System.Drawing.Point(154, 255);
            this.passwordtb.Name = "passwordtb";
            this.passwordtb.PasswordChar = '*';
            this.passwordtb.Size = new System.Drawing.Size(257, 29);
            this.passwordtb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(154, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(154, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parola:";
            // 
            // inchide
            // 
            this.inchide.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.inchide.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inchide.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.inchide.Location = new System.Drawing.Point(208, 385);
            this.inchide.Name = "inchide";
            this.inchide.Size = new System.Drawing.Size(131, 53);
            this.inchide.TabIndex = 4;
            this.inchide.Text = "Inchide";
            this.inchide.UseVisualStyleBackColor = false;
            this.inchide.Click += new System.EventHandler(this.inchide_Click);
            // 
            // vizita
            // 
            this.vizita.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.vizita.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.vizita.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.vizita.Location = new System.Drawing.Point(217, 316);
            this.vizita.Name = "vizita";
            this.vizita.Size = new System.Drawing.Size(109, 53);
            this.vizita.TabIndex = 5;
            this.vizita.Text = "Joaca!";
            this.vizita.UseVisualStyleBackColor = false;
            this.vizita.Click += new System.EventHandler(this.button2_Click);
            // 
            // Inscrie
            // 
            this.Inscrie.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Inscrie.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Inscrie.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Inscrie.Location = new System.Drawing.Point(361, 316);
            this.Inscrie.Name = "Inscrie";
            this.Inscrie.Size = new System.Drawing.Size(161, 53);
            this.Inscrie.TabIndex = 6;
            this.Inscrie.Text = "Inscrie-te!";
            this.Inscrie.UseVisualStyleBackColor = false;
            this.Inscrie.Click += new System.EventHandler(this.Inscrie_Click);
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Login.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Login.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Login.Location = new System.Drawing.Point(54, 316);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(122, 53);
            this.Login.TabIndex = 7;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProiectTetris2.Properties.Resources.Tetris;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(546, 450);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Inscrie);
            this.Controls.Add(this.vizita);
            this.Controls.Add(this.inchide);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordtb);
            this.Controls.Add(this.usernametb);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Tetris - Sesiune de Comunicare";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox usernametb;
        private TextBox passwordtb;
        private Label label1;
        private Label label2;
        private Button inchide;
        private Button vizita;
        private Button Inscrie;
        private Button Login;
    }
}
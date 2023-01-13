namespace ProiectTetris2
{
    partial class Jocul
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Scor = new System.Windows.Forms.Label();
            this.nume = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.reclame = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Bomba = new System.Windows.Forms.PictureBox();
            this.LaComanda = new System.Windows.Forms.PictureBox();
            this.Skip = new System.Windows.Forms.PictureBox();
            this.EliminaRand = new System.Windows.Forms.PictureBox();
            this.Laser = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reclame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bomba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaComanda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Skip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EliminaRand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Laser)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(763, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "Score";
            // 
            // Scor
            // 
            this.Scor.AutoSize = true;
            this.Scor.Font = new System.Drawing.Font("Algerian", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Scor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Scor.Location = new System.Drawing.Point(825, 100);
            this.Scor.Name = "Scor";
            this.Scor.Size = new System.Drawing.Size(51, 54);
            this.Scor.TabIndex = 2;
            this.Scor.Text = "0";
            this.Scor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nume
            // 
            this.nume.AutoSize = true;
            this.nume.Font = new System.Drawing.Font("Algerian", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nume.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.nume.Location = new System.Drawing.Point(12, 34);
            this.nume.Name = "nume";
            this.nume.Size = new System.Drawing.Size(233, 39);
            this.nume.TabIndex = 3;
            this.nume.Text = "Vizitatorul";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ProiectTetris2.Properties.Resources.Game_Over;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(982, 863);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // reclame
            // 
            this.reclame.Image = global::ProiectTetris2.Properties.Resources.reclama1;
            this.reclame.Location = new System.Drawing.Point(12, 748);
            this.reclame.Name = "reclame";
            this.reclame.Size = new System.Drawing.Size(779, 101);
            this.reclame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.reclame.TabIndex = 5;
            this.reclame.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(806, 758);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(20);
            this.label2.Size = new System.Drawing.Size(156, 82);
            this.label2.TabIndex = 6;
            this.label2.Text = "Inapoi";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label2_MouseClick);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            this.label2.MouseHover += new System.EventHandler(this.label2_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ProiectTetris2.Properties.Resources.profil3;
            this.pictureBox2.Location = new System.Drawing.Point(47, 100);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(165, 156);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // Bomba
            // 
            this.Bomba.Image = global::ProiectTetris2.Properties.Resources.BombaB;
            this.Bomba.Location = new System.Drawing.Point(748, 189);
            this.Bomba.Name = "Bomba";
            this.Bomba.Size = new System.Drawing.Size(91, 88);
            this.Bomba.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Bomba.TabIndex = 8;
            this.Bomba.TabStop = false;
            this.Bomba.Visible = false;
            this.Bomba.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // LaComanda
            // 
            this.LaComanda.Image = global::ProiectTetris2.Properties.Resources.Bagheta;
            this.LaComanda.Location = new System.Drawing.Point(861, 189);
            this.LaComanda.Name = "LaComanda";
            this.LaComanda.Size = new System.Drawing.Size(91, 88);
            this.LaComanda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LaComanda.TabIndex = 9;
            this.LaComanda.TabStop = false;
            this.LaComanda.Visible = false;
            this.LaComanda.Click += new System.EventHandler(this.LaComanda_Click);
            // 
            // Skip
            // 
            this.Skip.Image = global::ProiectTetris2.Properties.Resources.Skip;
            this.Skip.Location = new System.Drawing.Point(748, 300);
            this.Skip.Name = "Skip";
            this.Skip.Size = new System.Drawing.Size(91, 88);
            this.Skip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Skip.TabIndex = 10;
            this.Skip.TabStop = false;
            this.Skip.Visible = false;
            this.Skip.Click += new System.EventHandler(this.pictureBox3_Click_1);
            // 
            // EliminaRand
            // 
            this.EliminaRand.Image = global::ProiectTetris2.Properties.Resources.Remove_line;
            this.EliminaRand.Location = new System.Drawing.Point(861, 300);
            this.EliminaRand.Name = "EliminaRand";
            this.EliminaRand.Size = new System.Drawing.Size(91, 88);
            this.EliminaRand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EliminaRand.TabIndex = 11;
            this.EliminaRand.TabStop = false;
            this.EliminaRand.Visible = false;
            this.EliminaRand.Click += new System.EventHandler(this.EliminaRand_Click);
            // 
            // Laser
            // 
            this.Laser.Image = global::ProiectTetris2.Properties.Resources.Laser;
            this.Laser.Location = new System.Drawing.Point(748, 418);
            this.Laser.Name = "Laser";
            this.Laser.Size = new System.Drawing.Size(91, 88);
            this.Laser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Laser.TabIndex = 12;
            this.Laser.TabStop = false;
            this.Laser.Visible = false;
            this.Laser.Click += new System.EventHandler(this.Laser_Click);
            // 
            // Jocul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(984, 861);
            this.Controls.Add(this.Laser);
            this.Controls.Add(this.EliminaRand);
            this.Controls.Add(this.Skip);
            this.Controls.Add(this.LaComanda);
            this.Controls.Add(this.Bomba);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reclame);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.nume);
            this.Controls.Add(this.Scor);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1000, 900);
            this.Name = "Jocul";
            this.Text = "Jocul Tetris";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Jocul_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Jocul_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Jocul_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reclame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bomba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaComanda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Skip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EliminaRand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Laser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Label Scor;
        private Label nume;
        private PictureBox pictureBox1;
        private PictureBox reclame;
        private System.Windows.Forms.Timer timer2;
        private Label label2;
        private PictureBox pictureBox2;
        private PictureBox Bomba;
        private PictureBox LaComanda;
        private PictureBox Skip;
        private PictureBox EliminaRand;
        private PictureBox Laser;
    }
}
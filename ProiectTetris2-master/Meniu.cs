using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using Microsoft.VisualBasic;

namespace ProiectTetris2
{
    public partial class Meniu : Form
    {
        public Meniu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void populeazaComboBox()
        {

            comboBox1.Visible = true;
            for (int i = 0; i < Program.contActual.produseCumparate.Count; i++) //6 pentru ca pana la 5 sunt produse de profil
            {
                
                int indiceProdus = Program.contActual.produseCumparate[i];
                if (indiceProdus < 6)
                {
                    string adaugaProdus = Program.listaProduselor.produse[indiceProdus].numeProdus;
                    comboBox1.Items.Add(adaugaProdus);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem.ToString();
            for (int i = 0; i < 6; i++)
            {
                if (Program.listaProduselor.produse[i].numeProdus == selected)
                {
                    pictureBox1.Image = Image.FromFile(Program.listaProduselor.produse[i].pozaProdus);
                    Program.listaConturi.conturi[Program.contActual.id].pozaProfil = i;
                    System.IO.File.WriteAllText(@"..\\..\\..\\Resources\\Conturi.txt", JsonSerializer.Serialize(Program.listaConturi));
                }
            }

        }

        private void Meniu_Load(object sender, EventArgs e)
        {
            if (Program.contActual != null)
            {
                nume.Text = "Buna, " + Program.contActual.username + "!";
                pictureBox1.Image = Image.FromFile(Program.listaProduselor.produse[Program.contActual.pozaProfil].pozaProdus);
                BaniLB.Text = "Bani: " + Program.contActual.bani;
                XPLB.Text = "XP: " + Program.contActual.xp;
                button4.Visible = true;
                populeazaComboBox();
            }
            else
            {
                button1.Enabled = false;
                button5.Text = "Inapoi";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Program.contActual = null;
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ScoruriTop form3 = new ScoruriTop("0");
            form3.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int nivel = 1;
            if (radioButton2.Checked == true) nivel = 2;
            else if (radioButton3.Checked == true) nivel = 3;
            var joc = new Jocul(nivel);
            joc.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Shop sh = new Shop();
            this.Close();
            sh.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string parolaPropusa = Interaction.InputBox("Ce parola vrei?", "Schimba parola");
            if (parolaPropusa != null)
            {
                Program.listaConturi.conturi[Program.contActual.id].parola = parolaPropusa;

                System.IO.File.WriteAllText(@"..\\..\\..\\Resources\\Conturi.txt", JsonSerializer.Serialize(Program.listaConturi));
            }
            else
            {
                MessageBox.Show("N-ai tastat o parola.");
            }
        }
            private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void XPLB_Click(object sender, EventArgs e)
        {

        }
    }
}

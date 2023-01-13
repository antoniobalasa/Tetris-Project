using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Text.Json;

namespace ProiectTetris2
{
    public partial class Shop : Form
    {
        public Shop()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        List<(Label, PictureBox, Button, int)> abilitati = new List<(Label, PictureBox, Button, int)>();
        List<(Label, PictureBox, Button, int)> pozeProfil = new List<(Label, PictureBox, Button, int)>();

        private void Shop_Load(object sender, EventArgs e)
        {
            salutare.Text = "Bine ai venit la Shop, " + Program.contActual.username + "!";
            BaniLB.Text = Program.contActual.bani.ToString();
            XPLB.Text = Program.contActual.xp.ToString();
            pozeProfil.Add((label3, pictureBox1, button3, 0));
            pozeProfil.Add((label4, pictureBox2, button4, 1));
            pozeProfil.Add((label7, pictureBox3, button5, 2));
            pozeProfil.Add((label6, pictureBox4, button6, 3));
            pozeProfil.Add((label9, pictureBox14, button10, 4));
            pozeProfil.Add((label5, pictureBox5, button7, 5));
            abilitati.Add((label12, pictureBox12, button14, 6));
            abilitati.Add((label11, pictureBox11, button13, 7));
            abilitati.Add((label10, pictureBox10, button12, 8));
            abilitati.Add((label17, pictureBox9, button11, 9));
            abilitati.Add((label16, pictureBox7, button9, 10));
            abilitati.Add((label15, pictureBox6, button8, 11));

            for (int i = 0; i < 6; i++)
            {
                pozeProfil[i].Item1.Text = $"{Program.listaProduselor.produse[i].numeProdus} \nXP: {Program.listaProduselor.produse[i].pretXP} \nBani: {Program.listaProduselor.produse[i].pretBani}";
                pozeProfil[i].Item2.Image = Image.FromFile(Program.listaProduselor.produse[i].pozaProdus);
                if (dejaCumparat(i, Program.contActual.produseCumparate))
                    pozeProfil[i].Item3.Enabled = false;
            }
            for (int i = 0; i < 6; i++)
            {
                abilitati[i].Item1.Text = $"{Program.listaProduselor.produse[i+6].numeProdus} \nXP: {Program.listaProduselor.produse[i + 6].pretXP}\nBani: {Program.listaProduselor.produse[i+6].pretBani}";
                abilitati[i].Item2.Image = Image.FromFile(Program.listaProduselor.produse[i + 6].pozaProdus);
                if (dejaCumparat(i+6, Program.contActual.produseCumparate))
                    abilitati[i].Item3.Enabled = false;
            }
        }

        static bool dejaCumparat(int prodID, List<int> prodCumparate)
        {
            for (int i = 0; i < prodCumparate.Count; i++)
            {
                if (prodID == prodCumparate[i])
                    return true;
            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Meniu m = new Meniu();
            m.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)  
        {
            string input = Interaction.InputBox("Cati T-Gold vrei sa cumperi?", "Incarca banii in cont");
            int baniadaugat;
            int.TryParse(input, out baniadaugat);
            if (baniadaugat != null)
            {
                int suma = Convert.ToInt32(BaniLB.Text) + baniadaugat;
                BaniLB.Text = suma.ToString();
                Program.contActual.bani = suma;
                Program.listaConturi.conturi[Program.contActual.id].bani = suma;
                System.IO.File.WriteAllText(@"..\\..\\..\\Resources\\Conturi.txt", JsonSerializer.Serialize(Program.listaConturi));
            }
            else MessageBox.Show("Ai tastat un raspuns care nu este un numar.");
        }

        private void toateButoanele(Button b, int prodID)
        {

            bool tranzactie = true;
            if (Program.contActual.xp < Program.listaProduselor.produse[prodID].pretXP && Program.contActual.bani < Program.listaProduselor.produse[prodID].pretBani)
            {
                MessageBox.Show("Nu ai destule XP sau T-Gold sa cumperi acest produs!");
                tranzactie = false;
            }
            else
            {
                if (Program.contActual.xp >= Program.listaProduselor.produse[prodID].pretXP && Program.contActual.bani < Program.listaProduselor.produse[prodID].pretBani)
                {
                    Program.contActual.xp -= Program.listaProduselor.produse[prodID].pretXP;
                    XPLB.Text = (Program.contActual.xp).ToString();
                }
                else if (Program.contActual.xp < Program.listaProduselor.produse[prodID].pretXP && Program.contActual.bani >= Program.listaProduselor.produse[prodID].pretBani)
                {
                    Program.contActual.bani -= Program.listaProduselor.produse[prodID].pretBani;
                    BaniLB.Text = (Program.contActual.bani).ToString();
                }
                else
                {
                    MessageBoxButtons btn = MessageBoxButtons.YesNoCancel;
                    DialogResult raspuns = MessageBox.Show("Vrei sa-l cumperi cu XP?", "Cumparare cu XP", btn);
                    if (raspuns == DialogResult.Yes)
                    {
                        Program.contActual.xp -= Program.listaProduselor.produse[prodID].pretXP;
                        XPLB.Text = (Program.contActual.xp).ToString();
                    }
                    else if (raspuns == DialogResult.No)
                    {
                        MessageBoxButtons btn2 = MessageBoxButtons.OKCancel;
                        DialogResult raspuns2 = MessageBox.Show("Atunci cumperi cu T-Gold?", "Cumparare cu T-Gold", btn);
                        if (raspuns2 == DialogResult.OK)
                        {
                            Program.contActual.bani -= Program.listaProduselor.produse[prodID].pretBani;
                            BaniLB.Text = (Program.contActual.bani).ToString();
                        }
                        else tranzactie = false;
                    }
                    else tranzactie = false;
                }
                if (tranzactie)
                {
                    Program.contActual.produseCumparate.Add(prodID);
                    Program.listaConturi.conturi[Program.contActual.id] = Program.contActual;
                    System.IO.File.WriteAllText(@"..\\..\\..\\Resources\\Conturi.txt", JsonSerializer.Serialize(Program.listaConturi));
                    b.Enabled = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            toateButoanele(button3, 0);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            toateButoanele(button4, 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            toateButoanele(button5, 2);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            toateButoanele(button6, 3);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            toateButoanele(button10, 4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            toateButoanele(button7, 5);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            toateButoanele(button14, 6);

        }
        private void button13_Click(object sender, EventArgs e)
        {
            toateButoanele(button13, 7);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            toateButoanele(button12, 8);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            toateButoanele(button11, 9);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            toateButoanele(button9, 10);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            toateButoanele(button8, 11);
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }
    }
}

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

namespace ProiectTetris2
{
    public partial class ScoruriTop : Form
    {
        public ScoruriTop(string scorul)
        {
            InitializeComponent();
            scorActual = Convert.ToInt32(scorul);

        }

        public int scorActual;
        class Scoruri
        {
            public List<Player> Players { get; set; }
        }
        class Player
        {
            public string id { get; set; }
            public int scor { get; set; }
        }

        private int loculScor(Scoruri scoruri)
        {
            int locul = 10;
            for (int i = 9; i >= 0; i--)
            {
                if (scorActual < scoruri.Players[i].scor)
                {
                    return locul;
                }
                else locul = i;
            }
            return locul;
        }

        private void ScoruriTop_Load(object sender, EventArgs e)
        {
            Label[] nume = {label2, label3, label4, label5, label6, label7, label8, label9, label10, label11 };
            Label[] scorEtichete = { label21, label20, label19, label18, label17, label16, label15, label14, label13,label12};
            string jsonString = System.IO.File.ReadAllText(@"..\\..\\..\\Resources\\Scoruri.txt");
            Scoruri scoruri = JsonSerializer.Deserialize<Scoruri>(jsonString);
            int locul = loculScor(scoruri);
            if (locul < 10)
            {
                Player jucatorActual = new Player();
                jucatorActual.scor = scorActual;
                jucatorActual.id = Microsoft.VisualBasic.Interaction.InputBox("Felicitari! Ai ajuns la scoruri de top! Tasteaza-ti nume!", "Tasteaza Numele");
                scoruri.Players.Insert(loculScor(scoruri), jucatorActual);
                scoruri.Players.RemoveAt(10);
            }
            for (int i = 0; i < scoruri.Players.Count; i++)
            {
                nume[i].Text = scoruri.Players[i].id;
                scorEtichete[i].Text = (scoruri.Players[i].scor).ToString();
            }
            System.IO.File.WriteAllText(@"..\\..\\..\\Resources\\Scoruri.txt", JsonSerializer.Serialize(scoruri));


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Meniu m = new Meniu();
            this.Close();
            m.Show();
        }
    }
}

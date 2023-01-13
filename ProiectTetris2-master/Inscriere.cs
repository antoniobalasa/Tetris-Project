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
    public partial class W : Form
    {
        public W()
        {
            InitializeComponent();
        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void Gata_Click(object sender, EventArgs e)
        {
            bool gasit = false;
            bool gol = false;
            if (userN.Text == "")
            { 
                MessageBox.Show("Numele de utilizator nu poate fi gol");
            }
            else if (userN.Text!="")
            {
                for (int i = 0; i < Program.listaConturi.conturi.Count; i++)
                {
                    if (Program.listaConturi.conturi[i].username == userN.Text)
                    {
                        MessageBox.Show("Utilizatorul deja exista.");
                        gasit = true;
                        break;
                    }

                }
                if (pw1.Text == "")
                {
                    MessageBox.Show("Nu a fost introdusa nicio parola");

                }
                else if (pw1.Text != "")
                {
                    if (pw1.Text != pw2.Text)
                    {
                        MessageBox.Show("Parole nu sunt la fel. Reintrodu-le.");
                        pw1.Text = "";
                        pw2.Text = "";
                    }
                    else if (pw1.Text == pw2.Text && gasit == false)
                    {
                        Program.Cont nouCont = new Program.Cont();
                        nouCont.username = userN.Text;
                        nouCont.parola = pw2.Text;
                        nouCont.id = Program.listaConturi.conturi.Count; //pentru ca numaram id de la 0, .Count ne da urmatorul numar nefolosit
                        nouCont.pozaProfil = 0;
                        nouCont.bani = 0;
                        nouCont.xp = 0;
                        nouCont.produseCumparate = new List<int>();
                        nouCont.produseCumparate.Add(0);
                        Program.listaConturi.conturi.Add(nouCont);
                        System.IO.File.WriteAllText(@"..\\..\\..\\Resources\\Conturi.txt", JsonSerializer.Serialize(Program.listaConturi));
                        MessageBox.Show("Contul a fost creat!");
                        this.Close();
                        Form1 f1 = new Form1();
                        f1.Show();
                    }
                }

            }

        }

        private void W_Load(object sender, EventArgs e)
        {

        }
    }
}

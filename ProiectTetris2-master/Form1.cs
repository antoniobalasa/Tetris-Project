using System.Text.Json;

namespace ProiectTetris2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool usr = false;
            for (int i = 0; i < Program.listaConturi.conturi.Count(); i++)
            {

                if (usernametb.Text == Program.listaConturi.conturi[i].username)
                {
                    usr = true;
                    if (passwordtb.Text == Program.listaConturi.conturi[i].parola)
                    {
                        Program.contActual = Program.listaConturi.conturi[i];
                        Meniu m = new Meniu();
                        m.Show();
                        this.Hide();
                    }
                    else
                    {
                        passwordtb.BackColor = Color.Red;
                        MessageBox.Show("Autentificare esuata.");
                    }
                }
            }
            if (usr == false)
            {
                usernametb.BackColor = Color.Red;
                MessageBox.Show("Nu exista un utilizator cu acest username.");
            }
            usernametb.BackColor = Color.White;
            passwordtb.BackColor = Color.White;
        }

        private void inchide_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string JSONconturi = System.IO.File.ReadAllText(@"..\\..\\..\\Resources\\Conturi.txt");
            
            Program.Conturi conturi = JsonSerializer.Deserialize<Program.Conturi>(JSONconturi);
            Program.listaConturi = conturi;
            string JSONproduse = System.IO.File.ReadAllText(@"..\\..\\..\\Resources\\produse.txt");
            Program.Produse clasaProduse = JsonSerializer.Deserialize<Program.Produse>(JSONproduse);
            Program.listaProduselor = clasaProduse;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Meniu m = new Meniu();
            m.Show();
            this.Hide();
        }

        private void Inscrie_Click(object sender, EventArgs e)
        {
            W ins = new W();
            ins.Show();
            this.Hide();
        }
    }
}
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
    public partial class Jocul : Form
    {
        public Jocul(int nivel)
        {
            InitializeComponent();
            timer1.Interval = 1300 - nivel * 400;
            timer2.Interval = 3000;
        }

#region declar culori, forme, puncte pentru a desena
        SolidBrush rosu = new SolidBrush(Color.Red);
        SolidBrush albastru = new SolidBrush(Color.Blue);
        SolidBrush verde = new SolidBrush(Color.Green);
        SolidBrush galben = new SolidBrush(Color.Yellow);
        SolidBrush roz = new SolidBrush(Color.Pink);
        SolidBrush porto = new SolidBrush(Color.Orange);
        SolidBrush mov = new SolidBrush(Color.Purple);
        SolidBrush alb = new SolidBrush(Color.White);

        public static List<List<(int, int)>> Patrat = new List<List<(int, int)>>();
        public static List<List<(int, int)>> Bagheta = new List<List<(int, int)>>();
        public static List<List<(int, int)>> T = new List<List<(int, int)>>();
        public static List<List<(int, int)>> L = new List<List<(int, int)>>();
        public static List<List<(int, int)>> J = new List<List<(int, int)>>();
        public static List<List<(int, int)>> S = new List<List<(int, int)>>();
        public static List<List<(int, int)>> Z = new List<List<(int, int)>>();
        string[] reclamele = System.IO.File.ReadAllLines(@"..\\..\\..\\Resources\\reclame.txt");

        public struct Punct
        {
            public int rand { get; set; }
            public int col { get; set; }
            public SolidBrush culoare { get; set; }
            public Punct(int r, int c, SolidBrush cul)
            {
                this.rand = r;
                this.col = c;
                this.culoare = cul;
            }
        }

        List<Punct> spatiulOcupat = new List<Punct>();
        public struct FormaCurenta
        {
            public int rand;
            public int col;
            public int config;
            public string tipForma;
            public FormaCurenta(int r, int c, int con, string tip)
            {
                rand = r;
                col = c;
                config = con;
                tipForma = tip;
            }
        }
        FormaCurenta forma = new FormaCurenta();
        #endregion

        #region initializez formele, pozitia initiala
        private void Form2_Load(object sender, EventArgs e)
        {
            initializare();
            forma.rand = 0;
            forma.col = 4;
            forma.config = 0;
            forma.tipForma = formaAleatorie();
            timer1.Enabled = true;
            timer2.Enabled = true;
            if (Program.contActual != null)
            {
                nume.Text = Program.contActual.username;
                pictureBox2.Image = Image.FromFile(Program.listaProduselor.produse[Program.contActual.pozaProfil].pozaProdus);
                if (Program.contActual.produseCumparate.Contains(6)) reclame.Visible = false;
                if (Program.contActual.produseCumparate.Contains(7)) Bomba.Visible = true;
                if (Program.contActual.produseCumparate.Contains(8)) LaComanda.Visible = true;
                if (Program.contActual.produseCumparate.Contains(9)) Skip.Visible = true;
                if (Program.contActual.produseCumparate.Contains(10)) EliminaRand.Visible = true;
                if (Program.contActual.produseCumparate.Contains(11)) Laser.Visible = true;
            }
        }

        private void initializare()
        {
            Patrat.Add(new List<(int, int)> { (0, 0), (1, 0), (0, 1), (1, 1) });
            Bagheta.Add(new List<(int, int)> { (0, 0), (1, 0), (2, 0), (3, 0) });
            Bagheta.Add(new List<(int, int)> { (2, -1), (2, 0), (2, 1), (2, 2) });
            Bagheta.Add(new List<(int, int)> { (1, 0), (2, 0), (3, 0), (4, 0) });
            Bagheta.Add(new List<(int, int)> { (2, -2), (2, -1), (2, 0), (2, 1) });
            T.Add(new List<(int, int)> { (1, 0), (1, 1), (1, 2), (0, 1) });
            T.Add(new List<(int, int)> { (0, 1), (1, 0), (1, 1), (2, 1) });
            T.Add(new List<(int, int)> { (1, 0), (2, 1), (1, 2), (1, 1) });
            T.Add(new List<(int, int)> { (0, 1), (1, 1), (1, 2), (2, 1) });
            L.Add(new List<(int, int)> { (0, 0), (1, 0), (2, 0), (2, 1) });
            L.Add(new List<(int, int)> { (1, -1), (1, 0), (1, 1), (0, 1) });
            L.Add(new List<(int, int)> { (0, -1), (0, 0), (1, 0), (2, 0) });
            L.Add(new List<(int, int)> { (1, -1), (1, 0), (1, 1), (2, -1) });
            J.Add(new List<(int, int)> { (1, 1), (0, 1), (2, 1), (2, 0) });
            J.Add(new List<(int, int)> { (0, 0), (1, 0), (1, 1), (1, 2) });
            J.Add(new List<(int, int)> { (0, 1), (0, 2), (1, 1), (2, 1) });
            J.Add(new List<(int, int)> { (1, 0), (1, 1), (1, 2), (2, 2) });
            S.Add(new List<(int, int)> { (0, 0), (1, 0), (1, 1), (2, 1) });
            S.Add(new List<(int, int)> { (1, 0), (1, 1), (2, -1), (2, 0) });
            S.Add(new List<(int, int)> { (0, -1), (1, -1), (1, 0), (2, 0) });
            S.Add(new List<(int, int)> { (1, -1), (1, 0), (0, 0), (0, 1) });
            Z.Add(new List<(int, int)> { (0, 1), (1, 1), (1, 0), (2, 0) });
            Z.Add(new List<(int, int)> { (1, -1), (1, 0), (2, 0), (2, 1) });
            Z.Add(new List<(int, int)> { (0, 0), (1, -0), (1, -1), (2, -1) });
            Z.Add(new List<(int, int)> { (0, -1), (0, 0), (1, 0), (1, 1) });
        }
        #endregion

        #region verificari despre unde sunt formele si la ce conditii sa dea refresh
        private bool iesitMargine(FormaCurenta propus)
        {
            int r = propus.rand;
            int c = propus.col;
            int c0, c1, c2, c3;
            int con = propus.config % 4;
            switch (propus.tipForma)
            {
                case "patrat":
                    c0 = c + Patrat[0][0].Item2;
                    c1 = c + Patrat[0][1].Item2;
                    c2 = c + Patrat[0][2].Item2;
                    c3 = c + Patrat[0][3].Item2;
                    if (c0 < 0 || c1 < 0 || c2 < 0 || c3 < 0 || c0 > 9 || c1 > 9 || c2 > 9 || c3 > 9)
                        return true;
                    else return false;
                case "bagheta":
                    c0 = c + Bagheta[con][0].Item2;
                    c1 = c + Bagheta[con][1].Item2;
                    c2 = c + Bagheta[con][2].Item2;
                    c3 = c + Bagheta[con][3].Item2;
                    if (c0 < 0 || c1 < 0 || c2 < 0 || c3 < 0 || c0 > 9 || c1 > 9 || c2 > 9 || c3 > 9)
                        return true;
                    else return false;
                case "T":
                    c0 = c + T[con][0].Item2;
                    c1 = c + T[con][1].Item2;
                    c2 = c + T[con][2].Item2;
                    c3 = c + T[con][3].Item2;
                    if (c0 < 0 || c1 < 0 || c2 < 0 || c3 < 0 || c0 > 9 || c1 > 9 || c2 > 9 || c3 > 9)
                        return true;
                    else return false;
                case "L":
                    c0 = c + L[con][0].Item2;
                    c1 = c + L[con][1].Item2;
                    c2 = c + L[con][2].Item2;
                    c3 = c + L[con][3].Item2;
                    if (c0 < 0 || c1 < 0 || c2 < 0 || c3 < 0 || c0 > 9 || c1 > 9 || c2 > 9 || c3 > 9)
                        return true;
                    else return false;
                case "J":
                    c0 = c + J[con][0].Item2;
                    c1 = c + J[con][1].Item2;
                    c2 = c + J[con][2].Item2;
                    c3 = c + J[con][3].Item2;
                    if (c0 < 0 || c1 < 0 || c2 < 0 || c3 < 0 || c0 > 9 || c1 > 9 || c2 > 9 || c3 > 9)
                        return true;
                    else return false;
                case "S":
                    c0 = c + S[con][0].Item2;
                    c1 = c + S[con][1].Item2;
                    c2 = c + S[con][2].Item2;
                    c3 = c + S[con][3].Item2;
                    if (c0 < 0 || c1 < 0 || c2 < 0 || c3 < 0 || c0 > 9 || c1 > 9 || c2 > 9 || c3 > 9)
                        return true;
                    else return false;
                case "Z":
                    c0 = c + Z[con][0].Item2;
                    c1 = c + Z[con][1].Item2;
                    c2 = c + Z[con][2].Item2;
                    c3 = c + Z[con][3].Item2;
                    if (c0 < 0 || c1 < 0 || c2 < 0 || c3 < 0 || c0 > 9 || c1 > 9 || c2 > 9 || c3 > 9)
                        return true;
                    else return false;
            }
            return false;
        }

        private bool ajunsJos(FormaCurenta propus)
        {
            int pr, pc, con = propus.config % 4;
            switch (propus.tipForma)
            {
                case "patrat":
                    for (int j = 0; j < 4; j++)
                    {
                        pr = propus.rand + Patrat[0][j].Item1;
                        pc = propus.col + Patrat[0][j].Item2;
                        if (pr == 20) return true;
                        for (int i = spatiulOcupat.Count - 1; i >= 0; i--)
                        {
                            if (pr == spatiulOcupat[i].rand && pc == spatiulOcupat[i].col)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                case "bagheta":
                    for (int j = 0; j < 4; j++)
                    {
                        pr = propus.rand + Bagheta[con][j].Item1;
                        pc = propus.col + Bagheta[con][j].Item2;
                        if (pr == 20) return true;
                        for (int i = spatiulOcupat.Count - 1; i >= 0; i--)
                        {
                            if (pr == spatiulOcupat[i].rand && pc == spatiulOcupat[i].col)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                case "T":
                    for (int j = 0; j < 4; j++)
                    {
                        pr = propus.rand + T[con][j].Item1;
                        pc = propus.col + T[con][j].Item2;
                        if (pr == 20) return true;
                        for (int i = spatiulOcupat.Count - 1; i >= 0; i--)
                        {
                            if (pr == spatiulOcupat[i].rand && pc == spatiulOcupat[i].col)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                case "L":
                    for (int j = 0; j < 4; j++)
                    {
                        pr = propus.rand + L[con][j].Item1;
                        pc = propus.col + L[con][j].Item2;
                        if (pr == 20) return true;
                        for (int i = spatiulOcupat.Count - 1; i >= 0; i--)
                        {
                            if (pr == spatiulOcupat[i].rand && pc == spatiulOcupat[i].col)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                case "J":
                    for (int j = 0; j < 4; j++)
                    {
                        pr = propus.rand + J[con][j].Item1;
                        pc = propus.col + J[con][j].Item2;
                        if (pr == 20) return true;
                    
                        for (int i = spatiulOcupat.Count - 1; i >= 0; i--)
                        {
                            if (pr == spatiulOcupat[i].rand && pc == spatiulOcupat[i].col)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                case "S":
                    for (int j = 0; j < 4; j++)
                    {
                        pr = propus.rand + S[con][j].Item1;
                        pc = propus.col + S[con][j].Item2;
                        if (pr == 20) return true;
                        for (int i = spatiulOcupat.Count - 1; i >= 0; i--)
                        {
                            if (pr == spatiulOcupat[i].rand && pc == spatiulOcupat[i].col)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                case "Z":
                    for (int j = 0; j < 4; j++)
                    {
                        pr = propus.rand + Z[con][j].Item1;
                        pc = propus.col + Z[con][j].Item2;
                        if (pr == 20) return true;
                        for (int i = spatiulOcupat.Count - 1; i >= 0; i--)
                        {
                            if (pr == spatiulOcupat[i].rand && pc == spatiulOcupat[i].col)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                default:
                    return false;
            }
        }

        private void linieCompleta()
        {
            int cate = 0;
            List<int> randuriDeScos = new List<int>();
            for (int i = 19; i >= 0; i--)
            {
                for (int j = 0; j < spatiulOcupat.Count; j++)
                {
                    if (spatiulOcupat[j].rand == i) cate++;
                }
                if (cate == 10)
                {
                    randuriDeScos.Add(i);
                }
                cate = 0;
            }
            if (randuriDeScos.Count != 0)
            {
                scoatePuncte(randuriDeScos);
                double multi = randuriDeScos.Count;
                int suma = Convert.ToInt32(Scor.Text) + Convert.ToInt32(Math.Pow(multi, 2)) * 100;
                Scor.Text = suma.ToString();
                linieCompleta();
            }
        }

        private void scoatePuncte(List<int> linii)
        {
            for (int i = linii.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < spatiulOcupat.Count; j++)
                {
                    if (linii[i] == spatiulOcupat[j].rand)
                    {
                        spatiulOcupat.RemoveAt(j);
                        j--;
                    }
                    else if (linii[i] > spatiulOcupat[j].rand)
                    {
                        Punct aux = spatiulOcupat[j];
                        aux.rand++;
                        spatiulOcupat[j] = aux;
                    }
                }
            }
            this.Refresh();
        }

        private void adaugaLaOcupat()
        {
            int r, c, con = forma.config % 4;
            switch (forma.tipForma)
            {
                case "patrat":
                    for (int i = 0; i < 4; i++)
                    {
                        r = forma.rand + Patrat[0][i].Item1;
                        if (r <= 0)
                        {
                            timer1.Enabled = false;
                            pictureBox1.Visible = true;
                        }
                        else
                        {
                            c = forma.col + Patrat[0][i].Item2;
                            spatiulOcupat.Add(new Punct(r, c, rosu));
                        }
                    }
                    break;
                case "bagheta":
                    for (int i = 0; i < 4; i++)
                    {
                        r = forma.rand + Bagheta[con][i].Item1;
                        c = forma.col + Bagheta[con][i].Item2;
                        spatiulOcupat.Add(new Punct(r, c, albastru));
                    }
                    break;
                case "T":
                    for (int i = 0; i < 4; i++)
                    {
                        r = forma.rand + T[con][i].Item1;
                        c = forma.col + T[con][i].Item2;
                        spatiulOcupat.Add(new Punct(r, c, galben));
                    }
                    break;
                case "L":
                    for (int i = 0; i < 4; i++)
                    {
                        r = forma.rand + L[con][i].Item1;
                        c = forma.col + L[con][i].Item2;
                        spatiulOcupat.Add(new Punct(r, c, verde));
                    }
                    break;
                case "J":
                    for (int i = 0; i < 4; i++)
                    {
                        r = forma.rand + J[con][i].Item1;
                        c = forma.col + J[con][i].Item2;
                        spatiulOcupat.Add(new Punct(r, c, mov));
                    }
                    break;
                case "S":
                    for (int i = 0; i < 4; i++)
                    {
                        r = forma.rand + S[con][i].Item1;
                        c = forma.col + S[con][i].Item2;
                        spatiulOcupat.Add(new Punct(r, c, porto));
                    }
                    break;
                case "Z":
                    for (int i = 0; i < 4; i++)
                    {
                        r = forma.rand + Z[con][i].Item1;
                        c = forma.col + Z[con][i].Item2;
                        spatiulOcupat.Add(new Punct(r, c, roz));
                    }
                    break;
                default:
                    break;
            }
        }


        #endregion

        #region tot ce tine de paint
        public void deseneazaForma(PaintEventArgs e)
        {
            int conf = forma.config % 4;
            switch (forma.tipForma)
            {
                case "patrat":
                    for (int i = 0; i < 4; i++)
                    {
                        deseneazaPunct(e, Patrat[0][i].Item1 + forma.rand, Patrat[0][i].Item2 + forma.col, rosu);
                    }
                    break;
                case "bagheta":
                    for (int i = 0; i < 4; i++)
                    {
                        deseneazaPunct(e, Bagheta[conf][i].Item1 + forma.rand, Bagheta[conf][i].Item2 + forma.col, albastru);
                    }
                    break;
                case "T":
                    for (int i = 0; i < 4; i++)
                    {
                        deseneazaPunct(e, T[conf][i].Item1 + forma.rand, T[conf][i].Item2 + forma.col, galben);
                    }
                    break;
                case "L":
                    for (int i = 0; i < 4; i++)
                    {
                        deseneazaPunct(e, L[conf][i].Item1 + forma.rand, L[conf][i].Item2 + forma.col, verde);
                    }
                    break;
                case "J":
                    for (int i = 0; i < 4; i++)
                    {
                        deseneazaPunct(e, J[conf][i].Item1 + forma.rand, J[conf][i].Item2 + forma.col, mov);
                    }
                    break;
                case "S":
                    for (int i = 0; i < 4; i++)
                    {
                        deseneazaPunct(e, S[conf][i].Item1 + forma.rand, S[conf][i].Item2 + forma.col, porto);
                    }
                    break;
                case "Z":
                    for (int i = 0; i < 4; i++)
                    {
                        deseneazaPunct(e, Z[conf][i].Item1 + forma.rand, Z[conf][i].Item2 + forma.col, roz);
                    }
                    break;
            }

        }
        
        public void deseneazaSpatiulJoc(PaintEventArgs e)
        {
            Pen pixAlb = new Pen(Color.White, 3);
            SolidBrush coloreaza = new SolidBrush(System.Drawing.Color.Black);
            Rectangle drept = new Rectangle(this.Width / 2 - 35 * 5, 35, 35 * 10, 35 * 20);
            e.Graphics.DrawRectangle(pixAlb, drept);
            e.Graphics.FillRectangle(coloreaza, drept);
            pixAlb.Dispose();
            coloreaza.Dispose();
        }

        public void deseneazaSpatiulOcupat(PaintEventArgs e)
        {
            foreach (Punct punct in spatiulOcupat)
            {
                deseneazaPunct(e, punct.rand, punct.col, punct.culoare);
            }
        }

        public void deseneazaPunct(PaintEventArgs e, int rand, int col, SolidBrush culoare)
        {
            Pen chenar = new Pen(Color.White, 3);
            Rectangle patrat = new Rectangle((this.Width / 2 - 35 * 5) + 35 * col, 35 + 35 * rand, 35, 35);
            e.Graphics.DrawRectangle(chenar, patrat);
            e.Graphics.FillRectangle(culoare, patrat);
            chenar.Dispose();
        }
        private void Jocul_Paint(object sender, PaintEventArgs e)
        {
            deseneazaSpatiulJoc(e);
            deseneazaSpatiulOcupat(e);
            deseneazaForma(e);
        }
        #endregion
        public string? formaAleatorie()
        {
            var rand = new Random();
            int r = rand.Next(7);
            switch (r)
            {
                case 0:
                    return "patrat";
                case 1:
                    return "bagheta";
                case 2:
                    return "T";
                case 3:
                    return "L";
                case 4:
                    return "J";
                case 5:
                    return "S";
                case 6:
                    return "Z";
                default:
                    return null;
            }
        }

        #region tasta si ceas
        private void Jocul_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Space:
                case Keys.Right:
                case Keys.Left:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void Jocul_KeyDown(object sender, KeyEventArgs e)
        {

            FormaCurenta propusa = forma;
            switch (e.KeyCode)
            {
                    case Keys.Up:
                        propusa.config += 1;
                        if (!iesitMargine(propusa) && !ajunsJos(propusa))
                        {
                            forma.config += 1;
                            this.Refresh();
                        }
                        break;
                    case Keys.Left:
                        propusa.col -= 1;
                        if (!iesitMargine(propusa) && !ajunsJos(propusa))
                        {
                            forma.col -= 1;
                            this.Refresh();
                        }
                        break;
                    case Keys.Right:
                        propusa.col += 1;
                        if (!iesitMargine(propusa) && !ajunsJos(propusa))
                        {
                            forma.col += 1;
                            this.Refresh();
                        }
                        break;
                    case Keys.Down:
                        propusa.rand += 1;
                        if (!iesitMargine(propusa) && !ajunsJos(propusa))
                        {
                            forma.rand += 1;
                            this.Refresh();
                        }
                        break;
                    case Keys.Space:
                        break;
              }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FormaCurenta propusa = forma;
            propusa.rand += 1;
            if (ajunsJos(propusa))
            {
                adaugaLaOcupat();
                linieCompleta();
                forma.rand = 0;
                forma.col = 4;
                forma.config = 0;
                forma.tipForma = formaAleatorie();
                this.Refresh();
                if (ajunsJos(forma))
                {
                    timer1.Enabled = false;
                    pictureBox1.Show();
                    int xpCastigat = Convert.ToInt32(Scor.Text) * 2/10;
                    Program.contActual.xp += xpCastigat;
                    Program.listaConturi.conturi[Program.contActual.id] = Program.contActual;
                    System.IO.File.WriteAllText(@"..\\..\\..\\Resources\\Conturi.txt", JsonSerializer.Serialize(Program.listaConturi));
                    MessageBox.Show($"Jocul s-a terminat. Ai castigat {xpCastigat} XP!");
                    ScoruriTop st = new ScoruriTop(Scor.Text);
                    st.Show();
                    this.Close();
                }
            }
            else
                if (!iesitMargine(propusa))
            {
                forma.rand += 1;
                this.Refresh();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            var rand = new Random();
            int r = rand.Next(reclamele.Length);
            string s = reclamele[r];
            reclame.Image = Image.FromFile(s);
        }
        #endregion

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            label2.BackColor = Color.Black;
            label2.ForeColor = Color.White;
            Meniu m = new Meniu();
            this.Close();
            m.Show();
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            spatiulOcupat.Clear();
            Bomba.Visible = false;
            Program.contActual.produseCumparate.Remove(7);
            Program.listaConturi.conturi[Program.contActual.id] = Program.contActual;
            System.IO.File.WriteAllText(@"..\\..\\..\\Resources\\Conturi.txt", JsonSerializer.Serialize(Program.listaConturi));

        }

        private void LaComanda_Click(object sender, EventArgs e)
        {
            forma.rand = 0;
            forma.col = 4;
            forma.config = 0;
            forma.tipForma = "bagheta";
            LaComanda.Visible = false;
            Program.contActual.produseCumparate.Remove(8);
            Program.listaConturi.conturi[Program.contActual.id] = Program.contActual;
            System.IO.File.WriteAllText(@"..\\..\\..\\Resources\\Conturi.txt", JsonSerializer.Serialize(Program.listaConturi));
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            forma.rand = 0;
            forma.col = 4;
            forma.config = 0;
            forma.tipForma = formaAleatorie();
            Skip.Visible = false;
            Program.contActual.produseCumparate.Remove(9);
            Program.listaConturi.conturi[Program.contActual.id] = Program.contActual;
            System.IO.File.WriteAllText(@"..\\..\\..\\Resources\\Conturi.txt", JsonSerializer.Serialize(Program.listaConturi));
        }
        private void EliminaRand_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            for (int i = 0; i < spatiulOcupat.Count; i++)
            {
                if (spatiulOcupat[i].rand == 19)
                {
                    spatiulOcupat.RemoveAt(i);
                    i--;
                }
                else
                {
                    Punct inlocuire = new Punct(spatiulOcupat[i].rand+1, spatiulOcupat[i].col, spatiulOcupat[i].culoare);
                    spatiulOcupat[i] = inlocuire;
                }
            }
            timer1.Enabled = true;
            EliminaRand.Visible = false;
            Program.contActual.produseCumparate.Remove(10);
            Program.listaConturi.conturi[Program.contActual.id] = Program.contActual;
            System.IO.File.WriteAllText(@"..\\..\\..\\Resources\\Conturi.txt", JsonSerializer.Serialize(Program.listaConturi));
        }
        private void Laser_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            int colLaserat = forma.col;

            for (int i = 0; i < spatiulOcupat.Count; i++)
            {
                if (spatiulOcupat[i].col == colLaserat)
                {
                    spatiulOcupat.RemoveAt(i);
                    i--;
                }
            }
            timer1.Enabled = true;
            Laser.Visible = false;
            Program.contActual.produseCumparate.Remove(11);
            Program.listaConturi.conturi[Program.contActual.id] = Program.contActual;
            System.IO.File.WriteAllText(@"..\\..\\..\\Resources\\Conturi.txt", JsonSerializer.Serialize(Program.listaConturi));

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
          }

    }
}

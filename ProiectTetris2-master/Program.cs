namespace ProiectTetris2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 


        public static Conturi listaConturi;
        public class Conturi
        {
            public List<Cont> conturi { get; set; }
        }
        public class Cont
        {
            public int id { get; set; }
            public string username { get; set; }
            public string parola { get; set; }
            public int pozaProfil { get; set; }
            public int bani { get; set; }
            public int xp { get; set; }
            public List <int> produseCumparate { get; set; }
        }

        public class Produs
        {
            int prodID { get; set; }
            public string numeProdus { get; set; }
            public string pozaProdus { get; set; }
            public int pretBani { get; set; }
            public int pretXP { get; set; }
        }

        public class Produse
        {
            public List<Produs> produse { get; set; }
        }

        public static Produse listaProduselor;

        public static Cont contActual;
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
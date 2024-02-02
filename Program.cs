namespace back_end_s1_l05
{
    public class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public char Sesso { get; set; }
        public string ComuneResidenza { get; set; }
        public double RedditoAnnuale { get; set; }

        public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, char sesso, string comuneResidenza, double redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }

        public double CalcolaImposta()
        {
            double imposta = 0;

            if (RedditoAnnuale <= 15000)
            {
                imposta = RedditoAnnuale * 0.23;
            }
            else if (RedditoAnnuale <= 28000)
            {
                imposta = 3450 + (RedditoAnnuale - 15000) * 0.27;
            }
            else if (RedditoAnnuale <= 55000)
            {
                imposta = 6960 + (RedditoAnnuale - 28000) * 0.38;
            }
            else if (RedditoAnnuale <= 75000)
            {
                imposta = 17220 + (RedditoAnnuale - 55000) * 0.41;
            }
            else
            {
                imposta = 25420 + (RedditoAnnuale - 75000) * 0.43;
            }

            return imposta;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci i dati del contribuente:");
            Console.WriteLine("=====================================");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();
            Console.Write("Data di nascita (YYYY-MM-DD): ");
            DateTime dataNascita = DateTime.Parse(Console.ReadLine());
            Console.Write("Codice Fiscale: ");
            string codiceFiscale = Console.ReadLine().ToUpper();
            Console.Write("Sesso (M/F): ");
            char sesso = char.Parse(Console.ReadLine().ToUpper());
            Console.Write("Comune di residenza: ");
            string comuneResidenza = Console.ReadLine();
            Console.Write("Reddito annuale: ");
            double redditoAnnuale = double.Parse(Console.ReadLine());
            Console.WriteLine("=====================================");
            Console.Clear();

            nome = char.ToUpper(nome[0]) + nome.Substring(1).ToLower();
            cognome = char.ToUpper(cognome[0]) + cognome.Substring(1).ToLower();
            comuneResidenza = char.ToUpper(comuneResidenza[0]) + comuneResidenza.Substring(1).ToLower();

            Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);

            double imposta = contribuente.CalcolaImposta();

            Console.WriteLine("\nCALCOLO DELL'IMPOSTA DA VERSARE:");
            Console.WriteLine($"Contribuente: {contribuente.Nome} {contribuente.Cognome}");
            Console.WriteLine($"Data di nascita: {contribuente.DataNascita.ToString("dd/MM/yyyy")} || Sesso: {contribuente.Sesso}");
            Console.WriteLine($"Residente in: {contribuente.ComuneResidenza}");
            Console.WriteLine($"codice fiscale: {contribuente.CodiceFiscale}");
            Console.WriteLine($"Reddito dichiarato: {contribuente.RedditoAnnuale:N2}");

            
            if (redditoAnnuale <= 15000)
            {
                Console.WriteLine("ALIQUOTA: 23%");
            }
            else if (redditoAnnuale <= 28000)
            {
                Console.WriteLine("ALIQUOTA: 27%");
            }
            else if (redditoAnnuale <= 55000)
            {
                Console.WriteLine("ALIQUOTA: 38%");
            }
            else if (redditoAnnuale <= 75000)
            {
                Console.WriteLine("ALIQUOTA: 41%");
            }
            else
            {
                Console.WriteLine("ALIQUOTA: 43%");
            }

            Console.WriteLine($"IMPOSTA DA VERSARE: {imposta:N2}");
        }
    }
}

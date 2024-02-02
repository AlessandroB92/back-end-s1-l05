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
            do
            {
                Console.Clear();
                Console.WriteLine("Inserisci i dati del contribuente:");
                Console.WriteLine("=====================================");
                Console.WriteLine();
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Cognome: ");
                string cognome = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Data di nascita (YYYY-MM-DD): ");
                DateTime dataNascita;
                while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dataNascita))
                {
                    Console.WriteLine("=====================================");
                    Console.WriteLine();
                    Console.WriteLine("Inserisci un input valido.");
                    Console.WriteLine("=====================================");
                    Console.WriteLine();
                    Console.Write("Data di nascita (YYYY-MM-DD): ");
                }
                Console.WriteLine();
                Console.Write("Codice Fiscale: ");
                string codiceFiscale = Console.ReadLine().ToUpper();
                Console.WriteLine();
                Console.Write("Sesso (M/F): ");
                char sesso;
                while (!char.TryParse(Console.ReadLine().ToUpper(), out sesso) || (sesso != 'M' && sesso != 'F'))
                {
                    Console.WriteLine("=====================================");
                    Console.WriteLine("Inserisci un input valido.");
                    Console.WriteLine("=====================================");
                    Console.Write("Sesso (M/F): ");
                }
                Console.WriteLine();
                Console.Write("Comune di residenza: ");
                string comuneResidenza = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Reddito annuale: ");
                double redditoAnnuale;
                while (!double.TryParse(Console.ReadLine(), out redditoAnnuale) || redditoAnnuale < 0)
                {
                    Console.WriteLine("=====================================");
                    Console.WriteLine("Inserisci un input valido.");
                    Console.WriteLine("=====================================");
                    Console.Write("Reddito annuale: ");
                }
                Console.WriteLine("=====================================");
                Console.Clear();

                nome = char.ToUpper(nome[0]) + nome.Substring(1).ToLower();
                cognome = char.ToUpper(cognome[0]) + cognome.Substring(1).ToLower();
                comuneResidenza = char.ToUpper(comuneResidenza[0]) + comuneResidenza.Substring(1).ToLower();

                Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);

                double imposta = contribuente.CalcolaImposta();

                Console.WriteLine("\nCALCOLO DELL'IMPOSTA DA VERSARE:");
                Console.WriteLine("=====================================");
                Console.WriteLine($"Contribuente: {contribuente.Nome} {contribuente.Cognome}");
                Console.WriteLine();
                Console.WriteLine($"Data di nascita: {contribuente.DataNascita.ToString("dd/MM/yyyy")} || Sesso: {contribuente.Sesso}");
                Console.WriteLine();
                Console.WriteLine($"Residente in: {contribuente.ComuneResidenza}");
                Console.WriteLine();
                Console.WriteLine($"codice fiscale: {contribuente.CodiceFiscale}");
                Console.WriteLine();
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
                Console.WriteLine();
                Console.WriteLine($"IMPOSTA DA VERSARE: {imposta:N2}");

                Console.WriteLine("\nScegli un'operazione:");
                Console.WriteLine("=====================================");
                Console.WriteLine();
                Console.WriteLine("1) Calcola imposte");
                Console.WriteLine();
                Console.WriteLine("2) Esci");

                int scelta;
                while (!int.TryParse(Console.ReadLine(), out scelta) || (scelta != 1 && scelta != 2))
                {
                    Console.WriteLine("Input non valido. Scegli 1 per Calcola imposte o 2 per Esci.");
                }

                if (scelta == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Grazie per aver utilizzato il servizio!");
                    break;
                }
            } while (true);

        }
    }
}


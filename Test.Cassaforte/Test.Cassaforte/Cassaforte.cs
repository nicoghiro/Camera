using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaforteMain
{
    public class Cassaforte
    {
        // Numero di matricola della cassaforte
        public int NumeroMatricola { get; set; }

        // Produttore della cassaforte
        public string Produttore { get; set; }

        // Modello della cassaforte
        public string Modello { get; set; }

        // Codice di sblocco segreto della cassaforte
        public string CodiceSblocco { get; set; }

        // Codice utente impostato per aprire la cassaforte
        public string CodiceUtente { get; set; }

        // Data per l'apertura programmata della cassaforte
        public DateTime DataProgrammata { get; set; }

        // Conteggio delle aperture effettuate con successo dalla creazione della cassaforte
        public int ApertureEffettuate { get; set; }

        // Conteggio delle aperture tentate dalla creazione della cassaforte
        public int ApertureTentate { get; set; }

        // Var per verificare se la cassaforte è bloccata
        public bool Bloccata { get; set; }

        // Var per verificare lo stato di apertura 
        public bool Stato { get; set; }

        // Data corrente
        public DateTime DataCorrente { get; set; }

        // Numero di tentativi di apertura di fila falliti
        public int TentativiFalliti { get; set; }

        // Costruttore della cassaforte
        public Cassaforte(int numeroMatricola, string produttore, string modello, string codiceSblocco, bool stato)
        {
            NumeroMatricola = numeroMatricola;
            Produttore = produttore;
            Modello = modello;
            CodiceSblocco = codiceSblocco = "752Gj4j50oM1";
            ApertureEffettuate = 0;
            DataCorrente = DateTime.Now;
            ApertureTentate = 0;
            Bloccata = false;
            Stato = stato;//=false
            //l'errore era qui , veniva automaicamente messo false
        }

        public Cassaforte() : this(0, null, null, null, false)
        {
        }

        // Imposta il codice utente per aprire la cassaforte
        public void ImpostaCodiceUtente(string codiceUtente)
        {
            CodiceUtente = codiceUtente;
        }

        // Apre la cassaforte se il codice utente corrisponde a quello impostato
        public void Apri(string codiceUtente)
        {
            ApertureTentate++;

            if (Bloccata == true)
            {
                throw new Exception("Cassaforte bloccata, non è possibile aprire.");

            }

            if (CodiceUtente == codiceUtente)
            {
                ApertureEffettuate++;



                Stato = true;
            }
            else
            {
                TentativiFalliti = ApertureTentate - ApertureEffettuate;

                if (TentativiFalliti >= 5)
                {
                    Bloccata = true;
                    TentativiFalliti = 0;
                    throw new Exception("Cassaforte bloccata dopo 5 tentativi di apertura falliti.");

                }
            }
        }
        public void Chiudi()
        {
            if (Stato == true)
            {
                Stato = false;
            }
            else
            {
                Console.WriteLine("Cassaforte già aperta.");
            }
        }
        public void Sblocca(string codiceSblocco)
        {
            // Confronta i due codici
            if (codiceSblocco == CodiceSblocco)
            {
                Stato = true;
            }
            else
                throw new Exception("Codice di sblocco errato.");
        }
        public void GeneraCod(string codiceUtente)
        {
            Random random = new Random();

            // Genera cinque numeri casuali e aggiungili al codice

            for (int i = 0; i < 5; i++)
            {
                codiceUtente += random.Next(10);
            }
            ImpostaCodiceUtente(codiceUtente);

        }
        public void ImpostaData(DateTime data)
        {
            DataProgrammata = data;
        }

        // Metodo per aprire la cassaforte
        public bool AperturaProgrammata(string codiceUtente)
        {
            // Se il numero di tentativi di apertura di fila falliti è maggiore o uguale a 5, la cassaforte è bloccata
            if (TentativiFalliti >= 5)
            {
                Bloccata = true;
                return false;
            }

            // Se la data corrente non corrisponde a quella impostata per l'apertura programmata, l'apertura viene rifiutata
            if (DataCorrente != DataProgrammata)
            {
                TentativiFalliti++;
                return false;
            }

            // Se il codice utente non corrisponde a quello di sblocco, l'apertura viene rifiutata
            if (codiceUtente != CodiceSblocco)
            {
                TentativiFalliti++;
                return false;
            }

            // Se siamo arrivati qui, vuol dire che l'apertura è stata effettuata con successo
            TentativiFalliti = 0;
            return true;
        }

        public Cassaforte(Cassaforte a) : this(a.NumeroMatricola, a.Produttore, a.Modello, a.CodiceSblocco, a.Stato)
        {

        }
        public Cassaforte Clone()
        {
            return new Cassaforte(this);
        }
        public string Stringa()
        {
            return Convert.ToString("Numero matricola: " + this.NumeroMatricola + "Produttore: " + this.Produttore + "Modello: " + this.Modello + "Codice Sblocco: " + this.CodiceSblocco);
        }
    }
}

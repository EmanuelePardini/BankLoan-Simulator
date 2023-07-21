using System;
using Prestiti;
using System.Collections.Generic;
using System.Linq;
namespace Banca_Ema_Par
{
    class Program
    {
        protected static Cliente[] DefinizioneClienti()
        {
            int nClienti;
            string nome, cognome, codFisc;
            float stipendio;
            Console.WriteLine("Quanti clienti ha la banca?");
            nClienti = Convert.ToInt32(Console.ReadLine());
            Cliente[] clienti = new Cliente[nClienti];
            for (int i = 0; i < nClienti; i++)
            {
                Console.WriteLine("Inserire nome, cognome, codice fiscale e stipendio " + i + " cliente:");
                nome = Console.ReadLine();
                cognome = Console.ReadLine();
                codFisc = Console.ReadLine();
                stipendio = float.Parse(Console.ReadLine());
                clienti[i] = new Cliente(nome, cognome, codFisc, stipendio);
            }
            return clienti;
        }

        protected static Banca DefinizioneBanca(Cliente[] clienti)
        {

            string nomeBanca;
            Console.WriteLine("Inserire il nome della banca:");
            nomeBanca = Console.ReadLine();
            
            Banca banca = new Banca(clienti, nomeBanca);
            return banca;
        }
        protected static List<Prestito> ConcediPrestiti(Banca banca, Cliente[] clienti)
        {
            DateTime DataInizio, DataFine;
            float Ammontare, Rata;
            char check = 'y';
            int codCliente;
            List<Prestito> prestito = new List<Prestito>();
            while (check != 'n')
            {
                Console.WriteLine("Inserire il codice Cliente, la data di inizio, data di fine, l'ammontare e la rata del prestito ");
                codCliente=Convert.ToInt32(Console.ReadLine());
                DataInizio = Convert.ToDateTime(Console.ReadLine());
                DataFine = Convert.ToDateTime(Console.ReadLine());
                Ammontare = float.Parse(Console.ReadLine());
                Rata = float.Parse(Console.ReadLine());
                Prestito p = new Prestito(banca, clienti[codCliente], DataInizio, DataFine, Ammontare, Rata);
                prestito.Add(p);
                Console.WriteLine("Aggiungere altri prestiti?(y/n)");
            }
           
            return prestito;
        }
        protected static void StampaPrestiti(List<Prestito> prestiti)
        {
            Console.WriteLine("Trovati " + prestiti.Count + " prestiti");
            for (int i = 0; i < prestiti.Count; i++)
            {
                Console.WriteLine("Il prestito è concesso a " + prestiti[i]._cliente._codFisc + " in data" + prestiti[i]._DataInizio+" ammonta a" +prestiti[i]._ammontare);
            }
            Console.WriteLine("");
        }
        protected static List<Prestito> Ricercaprestiti(List<Prestito> prestiti)
        {
            Console.WriteLine("Inserire codice fiscale del cliente per visualizzare i prestiti");
            string codFisc = Console.ReadLine();
            List<Prestito> prestiticliente = prestiti.Where(x => x._cliente._codFisc==codFisc).ToList();
            return prestiticliente;
        }
        protected static float Ammontareprestiti(List<Prestito> prestiti)
        {
            Console.WriteLine("Inserire codice fiscale del cliente per visualizzare l'ammontare dei prestiti");
            string codFisc = Console.ReadLine();
            float prestiticliente = prestiti.Where(p => p._cliente._codFisc == codFisc).Sum(x => x._ammontare);
            Console.WriteLine("La somma dei prestiti  del cliente è: " + prestiticliente);
            return prestiticliente;
        }
        protected static void CatturaErrori(Cliente[] clienti, Banca banca, List<Prestito> prestiti)
        {
            for(int i = 0; i < clienti.Length; i++)
            {
                if (clienti[i]._nome==null )
                {
                    throw new Exception("Mancante Nome");
                }
                if (clienti[i]._cognome == null)
                {
                    throw new Exception("Mancante Cognome");
                }
                if (clienti[i]._codFisc == null  || clienti[i]._codFisc.Length!=16)
                {
                    throw new Exception("Codice fiscale invalido");
                }
                if (clienti[i]._stipendio == null || clienti[i]._stipendio < 200)
                {
                    throw new Exception("Stipendio invalido");
                }

            }
            if (banca == null)
            {
                throw new Exception("Mancante nome della banca");
            }
            for (int i = 0; i < prestiti.Count; i++)
            {
                if (prestiti[i]._ammontare < 1000)
                {
                    throw new Exception("Ammontare invalido");
                }
                if (prestiti[i]._rata < 50 || prestiti[i]._ammontare < prestiti[i]._rata)
                {
                    throw new Exception("Rata invalida");
                }

            }

        }



        static void Main(string[] args)
        {
            try
            {
                Cliente[] clienti = DefinizioneClienti();
                Banca banca = DefinizioneBanca(clienti);
                List<Prestito> prestiti = ConcediPrestiti(banca, clienti);
                StampaPrestiti(prestiti);
                List<Prestito> prestitiCliente = Ricercaprestiti(prestiti);
                StampaPrestiti(prestitiCliente);
                float sommaPrestitiCliente = Ammontareprestiti(prestiti);
                CatturaErrori(clienti,banca,prestiti);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore generico: " + ex);
            }
            finally
            {
                Console.WriteLine("Sto rilasciando eventuali risorse...");
            }
        }
    }
}

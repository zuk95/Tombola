using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Tombola.Business
{
    public class PartitaRete : AbstractPartita
    {
        

        public override void GiocaPartita()
        {
            Console.WriteLine("PARTITA INIZIATA");

            bool tombola = false;

            while (tombola == false)
            {
                Console.WriteLine($"NUMERI ESTRATTI: {Tabellone.GetCountNumeriEstratti()}");
                Console.WriteLine("Sto per estrarre il prossimo numero...");
                Thread.Sleep(2500);

                int numeroEstratto = Tabellone.EstraiNumero();
                Console.WriteLine($"Il numero estratto è {numeroEstratto}");

                foreach (GiocatoreRete giocatore in Partecipanti)
                {
                    //se ritorna vero il giocatore in questione ha fatto tombola
                    if (giocatore.GiocaTurno(numeroEstratto))
                    {
                        Console.WriteLine($"TOMBOLA! Vincitore: {giocatore.Nome}");
                        tombola = true;
                    }

                }

            }

            Console.WriteLine($"TOTALE NUMERI ESTRATTI: {Tabellone.GetCountNumeriEstratti()}");
            Console.WriteLine("FINE PARTITA");

        }

    }
}

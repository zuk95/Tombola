using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tombola.Business
{
    public class Tabellone
    {
        public Dictionary<int, bool> Numeri { get; set; } = new Dictionary<int, bool>();

        public Tabellone()
        {
            InizializzaTabellone();
        }

        void InizializzaTabellone()
        {
            for(int i = RegoleTombola.LIMITE_MINIMO_NUMERO_TOMBOLA; i <= RegoleTombola.LIMITE_MASSIMO_NUMERO_TOMBOLA; i++)
            {
                this.Numeri.Add(i, false);
            }
        }

        public int EstraiNumero()
        {
            List<int> numeriNonUsciti = Numeri.Where(x => x.Value == false).Select(y => y.Key).ToList();

            Random random = new Random();

            int numeroEstratto = numeriNonUsciti.ElementAt(random.Next(0, numeriNonUsciti.Count - 1));
            Numeri[numeroEstratto] = true;

            return numeroEstratto;
        }

        public int GetCountNumeriEstratti()
        {
            return Numeri.Where(x => x.Value == true).ToList().Count;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Tombola.Business
{
    public class Cartella
    {
        public Dictionary<int, bool> NumeriCartella { get; private set; } = new Dictionary<int, bool>();

        public Cartella()
        {
            InizializzaCartella();
        }

        public bool IsTombola()
        {
            foreach(bool segnato in NumeriCartella.Values)
            {
                if(segnato == false)
                {
                    return false;
                }
            }

            return true;
        }

        void InizializzaCartella()
        {

            while(this.NumeriCartella.Count < RegoleTombola.MAX_NUMERI_CARTELLA)
            {

                int numeroGenerato = RegoleTombola.EstraiNumero();

                if (this.NumeriCartella.ContainsKey(numeroGenerato))
                {
                    ;
                }
                else
                {
                    this.NumeriCartella.Add(numeroGenerato, false);
                }

            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Tombola.Business
{
     public abstract class AbstractGiocatore
    {
        public string Nome { get; set; }
        public Cartella Cartella { get; set; }

        public AbstractGiocatore(string nome)
        {
            Nome = nome;
            Cartella = new Cartella();
        }

        public abstract bool GiocaTurno(int numero);


        protected void SegnaNumero(int numero)
        {

            if (Cartella.NumeriCartella.ContainsKey(numero))
            {
                Cartella.NumeriCartella[numero] = true;
            }

        }

        protected bool IsTombola()
        {
            return Cartella.IsTombola();
        }
    }
}

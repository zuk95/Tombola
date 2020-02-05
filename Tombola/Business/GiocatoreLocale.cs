using System;
using System.Collections.Generic;
using System.Text;

namespace Tombola.Business
{
    public class GiocatoreLocale : AbstractGiocatore
    {

        public GiocatoreLocale(string nome) : base(nome)
        {
            Nome = nome;
            Cartella = new Cartella();
        }

        public override bool GiocaTurno(int numero)
        {
            SegnaNumero(numero);

            return IsTombola();
        }

    }
}

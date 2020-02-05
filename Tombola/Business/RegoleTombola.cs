using System;
using System.Collections.Generic;
using System.Text;

namespace Tombola.Business
{
    public static class RegoleTombola
    {
        public static readonly int LIMITE_MINIMO_NUMERO_TOMBOLA = 1;
        public static readonly int LIMITE_MASSIMO_NUMERO_TOMBOLA = 90;
        public static readonly int MAX_NUMERI_CARTELLA = 15;

        public static int EstraiNumero()
        {
            Random randomNumber = new Random();
            return randomNumber.Next(RegoleTombola.LIMITE_MINIMO_NUMERO_TOMBOLA, RegoleTombola.LIMITE_MASSIMO_NUMERO_TOMBOLA);
        }
    }
}

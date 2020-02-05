using System;
using System.Collections.Generic;
using System.Text;

namespace Tombola.Business
{
    public abstract class AbstractPartita
    {
        public Tabellone Tabellone { get; set; } = new Tabellone();

        public List<AbstractGiocatore> Partecipanti { get; set; } = new List<AbstractGiocatore>();

        public abstract void GiocaPartita();
    }
}

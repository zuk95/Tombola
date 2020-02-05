using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tombola.Business
{
    public class GiocatoreRete : AbstractGiocatore
    {
        private TcpClient client;

        public GiocatoreRete(string nome,string indirizzoIp,int porta) : base(nome)
        {
            Nome = nome;
            Cartella = new Cartella();

            IPEndPoint endPointServer = new IPEndPoint(IPAddress.Parse(indirizzoIp), porta);

            client = new TcpClient(endPointServer);
        }

        public override bool GiocaTurno(int numero)
        {
            throw new NotImplementedException();
        }
    }
}

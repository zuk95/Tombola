using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Tombola;
using Tombola.Business;

namespace TombolaServer
{
    public class Server
    {
        PartitaLocale partita;
        TcpListener server;

        public List<GiocatoreLocale> giocatoriConnessi;

        public Server(string ipAdress, int porta)
        {
            giocatoriConnessi = new List<GiocatoreLocale>();

            IPAddress localAddress = IPAddress.Parse(ipAdress);
            server = new TcpListener(localAddress, porta);
            StartServer();
        }

        void StartServer()
        {
            try
            {
                server.Start();

                while (true)
                {
                    Console.WriteLine("In attesa di giocatori per iniziare la partita...");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Si è connesso un giocatore!");

                    Thread t = new Thread(new ParameterizedThreadStart(GestisciConnessione));
                    t.Start(client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                server.Stop();
            }
        }

        /// <summary>
        /// Metodo usato dai thread dei client creati dal server
        /// </summary>
        /// <param name="obj">il client che si è connesso</param>
        void GestisciConnessione(Object obj)
        {
            TcpClient client = (TcpClient)obj;

            byte[] bufferRead = new byte[1024];
            client.GetStream().Read(bufferRead, 0, bufferRead.Length);

            string nomeGiocatoreRicevuto = Encoding.ASCII.GetString(bufferRead);
            giocatoriConnessi.Add(new GiocatoreLocale(nomeGiocatoreRicevuto));

            try
            {
                int i = 0;
                while (client.Connected)
                {
                    //aspetto richiesta di aggiornamento e poi gli invio il json associato al giocatore
                    Console.WriteLine($"Ciao{i}");

                    //string jsonGiocatore = JsonConvert.SerializeObject(giocatoriConnessi.Find(x => x.Nome == "Ale"));
                    string messaggio = $"Ciao{i}";
                    byte[] bufferGiocatore = Encoding.ASCII.GetBytes(messaggio);

                    //Invio dati al client
                    client.GetStream().Write(bufferGiocatore, 0, bufferGiocatore.Length);

                    i++;
                    //Invio i dati ogni 2 secondi
                    Thread.Sleep(1000);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                client.Close();
            }
        }

    }
}

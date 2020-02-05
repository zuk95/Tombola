using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Tombola.Business;

namespace ClientTombola
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public Tabellone TabellonePartita { get; set; }
        public GiocatoreLocale Giocatore { get; set; }
        public ICommand PartecipaCommand { get; set; }

        private string stringa = string.Empty;
        public string Stringa { get { return stringa; } set { if (value != stringa) stringa = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Stringa"));  } }

        TcpClient client;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowVM()
        {
            PartecipaCommand = new RelayCommand(Partecipa);

            client = new TcpClient(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2222));
        }

        void Partecipa()
        {
            string nomeGiocatore = "Ale";

            try
            {
                client.Connect(IPAddress.Parse("127.0.0.1"), 3333);

                NetworkStream stream = client.GetStream();

                // Translate the Message into ASCII.
                byte[] data = new byte[1024];
                data = Encoding.ASCII.GetBytes(nomeGiocatore);
                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                Thread t = new Thread(new ParameterizedThreadStart(RiceviAggiornamento));
                t.Start(client);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }

        void RiceviAggiornamento(object obj)
        {
            TcpClient client = (TcpClient)obj;

            while (true)
            {
                // Bytes Array to receive Server Response.
                byte[] data = new byte[256];
                String response = String.Empty;
                // Read the Tcp Server Response Bytes.
                int bytes = client.GetStream().Read(data, 0, data.Length);
                response = Encoding.ASCII.GetString(data, 0, bytes);

                //Giocatore = JsonConvert.DeserializeObject<GiocatoreLocale>(response);
                Stringa = response;
            }
        }

    }
}

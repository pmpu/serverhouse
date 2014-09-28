using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System;
namespace Chat
{
    class Server
    {
        public TcpListener Listener; // Объект, принимающий TCP-клиентов
        public List<ClientInfo> clients = new List<ClientInfo>();
        public List<ClientInfo> NewClients = new List<ClientInfo>();
        public static Server server;
        static System.IO.TextWriter Out;
        public List<byte> MessageHistory = new List<byte>();//история сообщений

        public Server(int Port, System.IO.TextWriter _Out)
        {
            Out = _Out;
            Server.server = this;
            string Hello =" Welcome to chat!";
            foreach (char ch in Hello)
                MessageHistory.Add(Convert.ToByte(ch));
            MessageHistory.Add(Convert.ToByte('\n'));

            // Создаем "слушателя" для указанного порта
            Listener = new TcpListener(IPAddress.Any/**/, Port);
            Listener.Start();
        }

        public void Work()
        {
            Thread clientListener = new Thread(ListnerClients);
            clientListener.Start();
            while (true)
            {
                byte[] history = MessageHistory.ToArray();

                foreach (ClientInfo client in clients)
                {
                    if (client.IsConnect)
                    {
                        NetworkStream stream = client.Client.GetStream();//создаём поток ввода/вывода
                        if (!client.IsTheWholeSession)//если клент только зашёл
                        {
                            client.IsTheWholeSession = true;
                            client.Client.GetStream().Write(history, 0, history.Length);
                        }
                        while (stream.DataAvailable)
                        {
                            int ReadByte = stream.ReadByte();
                            if (ReadByte != -1)
                            {
                                client.buffer.Add((byte)ReadByte);
                            }
                        }
                        if (client.buffer.Count > 0)//если пользователь что-то прислал
                        {
                            Out.WriteLine("Resend");
                            foreach (ClientInfo otherClient in clients)
                            {
                                byte[] msg = client.buffer.ToArray();

                                    MessageHistory.AddRange(msg);//Записали в историю.
                                    MessageHistory.Add((byte)'\n');

                                client.buffer.Clear();//очищаем буфер клиента
                                foreach (ClientInfo _otherClient in clients)
                                {
                                    if (_otherClient != client)
                                    {
                                        try
                                        {
                                            _otherClient.Client.GetStream().Write(msg, 0, msg.Length);
                                            
                                        }
                                        catch
                                        {
                                            _otherClient.IsConnect = false;//то клиент вышел из сети
                                            _otherClient.Client.Close();//закрываем соединение
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
                clients.RemoveAll(delegate(ClientInfo CI)
                {//передаём анонимный метод
                    if (!CI.IsConnect)
                    {
                        Server.Out.WriteLine("Client disconect");
                        return true;

                    }
                    return false;
                });

                if (NewClients.Count > 0)//если появились новые клиенты
                {
                    clients.AddRange(NewClients);
                    NewClients.Clear();
                }
            }

        }

        // Остановка сервера
        ~Server()
        {
            // Если "слушатель" был создан
            if (Listener != null)
            {
                // Остановим его
                Listener.Stop();
            }
            foreach (ClientInfo client in clients)
            {
                client.Client.Close();
            }
        }

        static void ListnerClients()
        {
            while (true)
            {
                server.NewClients.Add(new ClientInfo(server.Listener.AcceptTcpClient()));
                Out.WriteLine("New Client");
            }
        }
    }


    class ClientInfo
    {
        public TcpClient Client;
        public List<byte> buffer = new List<byte>();
        public bool IsConnect;
        public bool IsTheWholeSession;
        public ClientInfo(TcpClient Client)
        {
            this.Client = Client;
            IsConnect = true;
            IsTheWholeSession = false;
        }
    }
}
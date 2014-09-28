using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

class Client
{
    static TcpClient client;//т.к статический, то в одном приложении не может быть два чата
    static bool IsRunClient;

    public Client(int Port, string connectIp)
    {
        IsRunClient = true;

        client = new TcpClient();
        client.Connect(IPAddress.Parse(connectIp), Port);//соединяемся с сервером
    }

    public void Work()
    {
        Thread clientListener = new Thread(Reader);
        clientListener.Start();
    }

    public void SendMessage(string message)
    {
        message.Trim();
        byte[] Buffer = Encoding.ASCII.GetBytes((message).ToCharArray());
        client.GetStream().Write(Buffer, 0, Buffer.Length);
        Chat.message.Add(message);
    }

    static void Reader()
    {
        while (IsRunClient)
        {
            NetworkStream NS = client.GetStream();
            List<byte> Buffer = new List<byte>();
            while (NS.DataAvailable)
            {
                int ReadByte = NS.ReadByte();
                if (ReadByte > -1)
                {
                    Buffer.Add((byte)ReadByte);
                }
            }
            if (Buffer.Count > 0)
                Chat.message.Add(Encoding.ASCII.GetString(Buffer.ToArray()));
        }
    }
    public void Destruct()
    {
        IsRunClient = false;

        if (client != null)
            client.Close();
    }
}

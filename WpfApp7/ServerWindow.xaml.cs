using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp7
{
    public partial class ServerWindow : Window
    {
        private Socket socket;
        private List<Socket> clients = new List<Socket>();
        DateTimeOffset currentTime = DateTimeOffset.Now;

        public ServerWindow()
        {
            InitializeComponent();
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipPoint);
            socket.Listen(1000);
            ListenToClients();
        }
        private async Task ListenToClients()
        {
            while (true)
            {
                var client = await socket.AcceptAsync();
                clients.Add(client);
                RecieveMessage(client);
            }
        }
        public async Task RecieveMessage(Socket client)
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                
                MessageList.Items.Add($" {currentTime.ToString("yyyy-MM-dd HH:mm:ss")} [Сообщение от {client.RemoteEndPoint}]: {message}");

                foreach (var item in clients)
                {
                    SendMessage(item, message);
                }
            }
        }
        private async Task SendMessage(Socket client, string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await client.SendAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
        }

        
    }
}

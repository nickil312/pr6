﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private Socket server;
        DateTimeOffset currentTime = DateTimeOffset.Now;
        public UserWindow()
        {
            InitializeComponent();
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.ConnectAsync("127.0.0.1", 8888);
            RecieveMessage();

        }
        private async Task RecieveMessage()
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await server.ReceiveAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                /*if(message == "/disconnect")
                {
                    MainWindow window = new MainWindow();
                    window.Show();
                    this.Close();
                    
                /*}
                else
                {*/
                Chat.Items.Add($"{currentTime.ToString("yyyy-MM-dd HH:mm:ss")}: {message}");

                /*}*/
                
            }
        }
        private async Task SendMessage(string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await server.SendAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
        }

        private void SendMessageByUser_Click(object sender, RoutedEventArgs e)
        {
            SendMessage(MessageBOX.Text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Create_chat_Click(object sender, RoutedEventArgs e)
        {
            if (Nickname.Text == "")
            {
                MessageBox.Show("Полу с именем пустое");
                return;
            }
            else
            {
                ServerWindow ban = new ServerWindow();
                ban.Show();
                this.Close();
            }

        }

        private void Go_In_Click(object sender, RoutedEventArgs e)
        {
            if (Nickname.Text == "" || IPADress.Text == "")
            {
                MessageBox.Show("Поля с данными пустые");
                return;
            }
            else if (IPADress.Text == "")
            {
                MessageBox.Show("Поле с адресом пустое");
                return;
            }
            else if (Nickname.Text == "")
            {
                MessageBox.Show("Поле с именем пустое");
                return;
            }
            else
            {
                bool n = IsValidIpAddress(IPADress.Text);
                if (n == true)
                {
                    UserWindow ban1 = new UserWindow();
                    ban1.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("IP nepravilno veden");

                }
            }

        }
        public static bool IsValidIpAddress(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
                return false;

            string[] numbers = ipAddress.Split('.');
            if (numbers.Length != 4)
                return false;

            foreach (string number in numbers)
            {
                if (!byte.TryParse(number, out byte n))
                    return false;
            }

            return Regex.IsMatch(ipAddress, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
        }
    }
}

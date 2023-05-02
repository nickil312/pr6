using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для LogPage.xaml
    /// </summary>
    public partial class LogPage : Page
    {
        public LogPage()
        {
            InitializeComponent();
            List<string> list = new List<string>();
            string ban = "sdf";
            list.Add(ban);
            PolsovatList.ItemsSource= list;
        }

        private void LOGOFCHAT_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new ServerWindow();

        }
    }
}

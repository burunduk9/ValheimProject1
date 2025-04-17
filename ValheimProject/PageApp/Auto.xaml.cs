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
using ValheimProject.ADOApp;

namespace ValheimProject.PageApp
{
    /// <summary>
    /// Логика взаимодействия для Auto.xaml
    /// </summary>
    public partial class Auto : Page
    {
        public Auto()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            var _user = ClassApp.ClassConnection.Connection.User.Where(u => u.login == txtLog.Text && u.password == txtPas.Password).FirstOrDefault();
            if (txtLog.Text != "" && txtPas.Password != null)
            {
                if (_user != null)
                {
                    MessageBox.Show("все норм");
                    NavigationService.Navigate(new PageApp.Main());
                }
                else
                {
                    MessageBox.Show("все не норм");
                }
            }
            else
            {
                MessageBox.Show("поля не полны");
            }
        }
    }
}

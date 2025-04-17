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
using System.Windows.Shapes;
using ValheimProject.ADOApp;
using ValheimProject.ClassApp;

namespace ValheimProject.WindowApp
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Edit()
        {
            InitializeComponent();
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var resourceEdit = new ValheimProject.ADOApp.Resource();
            string name = txtName.Text;
            string biome = txtBiome.Text;
            string desc = txtDesc.Text;
            ClassApp.ClassConnection.Connection.SaveChanges();
            MessageBox.Show("все норм");
            this.Close();
        }
    }
}

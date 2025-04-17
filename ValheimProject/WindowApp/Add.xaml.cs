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

namespace ValheimProject.WindowApp
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
            LoadBiome();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && txtBiome.SelectedItem != null && txtDesc.Text != "")
            {
                var selectedBiom = txtBiome.SelectedItem as Biome;
                Resource resource = new Resource()
                {
                    name = txtName.Text,
                    id_biome = selectedBiom.id,
                    description = txtDesc.Text,
                    is_delete = false
                };
                ClassApp.ClassConnection.Connection.Resource.Add(resource);
                ClassApp.ClassConnection.Connection.SaveChanges();
                MessageBox.Show("все норм");
                this.Close();
            }
            else
            {
                MessageBox.Show("заполни поля");
            }
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void LoadBiome()
        {
            txtBiome.ItemsSource = ClassApp.ClassConnection.Connection.Biome.ToList();
            txtBiome.DisplayMemberPath = "name";
        }
    }
}

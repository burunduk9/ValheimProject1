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
using ValheimProject.WindowApp;

namespace ValheimProject.PageApp
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public static List<Biome> biomes { get; set; }
        public static List<Resource> resources { get; set; }
        public Main()
        {
            InitializeComponent();
            biomes = new List<Biome>(ClassApp.ClassConnection.Connection.Biome);
            resources = new List<Resource>(ClassApp.ClassConnection.Connection.Resource);
            biomes.Insert(0, new Biome() { id = -1, name = "all" });
            this.DataContext = this;
        }

        private void ComboFiltr_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var filterUnit = ComboFiltr.SelectedItem as Biome;
            if (filterUnit.id != -1)
            {
                GigaLista.ItemsSource = resources.Where(u => u.id_biome == filterUnit.id).ToList();
            }
            else
            {
                GigaLista.ItemsSource = resources.ToList();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowApp.Add addWindow = new WindowApp.Add();
            addWindow.Show();
        }

        private void txtSearchik_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchLine = txtSearchik.Text.Trim();
            if (searchLine == "")
            {
                GigaLista.ItemsSource = resources.ToList();
            }
            else
            {
                GigaLista.ItemsSource = resources.Where(u => u.name.StartsWith(searchLine, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var edited = (sender as Button).DataContext as Resource;
            var editWindow = new WindowApp.Edit { DataContext = edited };
            if (editWindow.ShowDialog() == true)
            {
                GigaLista.ItemsSource = new List<Resource>(ClassApp.ClassConnection.Connection.Resource.Where(u => u.is_delete != false).ToList());
            }

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var toDelete = (sender as Button).DataContext as Resource;
            var message = MessageBox.Show($"уверены в удалении {toDelete.name}?", "подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (message == MessageBoxResult.Yes)
            {
                toDelete.is_delete = true;
                ClassApp.ClassConnection.Connection.SaveChanges();
                GigaLista.ItemsSource = new List<Resource>(ClassApp.ClassConnection.Connection.Resource.Where(u => u.is_delete != true).ToList());
            }
        }
    }
}

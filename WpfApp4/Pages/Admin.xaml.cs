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
using WpfApp4.Class;

namespace WpfApp4.Pages
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
            datagrid.ItemsSource = schoolAndIEntities.GetContext().Service.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AppPageServices((sender as Button).DataContext as WpfApp4.Service));
            var delete = datagrid.SelectedItems.Cast<WpfApp4.Service>().ToList();
            schoolAndIEntities.GetContext().Service.RemoveRange(delete);
            schoolAndIEntities.GetContext().SaveChanges();
        }

        private void BtnCreateServices_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AppPageServices(null));
        }

        private void BtnDeleteServices_Click(object sender, RoutedEventArgs e)
        {
            var delete = datagrid.SelectedItems.Cast<WpfApp4.Service>().ToList();

            if (delete.Count == 0)
            {
                MessageBox.Show($"Вы не выбрали строку для удаления", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show($"Вы хотите удалить, {delete.Count()} элементов", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                schoolAndIEntities.GetContext().Service.RemoveRange(delete);
                schoolAndIEntities.GetContext().SaveChanges();
                datagrid.ItemsSource = schoolAndIEntities.GetContext().Service.ToList();
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                schoolAndIEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                datagrid.ItemsSource = schoolAndIEntities.GetContext().Service.ToList();
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RbVozr_Checked(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = schoolAndIEntities.GetContext().Service.OrderBy(x => x.Cost).ToList();
        }

        private void RbUb_Checked(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = schoolAndIEntities.GetContext().Service.OrderByDescending(x => x.Cost).ToList();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string txt = Search.Text;
            datagrid.ItemsSource = schoolAndIEntities.GetContext().Service.Where(x => x.Title.ToLower().Contains(txt.ToLower())).ToList();
        }
    }
}

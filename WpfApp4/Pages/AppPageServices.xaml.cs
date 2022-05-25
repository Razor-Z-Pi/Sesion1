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
    /// Логика взаимодействия для AppPageServices.xaml
    /// </summary>
    public partial class AppPageServices : Page
    {
        private static Service _context = new Service();
        public AppPageServices(Service service)
        {
            InitializeComponent();

            if (service == null)
            {
                service = _context;
            }

            DataContext = service;
        }

        private void SaveDataServices_Click(object sender, RoutedEventArgs e)
        {
            Service _context = new Service();
            schoolAndIEntities.GetContext().Service.Add(_context);
            _context.Title = TitleData.Text;
            _context.Cost = Convert.ToDecimal(CostData.Text);
            _context.DurationInSeconds = Convert.ToInt32(DurationData.Text);
            _context.Discount = Convert.ToDouble(DiscountData.Text);
            schoolAndIEntities.GetContext().SaveChanges();
            MessageBox.Show("Данные сохранены", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            AppFrame.frameMain.GoBack();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }
    }
}

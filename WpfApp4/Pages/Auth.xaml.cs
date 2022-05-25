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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Login = schoolAndIEntities.GetContext().User.FirstOrDefault(x => x.login == TextLogin.Text && x.password == TextPassword.Password);

                if (Login != null)
                {
                    switch(Login.id_role)
                    {
                        case 1:
                            MessageBox.Show("Добро пожалывать, администратор!!!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.frameMain.Navigate(new Admin());
                            break;
                        case 2:
                            MessageBox.Show("Добро пожалывать, менеджер!!!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.frameMain.Navigate(new Manager());
                            break;
                        case 3:
                            MessageBox.Show("Добро пожалывать, клиент!!!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.frameMain.Navigate(new Client());
                            break;
                        default:
                            MessageBox.Show("Такого пользователя не существует!!!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Введённые данные не верны!!!","Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnGuest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Добро пожалывать, гость!!!","Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            AppFrame.frameMain.Navigate(new Guest());
        }
    }
}

﻿using System;
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
    /// Логика взаимодействия для Guest.xaml
    /// </summary>
    public partial class Guest : Page
    {
        public Guest()
        {
            InitializeComponent();
            datagrid.ItemsSource = schoolAndIEntities.GetContext().Service.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }
    }
}

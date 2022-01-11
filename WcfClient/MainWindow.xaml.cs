using System;
using System.Collections.Generic;
using System.Windows;
using WcfClient.ServiceReference1;

namespace WcfClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var client = new ContractsInfoServiceClient();
            var message =  client.GetData(123);
            MessageBox.Show(message);
        }
    }
}

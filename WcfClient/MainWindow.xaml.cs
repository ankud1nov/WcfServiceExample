using System;
using System.Collections.Generic;
using System.Linq;
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
            CompositeType data = new CompositeType() {StringValue = "введенное bool значение: ", BoolValue = true};
            data = client.GetDataUsingDataContract(data);
            MessageBox.Show(data.StringValue);
            ShowData(client);
        }

        private void ShowData(ContractsInfoServiceClient client)
        {
            var contracts = client.GetContractsInfo().ToList();
            string message = string.Empty;

            foreach (var contract in contracts)
            {
                message += $"{contract.Number} - {contract.CreateDateTime} - {contract.LastEditDateTime}\n";
            }

            MessageBox.Show(message);
        }
    }
}

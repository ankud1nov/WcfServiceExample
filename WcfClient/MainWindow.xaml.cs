using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        }
    }

    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ContractInfoForView> Contracts { get; set; }

        public MainWindowViewModel()
        {
            var client = new ContractsInfoServiceClient();
            Contracts = new ObservableCollection<ContractInfoForView>();
            foreach (var contractInfo in client.GetContractsInfo().ToList())
            {
                Contracts.Add(new ContractInfoForView(contractInfo));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class ContractInfoForView
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime LastEditDateTime { get; set; }
        public bool Actuality { get; set; }

        public ContractInfoForView(ContractInfo info)
        {
            Id = info.Id;
            Number = info.Number;
            CreateDateTime = info.CreateDateTime;
            LastEditDateTime = info.LastEditDateTime;
            Actuality = (DateTime.Today - LastEditDateTime).Days < 60;
        }
    }
}

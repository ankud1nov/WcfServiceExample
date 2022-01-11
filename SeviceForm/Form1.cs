using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;
using WcfServiceExample;

namespace SeviceForm
{
    public partial class Form1 : Form
    {
        private static ServiceHost _selfHost;
        public Form1()
        {
            InitializeComponent();
            Start();
        }

        public void Start()
        {
            // Step 1: Create a URI to serve as the base address.
            var baseAddress = new Uri("http://localhost:8000/GettingStarted/");

            // Step 2: Create a ServiceHost instance.
            _selfHost = new ServiceHost(typeof(ContractsInfoService), baseAddress);

            try
            {
                // Step 3: Add a service endpoint.
                _selfHost.AddServiceEndpoint(typeof(IContractsInfoService), new WSHttpBinding(), "CalculatorService");

                // Step 4: Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                _selfHost.Description.Behaviors.Add(smb);

                // Step 5: Start the service.
                _selfHost.Open();
                textBox1.Text += "The service is ready.\r\n";

                // Close the ServiceHost to stop the service.
                textBox1.Text += "Close window to terminate the service.\r\n";
            }
            catch (CommunicationException ce)
            {
                textBox1.Text += $"An exception occurred: {ce.Message}\r\n";
                _selfHost.Abort();
            }
        }

        public void Dispose()
        {
            _selfHost.Close();
        }
    }
}

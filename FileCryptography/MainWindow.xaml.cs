using FileCryptography.Application.Interfaces.Services;
using FileCryptography.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
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

namespace FileCryptography
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IApplicationService appSvc;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(IApplicationService appSvc)
            : this()
        {
            this.appSvc = appSvc;
        }

        private void EncryptClick(object sender, RoutedEventArgs e)
        {
            //this.appSvc.Execute(new DecryptFileCommand(null, null));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.appSvc.Execute(new GenerateKeyPairCommand());
        }
    }
}

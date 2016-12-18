using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FileCryptography
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
                        var unityContainer = new UnityContainer();
            base.OnStartup(e);
            var bootStrapper = new DiyBootStrapper(unityContainer);
            System.Windows.Application.Current.MainWindow = unityContainer.Resolve<MainWindow>();
            System.Windows.Application.Current.MainWindow.Show();
        }
    }
}

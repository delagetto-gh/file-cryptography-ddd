using FileCryptography.Presentation.Client.Wpf.FileCryptographyService;
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

namespace FileCryptography.Presentation.Client.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IFileCryptographyServiceCallback
    {
        private readonly FileCryptographyServiceClient svc;

        public MainWindow()
        {
            InitializeComponent();
            this.svc = new FileCryptographyServiceClient(new InstanceContext(this));
        }

        private void EncryptClick(object sender, RoutedEventArgs e)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(@"D:\Users\Goose\Documents\helloWorld.txt");

            string result = null;
            System.IO.DirectoryInfo assem = new System.IO.DirectoryInfo(Assembly.GetExecutingAssembly().FullName);
            using (System.IO.Stream stream = new System.IO.FileStream(assem.Parent.FullName + "\\Keys\\FileCryptographyService.Public.gpg", System.IO.FileMode.Open))
            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            EncryptionRequest req = new EncryptionRequest();
            req.File = new File { Name = file.Name, Content = System.IO.File.ReadAllBytes(file.FullName) };
            req.CryptionArgs = new FileCryptionArgs();
            req.CryptionArgs.PublicKey = new KeyFile { Name = "FileCryptographyService.Public.gpg", Email = "goose@goose.com", Content = Encoding.ASCII.GetBytes(result) };

            this.svc.Encrypt(req);
            int dd = 5;
        }

        public void OnFileDecrypted(FileCryptionEvent args)
        {
            throw new NotImplementedException();
        }

        public void OnFileEncrypted(FileCryptionEvent args)
        {
            throw new NotImplementedException();
        }
   } 
}

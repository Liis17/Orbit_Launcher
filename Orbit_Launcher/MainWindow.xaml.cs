using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace Orbit_Launcher
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new WebClient())
            {
                var Folder1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "gg.zip";
                var Link1 = "https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/HGJO9G_srk1yEw";
                await client.DownloadFileTaskAsync(Link1, Folder1);
            }
        }
                
    }
}

using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows;

namespace Orbit_Launcher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] graylink; // ссылка на Gray
        public static string downvelue;
        public static float maxdown;
        public static float value;
        public MainWindow()
        {
            //FirstWindow firstWindow = new FirstWindow();
            //firstWindow.Show();
            //MessageBox.Show("Обновление ссылок загрузки");
            InitializeComponent();
            

            downloadgray.Visibility = Visibility.Hidden;
            installgray.Visibility = Visibility.Hidden;
            opengray.Visibility = Visibility.Hidden;

            UIWork();
        }

        

        public void Downloadgray(object sender, RoutedEventArgs e)
        {
            //var count = graylink.Length;

            //using (var client = new WebClient())
            //{
            //    client.DownloadProgressChanged += Client_DownloadProgressChanged;
            //    client.DownloadDataCompleted += Client_DownloadDataCompleted;
            //    await client.DownloadFileTaskAsync("https://github.com/Liis17/StartellingerBee/releases/download/1.0.1.9/app.publish.rar", "fi1le.rar");
            // }

            LinkUpdate.DownloadFiles();
        }

        public static void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            //todo: ready.
        }

        public static void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var currentBytes = (int)e.TotalBytesToReceive;
            var allBytes = (int)e.BytesReceived;
            downvelue = allBytes / 1024 + "/" + currentBytes / 1024;
            maxdown = currentBytes / 100;
            value = allBytes / 100;
        }

        public void A()
        {
            ValueDownload.Text = downvelue;
            ProgressBarTest.Maximum = maxdown;
            ProgressBarTest.Value = value;
        }

        public void UIWork() //проверка для отображения кнопок
        {
            var path1 = "Extractor\\Gray.zip";
            if (File.Exists(path1) == false)
            {
                downloadgray.Visibility = Visibility.Visible;
                installgray.Visibility = Visibility.Hidden;
                opengray.Visibility = Visibility.Hidden;
            }
            if (File.Exists(path1) == true)
            {
                downloadgray.Visibility = Visibility.Hidden;
                installgray.Visibility = Visibility.Visible;
                opengray.Visibility = Visibility.Hidden;
            }
        }

        public void Installgray(object sender, RoutedEventArgs e)
        {
            Process.Start("Extractor\\installgray.cmd");
        }

        public void Opengray(object sender, RoutedEventArgs e)
        {
            //открытие/запуск gray
        }

        private void Linkupload(object sender, RoutedEventArgs e)
        {
            LinkUpdate.MainLinkDownload();
        }

        private void Launcherupload(object sender, RoutedEventArgs e)
        {
            AutoUpdateLauncher.AutoUpdate();
        }


    }
}

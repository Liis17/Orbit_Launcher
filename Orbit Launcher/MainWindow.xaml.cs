using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Compression;

namespace Orbit_Launcher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] graylink; // ссылка на Gray

        
        public MainWindow()
        {
            //FirstWindow firstWindow = new FirstWindow();
            //firstWindow.Show();
            MessageBox.Show("Обновление ссылок загрузки");
            InitializeComponent();
            LinkUpdate.MainLinkDownload();

            downloadgray.Visibility = Visibility.Hidden;
            installgray.Visibility = Visibility.Hidden;
            opengray.Visibility = Visibility.Hidden;

            UIWork();
        }

        

        public async void Downloadgray(object sender, RoutedEventArgs e)
        {
            //var count = graylink.Length;

            using (var client = new WebClient())
           {
                client.DownloadProgressChanged += Client_DownloadProgressChanged;
                client.DownloadDataCompleted += Client_DownloadDataCompleted;
                await client.DownloadFileTaskAsync("https://github.com/Liis17/StartellingerBee/releases/download/1.0.1.9/app.publish.rar", "fi1le.rar");
           }
        }

        private void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            //todo: ready.
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var currentBytes = (int)e.TotalBytesToReceive;
            var allBytes = (int)e.BytesReceived;
            ValueDownload.Text = allBytes / 1024 + "/" + currentBytes / 1024;
            ProgressBarTest.Maximum = currentBytes / 100;
            ProgressBarTest.Value = allBytes / 100;
        }

        public void UIWork() //проверка для отображения кнопок
        {
            var path1 = "Gray.zip";
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
            //распаковка в выбраную дерикторию
            Process.Start("Gray.zip");
            Process.Start("cmd");
        }

        public void Opengray(object sender, RoutedEventArgs e)
        {
            //открытие/запуск gray
        }

        private void Linkupload(object sender, RoutedEventArgs e)
        {

        }
    }
}

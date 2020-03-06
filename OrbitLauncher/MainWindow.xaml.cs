using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows;
using System;

namespace Orbit_Launcher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string downvelue;
        public float maxdown;
        public float value;
        public MainWindow()
        {

            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DownloadOrpad();
        } //нажатие на кнопку загрузки в окне блокнота
        public async void DownloadOrpad()
        {
            using (var client = new WebClient())
            {
                client.DownloadProgressChanged += Client_DownloadProgressChanged;

                var Folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad.exe";
                var Link = "https://github.com/Liis17/Orpad/releases/download/fix_beta/Orpad.exe";

                await client.DownloadFileTaskAsync(Link, Folder);
            }
        } // загрузка блокнота

        public void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var currentBytes = (int)e.TotalBytesToReceive;
            var allBytes = (int)e.BytesReceived;
            downvelue = allBytes / 1024 + "/" + currentBytes / 1024;
            maxdown = currentBytes / 100;
            value = allBytes / 100;
            PBOrpad.Value = value;
            PBOrpad.Maximum = maxdown;
        } // для прогресс бара загрузки блокнота

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PBOrpad.Value = testslider.Value;
        } // для дебага, удалить

        
    }
}

using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows;
using System;


using System.Windows.Forms;

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
            Orpad_check();
            check_install();

        }

        #region Загрузка блокнота
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DownloadOrpad();
        } //нажатие на кнопку загрузки в окне блокнота
        private void OrpadUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateOrpad();
        } //нажание на кнопку обновить
        public void Orpad_check()
        {
            var file = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad.exe";
            if (File.Exists(file) == true)
            {
                OrpadDownloadButton.IsEnabled = false;
            }
            if (File.Exists(file) == false)
            {
                OrpadDownloadButton.IsEnabled = true;
            }

        } //проверка на наличение установленого блокнота
        public async void DownloadOrpad()
        {
            OrpadDownloadButton.IsEnabled = false;
            using (var client = new WebClient())
            {
                client.DownloadProgressChanged += Client_DownloadProgressChanged;

                var Folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad.exe";
                var Link = "https://github.com/Liis17/Orpad/releases/download/fix_beta/Orpad.exe";

                await client.DownloadFileTaskAsync(Link, Folder);
                Orpad_check();
            }
            OrpadDownloadButton.IsEnabled = true;
            Orpad_check();
            check_install();
        } // загрузка блокнота
        public void check_install()
        {
            var file = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad.exe";
            if (File.Exists(file) == true)
            {
                OrpadUpdateButton.IsEnabled = true;
            }
            if (File.Exists(file) == false)
            {
                OrpadUpdateButton.IsEnabled = false;
            }
        } // управление кнопкой обновления блокнота
        public async void UpdateOrpad()
        {
            OrpadUpdateButton.IsEnabled = false;
            using (var client = new WebClient())
            {
                client.DownloadProgressChanged += Client_DownloadProgressChanged;

                var Folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad.exe";
                var Link = "https://github.com/Liis17/Orpad/releases/download/fix_beta/Orpad.exe";

                await client.DownloadFileTaskAsync(Link, Folder);
                Orpad_check();
            }
            OrpadUpdateButton.IsEnabled = true;
            Orpad_check();
        } // обновление блокнота



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

        #endregion

        #region дебаг
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PBOrpad.Value = testslider.Value;
        } // для дебага, удалить
        #endregion

        //if (System.Windows.Forms.MessageBox.Show("Подтвердите переход по ссылке 'https://ww3.orbitinspace.site/program/Orpad'",
        //    "Узнать больше",
        //    MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        //{
        //    //
        //}
        //else
        //{
        //    //
        //}
    }
}

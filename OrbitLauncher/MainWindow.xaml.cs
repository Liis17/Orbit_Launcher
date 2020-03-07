using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows;
using System;


using System.Windows.Forms;
using System.Threading.Tasks;

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
            Directory_Create();
            Orpad_Check_Update();
            Orpad_download_versionInfo();
            Orpad_check();
            Check_install();
            Check_for_launch();
            PBOrpad.Value = 0;

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

                var a = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "OrbitLauncher" + "\\" + "Orpad_LastVersion.d"); ;

                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad_Version.d", a);

            }
            OrpadDownloadButton.IsEnabled = true;
            Orpad_check();
            Check_install();
            Check_for_launch();
            Orpad_Check_Update();
        } // загрузка блокнота
        public void Check_install()
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

                var a = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "OrbitLauncher" + "\\" + "Orpad_LastVersion.d"); ;

                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad_Version.d", a);




            }
            OrpadUpdateButton.IsEnabled = true;
            Orpad_check();
            Orpad_Check_Update();
        } // обновление блокнота
        private void OrpadLaunchButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad.exe");
        } //запуск блокнота
        public void Check_for_launch()
        {
            var file = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad.exe";
            if (File.Exists(file) == true)
            {
                OrpadLaunchButton.IsEnabled = true;
            }
            if (File.Exists(file) == false)
            {
                OrpadLaunchButton.IsEnabled = false;
            }
        }//упарвление кнопкой запуска
        public void Directory_Create()
        {
            var a = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad";
            Directory.CreateDirectory(a);

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad_Version.d") == false)
            {
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad_Version.d","0");
            }

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "OrbitLauncher" + "\\" + "Orpad_LastVersion.d") == false)
            {
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "OrbitLauncher" + "\\" + "Orpad_LastVersion.d", "0");
            }
        } // создание папки для блокнота
        public async void Orpad_download_versionInfo()
        {
            using (var client = new WebClient())
            {
                await client.DownloadFileTaskAsync("https://github.com/Liis17/Orpad/releases/download/fix_beta/Orpad_LastVersion.d", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "OrbitLauncher" + "\\" + "Orpad_LastVersion.d");
                Orpad_Check_Update();
            }
            
        }
        public void Orpad_Check_Update()
        {
            Orpad_last_versoin.Text = "Последняя версия: " + File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "OrbitLauncher" + "\\" + "Orpad_LastVersion.d");
            Orpad_version.Text = "Установленая версия: " + File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad_Version.d");
        }



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


        WindowState prevState;

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                Hide();
            else
                prevState = WindowState;
        }

        private void TaskbarIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            Show();
            WindowState = prevState;
        }
    }
}

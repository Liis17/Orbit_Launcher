using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows;
using System;


using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Orbit_Launcher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {/// <summary>
    /// при смене экрана пусть значения обнуляются
    /// </summary>
        public string downvelue;
        public float maxdown;
        public float value;


        public string[] linkGray;


        public MainWindow()
        {

            InitializeComponent();

            Directory_Create_Orpad();
            Directory_Create_Gray();

            Orpad_Check_Update();
            Gray_Check_Update();

            Orpad_download_versionInfo();
            Gray_download_versionInfo();

            Orpad_check();
            Gray_check();

            Check_install_Orpad();
            Check_install_Gray();

            Check_for_launch_Orpad();
            Check_for_launch_Gray();

            PBOrpad.Value = 0;
            PBGray.Value = 0;

        }

        #region Загрузка блокнота

        private void OrpadFeedback_Click(object sender, RoutedEventArgs e)
        {
            var a = "https://forms.gle/7nyZLsomhToPTafp7";
            Process.Start(a);
        } // кнопка фитбека
        private void OrpadOpenSite_Click(object sender, RoutedEventArgs e)
        {
            var a = "https://ww3.orbitinspace.site/program/Orpad";
            Process.Start(a);
        } // кнопка открытия сайта
        private void OrpadOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            var a = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad";
            Process.Start(a);
        } // кнопка открытия папки

        private void Button_Click_Orpad(object sender, RoutedEventArgs e)
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
                client.DownloadProgressChanged += Client_DownloadProgressChanged_Orpad;

                var Folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad.exe";
                var Link = "https://github.com/Liis17/Orpad/releases/download/fix_beta/Orpad.exe";

                await client.DownloadFileTaskAsync(Link, Folder);

                var a = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "OrbitLauncher" + "\\" + "Orpad_LastVersion.d"); ;

                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad_Version.d", a);

            }
            OrpadDownloadButton.IsEnabled = true;
            Orpad_check();
            Check_install_Orpad();
            Check_for_launch_Orpad();
            Orpad_Check_Update();
        } // загрузка блокнота
        public void Check_install_Orpad()
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
                client.DownloadProgressChanged += Client_DownloadProgressChanged_Orpad;

                OrpadLaunchButton.IsEnabled = false;

                var Folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad.exe";
                var Link = "https://github.com/Liis17/Orpad/releases/download/fix_beta/Orpad.exe";

                await client.DownloadFileTaskAsync(Link, Folder);
                Orpad_check();

                OrpadLaunchButton.IsEnabled = true;

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
        public void Check_for_launch_Orpad()
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
        }//управление кнопкой запуска
        public void Directory_Create_Orpad()
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
        public async void Orpad_download_versionInfo() //узнавание последней версии блокнота
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
        } //вывод версий на экран



        public void Client_DownloadProgressChanged_Orpad(object sender, DownloadProgressChangedEventArgs e)
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


        #region Загрузка Gray

        private void GrayFeedback_Click(object sender, RoutedEventArgs e)
        {
            var a = "https://forms.gle/7nyZLsomhToPTafp7";
            Process.Start(a);
        } // кнопка фитбека
        private void GrayOpenSite_Click(object sender, RoutedEventArgs e)
        {
            var a = "https://ww3.orbitinspace.site/games/gray";
            Process.Start(a);
        } // кнопка открытия сайта
        private void GrayOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            var a = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray";
            Process.Start(a);
        } // кнопка открытия папки

        private void Button_Click_Gray(object sender, RoutedEventArgs e)
        {
            DownloadGray();
        } //нажатие на кнопку загрузки в окне блокнота
        private void GrayUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateGray();
        } //нажание на кнопку обновить
        public void Gray_check()
        {
            var file = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray" + "\\" + "Gray.exe";
            if (File.Exists(file) == true)
            {
                GrayDownloadButton.IsEnabled = false;
            }
            if (File.Exists(file) == false)
            {
                GrayDownloadButton.IsEnabled = true;
            }

        } //проверка на наличение установленой игры
        public async void DownloadGray()
        {
            GrayDownloadButton.IsEnabled = false;
            using (var client = new WebClient())
            {
                client.DownloadProgressChanged += Client_DownloadProgressChanged_Gray;

                var Folder1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "gg.png";
                var Link1 = "https://yadi.sk/i/HZjzct2V2aK71w";
                await client.DownloadFileTaskAsync(Link1, Folder1);

                var text = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "OrbitLauncher" + "\\" + "Cache" + "\\" + "GrayLink.d");
                linkGray = text.Split('!');
                var counter = 0;
                foreach (var link in linkGray)
                {
                    await client.DownloadFileTaskAsync(linkGray[counter], Folder1);
                    counter++;
                }


                var a = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "OrbitLauncher" + "\\" + "Gray_LastVersion.d"); ;

                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray" + "\\" + "Gray_Version.d", a);

            }
            GrayDownloadButton.IsEnabled = true;
            Gray_check();
            Check_install_Gray();
            Check_for_launch_Gray();
            Gray_Check_Update();
        } // загрузка блокнота
        public void Check_install_Gray()
        {
            var file = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray" + "\\" + "Gray.exe";
            if (File.Exists(file) == true)
            {
                GrayUpdateButton.IsEnabled = true;
            }
            if (File.Exists(file) == false)
            {
                GrayUpdateButton.IsEnabled = false;
            }
        } // управление кнопкой обновления блокнота
        public async void UpdateGray()
        {
            GrayUpdateButton.IsEnabled = false;
            using (var client = new WebClient())
            {
                client.DownloadProgressChanged += Client_DownloadProgressChanged_Gray;

                GrayLaunchButton.IsEnabled = false;

                var Folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray" + "\\" + "Gray.exe";
                var Link = "https://github.com/Liis17/Orpad/releases/download/fix_beta/Orpad.exe";

                await client.DownloadFileTaskAsync(Link, Folder);
                Gray_check();

                GrayLaunchButton.IsEnabled = true;

                var a = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "OrbitLauncher" + "\\" + "Orpad_LastVersion.d"); ;

                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad_Version.d", a);




            }
            GrayUpdateButton.IsEnabled = true;
            Gray_check();
            Gray_Check_Update();
        } // обновление блокнота
        private void GrayLaunchButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray" + "\\" + "Gray.exe");
        } //запуск блокнота
        public void Check_for_launch_Gray()
        {
            var file = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray" + "\\" + "Gray.exe";
            if (File.Exists(file) == true)
            {
                GrayLaunchButton.IsEnabled = true;
            }
            if (File.Exists(file) == false)
            {
                GrayLaunchButton.IsEnabled = false;
            }
        }//управление кнопкой запуска
        public void Directory_Create_Gray()
        {
            var a = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray";
            Directory.CreateDirectory(a);

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray" + "\\" + "Gray_Version.d") == false)
            {
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray" + "\\" + "Gray_Version.d", "0");
            }

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "OrbitLauncher" + "\\" + "Gray_LastVersion.d") == false)
            {
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "OrbitLauncher" + "\\" + "Gray_LastVersion.d", "0");
            }
        } // создание папки для блокнота
        public async void Gray_download_versionInfo() //узнавание последней версии блокнота
        {
            using (var client = new WebClient())
            {
                await client.DownloadFileTaskAsync("https://github.com/Liis17/Orpad/releases/download/fix_beta/Orpad_LastVersion.d", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "OrbitLauncher" + "\\" + "Gray_LastVersion.d");
                Gray_Check_Update();
            }

        }
        public void Gray_Check_Update()
        {
            Orpad_last_versoin.Text = "Последняя версия: " + File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "OrbitLauncher" + "\\" + "Gray_LastVersion.d");
            Orpad_version.Text = "Установленая версия: " + File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray" + "\\" + "Gray_Version.d");
        } //вывод версий на экран



        public void Client_DownloadProgressChanged_Gray(object sender, DownloadProgressChangedEventArgs e)
        {
            var currentBytes = (int)e.TotalBytesToReceive;
            var allBytes = (int)e.BytesReceived;
            downvelue = allBytes / 1024 + "/" + currentBytes / 1024;
            maxdown = currentBytes / 100;
            value = allBytes / 100;
            PBGray.Value = value;
            PBGray.Maximum = maxdown;
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
        } // что то для трея

        private void TaskbarIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            Show();
            WindowState = prevState;
        } // наверное для вывода в трей

        public void CanvasUpdate()
        {
            
        }

        
    }
}

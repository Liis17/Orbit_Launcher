using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
        public int screen; // для работы смены экранов
        public bool nfa = false; // смуществует или нет архиватор
        public int adv = 0;

        public MainWindow()
        {
            screen = 0;
            InitializeComponent();
            CheckArchiver();
            ScreenSwith();

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new WebClient())
            {
                var Folder1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "gg.zip";
                var Link1 = "https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/HGJO9G_srk1yEw";
                await client.DownloadFileTaskAsync(Link1, Folder1);
            }
        } //тест

        #region проверка архиватора и его загрузка
        public void CheckArchiver()
        {
            string Archiverexe = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orbit_Launcher" + "\\" + "7z.exe";
            string Archiverdll = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orbit_Launcher" + "\\" + "7z.dll";
            if (File.Exists(Archiverexe) == false || File.Exists(Archiverdll) == false)
            {
                MessageBox.Show("Отсутствует архиватор", "Проблема с запуском");
                MessageBox.Show("Приготовьтесь, сейчас будет запущен загрузчик файлов", "Автоматическое устранение проблемы");
                nfa = true; 
                SetDownScreen();
            }
        } // проверка на наличие архиватора

        public void SetDownScreen()
        {
            if (nfa == true)
            {
                DownloadArchver();
                FirstGrid.Visibility = Visibility.Hidden;
                ArchiverdownGrid.Visibility = Visibility.Visible;
            }
        } // проверка на наличие архиватора 2

        public async void DownloadArchver()
        {
            using (var client = new WebClient())
            {
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(DCArchiver);
                client.DownloadProgressChanged += DPArchiver;

                var path1 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orbit_Launcher" + "\\" + "7z.exe";
                var path2 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orbit_Launcher" + "\\" + "7z.dll";

                var link1 = "https://github.com/Liis17/Inspiration/releases/download/7z/7z.exe";
                var link2 = "https://github.com/Liis17/Inspiration/releases/download/7z/7z.dll";

                await client.DownloadFileTaskAsync(link1, path1);
                await client.DownloadFileTaskAsync(link2, path2);

                MessageBox.Show("Файлы загружены, программа готова к работе", "Готово!");
            }
        } // загрузка архиватора

        public void DCArchiver( object sender, AsyncCompletedEventArgs e)
        {
            adv += 1;
            ArchiverText.Text = adv + "/2";
            if (adv == 2)
            {
                nfa = false;
                FirstGrid.Visibility = Visibility.Visible;
                ArchiverdownGrid.Visibility = Visibility.Hidden;
            }
        }

        public void DPArchiver(object sender, DownloadProgressChangedEventArgs e)
        {
            var currentBytes = (int)e.TotalBytesToReceive;
            var allBytes = (int)e.BytesReceived;
            var downvelue = allBytes / 1024 + "/" + currentBytes / 1024;
            var maxdown = currentBytes / 100;
            var value = allBytes / 100;
            ArchiverProgessbar.Value = value;
            ArchiverProgessbar.Maximum = maxdown;
        } // для прогресс бара загрузки блокнота

        #endregion

        private void BaguetteScroll(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://ww3.orbitinspace.site/baguette");
        } // пасхалка с багетом

        #region смена экранов
        #region нажатия на кнопки
        private void Mainpage_Click(object sender, RoutedEventArgs e)
        {
            screen = 0;
            ScreenSwith();
        } // нажание на кнопку "главная"

        private void Graypage_Click(object sender, RoutedEventArgs e)
        {
            screen = 100;
            ScreenSwith();
        } // нажание на кнопку "Gray"

        private void Baetheexpage_Click(object sender, RoutedEventArgs e)
        {
            screen = 101;
            ScreenSwith();
        } // нажание на кнопку "Baetheex"

        private void FLinepage_Click(object sender, RoutedEventArgs e)
        {
            screen = 102;
            ScreenSwith();
        } // нажание на кнопку "FLine"

        private void Orpadpage_Click(object sender, RoutedEventArgs e)
        {
            screen = 200;
            ScreenSwith();
        } // нажание на кнопку "Orpad"

        private void WhatToMountpage_Click(object sender, RoutedEventArgs e)
        {
            screen = 201;
            ScreenSwith();
        } // нажание на кнопку "WhatToMount"
        #endregion

        public void ScreenSwith()
        {
            #region главный экран

            if (screen == 0)
            {
                Namebox.Text = "Главная";
            }

            #endregion 

            #region игры

            if (screen == 100)
            {
                Namebox.Text = "Gray";
            }
            if (screen == 101)
            {
                Namebox.Text = "Baetheex";
            }
            if (screen == 102)
            {
                Namebox.Text = "FLine";
            }

            #endregion

            #region программы

            if (screen == 200)
            {
                Namebox.Text = "Orpad";
            }
            if (screen == 201)
            {
                Namebox.Text = "WhatToMount";
            }

            #endregion 
        }
        #endregion


    }
}

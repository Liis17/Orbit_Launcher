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
using System.Timers;
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
        
        public static int adv = 0;

        #region ссылки на обьекты интерфейса
        public static object archivertext; // текст панель с выводом сачаных элементов (0/2)
        public static object archiverprogessbarvalue; // прогресс бар загрузки архиватора (значение)
        public static object archiverprogessbarmax; // прогресс бар загрузки архиватора (максимум)


        #endregion

        #region параметры для страниц
        public string gray_link = "https://github.com/Liis17/Orbit_Launcher/releases/download/linkfordownload/Gray.d"; //ссылка на ссылку с архивом
        public string gray_linkarchive; // ссылка на скачивание архива;
        public string gray_versiononline; // версия в сети
        public string gray_versionoffline; // версия на устройстве
        public string gray_description = "Тестовый проект созданый для тестирования различных штук для других проектов"; // описание

        public string gray_lastversion;


        public string baetheex_link = "https://github.com/Liis17/Orbit_Launcher/releases/download/linkfordownload/Baetheex.d"; //ссылка на ссылку с архивом
        public string baetheex_linkarchive; // ссылка на скачивание архива;
        public string baetheex_versiononline; // версия в сети
        public string baetheex_versionoffline; // версия на устройстве
        public string baetheex_description = "Замороженный проект, его загрузка нереконемдуется. В скором времени если у меня появится делание я сделаю его ремастер"; // описание

        public string baetheex_lastversion;


        public string fline_link = "https://github.com/Liis17/Orbit_Launcher/releases/download/linkfordownload/FLine.d"; //ссылка на ссылку с архивом
        public string fline_linkarchive; // ссылка на скачивание архива;
        public string fline_versiononline; // версия в сети
        public string fline_versionoffline; // версия на устройстве
        public string fline_description = "Замороженный проект, рабочих сборок которого больше нет. В будующем возможен ремастер"; // описание

        public string fline_lastversion;


        public string orpad_link = "https://github.com/Liis17/Orbit_Launcher/releases/download/linkfordownload/Orpad.d"; //ссылка на ссылку с архивом
        public string orpad_linkarchive; // ссылка на скачивание архива;
        public string orpad_versiononline; // версия в сети
        public string orpad_versionoffline; // версия на устройстве
        public string orpad_description = "Блокнот, просто блокнот, больше нечего о нем сказать"; // описание

        public string orpad_lastversion;


        public string whattomount_link = "https://github.com/Liis17/Orbit_Launcher/releases/download/linkfordownload/WhatToMount.d"; //ссылка на ссылку с архивом
        public string whattomount_linkarchive; // ссылка на скачивание архива;
        public string whattomount_versiononline; // версия в сети
        public string whattomount_versionoffline; // версия на устройстве
        public string whattomount_description = "Эта программа выдает случайную строку из файла, вот зачем эта программа вам тут нужна я не знаю"; // описание

        public string whattomount_lastversion;


        #endregion

        public MainWindow()
        {
            Startup.DirectoryCreate();
            screen = 0;
            InitializeComponent();
            
            ScreenSwith();
            PageOptions();
            ButtonStart.IsEnabled = false;

            #region установка обьектов интерфейса в статические переменые

            archivertext = ArchiverText.Text;

            archiverprogessbarvalue = ArchiverProgessbar.Value;
            archiverprogessbarmax = ArchiverProgessbar.Maximum;



            #endregion

            Startup.CheckArchiver();
        }

        #region вывод окон с предумпеждением

        public static void EnableBootScreen()
        {
            FirstGrid.Visibility = Visibility.Hidden;
            ArchiverdownGrid.Visibility = Visibility.Visible;
        } // включение экрана загрузки архиватора

        public static void ShutdownBootScreen()
        {
            FirstGrid.Visibility = Visibility.Visible;
            ArchiverdownGrid.Visibility = Visibility.Hidden;
        } // выключение экрана загрузки архиватора

        #endregion


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var foldergame = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\";
            var folderprogramm = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\";
            if (screen == 0)
            {
                MessageBox.Show("Зачем, лаунчер же у тебя уже есть");
            }
            if (screen == 100)
            {
                ButtonDownload.IsEnabled = false;
                Mainpage.IsEnabled = false;
                Graypage.IsEnabled = false;
                Baetheexpage.IsEnabled = false;
                FLinepage.IsEnabled = false;
                Orpadpage.IsEnabled = false;
                WhatToMountpage.IsEnabled = false;

                using (var client = new WebClient())
                {
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownComp);
                    client.DownloadProgressChanged += ProgressPanel;
                    await client.DownloadFileTaskAsync(gray_linkarchive, foldergame + "Cache" + "\\" + "GrayRelease.zip");
                    //await client.DownloadFileTaskAsync("https://github.com/Liis17/Orbit_Launcher/releases/download/linkfordownload/unpackinggray.cmd", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "GrayRelease.zip");
                }
                File.WriteAllText(foldergame + "Gray" + "\\" + "Gray.d", gray_lastversion);
            }
            if (screen == 101)
            {
                MessageBox.Show("Нет, ты не скачаешь тут ничего", "Предупреждение");
            }
            if (screen == 102)
            {
                MessageBox.Show("Нет, ты не скачаешь тут ничего","Предупреждение");
            }
            if (screen == 200)
            {
                ButtonDownload.IsEnabled = false;
                Mainpage.IsEnabled = false;
                Graypage.IsEnabled = false;
                Baetheexpage.IsEnabled = false;
                FLinepage.IsEnabled = false;
                Orpadpage.IsEnabled = false;
                WhatToMountpage.IsEnabled = false;

                using (var client = new WebClient())
                {
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownComp);
                    client.DownloadProgressChanged += ProgressPanel;
                    await client.DownloadFileTaskAsync(orpad_linkarchive, folderprogramm + "Orpad" + "\\" + "Orpad.exe");
                }
                File.WriteAllText(folderprogramm + "Orpad" + "\\" + "Orpad.d", orpad_lastversion);
            }
            if (screen == 201)
            {
                ButtonDownload.IsEnabled = false;
                Mainpage.IsEnabled = false;
                Graypage.IsEnabled = false;
                Baetheexpage.IsEnabled = false;
                FLinepage.IsEnabled = false;
                Orpadpage.IsEnabled = false;
                WhatToMountpage.IsEnabled = false;

                using (var client = new WebClient())
                {
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownComp);
                    client.DownloadProgressChanged += ProgressPanel;
                    await client.DownloadFileTaskAsync(whattomount_linkarchive, folderprogramm + "Cache" + "\\" + "WhatToMount.zip");
                }
                File.WriteAllText(folderprogramm + "WhatToMount" + "\\" + "WhatToMount.d", whattomount_lastversion);
            }
            
        } //Загрузка

        public async void DownComp(object sender, AsyncCompletedEventArgs e)
        {
            MainProgressBar.Value = 0;
            ButtonDownload.IsEnabled = true;
            Mainpage.IsEnabled = true;
            Graypage.IsEnabled = true;
            Baetheexpage.IsEnabled = true;
            FLinepage.IsEnabled = true;
            Orpadpage.IsEnabled = true;
            WhatToMountpage.IsEnabled = true;
            PageOptions();
            ScreenSwith();


            if (screen == 100)
            {
                using (var client = new WebClient())
                {
                    await client.DownloadFileTaskAsync("https://github.com/Liis17/Orbit_Launcher/releases/download/linkfordownload/unpackinggray.cmd", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "unpackinggray.cmd");
                }

                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "unpackinggray.cmd");
                ButtonStart.IsEnabled = true;
            }
            if (screen == 200)
            {
                ButtonStart.IsEnabled = true;
            }
            if (screen == 201)
            {
                using (var client = new WebClient())
                {
                    await client.DownloadFileTaskAsync("https://github.com/Liis17/Orbit_Launcher/releases/download/linkfordownload/unpackingwhattomount.cmd", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "unpackingwhattomount.cmd");
                }

                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "unpackingwhattomount.cmd");
                ButtonStart.IsEnabled = true;
            }
        }
        public void ProgressPanel(object sender, DownloadProgressChangedEventArgs e)
        {
            var currentBytes = (int)e.TotalBytesToReceive;
            var allBytes = (int)e.BytesReceived;
            var downvelue = allBytes / 1024 + "/" + currentBytes / 1024;
            var maxdown = currentBytes / 100;
            var value = allBytes / 100;
            MainProgressBar.Value = value;
            MainProgressBar.Maximum = maxdown;
        } // для прогресс бара загрузки 

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
                description.Text = "Orbit Launcher" + "\n" + "Средство загрузки продуктов Orbit is Space";
                versiononline.Text = "Нажмите на любую";
                versionoffline.Text = "икоку справа";
                ButtonStart.IsEnabled = false;
            }

            #endregion 

            #region игры

            if (screen == 100)
            {
                Namebox.Text = "Gray";
                description.Text = gray_description;
                versiononline.Text = gray_versiononline;
                versionoffline.Text = gray_versionoffline;
                ButtonStart.IsEnabled = false;
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray" + "\\" + "Gray.exe") == true)
                {
                    ButtonStart.IsEnabled = true;
                }
            }
            if (screen == 101)
            {
                Namebox.Text = "Baetheex";
                description.Text = baetheex_description;
                versiononline.Text = baetheex_versiononline;
                versionoffline.Text = baetheex_versionoffline;
                ButtonStart.IsEnabled = false;
            }
            if (screen == 102)
            {
                Namebox.Text = "FLine";
                description.Text = fline_description;
                versiononline.Text = fline_versiononline;
                versionoffline.Text = fline_versionoffline;
                ButtonStart.IsEnabled = false;
            }

            #endregion

            #region программы

            if (screen == 200)
            {
                Namebox.Text = "Orpad";
                description.Text = orpad_description;
                versiononline.Text = orpad_versiononline;
                versionoffline.Text = orpad_versionoffline;
                ButtonStart.IsEnabled = false;
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad.exe") == true)
                {
                    ButtonStart.IsEnabled = true;
                }
            }
            if (screen == 201)
            {
                Namebox.Text = "WhatToMount";
                description.Text = whattomount_description;
                versiononline.Text = whattomount_versiononline;
                versionoffline.Text = whattomount_versionoffline;
                ButtonStart.IsEnabled = false;
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "WhatToMount" + "\\" + "WhatToMount.exe") == true)
                {
                    ButtonStart.IsEnabled = true;
                }
            }

            #endregion 
        }
        #endregion

        public async void PageOptions()
        {

            var folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orbit_Launcher" + "\\" + "Link" + "\\";
            if (File.Exists(folder) == false)
            {
                Directory.CreateDirectory(folder);
            }
            var folder_gray = folder + "Gray.d";
            var folder_baetheex = folder + "Baetheex.d";
            var folder_fline = folder + "FLine.d";
            var folder_orpad = folder + "Orpad.d";
            var folder_whattomount = folder + "WhatToMount.d";
            using (var client = new WebClient())
            {
                await client.DownloadFileTaskAsync(gray_link, folder_gray);
                await client.DownloadFileTaskAsync(baetheex_link, folder_baetheex);
                await client.DownloadFileTaskAsync(fline_link, folder_fline);
                await client.DownloadFileTaskAsync(orpad_link, folder_orpad);
                await client.DownloadFileTaskAsync(whattomount_link, folder_whattomount);
            }
            #region gray
            if (File.Exists(folder_gray) == true)
            {
                var gray_string = File.ReadAllText(folder_gray);
                var gray_arroy = gray_string.Split('\n');
                gray_linkarchive = "https://getfile.dokpub.com/yandex/get/" + gray_arroy[0];
                gray_versiononline = "Последняя версия: " + gray_arroy[1];
                gray_lastversion = gray_arroy[1];
            }
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray" + "\\" + "Gray.d") == true)
            {
                gray_versionoffline = "Установленная версия: " + File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray" + "\\" + "Gray.d");
            }
            else if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray" + "\\" + "Gray.d") == false)
            {
                gray_versionoffline = "Файл с версией не найден";
            }
            #endregion

            #region baetheex
            if (File.Exists(folder_baetheex) == true)
            {
                var baetheex_string = File.ReadAllText(folder_baetheex);
                var baetheex_arroy = baetheex_string.Split('\n');
                baetheex_linkarchive = "https://getfile.dokpub.com/yandex/get/" + baetheex_arroy[0];
                baetheex_versiononline = "Последняя версия: " + baetheex_arroy[1];
                baetheex_lastversion = baetheex_arroy[1];
            }
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Baetheex" + "\\" + "Baetheex.d") == true)
            {
                baetheex_versionoffline = "Установленная версия: " + File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Baetheex" + "\\" + "Baetheex.d");
            }
            else if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Baetheex" + "\\" + "Baetheex.d") == false)
            {
                baetheex_versionoffline = "Файл с версией не найден";
            }
            #endregion

            #region fline
            if (File.Exists(folder_fline) == true)
            {
                var fline_string = File.ReadAllText(folder_fline);
                var fline_arroy = fline_string.Split('\n');
                fline_linkarchive = "https://getfile.dokpub.com/yandex/get/" + fline_arroy[0];
                fline_versiononline = "Последняя версия: " + fline_arroy[1];
                fline_lastversion = fline_arroy[1];
            }
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "FLine" + "\\" + "FLine.d") == true)
            {
                fline_versionoffline = "Установленная версия: " + File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "FLine" + "\\" + "FLine.d");
            }
            else if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "FLine" + "\\" + "FLine.d") == false)
            {
                fline_versionoffline = "Файл с версией не найден";
            }
            #endregion

            #region orpad
            if (File.Exists(folder_orpad) == true)
            {
                var orpad_string = File.ReadAllText(folder_orpad);
                var orpad_arroy = orpad_string.Split('\n');
                orpad_linkarchive = orpad_arroy[0];
                orpad_versiononline = "Последняя версия: " + orpad_arroy[1];
                orpad_lastversion = orpad_arroy[1];
            }
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "orpad.d") == true)
            {
                orpad_versionoffline = "Установленная версия: " + File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad.d");
            }
            else if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "orpad.d") == false)
            {
                orpad_versionoffline = "Файл с версией не найден";
            }
            #endregion

            #region whattomount
            if (File.Exists(folder_whattomount) == true)
            {
                var whattomount_string = File.ReadAllText(folder_whattomount);
                var whattomount_arroy = whattomount_string.Split('\n');
                whattomount_linkarchive = whattomount_arroy[0];
                whattomount_versiononline = "Последняя версия: " + whattomount_arroy[1];
                whattomount_lastversion = whattomount_arroy[1];
            }
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "WhatToMount" + "\\" + "WhatToMount.d") == true)
            {
                whattomount_versionoffline = "Установленная версия: " + File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "WhatToMount" + "\\" + "WhatToMount.d");
            }
            else if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "WhatToMount" + "\\" + "WhatToMount.d") == false)
            {
                whattomount_versionoffline = "Файл с версией не найден";
            }
            #endregion

        } //установка значений на переменые

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            if (screen == 100)
            {
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray" + "\\" + "Gray.exe");
            }
            if (screen == 200)
            {
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad" + "\\" + "Orpad.exe");
            }
            if (screen == 201)
            {
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "WhatToMount" + "\\" + "WhatToMount.exe");
            }
        }
    }
}

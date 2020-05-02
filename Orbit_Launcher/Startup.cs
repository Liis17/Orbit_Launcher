using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;
using System.Windows;
using System.Net;

namespace Orbit_Launcher
{
    class Startup
    {
        public static bool nfa = false; // существует ли архиватор

        public static void DirectoryCreate()
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Gray");
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Baetheex");
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "FLine");
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orpad");
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "WhatToMount");
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Cache");
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orbit_Launcher");
        } //создание папок

        public static void FileCreate()
        {
            var pathfile1 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "unpackingwhattomount.cmd";
            var pathfile2 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "unpackinggray.cmd";


            var pathfolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space";

            var sys = MainWindow.symboltext.Text;

            string content1 = "7z x " + pathfolder + "\\Cache\\WhatToMount.zip -o" + sys + pathfolder + "\\WhatToMount" + sys;
            string content2 = "7z x " + pathfolder + "\\Cache\\GrayRelease.zip -o" + sys + pathfolder + "\\Gray" + sys;

            File.WriteAllText(pathfile1, content1);
            File.WriteAllText(pathfile2, content2);
        }

        public static void CheckArchiver()
        {
            string Archiverexe = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "7z.exe";
            string Archiverdll = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "7z.dll";
            string Archiverser = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orbit_Launcher_Service.exe";
            if (File.Exists(Archiverexe) == false || File.Exists(Archiverdll) == false || File.Exists(Archiverser) == false)
            {
                MessageBox.Show("Отсутствует архиватор" + "\n" +"Cейчас будет запущен загрузчик файлов", "Автоматическое устранение проблемы");
                nfa = true;
                if (nfa == true)
                {
                    DownloadArchver();
                    MainWindow.EnableBootScreen();
                }
            }
            else if (File.Exists(Archiverexe) == true && File.Exists(Archiverdll) == true && File.Exists(Archiverser) == true)
            {
                MainWindow.ScreenSwith();
                MainWindow.PageOptions();
            }

        } // проверка на наличие архиватора

        public static async void DownloadArchver()
        {
            using (var client = new WebClient())
            {
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(DCArchiver);
                client.DownloadProgressChanged += DPArchiver;

                var path1 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "7z.exe";
                var path2 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "7z.dll";
                var path3 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orbit_Launcher_Service.exe";

                var link1 = "https://github.com/Liis17/Inspiration/releases/download/7z/7z.exe";
                var link2 = "https://github.com/Liis17/Inspiration/releases/download/7z/7z.dll";
                var link3 = "https://github.com/Liis17/Orbit_Launcher/releases/download/launch2.1/Orbit_Launcher_Service.exe";

                await client.DownloadFileTaskAsync(link1, path1);
                await client.DownloadFileTaskAsync(link3, path3);
                await client.DownloadFileTaskAsync(link2, path2);


                //MessageBox.Show("Файлы загружены, программа готова к работе", "Готово!");

                string Archiverexe = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "7z.exe";
                string Archiverdll = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "7z.dll";
                string Archiverser = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "Orbit_Launcher_Service.exe";
                if (File.Exists(Archiverexe) == true || File.Exists(Archiverdll) == true || File.Exists(Archiverser) == true)
                {
                    MainWindow.ScreenSwith();
                    MainWindow.PageOptions();
                }
            }
        } // загрузка архиватора

        public static void DCArchiver(object sender, AsyncCompletedEventArgs e)
        {
            MainWindow.adv += 1;
            MainWindow.archivertext.Text = MainWindow.adv + "/3";
            if (MainWindow.adv == 3)
            {
                nfa = false;
                MainWindow.ShutdownBootScreen();
            }
        } // выполняется после загрузки архиватора

        public static void DPArchiver(object sender, DownloadProgressChangedEventArgs e)
        {
            var currentBytes = (int)e.TotalBytesToReceive;
            var allBytes = (int)e.BytesReceived;
            var downvelue = allBytes / 1024 + "/" + currentBytes / 1024;
            var maxdown = currentBytes / 100;
            var value = allBytes / 100;
            MainWindow.archiverprogessbar.Value = value;
            MainWindow.archiverprogessbar.Maximum = maxdown;
        } // для прогресс бара загрузки 

    }
}

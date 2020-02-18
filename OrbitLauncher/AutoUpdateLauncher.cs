using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Orbit_Launcher
{
    class AutoUpdateLauncher
    {
        
        public static string versionlauncher;
        public static void AutoUpdate()
        {
            var pathserver = "VersionServer.txt"; //последняя версия 
            var pathdownload = "Extractor/Download.zip"; // путь до архива с обновлением
            var pathExtractor = "LauncherUpdate.cmd";
            var versionserver = "";
            var pathinclient = "VersionClient.txt";
            versionlauncher = File.ReadAllText(pathinclient);
            var folder1 = "installgray.cmd"; // автораспаковщик gray
            var folder2 = "LauncherUpdate.cmd"; // автораспаковщик обновления

            Task.Run(() =>
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Liis17/Orbit_Launcher/releases/download/1/Launcher.version.txt", pathserver);
                    client.DownloadFile("https://github.com/Liis17/Orbit_Launcher/releases/download/1/LauncherUpdate.cmd", folder2);
                    client.DownloadFile("https://github.com/Liis17/Orbit_Launcher/releases/download/1/installgray.cmd", folder1);
                }

                versionserver = File.ReadAllText(pathserver);

                if (versionserver != versionlauncher)
                {
                    Task.Run(() =>
                    {
                        using (var client = new WebClient())
                        {
                            client.DownloadFile("https://github.com/Liis17/Orbit_Launcher/releases/download/1/ServerVersion.zip", pathdownload);
                            Process.Start(pathExtractor);
                        }

                        


                    }); // загрузка последней версии лаунчера
                }
                

            }); // загрузка номера последней версии лаунчера

            
        }

        public static void MainLinkDownload()
        {
            
        } 

    }
}

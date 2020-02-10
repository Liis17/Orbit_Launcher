using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Orbit_Launcher
{
    class AutoUpdateLauncher
    {
        public static string versionlauncher;
        public static void AutoUpdate()
        {
            var pathserver = "VersionServer.txt";
            var pathdownload = "Extractor\\Download.zip";
            var pathExtractor = "Extractor\\LauncherUpdate.cmd";
            var versionserver = "";
            var pathinclient = "VersionClient.txt";
            versionlauncher = File.ReadAllText(pathinclient);
            var folder1 = "Extractor\\installgray.cmd";
            var folder2 = "Extractor\\LauncherUpdate.cmd";

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
                            client.DownloadFile("https://github.com/Liis17/Orbit_Launcher/releases/download/1/Launcher.version.txt", pathdownload);
                        }

                        Process.Start(pathExtractor);


                    }); // загрузка последней версии лаунчера
                }


            }); // загрузка номера последней версии лаунчера

            
        }

        public static void MainLinkDownload()
        {
            
        } 

    }
}

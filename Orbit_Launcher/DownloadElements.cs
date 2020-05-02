using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;

namespace Orbit_Launcher
{
    class DownloadElements
    {
        public static string firstfolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\";
        public static string cachefolder = firstfolder + "Cache" + "\\";
        public async static void DownloadGray()
        {
            if (File.Exists(cachefolder + "GrayRelease.zip") == true)
            {
                if (MessageBox.Show("Файл уже существует, скачать его еще раз?", "Необходимо вмешательство пользователя", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(MainWindow.DownComp);
                        client.DownloadProgressChanged += MainWindow.ProgressPanel;


                        var path = cachefolder + "GrayRelease.zip";
                        await client.DownloadFileTaskAsync(MainWindow.gray_linkarchive, path);

                        File.WriteAllText(cachefolder + "Gray.d", MainWindow.gray_lastversion);
                    }

                    Process.Start(firstfolder + "unpackinggray.cmd");
                    var a = File.ReadAllText(cachefolder + "Gray.d");
                    File.WriteAllText(firstfolder + "Gray" + "\\" + "Gray.d", a);
                    MainWindow.DownloadStop();
                }
                else
                {
                    if (MessageBox.Show("Попытаться распаковать?" + "\n" + "Предупреждение" + "\n" + "Файл может быть скачан не полностью, поэтому рекомендуется скачать его еще раз", "Необходимо вмешательство пользователя", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Process.Start(firstfolder + "unpackinggray.cmd");
                        var a = File.ReadAllText(cachefolder + "Gray.d");
                        File.WriteAllText(firstfolder + "Gray" + "\\" + "Gray.d", a);
                        MainWindow.DownloadStop();
                    }
                    else
                    {
                        MainWindow.DownloadStop();
                    }
                }
            }
            if(File.Exists(cachefolder + "GrayRelease.zip") == false)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(MainWindow.DownComp);
                    client.DownloadProgressChanged += MainWindow.ProgressPanel;


                    var path = cachefolder + "GrayRelease.zip";
                    await client.DownloadFileTaskAsync(MainWindow.gray_linkarchive, path);

                    File.WriteAllText(cachefolder + "Gray.d", MainWindow.gray_lastversion);
                }

                Process.Start(firstfolder + "unpackinggray.cmd");
                var a = File.ReadAllText(cachefolder + "Gray.d");
                File.WriteAllText(firstfolder + "Gray" + "\\" + "Gray.d", a);
                MainWindow.DownloadStop();
            }
            
        }

        public async static void DownloadOrpad()
        {
            using (var client = new WebClient())
            {
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(MainWindow.DownComp);
                client.DownloadProgressChanged += MainWindow.ProgressPanel;


                var path = firstfolder + "\\"+ "Orpad" + "\\" + "Orpad.exe";
                await client.DownloadFileTaskAsync(MainWindow.orpad_linkarchive, path);

                File.WriteAllText(firstfolder + "\\" + "Orpad" + "\\" + "Orpad.d", MainWindow.orpad_lastversion);
            }
        }

        public async static void DownloadWhatToMount()
        {
            using (var client = new WebClient())
            {
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(MainWindow.DownComp);
                client.DownloadProgressChanged += MainWindow.ProgressPanel;


                var path = cachefolder + "WhatToMount.zip";
                await client.DownloadFileTaskAsync(MainWindow.whattomount_linkarchive, path);

                File.WriteAllText(cachefolder + "WhatToMount.d", MainWindow.whattomount_lastversion);
            }

            Process.Start(firstfolder + "unpackingwhattomount.cmd");
            var a = File.ReadAllText(cachefolder + "WhatToMount.d");
            File.WriteAllText(firstfolder + "WhatToMount" + "\\" + "WhatToMount.d", a);
            MainWindow.DownloadStop();
        }


    }
}

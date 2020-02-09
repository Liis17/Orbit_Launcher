using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Orbit_Launcher
{   
    class LinkUpdate
    {
        public string[] link;
        public static void Updatelink()
        {
            MainLinkDownload();
        }

        public static void MainLinkDownload()
        {
            Task.Run(() =>
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Liis17/Orbit_Launcher/releases/download/1/link.all.txt", "MainLink.txt");
                    AllLinkSearch();
                }
            });
        } // загрузка списка ссылок на ссылки файлов

        public static void AllLinkSearch()
        {
            var path = "MainLink.txt"; //название главного файла со ссылками
            var AllValue = File.ReadAllText(path); // чтение этого файла
            var array = AllValue.Split('^'); // разделение на строки (1 строка одна ссылка)
            var array2 = array[0].Split('|'); // разделение строки на части (рабочая только вторая)
            AllLinkDownload();
        } // поиск ссылки в главном файле со ссылками

        public static void AllLinkDownload()
        {
            Task.Run(() =>
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Liis17/Orbit_Launcher/releases/download/1/link.all.txt", "MainLink.txt");
                    AllLinkDownload();
                }
            });
        }




        

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Orbit_Launcher
{
    class Graydownload
    {
        public static List<string> links;
        public static List<string> AllLinks = new List<string>();
        public static void GrayLinkDownload() // скачивание файла со ссылками на архивы gray
        {
            Task.Run(() =>
            {
                using (var client = new WebClient())
                {
                    Directory.CreateDirectory("Link");
                    var GrayLink = "Link/GrayLink.link";
                    client.DownloadFile("https://github.com/Liis17/gray/releases/download/1.0.1/link.gray.txt", GrayLink);
                }
            });
        }

        public static void Graydownloadfiles()
        {
            Task.Run(() =>
            {
                foreach (var file in AllLinks)
                {

                    var AllValue = File.ReadAllText("Link/" + file); // чтение этого файла
                    var line = AllValue.Split('^'); // разделение на строки (1 строка одна ссылка)
                    links = line.ToList();

                    foreach (var link in links)
                    {

                        using (var client = new WebClient())
                        {
                            if (link != "")
                            {
                                client.DownloadProgressChanged += MainWindow.Client_DownloadProgressChanged;
                                client.DownloadDataCompleted += MainWindow.Client_DownloadDataCompleted;
                                var a = link.Split('/');
                                var ext = a[a.Length - 1];
                                client.DownloadFileTaskAsync(link, "Extractor/" + ext);
                            }

                        }
                    }

                    //todo: все скачивания завершены.



                }
            });
        }
    }
}

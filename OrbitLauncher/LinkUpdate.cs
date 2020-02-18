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
        public static List<string> links;
        public static List<string> AllLinks = new List<string>();

        public static void Updatelink() //начало обновления ссылок
        {
            MainLinkDownload();
        }

        public static void MainLinkDownload()
        {
            Task.Run(() =>
            {
                using (var client = new WebClient())
                {
                    Directory.CreateDirectory("Link");
                    var a = "Link/MainLink.txt";
                    client.DownloadFile("https://github.com/Liis17/Orbit_Launcher/releases/download/1/link.all.txt", a);
                    AllLinkSearch(a);
                }
            });
        } // загрузка списка ссылок на ссылки файлов

        public static void AllLinkSearch(string path)
        {
            var AllValue = File.ReadAllText(path); // чтение этого файла
            var line = AllValue.Split('^'); // разделение на строки (1 строка одна ссылка)
            links = line.ToList();
            AllLinkDownload();
        } // поиск ссылки в главном файле со ссылками

        public static void AllLinkDownload()
        {


            Task.Run(() =>
            {
                int counter = 0;
                foreach (var link in links)
                {

                    using (var client = new WebClient())
                    {
                        if (link != "")
                        {
                            client.DownloadFile(link, "Link/" + $"link{counter}.txt");
                            AllLinks.Add($"link{counter}.txt");
                        }
                        
                    }
                    counter++;
                }

                
                //todo: все скачивания завершены.


            });
        } 


        public static void DownloadFiles()
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
                            if(link != "")
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
            
           
        } //скачивание файлов
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Orbit_Launcher
{
    class DownloadElements
    {
        public async static void DownloadGray()
        {
            using (var client = new WebClient())
            {
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(MainWindow.DownComp);
                client.DownloadProgressChanged += MainWindow.ProgressPanel;
                var link = "";
                var path = "";
                await client.DownloadFileTaskAsync(link, path);
            }
        }

        public async static void DownloadOrpad()
        {
            using (var client = new WebClient())
            {
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(MainWindow.DownComp);
                client.DownloadProgressChanged += MainWindow.ProgressPanel;
                var link = "";
                var path = "";
                await client.DownloadFileTaskAsync(link, path);
            }
        }

        public async static void DownloadWhatToMount()
        {
            using (var client = new WebClient())
            {
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(MainWindow.DownComp);
                client.DownloadProgressChanged += MainWindow.ProgressPanel;
                var link = "";
                var path = "";
                await client.DownloadFileTaskAsync(link, path);
            }
        }


    }
}

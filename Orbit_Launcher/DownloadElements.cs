using System;
using System.Collections.Generic;
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
                await client.DownloadFileTaskAsync(gray_link, folder_gray);
            }
        }

        public async static void DownloadOrpad()
        {
            using (var client = new WebClient())
            {
                await client.DownloadFileTaskAsync(gray_link, folder_gray);
            }
        }

        public async static void DownloadWhatToMount()
        {
            using (var client = new WebClient())
            {
                await client.DownloadFileTaskAsync(gray_link, folder_gray);
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OrbitLaunch
{
    /// <summary>
    /// Логика взаимодействия для WindowLauncher.xaml
    /// </summary>
    public partial class WindowLauncher
    {
        public WindowLauncher()
        {
            InitializeComponent();

        }

        public void DownloadTestImage()
        {
            WebClient web = new WebClient();
            var adress = "https://github.com/Liis17/Orbit_Launcher/blob/dungeon_master/OrbitLaunch/Assets/Images/innetwork/testpick.png?raw=true";
            var filename = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) + "\\OrbitLaunch\\testimage.png";
            web.DownloadFile(adress, filename);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Orbit_Launcher_Service
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            foreach (string whattomount in e.Args)
            {
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "unpackingwhattomount.cmd");
                Process.GetCurrentProcess().Kill();
            }


            foreach (string repeat in e.Args)
            {
                
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}

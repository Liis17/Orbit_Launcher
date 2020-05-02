using System;
using System.IO;
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
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Orbit_in_Space" + "\\" + "unpackingwhattomount.cmd";
                string content = "7z x %cd%\\Cache\\WhatToMount.zip -o'%cd%\\WhatToMount' ";

                File.WriteAllText(path, content);


                //Process.Start(path);
                Process.GetCurrentProcess().Kill();
            }


            foreach (string repeat in e.Args)
            {
                
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}

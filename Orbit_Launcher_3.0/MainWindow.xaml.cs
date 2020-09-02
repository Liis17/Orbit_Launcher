using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using sf = Orbit_Launcher_3._0.StringField;

namespace Orbit_Launcher_3._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MessageBox.Show("Сейчас будут запрошены права администратора");
            CreateFolder();
            InitializeComponent();
            File.WriteAllText(sf.tempfolder, "тестовый текст");
        }

        public void CreateFolder()
        {
            Directory.CreateDirectory(sf.mainfolder);
            Directory.CreateDirectory(sf.tempfolder);
            MessageBox.Show(sf.tempfolder);
            //
        }

        
    }
}

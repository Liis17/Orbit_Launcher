using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;



namespace OrbitLaunch
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        DispatcherTimer timer;
        int time;
        public MainWindow()
        {
            InitializeComponent();
            StartupProgressBar.Maximum = 2;
            StartupProgressBar.Value = 0;
            SetTimer();
        }

        public void SetTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(199);
            timer.Tick += OnTimedEvent;
            timer.Start();
        }

        public void OnTimedEvent(object sender, EventArgs e)
        {
            CheckNetwork();
            timer.Stop();
            
        }

        void CheckNetwork()
        {
            StartupTextBlock.Text = "Проверка соединения";
            try
            {
                WebClient web = new WebClient();
                var adress = "https://upload.wikimedia.org/wikipedia/en/thumb/5/51/Overwatch_cover_art.jpg/220px-Overwatch_cover_art.jpg";
                var filename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\overwatch.jpg";
                web.DownloadFile(adress, filename);
                StartupProgressBar.Value++;
            }
            catch
            {
                MessageBox.Show("Проверьте соединение и посторите попытку","Отсутствует соединение");
                Application.Current.Shutdown();
            }


            CheckFile();
        }

        void CheckFile()
        {
            StartupTextBlock.Text = "Проверка файлов";


            


            StartupProgressBar.Value++;
            LoadMainProgramm();
        }

        void LoadMainProgramm()
        {
            if (StartupProgressBar.Value == StartupProgressBar.Maximum)
            {
                timer.Stop();
                StartupProgressBar.Foreground = Brushes.Green;
                WindowLauncher win = new WindowLauncher();
                win.Show();
                StartWindow.Close();
            }
        }
    }
}

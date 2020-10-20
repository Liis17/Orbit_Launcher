using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class MainWindow : Window
    {

        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            SetTimer();
        }

        public void SetTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += OnTimedEvent;
            timer.Start();


        }

        public void OnTimedEvent(object sender, EventArgs e)
        {

            if (StartupProgressBar.Value <= 100)
            {
                StartupProgressBar.Foreground = Brushes.Blue;
            }

            if (StartupProgressBar.Value == 100)
            {
                StartupProgressBar.Foreground = Brushes.Green;
                timer.Stop();
            }
            if(StartupProgressBar.Value == 102)
            {
                MessageBox.Show("авфыв");
            }
            StartupProgressBar.Value += 1;
        }
    }
}

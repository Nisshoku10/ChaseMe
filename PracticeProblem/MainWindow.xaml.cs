using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace PracticeProblem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer _timer = null;
        Random _rnd = new Random();

        

        public MainWindow()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Tick += _timer_tick;
            _timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btnStart.Visibility = Visibility.Hidden;
            Caption.Visibility = Visibility.Hidden;
            Min.Visibility = Visibility.Visible;
            Secs.Visibility = Visibility.Visible;
            _timer.Start();
            btnChase.Visibility = Visibility.Visible;
            btnChase.Content = "Click Me!";
        }
        private void Chase_Click (object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            MessageBox.Show($"It took you {Min.Content} minutes and {Secs.Content} to click the button.");
        }
        private void MouseEnter(object sender, MouseEventArgs e)
        {
            int width = _rnd.Next(0, (int)ActualWidth - (int)btnChase.ActualWidth);
            int height = _rnd.Next(0, (int)ActualHeight - (int)btnChase.ActualHeight);
            btnChase.Margin = new Thickness(width, height, 0, 0);
        }

        private void _timer_tick(object sender, EventArgs e)
        {
            int sec = int.Parse(Secs.Content.ToString());
            sec++;

            if (sec > 59)
            {
                sec = 0;
                Min.Content = int.Parse(Min.Content.ToString()) + 1;
            }

            Secs.Content = sec.ToString();
        }

    }
}

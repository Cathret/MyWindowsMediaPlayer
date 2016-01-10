using System;
using System.Windows;
using Microsoft.Win32;
using MyWindowsMediaPlayer.Model;
using MyWindowsMediaPlayer.ViewModel;

namespace MyWindowsMediaPlayer.View
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    
    public partial class PlayerWindow : Window
    {
        bool _bIsBoucle = false;
        Playlist _playlist = null;

        public  PlayerWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModelPlayer(_playlist, MediaElementPlayer);
        }

        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            MediaElementPlayer.Volume = (double)SliderVolume.Value;
        }

        private void ChangeMediaSeek(object sender, RoutedEventArgs e)
        {
            MediaElementPlayer.Position = TimeSpan.FromSeconds(SliderSeek.Value);
        }

        private void MediaOpened(object sender, RoutedEventArgs e)
        {
            MediaElementPlayer.Volume = (double)SliderVolume.Value;
            SliderSeek.Maximum = MediaElementPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(timer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            SliderSeek.Value = MediaElementPlayer.Position.TotalSeconds;
        }

        private void MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaElementPlayer.Stop();
            if (_playlist != null)
            {
                int index = _playlist.Files.FindIndex(x => x.Path.Equals(MediaElementPlayer.Source.ToString()));
                try
                {
                    if (_playlist.Files.Count > index + 1)
                    {
                        MediaElementPlayer.Source = new Uri(_playlist.Files[index + 1].Path);
                        MediaElementPlayer.Play();
                    }
                    else if (_bIsBoucle)
                    {
                        MediaElementPlayer.Source = new Uri(_playlist.Files[0].Path);
                        MediaElementPlayer.Play();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
            else if (_bIsBoucle)
                MediaElementPlayer.Play();
        }
    }
}

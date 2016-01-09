using System;
using System.Windows;
using Microsoft.Win32;
using MyWindowsMediaPlayer.ViewModel;

namespace MyWindowsMediaPlayer.View
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    
    public partial class PlayerWindow : Window
    {
        public  PlayerWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModelPlayer();
        }

        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            MediaElementPlayer.Volume = (double)SliderVolume.Value;
        }

        private void ChangedMediaSeek(object sender, RoutedEventArgs e)
        {
            MediaElementPlayer.Pause();
            MediaElementPlayer.Position = TimeSpan.FromSeconds(SliderSeek.Value);
            MediaElementPlayer.Play();
        }

        private void MediaOpened(object sender, RoutedEventArgs e)
        {
            SliderSeek.Maximum = MediaElementPlayer.NaturalDuration.TimeSpan.TotalSeconds;
        }

        private void MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaElementPlayer.Position = TimeSpan.FromSeconds(0);
        }
    }
}

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

        private void ChangeMediaSeek(object sender, RoutedEventArgs e)
        {
            MediaElementPlayer.Position = TimeSpan.FromSeconds(SliderSeek.Value);
        }

        private void MediaOpened(object sender, RoutedEventArgs e)
        {
            MediaElementPlayer.Volume = (double)SliderVolume.Value;
            SliderSeek.Maximum = MediaElementPlayer.NaturalDuration.TimeSpan.TotalSeconds;
        }

        private void MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaElementPlayer.Stop();
#warning "If boucle is active, play | if playlist, load next file"
            MediaElementPlayer.Play();
        }
    }
}

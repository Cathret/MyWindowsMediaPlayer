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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaElementPlayer.Source = new Uri("https://www.youtube.com/embed/R-morg7h7Xk");
            MediaElementPlayer.Volume = 1;
            MediaElementPlayer.Play();
        }

        private void MediaElementPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {

        }
    }
}
